using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    /// <summary>
    /// A class that clears a given canvas of any graphical drawing.
    /// </summary>
    public class Clear : Command
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="canvas">The canvas to be drawn on.</param>
        /// <param name="userInput">The input of the user.</param>
        public Clear(Canvas canvas, string userInput)
        {
            Name = "clear";
            UserInput = userInput;
            DrawingCanvas = canvas;
            ParseParameters(userInput);
        }

        /// <summary>
        /// Parses the user input.
        /// 
        /// If criteria is not met, adds to a list collection named
        /// 'errors'.
        /// </summary>
        /// <param name="userInput">The input of the user to be parsed.</param>
        public override void ParseParameters(string userInput)
        {
            string[] splitUserInput = userInput.Split(" ");

            if (splitUserInput.Length != 1)
            {
                Errors.Add(InvalidNumberOfParameters);
                return;
            }
        }

        /// <summary>
        /// Outputs an error message if there are any.
        /// 
        /// Otherwise, clears the canvas.
        /// </summary>
        public override void Operation()
        {
            if (Errors.Count != 0)
            {
                Console = new ConsoleDisplayError(UserInput, Errors);
                Console.PrintErrorToConsole();
                return;
            }

            Graphics g = Graphics.FromImage(drawingCanvas.Bitmap);

            g.Clear(Color.Gray);

            g.Dispose();
        }
    }
}
