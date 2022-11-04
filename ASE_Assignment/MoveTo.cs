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
        /// Otherwise, updates the 'pointX' and 'pointY'
        /// attributes of the canvas.
        /// </summary>
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
