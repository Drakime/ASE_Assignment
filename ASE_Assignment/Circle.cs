using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    public class Circle : Command
    {
        int radius;

        public Circle(Canvas canvas, string userInput)
        {
            Name = "circle";
            drawingCanvas = canvas;
            ParseParameters(userInput);
        }
        
        public override void ParseParameters(string userInput)
        {
            string[] splitUserInput = userInput.Split(" ");

            if (splitUserInput.Length != 2)
            {
                throw new ArgumentException("Number of parameters are incorrect");
            }
            else
            {
                try
                {
                    radius = Int32.Parse(splitUserInput[1]);
                }
                catch (ArgumentException e)
                {
                    throw new ArgumentException("Invalid parameters", e);
                }
            }
        }

        public override void Operation()
        {
            int[] parameters = ParameterList.ToArray();
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
    }
}
