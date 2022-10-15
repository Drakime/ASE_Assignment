using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    public class CommandException : Command
    {
        private string command;

        public CommandException(string command)
        {
            this.command = command;
        }

        public override void Operation()
        {
            TextBox t = Application.OpenForms["Form1"].Controls["console"] as TextBox;

            t.AppendText("'" + command + "'" + " command does not exist\r\n");
        }

        public override void ParseParameters(string userInput)
        {
            return;
        }
    }
}
