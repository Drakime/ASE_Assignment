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
            DrawingCanvas = canvas;
            ParseParameters(userInput);
        }
        
        public override void ParseParameters(string userInput)
        {
            string[] splitUserInput = userInput.Split(" ");

            if (splitUserInput.Length != 2)
            {
                Errors.Add(InvalidNumberOfParameters);
                return;
            }
            
            if (Int32.TryParse(splitUserInput[1], out int parsedRadius))
            {
                radius = parsedRadius;
            }
            else
            {
                Errors.Add(InvalidTypeOfParameters);
            }
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
