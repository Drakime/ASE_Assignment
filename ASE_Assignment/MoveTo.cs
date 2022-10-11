using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    public class MoveTo : Command
    {
        public MoveTo(Canvas drawingCanvas, string userInput)
        {
            Name = "moveto";
            UserInput = userInput;
            DrawingCanvas = drawingCanvas;
            ParseParameters(userInput);
        }

        public void ParseParameters(string userInput)
        {
            string[] splitUserInput = userInput.Split(" ");

            if (splitUserInput.Length == 3)
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
            else
            {
                throw new ArgumentException("Number of parameters is incorrect");
            }
        }

        public override void Operation()
        {
            int[] parameters = ParameterList.ToArray();
            drawingCanvas.PointX = parameters[0];
            drawingCanvas.PointY = parameters[1];
        }
    }
}
