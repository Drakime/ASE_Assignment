using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    /// <summary>
    /// A class that draws a triangle on a given canvas.
    /// </summary>
    public class Triangle : Command
    {
        /// <summary>
        /// The list of coordinate points of the triangle vertices.
        /// </summary>
        private List<Point> points = new List<Point>();
        /// <summary>
        /// The list of integers making up the coordinate points
        /// of the triangle vertices.
        /// </summary>
        private List<int> splitPoints = new List<int>();

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="canvas">The canvas to be drawn on.</param>
        /// <param name="parameters">The parameters of the user input.</param>
        public Triangle(Canvas canvas, List<string> parameters)
        {
            Name = "triangle";
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
            // Checks that the split string has 3 tokens
            if (Parameters.Count != 3)
            {
                Errors.Add(InvalidNumberOfParameters);
                return;
            }

            // Split the points by a comma, and add to a list for integers
            foreach (string parameter in Parameters)
            {
                string[] splitParameter = parameter.Split(",");

                for (int i = 0; i < splitParameter.Length; i++)
                {
                    if (Int32.TryParse(splitParameter[i], out int result))
                    {
                        splitPoints.Add(result);
                    }
                    else
                    {
                        Errors.Add(InvalidTypeOfParameters);
                        return;
                    }
                }
            }

            // Add to 'Errors' list collection if total number of integers is greater than 6
            if (splitPoints.Count != 6)
            {
                Errors.Add(InvalidNumberOfParameters);
                return;
            }

            // Combine integers to create points, and add to list collection.
            Point pt1 = new Point(splitPoints[0], splitPoints[1]);
            Point pt2 = new Point(splitPoints[2], splitPoints[3]);
            Point pt3 = new Point(splitPoints[4], splitPoints[5]);
            points.Add(pt1);
            points.Add(pt2);
            points.Add(pt3);
        }

        /// <summary>
        /// Outputs an error message if there are any.
        /// 
        /// Otherwise, draws a triangle on a canvas with
        /// the arguments provided by the user.
        /// </summary>
        public override void Operation()
        {
            if (Errors.Count != 0)
            {
                Console = new ConsoleDisplayError(Errors);
                Console.PrintErrorToConsole();
                return;
            }

            Point[] pointsArray = points.ToArray();
            Graphics g = Graphics.FromImage(DrawingCanvas.Bitmap);

            if (DrawingCanvas.HasShapeFilled == false)
            {
                Pen pen = new Pen(DrawingCanvas.ToolColour);
                g.DrawPolygon(pen, pointsArray);
                pen.Dispose();
            }
            else
            {
                SolidBrush brush = new SolidBrush(DrawingCanvas.ToolColour);
                g.FillPolygon(brush, pointsArray);
                brush.Dispose();
            }

            g.Dispose();
        }

        // For unit tests
        public List<Point> Points
        {
            get { return points; }
        }
    }
}
