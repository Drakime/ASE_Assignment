using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    /// <summary>
    /// A class that signifies the end of a conditional command code block.
    /// </summary>
    public class EndConditional : Command
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="parameters">The parameters of the user input.</param>
        public EndConditional(List<string> parameters)
        {
            Parameters = parameters;
        }

        /// <summary>
        /// If criteria for the parameters is not met, adds to a list
        /// of list collection named 'Errors'.
        /// </summary>
        public override void VerifyParameters()
        {
            if (Parameters.Count != 0)
            {
                Errors.Add(InvalidNumberOfParameters);
                return;
            }
        }

        /// <summary>
        /// Returns execution back to the class that called the command.
        /// </summary>
        public override void Operation()
        {
            return;
        }
    }
}
