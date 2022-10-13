using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    public class CommandException : Command
    {
        public override void Operation()
        {
            MessageBox.Show("Command does not exist");
        }

        public override void ParseParameters(string userInput)
        {
            return;
        }
    }
}
