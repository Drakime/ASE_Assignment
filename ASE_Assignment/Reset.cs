using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    /// <summary>
    /// A class that resets the tool position on a given canvas.
    /// </summary>
    public class Reset : Command
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="canvas">The canvas of the current application instance.</param>
        /// <param name="parameters">The parameters of the user input.</param>
        public Reset(Canvas canvas, List<string> parameters)
        {
            Name = "reset";
            Parameters = parameters;
            DrawingCanvas = canvas;
            VerifyParameters();
        }

        /// <summary>
        /// If criteria is not met, adds to a list collection named 'errors'.
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
        /// Resets the tool position of the canvas to zero.
        /// </summary>
        /// <remarks>Outputs an error message if there are any, ignoring the update action.</remarks>
        public override void Operation()
        {
            if (Errors.Count != 0)
            {
                Console = new ConsoleDisplayError(Errors);
                Console.PrintErrorToConsole();
                return;
            }

            Graphics g = Graphics.FromImage(DrawingCanvas.Bitmap);

            DrawingCanvas.PointX = 0;
            DrawingCanvas.PointY = 0;

            g.Dispose();
        }
    }
}
