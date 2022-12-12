using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    /// <summary>
    /// A factory class that returns command type objects.
    /// </summary>
    public class CommandFactory : CommandFactoryFactory
    {
        public override Command CreateCommand(Canvas canvas, string userInput)
        {
            string command = Parser.ParseCommand(userInput);
            List<string> parameters = Parser.ParseParameters(userInput);

            switch (command)
            {
                case "moveto":
                    return new MoveTo(canvas, parameters);
                case "drawto":
                    return new DrawTo(canvas, parameters);
                case "circle":
                    return new Circle(canvas, parameters);
                case "rect":
                    return new Rect(canvas, parameters);
                case "triangle":
                    return new Triangle(canvas, parameters);
                case "clear":
                    return new Clear(canvas, parameters);
                case "reset":
                    return new Reset(canvas, parameters);
                case "pen":
                    return new Colour(canvas, parameters);
                case "fill":
                    return new Fill(canvas, parameters);
                case "run":
                    string userProgram = Parser.ParseProgram(userInput);
                    return new Run(canvas, userProgram);
                case "save":
                    return new Save(parameters);
                case "load":
                    return new Load(parameters);
                case "var":
                    return new Variable(parameters);
                default:
                    return new CommandException(command);
            }
        }
    }
}
