using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    public abstract class Command
    {
        // Error messages
        private const string invalidTypeOfParameters = "Parameter types are invalid\r\n";
        private const string invalidNumberOfParameters = "Number of parameters are incorrect\r\n";

        private string name = "";
        private string userInput = "";
        private List<int> parameterList = new List<int>();
        public Canvas drawingCanvas;

        /// <summary>
        /// The collection of errors in a command.
        /// </summary>
        List<string> errors = new List<string>();

        /// <summary>
        /// Parses the provided user input, to retrieve
        /// command parameters.
        /// </summary>
        /// <param name="userInput">The input of the user.</param>
        public abstract void ParseParameters(string userInput);

        /// <summary>
        /// The action of the command.
        /// 
        /// This could be the graphical drawing onto a given canvas
        /// or the updating of attributes for a canvas instance.
        /// </summary>
        public abstract void Operation();

        /// <summary>
        /// Gets the error message for invalid
        /// types of parameters.
        /// </summary>
        public string InvalidTypeOfParameters
        {
            get { return invalidTypeOfParameters; }
        }

        /// <summary>
        /// Gets the error message for invalid
        /// number of parameters.
        /// </summary>
        public string InvalidNumberOfParameters
        {
            get { return invalidNumberOfParameters; }
        }

        /// <summary>
        /// Gets or sets the name of the command.
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Gets or sets the user input.
        /// </summary>
        public string UserInput
        {
            get { return userInput; }
            set { userInput = value; }
        }

        /// <summary>
        /// Gets or sets the list of parameters.
        /// </summary>
        public List<int> ParameterList
        {
            get { return parameterList; }
            set { parameterList = value; }
        }

        /// <summary>
        /// Gets or sets the canvas.
        /// </summary>
        public Canvas DrawingCanvas
        {
            get { return drawingCanvas; }
            set { drawingCanvas = value; }
        }

        /// <summary>
        /// Gets or sets the list of errors.
        /// </summary>
        public List<string> Errors
        {
            get { return errors; }
            set { errors = value; }
        }
    }
}
