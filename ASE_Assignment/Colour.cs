﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    /// <summary>
    /// A class that changes the colour of the drawing tool.
    /// </summary>
    public class Colour : Command
    {
        /// <summary>
        /// The colour of the drawing tool.
        /// </summary>
        private Color toolColour;
        
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="canvas">The canvas of the current application instance.</param>
        /// <param name="parameters">The parameters of the user input.</param>
        public Colour(Canvas canvas, List<string> parameters)
        {
            Name = "colour";
            Parameters = parameters;
            DrawingCanvas = canvas;
            VerifyParameters();
        }

        /// <summary>
        /// Parses the parameter from the user input and sets the
        /// class attribute accordingly.
        /// 
        /// If criteria is not met, adds to a list collection named
        /// 'errors'.
        /// </summary>
        public override void VerifyParameters()
        {
            string inputColour = Parameters[0];

            if (Parameters.Count != 1)
            {
                Errors.Add(InvalidNumberOfParameters);
                return;
            }

            switch (inputColour)
            {
                case "black":
                    toolColour = Color.Black;
                    break;
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

        /// <summary>
        /// Outputs an error message if there are any.
        /// 
        /// Otherwise, updates the 'toolColour' attribute
        /// of the canvas.
        /// </summary>
        public override void Operation()
        {
            if (Errors.Count != 0)
            {
                Console = new ConsoleDisplayError(Errors);
                Console.PrintErrorToConsole();
                return;
            }

            DrawingCanvas.ToolColour = ToolColour;
        }

        /// <summary>
        /// Gets the colour of the tool.
        /// </summary>
        public Color ToolColour
        {
            get { return toolColour; }
        }
    }
}
