using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    public class CommandFactory : CommandFactoryFactory
    {
        public override Command CreateCommand(Canvas canvas, string userInput)
        {
            string[] command = userInput.Split(" ");
            string commandType = command[0];

            switch (commandType)
            {
                case "moveto":
                    return new MoveTo(canvas, userInput);
                case "drawto":
                    return new DrawTo(canvas, userInput);
                case "circle":
                    return new Circle(canvas, userInput);
                case "rectangle":
                    return new Rectangle(canvas, userInput);
                case "triangle":
                    return new Triangle(canvas, userInput);
                case "clear":
                    return new Clear(canvas, userInput);
                case "reset":
                    return new Reset(canvas, userInput);
                case "pen":
                    return new Colour(canvas, userInput);
                case "fill":
                    return new Fill(canvas, userInput);
                default:
                    return new CommandException();
            }
        }
    }
}
