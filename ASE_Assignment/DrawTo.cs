using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    public class DrawTo : Command
    {
        private int x;
        private int y;

        public DrawTo(Canvas canvas, string userInput)
        {
            Name = "drawto";
            UserInput = userInput;
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

            if (Int32.TryParse(userInputParameters[0], out int parsedX)
                && Int32.TryParse(userInputParameters[1], out int parsedY))
            {
                x = parsedX;
                y = parsedY;
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
            Pen pen = new Pen(drawingCanvas.ToolColour);

            g.DrawLine(pen, drawingCanvas.PointX, drawingCanvas.PointY, x, y);

            pen.Dispose();
            g.Dispose();
        }

        // For unit tests
        public int X
        {
            get { return x; }
        }

        // For unit tests
        public int Y
        {
            get { return y; }
        }
    }
}
