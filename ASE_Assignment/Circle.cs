using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    /// <summary>
    /// A class that draws a circle onto a given canvas.
    /// </summary>
    public class Circle : Command
    {
        /// <summary>
        /// The radius of the circle.
        /// </summary>
        private int radius;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="canvas">The canvas to be drawn on.</param>
        /// <param name="userInput">The input of the user.</param>
        public Circle(Canvas canvas, List<string> parameters)
        {
            Name = "circle";
            DrawingCanvas = canvas;
            Parameters = parameters;
            VerifyParameters();
        }
        
        /// <summary>
        /// Parses the parameter from the user input and sets the
        /// class attribute accordingly.
        /// 
        /// If criteria is not met, adds to a list collection named
        /// 'errors'.
        /// </summary>
        /// <param name="userInput">The input of the user to be parsed.</param>
        public override void VerifyParameters()
        {
            if (Parameters.Count != 1)
            {
                Errors.Add(InvalidNumberOfParameters);
                return;
            }
            
            if (Int32.TryParse(Parameters[0], out int parsedRadius))
            {
                radius = parsedRadius;
            }
            else
            {
                Errors.Add(InvalidTypeOfParameters);
            }
        }

        /// <summary>
        /// Outputs an error message if there are any.
        /// 
        /// Otherwise, draws a circle on a canvas with
        /// the argument provided by the user.
        /// </summary>
        public override void Operation()
        {
            if (Errors.Count != 0)
            {
                Console = new ConsoleDisplayError(Errors);
                Console.PrintErrorToConsole();
                return;
            }

            Graphics g = Graphics.FromImage(drawingCanvas.Bitmap);

            if (drawingCanvas.HasShapeFilled == false)
            {
                Pen pen = new Pen(drawingCanvas.ToolColour);
                g.DrawEllipse(pen, drawingCanvas.PointX, drawingCanvas.PointY, radius * 2, radius * 2);
                pen.Dispose();
            }
            else
            {
                SolidBrush brush = new SolidBrush(drawingCanvas.ToolColour);
                g.FillEllipse(brush, drawingCanvas.PointX, drawingCanvas.PointY, radius * 2, radius * 2);
                brush.Dispose();
            }

            g.Dispose();
        }

        // For unit tests
        public int Radius
        {
            get { return radius; }
        }
    }
}
