using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    public class Rectangle : Command
    {
        public Rectangle(Canvas canvas, string userInput)
        {
            Name = "rectangle";
            drawingCanvas = canvas;
            ParseParameters(userInput);
        }

        public override void ParseParameters(string userInput)
        {
            string[] splitUserInput = userInput.Split(" ");

            if (splitUserInput.Length != 3)
            {
                throw new ArgumentException("Number of parameters are incorrect");
            }
            else
            {
                try
                {
                    ParameterList.Add(Int32.Parse(splitUserInput[1]));
                    ParameterList.Add(Int32.Parse(splitUserInput[2]));
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
                g.DrawRectangle(pen, drawingCanvas.PointX, drawingCanvas.PointY, parameters[0], parameters[1]);
                pen.Dispose();
            }
            else
            {
                SolidBrush brush = new SolidBrush(drawingCanvas.ToolColour);
                g.FillRectangle(brush, drawingCanvas.PointX, drawingCanvas.PointY, parameters[0], parameters[1]);
                brush.Dispose();
            }

            g.Dispose();
        }
    }
}
