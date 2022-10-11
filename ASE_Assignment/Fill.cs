using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    public class Fill : Command
    {
        string shapeFill;

        public Fill(Canvas drawingCanvas, string userInput)
        {
            Name = "fill";
            DrawingCanvas = drawingCanvas;
            ParseParameters(userInput);
        }

        public override void ParseParameters(string userInput)
        {
            string[] splitUserInput = userInput.Split(" ");

            if (splitUserInput.Length != 2)
            {
                throw new ArgumentException("Number of parameters is incorrect");
            }

            if (splitUserInput[1].Equals("on") || splitUserInput[1].Equals("off"))
            {
                shapeFill = splitUserInput[1];
            }
            else
            {
                throw new ArgumentException("Invalid parameter");
            }
        }

        public override void Operation()
        {
            if (shapeFill.Equals("on"))
            {
                drawingCanvas.HasShapeFilled = true;
            }
            else
            {
                drawingCanvas.HasShapeFilled = false;
            }
        }
    }
}
