using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    /// <summary>
    /// A class that stores the program written
    /// by the user.
    /// </summary>
    public class UserProgram
    {
        private CommandFactory factory;
        private ArrayList programLines;
        private Canvas drawingCanvas;
        private bool hasNoSyntaxError = true;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="drawingCanvas">The canvas that is to be drawn on.</param>
        public UserProgram(Canvas drawingCanvas)
        {
            factory = new CommandFactory();
            programLines = new ArrayList();
            this.drawingCanvas = drawingCanvas;
        }

        /// <summary>
        /// Adds each line in the user program as a 'Command' object to
        /// an arraylist.
        /// </summary>
        public void SetProgramLines()
        {
            TextBox t = Application.OpenForms["Form1"].Controls["programTextBox"] as TextBox;

            string[] userProgram = Regex.Split(t.Text.Trim().ToLower(), @"\r\n");

            foreach (string line in userProgram)
            {
                programLines.Add(factory.CreateCommand(drawingCanvas, line));
            }
        }

        /// <summary>
        /// Checks each 'Command' object in an arraylist for errors.
        /// If there are any errors, the error is printed to the console.
        /// </summary>
        public void CheckSyntax()
        {
            foreach (Command line in programLines)
            {
                if (line.Errors.Count != 0)
                {
                    ConsoleDisplayError console = new ConsoleDisplayError(line.Errors);
                    console.PrintProgramErrorToConsole(programLines.IndexOf(line) + 1);
                    hasNoSyntaxError = false;
                    break;
                }
            }
        }

        /// <summary>
        /// Executes the drawing method of each object in an arraylist.
        /// </summary>
        public void Execute()
        {
            foreach (Command line in programLines)
            {
                line.Operation();
            }
        }

        /// <summary>
        /// Gets the value indicating whether the user program has syntax errors.
        /// </summary>
        public bool HasNoSyntaxError
        {
            get { return hasNoSyntaxError; }
        }
    }
}
