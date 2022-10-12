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
            string inputColour = splitUserInput[1];

            if (splitUserInput.Length != 2)
            {
                throw new ArgumentException("Number of parameters is incorrect");
            }

            switch (inputColour)
            {
                case "green":
                    colour = Color.Green;
                    break;
                case "red":
                    colour = Color.Red;
                    break;
                case "orange":
                    colour = Color.Orange;
                    break;
                case "blue":
                    colour = Color.RoyalBlue;
                    break;
                default:
                    throw new ArgumentException("Invalid parameter");
            }
        }

        public override void Operation()
        {
            drawingCanvas.ToolColour = colour;
        }
    }
}
