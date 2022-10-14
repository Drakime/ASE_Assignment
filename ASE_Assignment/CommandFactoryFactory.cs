using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    public abstract class CommandFactoryFactory
    {
        /// <summary>
        /// Requests a command object and executes its operation.
        /// </summary>
        /// <param name="canvas">The canvas that the command affects.</param>
        /// <param name="userInput">The input of the user.</param>
        /// <returns></returns>
        public void Command(Canvas canvas, string userInput)
        {
            Command command;

            command = CreateCommand(canvas, userInput);

            command.Operation();
        }

        /// <summary>
        /// Returns a command object, depending on the
        /// command the user input.
        /// </summary>
        /// <param name="canvas">The canvas that the command affects.</param>
        /// <param name="userInput"></param>
        /// <returns></returns>
        public abstract Command CreateCommand(Canvas canvas, string userInput);
    }
}
