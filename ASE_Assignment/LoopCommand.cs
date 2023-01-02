using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    /// <summary>
    /// A class that executes the commands within a loop block, if
    /// conditions are met.
    /// </summary>
    public class LoopCommand : Command
    {
        /// <summary>
        /// The variables of the user program.
        /// </summary>
        private Dictionary<string, int> variables;

        /// <summary>
        /// The code block within the loop conditional.
        /// </summary>
        private string codeBlockProgram;

        /// <summary>
        /// An instance of the <see cref="UserProgram"/> class for code block execution.
        /// </summary>
        private UserProgram codeBlock;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="drawingCanvas">The canvas to be drawn on.</param>
        /// <param name="parameters">The condition to be checked.</param>
        public LoopCommand(Canvas drawingCanvas, string parameters)
        {
            DrawingCanvas = drawingCanvas;
            Parameters = parameters.Split(" ").ToList();
            codeBlock = new UserProgram(drawingCanvas);
            VerifyParameters();
        }

        /// <summary>
        /// Verifies that the condition has the correct number of terms.
        /// </summary>
        public override void VerifyParameters()
        {
            if (Parameters.Count != 3)
            {
                Errors.Add("Invalid condition");
                return;
            }
        }

        /// <summary>
        /// Evaluates the condition provided by the user in the loop command.
        /// </summary>
        /// <returns>A flag determining if the condition is true.</returns>
        public bool ParseCondition()
        {
            string conditionVariable = " ";

            if (variables.ContainsKey(Parameters[0]))
            {
                conditionVariable = variables[Parameters[0]].ToString();
            }
            else
            {
                Errors.Add("Variable not found");
                return false;
            }

            if (Int32.TryParse(conditionVariable, out int var)) { }
            else
            {
                Errors.Add(InvalidTypeOfParameters);
                return false;
            }

            if (Int32.TryParse(Parameters[2], out int value)) { }
            else
            {
                Errors.Add(InvalidTypeOfParameters);
                return false;
            }

            string comparisonOperator = Parameters[1];

            switch (comparisonOperator)
            {
                case "==":
                    return var == value;
                case ">":
                    return var > value;
                case "<":
                    return var < value;
                case "<=":
                    return var <= value;
                case ">=":
                    return var >= value;
                default: return false;
            }
        }

        /// <summary>
        /// Executes the commands in the conditional block if the 
        /// condition is met.
        /// </summary>
        public override void Operation()
        {
            bool execute = ParseCondition();

            while (execute)
            {
                codeBlock.Variables = variables;
                codeBlock.SetProgramLines(codeBlockProgram);
                codeBlock.CheckSyntax();
                codeBlock.Execute();
                variables = codeBlock.Variables;
                execute = ParseCondition();
            }
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
