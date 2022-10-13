using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    public class Fill : Command
    {
        private string shapeFill;

        public Fill(Canvas canvas, string userInput)
        {
            Name = "fill";
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

            if (splitUserInput[1].Equals("on") || splitUserInput[1].Equals("off"))
            {
                shapeFill = splitUserInput[1];
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

            if (shapeFill.Equals("on"))
            {
                drawingCanvas.HasShapeFilled = true;
            }
            else
            {
                drawingCanvas.HasShapeFilled = false;
            }
        }

        // For unit tests
        public string ShapeFill
        {
            get { return shapeFill; }
        }
    }
}
