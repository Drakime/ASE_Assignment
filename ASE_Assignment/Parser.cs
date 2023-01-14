using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
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

        /// <summary>
        /// Extracts the user program from the user input.
        /// </summary>
        /// <param name="userInput">The input of the user.</param>
        /// <returns>The user program from the input.</returns>
        public static string ParseProgram(string userInput)
        {
            List<string> userProgram = new List<string>();
            string[] splitInput = userInput.Split(" ");
            userProgram = splitInput.ToList();
            userProgram.RemoveAt(0);

            return string.Join(" ", userProgram);
        }

        /// <summary>
        /// Extracts the parameters of the parameters list from the user input.
        /// </summary>
        /// <param name="userInput">The input of the user.</param>
        /// <returns>The parameter list from the input.</returns>
        public static List<string> ParseMethod(string userInput)
        {
            List<string> parameters = new List<string>();

            string methodParameters = userInput.Substring(7);
            string otherInput = methodParameters.Substring(methodParameters.IndexOf(")") + 1);
            parameters.Add(methodParameters);
            parameters.Add(otherInput);

            return parameters;
        }
    }
}
