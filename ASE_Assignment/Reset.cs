using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    public class Reset : Command
    {
        public Reset(Canvas drawingCanvas, string userInput)
        {
            Name = "reset";
            DrawingCanvas = drawingCanvas;
            ParseParameters(userInput);
        }

        public override void ParseParameters(string userInput)
        {
            string[] splitUserInput = userInput.Split(" ");

            if (splitUserInput.Length != 1)
            {
                throw new ArgumentException("Command does not require parameters");
            }
        }

        public override void Operation()
        {
            Graphics g = Graphics.FromImage(drawingCanvas.Bitmap);

            drawingCanvas.PointX = 0;
            drawingCanvas.PointY = 0;

            g.Dispose();
        }
    }
}
