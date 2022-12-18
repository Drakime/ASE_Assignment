using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    /// <summary>
    /// A class that stores a value as a variable.
    /// </summary>
    public class Variable : Command
    {
        private string variableName = "";
        private int value = 0;

        public int Value { get { return value; } }
        public string VariableName { get { return variableName; } }

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
        /// Parses the parameter from the user input and sets the class
        /// attribute accordingly.
        /// 
        /// If criteria is not met, adds to a list collection named 'errors'.
        /// </summary>
        public override void VerifyParameters()
        {
            if (Parameters.Count != 3 || !Parameters[1].Equals("=") || Parameters[0].GetType() != typeof(string))
            {
                Errors.Add("Command format incorrect.");
                return;
            }

            if (Int32.TryParse(Parameters[2], out int parsedValue))
            {
                value = parsedValue;
                variableName = Parameters[0];
            }
            else
            {
                Errors.Add(InvalidTypeOfParameters);
            }
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
