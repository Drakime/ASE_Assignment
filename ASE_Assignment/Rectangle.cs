using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    public class Rectangle : Command
    {
        int width;
        int height;

        public Rectangle(Canvas canvas, string userInput)
        {
            Name = "rectangle";
            DrawingCanvas = canvas;
            ParseParameters(userInput);
        }

        public override void ParseParameters(string userInput)
        {
            string[] splitUserInput = userInput.Split(" ");
            string[] userInputParameters = splitUserInput[1].Split(",");

            if (splitUserInput.Length != 2 || userInputParameters.Length != 2)
            {
                Errors.Add(InvalidNumberOfParameters);
                return;
            }

            if (Int32.TryParse(userInputParameters[0], out int parsedWidth)
                && Int32.TryParse(userInputParameters[1], out int parsedHeight))
            {
                width = parsedWidth;
                height = parsedHeight;
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
                g.DrawRectangle(pen, drawingCanvas.PointX, drawingCanvas.PointY, width, height);
                pen.Dispose();
            }
            else
            {
                SolidBrush brush = new SolidBrush(drawingCanvas.ToolColour);
                g.FillRectangle(brush, drawingCanvas.PointX, drawingCanvas.PointY, width, height);
                brush.Dispose();
            }

            g.Dispose();
        }
    }
}
