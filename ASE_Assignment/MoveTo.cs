using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    /// <summary>
    /// A class that moves the position of a tool.
    /// </summary>
    public class MoveTo : Command
    {
        /// <summary>
        /// The x-coordinate of the tool.
        /// </summary>
        private int x;

        /// <summary>
        /// The y-coordinate of the tool.
        /// </summary>
        private int y;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="canvas">The canvas of the current application instance.</param>
        /// <param name="parameters">The parameters of the user input.</param>
        public MoveTo(Canvas canvas, List<string> parameters)
        {
            Name = "moveto";
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
        /// Updates the 'pointX' and 'pointY' attributes of the canvas.
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

            DrawingCanvas.PointX = x;
            DrawingCanvas.PointY = y;
        }

        /// <summary>
        /// Gets the x-coordinate to move to.
        /// </summary>
        public int X
        {
            get { return x; }
        }

        /// <summary>
        /// Gets the y-coordinate to move to.
        /// </summary>
        public int Y
        {
            get { return y; }
        }
    }
}
