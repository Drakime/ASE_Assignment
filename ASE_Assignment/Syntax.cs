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
        private UserProgram program;
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
        /// Parses the user input.
        /// 
        /// If criteria is not met, adds to a list collection named
        /// 'errors'.
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
        /// Outputs an error message if there are any.
        /// 
        /// Otherwise, checks the syntax of the program and outputs any error messages to the console.
        /// </summary>
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
