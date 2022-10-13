using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    public class Rect : Command
    {
        private int width;
        private int height;

        public Rect(Canvas canvas, string userInput)
        {
            Name = "rectangle";
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

            string[] userInputParameters = splitUserInput[1].Split(",");

            if (userInputParameters.Length != 2)
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

        // For unit tests
        public int Width
        {
            get { return width; }
        }

        // For unit tests
        public int Height
        {
            get { return height; }
        }
    }
}
