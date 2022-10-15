using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    /// <summary>
    /// A class that draws a rectangle onto a given canvas.
    /// </summary>
    public class Rect : Command
    {
        /// <summary>
        /// The width of the rectangle.
        /// </summary>
        private int width;
        /// <summary>
        /// The height of the rectangle.
        /// </summary>
        private int height;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="canvas">The canvas to be drawn on.</param>
        /// <param name="userInput">The input of the user.</param>
        public Rect(Canvas canvas, string userInput)
        {
            Name = "rectangle";
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

            if (splitUserInput.Length != 2)
            {
                Errors.Add(InvalidNumberOfParameters);
                return;
            }

            string[] userInputParameters = splitUserInput[1].Split(",");

            if (userInputParameters.Length != 2)
            {
                Errors.Add(InvalidNumberOfParameters);
                return;
            }

            if (Int32.TryParse(userInputParameters[0], out int parsedWidth)
                && Int32.TryParse(userInputParameters[1], out int parsedHeight))
            {
                width = parsedWidth;
                height = parsedHeight;
            }
            else
            {
                Errors.Add(InvalidTypeOfParameters);
            }
        }

        /// <summary>
        /// Outputs an error message if there are any.
        /// 
        /// Otherwise, draws a rectangle on the canvas with
        /// the argument provided by the user.
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

            if (drawingCanvas.HasShapeFilled == false)
            {
                Pen pen = new Pen(drawingCanvas.ToolColour);
                g.DrawRectangle(pen, drawingCanvas.PointX, drawingCanvas.PointY, width, height);
                pen.Dispose();
            }
            else
            {
                SolidBrush brush = new SolidBrush(drawingCanvas.ToolColour);
                g.FillRectangle(brush, drawingCanvas.PointX, drawingCanvas.PointY, width, height);
                brush.Dispose();
            }

            g.Dispose();
        }

        // For unit tests
        public int Width
        {
            get { return width; }
        }

        // For unit tests
        public int Height
        {
            get { return height; }
        }
    }
}
