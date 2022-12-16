using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    public class ConditionalCommand : Command
    {
        private Dictionary<string, int> variables;
        private ArrayList programLines;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="drawingCanvas">The canvas to be drawn on.</param>
        /// <param name="parameters">The condition to be checked.</param>
        public ConditionalCommand(Canvas drawingCanvas, string parameters)
        {
            DrawingCanvas = drawingCanvas;
            Parameters = parameters.Split(" ").ToList();
        }

        public override void VerifyParameters()
        {
            if (Parameters.Count != 3)
            {
                Errors.Add("Invalid condition");
                return;
            }
        }

        public void SetConditionalProgramLines(ArrayList programLines)
        {
            this.programLines = programLines;
        }

        public void SetVariables(Dictionary<string, int> variables)
        {
            this.variables = variables;
        }

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
    }
}
