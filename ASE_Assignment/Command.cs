using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    public abstract class Command
    {
        /// <summary>
        /// An error message for invalid parameter types.
        /// </summary>
        private const string invalidTypeOfParameters = "Parameter types are invalid\r\n";

        /// <summary>
        /// An error message of an invalid number of parameters.
        /// </summary>
        private const string invalidNumberOfParameters = "Number of parameters are incorrect\r\n";

        /// <summary>
        /// The name of the command.
        /// </summary>
        private string name = "";

        /// <summary>
        /// A collection of parameters of the command.
        /// </summary>
        private List<string> parameters = new List<string>();

        /// <summary>
        /// The canvas to be drawn on.
        /// </summary>
        private Canvas drawingCanvas;

        /// <summary>
        /// The collection of errors in a command.
        /// </summary>
        private List<string> errors = new List<string>();

        private ConsoleDisplayError console;

        /// <summary>
        /// Parses the provided user input, to retrieve
        /// command parameters.
        /// </summary>
        public abstract void VerifyParameters();

        /// <summary>
        /// The action of the command.
        /// </summary>
        /// <remarks>The action could be the graphical drawing onto a given canvas
        /// or the updating of attributes for a canvas instance.</remarks>
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
        public List<string> Parameters
        {
            get { return parameters; }
            set { parameters = value; }
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

        public ConsoleDisplayError Console
        {
            get { return console; }
            set { console = value; }
        }
    }
}
