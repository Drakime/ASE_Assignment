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
        /// The code block of the user program within the conditional command.
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
        public MethodCommand(Canvas drawingCanvas)
        {
            DrawingCanvas = drawingCanvas;
            codeBlock = new UserProgram(drawingCanvas);
        }

        public override void VerifyParameters()
        {
            // In this case, the verification would be of the parameters for the parameters list
            return;
        }

        /// <summary>
        /// Executes the commands in the method block.
        /// </summary>
        public override void Operation()
        {
            codeBlock.Variables = variables;
            codeBlock.SetProgramLines(codeBlockProgram);
            codeBlock.CheckSyntax();
            codeBlock.Execute();
        }

        /// <summary>
        /// Gets or sets the program lines for the conditional command.
        /// </summary>
        public string CodeBlockProgram
        {
            get { return codeBlockProgram; }
            set { codeBlockProgram = value; }
        }

        /// <summary>
        ///  Gets or sets the current variables of the program
        ///  at the point that the conditional command is declared.
        /// </summary>
        public Dictionary<string, int> Variables
        {
            get { return variables; }
            set { variables = value; }
        }
    }
}
