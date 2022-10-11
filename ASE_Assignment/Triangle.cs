using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    public class Triangle : Command
    {
        private List<Point> points = new List<Point>();

        public Triangle(Canvas canvas, string userInput)
        {
            Name = "triangle";
            ParseParameters(userInput);
        }

        public override void ParseParameters(string userInput)
        {
            string[] splitUserInput = userInput.Split(" ");

            if (splitUserInput.Length != 7)
            {
                throw new ArgumentException("Number of parameters are incorrect");
            }
            else
            {
                try
                {
                    Point pt1 = new Point(Int32.Parse(splitUserInput[1]), Int32.Parse(splitUserInput[2]));
                    Point pt2 = new Point(Int32.Parse(splitUserInput[3]), Int32.Parse(splitUserInput[4]));
                    Point pt3 = new Point(Int32.Parse(splitUserInput[5]), Int32.Parse(splitUserInput[6]));
                    points.Add(pt1);
                    points.Add(pt2);
                    points.Add(pt3);
                }
                catch (ArgumentException e)
                {
                    throw new ArgumentException("Invalid parameters", e);
                }
            }
        }

        public override void Operation()
        {
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
