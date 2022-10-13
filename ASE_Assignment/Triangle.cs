using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    public class Triangle : Command
    {
        private List<Point> points = new List<Point>();
        private List<int> splitPoints = new List<int>();

        public Triangle(Canvas canvas, string userInput)
        {
            Name = "triangle";
            DrawingCanvas = canvas;
            ParseParameters(userInput);
        }

        public override void ParseParameters(string userInput)
        {
            string[] splitUserInput = userInput.Split(" ");

            if (splitUserInput.Length != 4)
            {
                Errors.Add(InvalidNumberOfParameters);
                return;
            }

            //
            foreach (string parameter in splitUserInput.Skip(1))
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

            if (splitPoints.Count != 6)
            {
                Errors.Add(InvalidNumberOfParameters);
                return;
            }

            Point pt1 = new Point(splitPoints[0], splitPoints[1]);
            Point pt2 = new Point(splitPoints[2], splitPoints[3]);
            Point pt3 = new Point(splitPoints[4], splitPoints[5]);
            points.Add(pt1);
            points.Add(pt2);
            points.Add(pt3);
        }

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

            Point[] pointsArray = points.ToArray();
            Graphics g = Graphics.FromImage(drawingCanvas.Bitmap);

            if (drawingCanvas.HasShapeFilled == false)
            {
                Pen pen = new Pen(drawingCanvas.ToolColour);
                g.DrawPolygon(pen, pointsArray);
                pen.Dispose();
            }
            else
            {
                SolidBrush brush = new SolidBrush(drawingCanvas.ToolColour);
                g.FillPolygon(brush, pointsArray);
                brush.Dispose();
            }

            g.Dispose();
        }
    }
}
