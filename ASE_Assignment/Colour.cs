using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    public class Colour : Command
    {
        private Color toolColour;
        
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
                Errors.Add(InvalidNumberOfParameters);
                return;
            }

            switch (inputColour)
            {
                case "green":
                    toolColour = Color.Green;
                    break;
                case "red":
                    toolColour = Color.Red;
                    break;
                case "orange":
                    toolColour = Color.Orange;
                    break;
                case "blue":
                    toolColour = Color.RoyalBlue;
                    break;
                default:
                    Errors.Add(InvalidTypeOfParameters);
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

            drawingCanvas.ToolColour = ToolColour;
        }

        // For unit tests
        public Color ToolColour
        {
            get { return toolColour; }
        }
    }
}
