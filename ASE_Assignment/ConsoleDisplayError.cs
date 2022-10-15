using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    public class ConsoleDisplayError
    {
        private string userInput;
        private List<string> errors;
        TextBox consoleWindow = Application.OpenForms["Form1"].Controls["console"] as TextBox;

        public ConsoleDisplayError(string userInput, List<string> errors)
        {
            this.userInput = userInput;
            this.errors = errors;
        }

        public void PrintErrorToConsole()
        {
            foreach (string error in errors)
            {
                consoleWindow.AppendText("'" + userInput + "'" + " : " + error);
            }
        }
    }
}
