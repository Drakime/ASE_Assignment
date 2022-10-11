using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    public class Colour : Command
    {
        Color colour;
        
        public Colour(Canvas canvas, string userInput)
        {
            Name = "colour";
            DrawingCanvas = canvas;
            ParseParameters(userInput);
        }

        public override void ParseParameters(string userInput)
        {
            string[] splitUserInput = userInput.Split(' ');

            if (splitUserInput.Length != 2)
            {
                throw new ArgumentException("Number of parameters is incorrect");
            }
            else
            {
                if (splitUserInput[1].Equals("green"))
                {
                    colour = Color.Green;
                }
                else if (splitUserInput[1].Equals("red"))
                {
                    colour = Color.Red;

                }
                else if (splitUserInput[1].Equals("orange"))
                {
                    colour = Color.Orange;
                }
                else if (splitUserInput[1].Equals("blue"))
                {
                    colour = Color.RoyalBlue;
                }
                else
                {
                    throw new ArgumentException("Invalid parameter");
                }
            }
        }

        public override void Operation()
        {
            drawingCanvas.ToolColour = colour;
        }
    }
}
