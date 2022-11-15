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
        /// 
        /// If criteria is not met, adds to a list collection named
        /// 'errors'.
        /// </summary>
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
