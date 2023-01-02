using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace ASE_Assignment
{
    /// <summary>
    /// A class that checks the syntax of the program
    /// before execution.
    /// </summary>
    public class Syntax : Command
    {
        /// <summary>
        /// An instance of the <see cref=">UserProgram"/> class to check syntax.
        /// </summary>
        private UserProgram program;

        /// <summary>
        /// The user program from the program text box.
        /// </summary>
        private string userProgram;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="canvas">The canvas to be manipulated.</param>
        /// <param name="parameters">The parameters of the user input.</param>
        public Syntax(Canvas canvas, string userProgram)
        {
            Name = "syntax";
            DrawingCanvas = canvas;
            this.userProgram = userProgram;
            program = new UserProgram(DrawingCanvas);
            VerifyParameters();
        }

        /// <summary>
        /// If criteria is not met, adds to a list collection named 'errors'.
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
        /// Checks the syntax of the program and outputs any error messages to the console.
        /// </summary>
        /// <remarks>Outputs an error message if there are any, ignoring the action.</remarks>
        public override void Operation()
        {
            if (Errors.Count != 0)
            {
                Console = new ConsoleDisplayError(Errors);
                Console.PrintErrorToConsole();
                return;
            }

            program.SetProgramLines(userProgram);
            program.CheckSyntax();

            if (program.HasNoSyntaxError == true)
            {
                TextBox consoleWindow = Application.OpenForms["Form1"].Controls["console"] as TextBox;

                consoleWindow.AppendText("No syntax errors in program.\r\n");
            }

            return;
        } 
    }
}
