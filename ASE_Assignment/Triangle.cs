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
        /// </summary>
        /// <remarks>If criteria is not met, adds to a list collection named 'errors'.</remarks>
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

            // Calculate centroid of triangle and the vector to the cursor position,
            // making the cursor position the new centroid.
            int centroidX = (splitPoints[0] + splitPoints[2] + splitPoints[4]) / 3;
            int centroidY = (splitPoints[1] + splitPoints[3] + splitPoints[5]) / 3;
            int vectorX = DrawingCanvas.PointX - centroidX;
            int vectorY = DrawingCanvas.PointY - centroidY;

            // Combine integers with vector to create points, and add to list collection
            Point pt1 = new Point(splitPoints[0] + vectorX, splitPoints[1] + vectorY);
            Point pt2 = new Point(splitPoints[2] + vectorX, splitPoints[3] + vectorY);
            Point pt3 = new Point(splitPoints[4] + vectorX, splitPoints[5] + vectorY);
            points.Add(pt1);
            points.Add(pt2);
            points.Add(pt3);
        }

        /// <summary>
        /// Draws a triangle on a canvas the arguments provided by the user.
        /// </summary>
        /// <remarks>Outputs an error message if there are any, ignoring the drawing action.</remarks>
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

        /// <summary>
        /// Gets the list of points of the triangle.
        /// </summary>
        public List<Point> Points
        {
            get { return points; }
        }
    }
}
