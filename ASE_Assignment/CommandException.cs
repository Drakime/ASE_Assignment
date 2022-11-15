using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    /// <summary>
    /// A class that outputs and error message to the console
    /// if the command input by the user is not valid.
    /// </summary>
    public class CommandException : Command
    {
        /// <summary>
        /// The command of the user input.
        /// </summary>
        private string command;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="command">The command of the user input.</param>
        public CommandException(string command)
        {
            this.command = command;
            VerifyParameters();
        }

        /// <summary>
        /// Adds a message to a list collection named 'errors'.
        /// </summary>
        public override void VerifyParameters()
        {
            Errors.Add("'" + command + "'" + " command does not exist\r\n");
        }

        /// <summary>
        /// Outputs an error message to the console for a command line input.
        /// </summary>
        public override void Operation()
        {
            TextBox t = Application.OpenForms["Form1"].Controls["console"] as TextBox;

            t.AppendText("'" + command + "'" + " command does not exist\r\n");
        }
    }
}
