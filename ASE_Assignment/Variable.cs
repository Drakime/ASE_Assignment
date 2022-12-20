using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    /// <summary>
    /// A class that stores a value as a variable.
    /// </summary>
    public class Variable : Command
    {
        private string variableName = "";
        private int variableValue = 0;
        private Dictionary<string, int> variables = new Dictionary<string, int>();

        public int VariableValue
        {
            get { return variableValue; }
            set { variableValue = value; }
        }

        public string VariableName
        {
            get { return variableName; }
            set { variableName = value; }
        }

        public Dictionary<string, int> Variables
        {
            get { return variables; }
            set { variables = value; }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="parameters">The parameters of the user input.</param>
        public Variable(List<string> parameters)
        {
            Parameters = parameters;
            VerifyParameters();
        }

        /// <summary>
        /// Constructor for use by user program class.
        /// </summary>
        public Variable()
        {

        }

        /// <summary>
        /// Parses the parameter from the user input and sets the class
        /// attribute accordingly.
        /// 
        /// If criteria is not met, adds to a list collection named 'errors'.
        /// </summary>
        public override void VerifyParameters()
        {
            // Create a constructor that doesn't immediately call VerifyParameters();
            if (Parameters.Count == 3)
            {
                if (variables.ContainsKey(Parameters[2]))
                {
                    Parameters[2] = variables[Parameters[2]].ToString();
                }

                if (!Parameters[1].Equals("="))
                {
                    Errors.Add("Command format incorrect.");
                    return;
                }
                else if (Int32.TryParse(Parameters[2], out int parsedValue))
                {
                    variableValue = parsedValue;
                    variableName = Parameters[0];
                }
                else
                {
                    Errors.Add(InvalidTypeOfParameters);
                }
            }
            else if (Parameters.Count == 5 && CheckVariableDeclaration(string.Join(" ", Parameters)))
            {
                variableName = Parameters[0];

                string mathOperator = Parameters[3];

                if (Int32.TryParse(Parameters[4], out int increment)) { }
                else
                {
                    Errors.Add(InvalidTypeOfParameters);
                }

                switch (mathOperator)
                {
                    case "+":
                        variableValue += increment;
                        break;
                    case "-":
                        variableValue -= increment;
                        break;
                    case "*":
                        variableValue *= increment;
                        break;
                    case "/":
                        variableValue /= increment;
                        break;
                }
            }
            else
            {
                Errors.Add(InvalidTypeOfParameters);
            }
        }

        public bool CheckVariableDeclaration(string input)
        {
            Regex regex = new Regex("[a-zA-Z]+\\s=\\s[a-zA-Z]+\\s\\+\\s[0-9]+", RegexOptions.IgnoreCase);
            return regex.IsMatch(input);
        }

        /// <summary>
        /// Assigns the variable name to the class attribute.
        /// </summary>
        public override void Operation()
        {
            return;
        }
    }
}
