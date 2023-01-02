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
        /// <param name="parameters">The parameters of the user input.</param>
        public Rect(Canvas canvas, List<string> parameters)
        {
            Name = "rectangle";
            Parameters = parameters;
            DrawingCanvas = canvas;
            VerifyParameters();
        }

        /// <summary>
        /// Parses the parameter from the user input and sets the
        /// class attribute accordingly.
        /// </summary>
        /// <remarks>If criteria is not met, adds to a list collection named 'errors'.</remarks>
        public override void VerifyParameters()
        {
            if (Parameters.Count != 1)
            {
                Errors.Add(InvalidNumberOfParameters);
                return;
            }

            string[] userInputParameters = Parameters[0].Split(",");

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
        /// Draws a rectangle on the canvas with the argument provided by the user.
        /// </summary>
        /// <remarks>Outputs an error message if there are any, ignoring the drawing action.</remarks>
        public override void Operation()
        {
            if (Errors.Count != 0)
            {
                Console = new ConsoleDisplayError(Errors);
                Console.PrintErrorToConsole();
                return;
            }

            Graphics g = Graphics.FromImage(DrawingCanvas.Bitmap);

            if (DrawingCanvas.HasShapeFilled == false)
            {
                Pen pen = new Pen(DrawingCanvas.ToolColour);
                g.DrawRectangle(pen, DrawingCanvas.PointX, DrawingCanvas.PointY, width, height);
                pen.Dispose();
            }
            else
            {
                SolidBrush brush = new SolidBrush(DrawingCanvas.ToolColour);
                g.FillRectangle(brush, DrawingCanvas.PointX, DrawingCanvas.PointY, width, height);
                brush.Dispose();
            }

            g.Dispose();
        }

        /// <summary>
        /// Gets the width of the rectangle.
        /// </summary>
        public int Width
        {
            get { return width; }
        }

        /// <summary>
        /// Gets the height of the rectangle.
        /// </summary>
        public int Height
        {
            get { return height; }
        }
    }
}
