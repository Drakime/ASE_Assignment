using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace ASE_Assignment
{
    /// <summary>
    /// A class that executes the program written by
    /// the user.
    /// </summary>
    public class Run : Command
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="canvas">The canvas to be manipulated.</param>
        /// <param name="userInput">The input of the user.</param>
        public Run(Canvas canvas, List<string> parameters)
        {
            Name = "run";
            DrawingCanvas = canvas;
            Parameters = parameters;
            VerifyParameters();
        }

        /// <summary>
        /// Parses the user input.
        /// 
        /// If criteria is not met, adds to a list collection named
        /// 'errors'.
        /// </summary>
        /// <param name="userInput">The input of the user to be parsed.</param>
        public override void VerifyParameters()
        {
            if (Parameters.Count != 0)
            {
                Errors.Add(InvalidNumberOfParameters);
                return;
            }
        }

        /// <summary>
        /// Outputs an error message if there are any.
        /// 
        /// Otherwise, executes the user program.
        /// </summary>
        public override void Operation()
        {
            if (Errors.Count != 0)
            {
                Console = new ConsoleDisplayError(Errors);
                Console.PrintErrorToConsole();
                return;
            }

            TextBox t = Application.OpenForms["Form1"].Controls["programTextBox"] as TextBox;

            CommandFactory factory = new CommandFactory();

            string[] commands = Regex.Split(t.Text.Trim().ToLower(), @"\r\n");

            foreach (string command in commands)
            {
                factory.Command(DrawingCanvas, command);
            }

            PictureBox p = Application.OpenForms["Form1"].Controls["drawingCanvas"] as PictureBox;
            p.Image = DrawingCanvas.Bitmap;
        } 
    }
}
