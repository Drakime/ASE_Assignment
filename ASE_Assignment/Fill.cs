using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    /// <summary>
    /// A class that changes if drawn shapes are filled or not.
    /// </summary>
    public class Fill : Command
    {
        private string shapeFill;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="canvas">The canvas to be drawn on.</param>
        /// <param name="userInput">The input of the user.</param>
        public Fill(Canvas canvas, string userInput)
        {
            Name = "fill";
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

            if (splitUserInput[1].Equals("on") || splitUserInput[1].Equals("off"))
            {
                shapeFill = splitUserInput[1];
            }
            else
            {
                Errors.Add(InvalidTypeOfParameters);
            }
        }

        /// <summary>
        /// Outputs an error message if there are any.
        /// 
        /// Otherwise, updates the 'hasShapeFilled' attribute
        /// of the canvas.
        /// </summary>
        public override void Operation()
        {
            if (Errors.Count != 0)
            {
                foreach (string error in Errors)
                {
                    MessageBox.Show(error);
                    return;
                }
            }

            if (shapeFill.Equals("on"))
            {
                drawingCanvas.HasShapeFilled = true;
            }
            else
            {
                drawingCanvas.HasShapeFilled = false;
            }
        }

        // For unit tests
        public string ShapeFill
        {
            get { return shapeFill; }
        }
    }
}
