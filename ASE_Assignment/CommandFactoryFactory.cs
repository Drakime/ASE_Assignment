using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    public abstract class CommandFactoryFactory
    {
        public Command Command(Canvas canvas, string userInput)
        {
            Command command;

            command = CreateCommand(canvas, userInput);

            command.Operation();

            return command;
        }

        public abstract Command CreateCommand(Canvas canvas, string userInput);
    }
}
