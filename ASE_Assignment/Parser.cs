using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    /// <summary>
    /// A class that parses the user input
    /// </summary>
    public class Parser
    {
        /// <summary>
        /// Extracts the command from the user input.
        /// </summary>
        /// <param name="userInput">The input of the user.</param>
        /// <returns>The command from the input.</returns>
        public static string ParseCommand(string userInput)
        {
            string[] splitInput = userInput.ToLower().Split(" ");

            return splitInput[0];
        }

        /// <summary>
        /// Extracts the parameters of the user input.
        /// </summary>
        /// <param name="userInput">The input of the user.</param>
        /// <returns>The parameters from the input.</returns>
        public static List<string> ParseParameters(string userInput)
        {
            List<string> parameters = new List<string>();
            string[] splitInput = userInput.Split(" ");
            parameters = splitInput.ToList();
            parameters.RemoveAt(0);

            return parameters;
        }

        // Currently exists for test-driven development
        public static int ParseVariable(string userInput)
        {
            // TODO: To be implemented
            return 0;
        }
    }
}
