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
        /// <param name="userInput">The input of the user.</param>
        public Reset(Canvas canvas, string userInput)
        {
            Name = "reset";
            DrawingCanvas = canvas;
            ParseParameters(userInput);
        }

        /// <summary>
        /// Parses the user input.
        /// 
        /// If criteria is not met, adds to a list collection named
        /// 'errors'.
        /// </summary>
        /// <param name="userInput">The input of the user to be parsed.</param>
        public override void ParseParameters(string userInput)
        {
            string[] splitUserInput = userInput.Split(" ");

            if (splitUserInput.Length != 1)
            {
                Errors.Add(InvalidNumberOfParameters);
                return;
            }
        }

        /// <summary>
        /// Outputs an error message if there are any.
        /// 
        /// Otherwise, resets the tool position of the canvas
        /// to zero.
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

            Graphics g = Graphics.FromImage(drawingCanvas.Bitmap);

            drawingCanvas.PointX = 0;
            drawingCanvas.PointY = 0;

            g.Dispose();
        }
    }
}
