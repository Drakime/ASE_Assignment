using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    /// <summary>
    /// A class that stores the commands within a method block.
    /// </summary>
    public class MethodCommand : Command
    {
        /// <summary>
        /// A collection of currently known variables of the user program.
        /// </summary>
        private Dictionary<string, int> variables;

        /// <summary>
        /// The code block of the user program within the method command.
        /// </summary>
        private string codeBlockProgram;

        /// <summary>
        /// An instance of the <see cref="UserProgram"/> class, for the code block.
        /// </summary>
        private UserProgram codeBlock;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="drawingCanvas">The canvas to be drawn on.</param>
        public MethodCommand(Canvas drawingCanvas, List<string> parameters)
        {
            DrawingCanvas = drawingCanvas;
            Parameters = parameters;
            Name = parameters[0];
            codeBlock = new UserProgram(drawingCanvas);
            VerifyParameters();
            codeBlock.Variables = variables;
            codeBlock.SetProgramLines(codeBlockProgram);
        }

        /// <summary>
        /// Parses the parameters from the user input.
        /// </summary>
        public override void VerifyParameters()
        {
            if (Parameters.Count != 2 || Parameters[1] != " ")
            {
                Errors.Add(InvalidNumberOfParameters);
                return;
            }
        }

        /// <summary>
        /// Returns execution to the user program.
        /// </summary>
        public override void Operation()
        {
            return;
        }

        /// <summary>
        /// Gets or sets the program lines for the method command.
        /// </summary>
        public string CodeBlockProgram
        {
            get { return codeBlockProgram; }
            set { codeBlockProgram = value; }
        }

        /// <summary>
        ///  Gets or sets the current variables of the program
        ///  at the point that the method command is declared.
        /// </summary>
        public Dictionary<string, int> Variables
        {
            get { return variables; }
            set { variables = value; }
        }
    }
}
