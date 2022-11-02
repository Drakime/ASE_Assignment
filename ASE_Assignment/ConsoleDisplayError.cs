using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    public class ConsoleDisplayError
    {
        private List<string> errors;
        TextBox consoleWindow = Application.OpenForms["Form1"].Controls["console"] as TextBox;

        public ConsoleDisplayError(List<string> errors)
        {
            this.errors = errors;
        }

        public void PrintErrorToConsole()
        {
            foreach (string error in errors)
            {
                consoleWindow.AppendText(error);
            }
        }
    }
}
