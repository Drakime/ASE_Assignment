using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    /// <summary>
    /// A class that determines if drawn shapes are filled or not.
    /// </summary>
    public class Fill : Command
    {
        /// <summary>
        /// The parameter of the user input specifying if the fill feature is on or off.
        /// </summary>
        private string shapeFill;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="canvas">The canvas to be drawn on.</param>
        /// <param name="parameters">The parameters of the user input.</param>
        public Fill(Canvas canvas, List<string> parameters)
        {
            Name = "fill";
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

            if (Parameters[0].Equals("on") || Parameters[0].Equals("off"))
            {
                shapeFill = Parameters[0];
            }
            else
            {
                Errors.Add(InvalidTypeOfParameters);
            }
        }

        /// <summary>
        /// Updates the 'hasShapeFilled' attribute
        /// of the canvas.
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

            if (shapeFill.Equals("on"))
            {
                DrawingCanvas.HasShapeFilled = true;
            }
            else
            {
                DrawingCanvas.HasShapeFilled = false;
            }
        }

        /// <summary>
        /// Gets the parameter of the user input specifying if the shape is filled or not.
        /// </summary>
        public string ShapeFill
        {
            get { return shapeFill; }
        }
    }
}
