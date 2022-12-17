using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    /// <summary>
    /// A class that executes the commands within a conditional block, if
    /// conditions are met.
    /// </summary>
    public class ConditionalCommand : Command
    {
        private Dictionary<string, int> variables;
        private ArrayList programLines;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="drawingCanvas">The canvas to be drawn on.</param>
        /// <param name="parameters">The condition to be checked.</param>
        public ConditionalCommand(Canvas drawingCanvas, string parameters)
        {
            DrawingCanvas = drawingCanvas;
            Parameters = parameters.Split(" ").ToList();
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
        /// Evaluates the condition provided by the user in the conditional command.
        /// </summary>
        /// <returns>A boolean determining if the condition is true or false.</returns>
        /// <exception cref="Exception">Thrown if the variable in the condition does not exist
        /// in the current program.</exception>
        public bool ParseCondition()
        {
            if (variables.ContainsKey(Parameters[0]))
            {
                Parameters[0] = variables[Parameters[0]].ToString();
            }
            else
            {
                throw new Exception("Variable not found.");
            }

            int var = Int32.Parse(Parameters[0]);
            string comparisonOperator = Parameters[1];
            int value = Int32.Parse(Parameters[2]);

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
            if (ParseCondition())
            {
                foreach (Command line in programLines)
                {
                    line.Operation();
                }
            }
        }

        /// <summary>
        /// Gets or sets the program lines for the conditional command.
        /// </summary>
        public ArrayList ProgramLines
        {
            get { return programLines; }
            set { programLines = value; }
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
