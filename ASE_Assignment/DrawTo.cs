using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    /// <summary>
    /// A class that draws a line onto a given canvas.
    /// </summary>
    public class DrawTo : Command
    {
        /// <summary>
        /// The x-coordinate to draw a line to.
        /// </summary>
        private int x;
        /// <summary>
        /// The y-coordinate to draw a line to.
        /// </summary>
        private int y;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="canvas">The canvas to be drawn on.</param>
        /// <param name="userInput">The input of the user.</param>
        public DrawTo(Canvas canvas, string userInput)
        {
            Name = "drawto";
            UserInput = userInput;
            DrawingCanvas = canvas;
            ParseParameters(userInput);
        }

        /// <summary>
        /// Parses the parameter from the user input and sets the
        /// class attribute accordingly.
        /// 
        /// If criteria is not met, adds to a list collection named
        /// 'errors'.
        /// </summary>
        /// <param name="userInput">The input of the user to be parsed.</param>
        public override void ParseParameters(string userInput)
        {
            string[] splitUserInput = userInput.Split(" ");
            string[] userInputParameters = splitUserInput[1].Split(",");

            if (splitUserInput.Length != 2 || userInputParameters.Length != 2)
            {
                Errors.Add(InvalidNumberOfParameters);
                return;
            }

            if (Int32.TryParse(userInputParameters[0], out int parsedX)
                && Int32.TryParse(userInputParameters[1], out int parsedY))
            {
                x = parsedX;
                y = parsedY;
            }
            else
            {
                Errors.Add(InvalidTypeOfParameters);
            }
        }

        /// <summary>
        /// Outputs an error message if there are any.
        /// 
        /// Otherwise, draws a line on a canvas from the
        /// current tool position to the coordinates provided
        /// by the user.
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
            Pen pen = new Pen(drawingCanvas.ToolColour);

            g.DrawLine(pen, drawingCanvas.PointX, drawingCanvas.PointY, x, y);

            pen.Dispose();
            g.Dispose();
        }

        // For unit tests
        public int X
        {
            get { return x; }
        }

        // For unit tests
        public int Y
        {
            get { return y; }
        }
    }
}
