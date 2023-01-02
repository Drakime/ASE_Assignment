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
        /// An instance of the <see cref=">UserProgram"/> class for program execution.
        /// </summary>
        private UserProgram program;

        /// <summary>
        /// The user program from the program textbox.
        /// </summary>
        private string userProgram;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="canvas">The canvas to be manipulated.</param>
        /// <param name="parameters">The parameters of the user input.</param>
        public Run(Canvas canvas, string userProgram)
        {
            Name = "run";
            DrawingCanvas = canvas;
            this.userProgram = userProgram;
            program = new UserProgram(DrawingCanvas);
            VerifyParameters();
        }

        /// <summary>
        /// If criteria is not met, adds to a list collection named
        /// 'errors'.
        /// </summary>
        public override void VerifyParameters()
        {
            if (Parameters.Count != 0)
            {
                Errors.Add(InvalidNumberOfParameters);
                return;
            }
        }

        /// <summary>
        /// Sets up and executes the user program.
        /// </summary>
        /// <remarks>Outputs an error message if there are any, ignoring program execution.</remarks>
        public override void Operation()
        {
            if (Errors.Count != 0)
            {
                Console = new ConsoleDisplayError(Errors);
                Console.PrintErrorToConsole();
                return;
            }

            program.SetProgramLines(userProgram);
            program.CheckSyntax();

            if (program.HasNoSyntaxError == true)
            {
                program.Execute();

                PictureBox p = Application.OpenForms["Form1"].Controls["drawingCanvas"] as PictureBox;
                p.Image = DrawingCanvas.Bitmap;
            }
            else
            {
                return;
            }
        } 
    }
}
