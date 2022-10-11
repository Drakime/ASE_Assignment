using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    public class Clear : Command
    {
        public Clear(Canvas drawingCanvas, string userInput)
        {
            Name = "clear";
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

            g.Clear(Color.Gray);

            g.Dispose();
        }
    }
}
