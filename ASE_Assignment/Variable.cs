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
        /// <summary>
        /// The name of the variable.
        /// </summary>
        private string variableName = "";

        /// <summary>
        /// The value of the variable.
        /// </summary>
        private int variableValue = 0;

        /// <summary>
        /// The currently existing variables of the user program.
        /// </summary>
        private Dictionary<string, int> variables = new Dictionary<string, int>();

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
        /// Constructor for use by the <see cref=">UserProgram"/> class.
        /// </summary>
        public Variable()
        {

        }

        /// <summary>
        /// Parses the parameter from the user input and sets the class
        /// attribute accordingly.
        /// </summary>
        /// <remarks>If criteria is not met, adds to a list collection named 'errors'.</remarks
        public override void VerifyParameters()
        {
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
            else if (Parameters.Count == 5 && CheckVariableDeclaration(string.Join(" ", Parameters)))   // For variables that increment
            {
                variableName = Parameters[0];

                string mathOperator = Parameters[3];

                if (variables.ContainsKey(variableName))
                {
                    variableValue = variables[variableName];
                } else
                {
                    Errors.Add(InvalidTypeOfParameters);
                }

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

        /// <summary>
        /// Checks that the variable declaration has been declared in the correct format.
        /// </summary>
        /// <param name="input">The variable declaration.</param>
        /// <returns>A flag determining if the variable declaration format is valid.</returns>
        public bool CheckVariableDeclaration(string input)
        {
            Regex regex = new Regex("[a-zA-Z]+\\s=\\s[a-zA-Z]+\\s\\+\\s[0-9]+", RegexOptions.IgnoreCase);
            return regex.IsMatch(input);
        }

        /// <summary>
        /// Returns execution back to the class that called the command.
        /// </summary>
        public override void Operation()
        {
            return;
        }

        /// <summary>
        /// Gets or sets the value of the variable.
        /// </summary>
        public int VariableValue
        {
            get { return variableValue; }
            set { variableValue = value; }
        }

        /// <summary>
        /// Gets or sets the name of the variable.
        /// </summary>
        public string VariableName
        {
            get { return variableName; }
            set { variableName = value; }
        }

        /// <summary>
        /// Gets or sets the current list of variables that the variable has access to.
        /// </summary>
        public Dictionary<string, int> Variables
        {
            get { return variables; }
            set { variables = value; }
        }
    }
}
