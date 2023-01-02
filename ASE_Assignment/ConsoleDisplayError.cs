using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    /// <summary>
    /// A class that handles the printing of error messages
    /// to the console.
    /// </summary>
    public class ConsoleDisplayError
    {
        private List<string> errors;
        TextBox consoleWindow = Application.OpenForms["Form1"].Controls["console"] as TextBox;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="errors">A list of errors.</param>
        public ConsoleDisplayError(List<string> errors)
        {
            this.errors = errors;
        }

        /// <summary>
        /// Prints errors to the console, based on the user input
        /// from the command line.
        /// </summary>
        public void PrintErrorToConsole()
        {
            foreach (string error in errors)
            {
                consoleWindow.AppendText(error);
            }
        }

        /// <summary>
        /// Prints errors to the console, based on the user input
        /// from the program textbox.
        /// </summary>
        /// <param name="lineNumber">The line number that the error occurs.</param>
        public void PrintProgramErrorToConsole(int lineNumber)
        {
            foreach (string error in errors)
            {
                consoleWindow.AppendText("Line " + lineNumber + ": " + error);
            }
        }
    }
}
