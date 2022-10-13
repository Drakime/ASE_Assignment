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
                Errors.Add(InvalidNumberOfParameters);
                return;
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

            g.Clear(Color.Gray);

            g.Dispose();
        }
    }
}
