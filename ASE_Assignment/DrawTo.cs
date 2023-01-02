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
        /// <param name="parameters">The parameters of the user input.</param>
        public DrawTo(Canvas canvas, List<string> parameters)
        {
            Name = "drawto";
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
            string[] userInputParameters = Parameters[0].Split(",");

            if (Parameters.Count != 1 || userInputParameters.Length != 2)
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
        /// Draws a line on a canvas from the current tool position to 
        /// the coordinates provided by the user.
        /// </summary>
        /// <remarks>Outs an error message if there are any, ignoring the drawing action.</remarks>
        public override void Operation()
        {
            if (Errors.Count != 0)
            {
                Console = new ConsoleDisplayError(Errors);
                Console.PrintErrorToConsole();
                return;
            }

            Graphics g = Graphics.FromImage(DrawingCanvas.Bitmap);
            Pen pen = new Pen(DrawingCanvas.ToolColour);

            g.DrawLine(pen, DrawingCanvas.PointX, DrawingCanvas.PointY, x, y);

            pen.Dispose();
            g.Dispose();

            DrawingCanvas.PointX = x;
            DrawingCanvas.PointY = y;
        }

        /// <summary>
        /// Gets the x-coordinate to draw to.
        /// </summary>
        public int X
        {
            get { return x; }
        }

        /// <summary>
        /// Gets the y-coordinate to draw to.
        /// </summary>
        public int Y
        {
            get { return y; }
        }
    }
}
