using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    public class DrawTo : Command
    {
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
            Graphics g = Graphics.FromImage(drawingCanvas.Bitmap);
            Pen pen = new Pen(drawingCanvas.ToolColour);
            
            g.DrawLine(pen, drawingCanvas.PointX, drawingCanvas.PointY, parameters[0], parameters[1]);

            pen.Dispose();
            g.Dispose();
        }
    }
}
