using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    public abstract class Command
    {
        private const string invalidTypeOfParameters = "Parameter types are invalid\r\n";
        private const string invalidNumberOfParameters = "Number of parameters are incorrect\r\n";

        private string name = "";
        private string userInput = "";
        private List<int> parameterList = new List<int>();
        public Canvas drawingCanvas;
        List<string> errors = new List<string>();

        public abstract void ParseParameters(string userInput);

        public abstract void Operation();

        public string InvalidTypeOfParameters
        {
            get { return invalidTypeOfParameters; }
        }

        public string InvalidNumberOfParameters
        {
            get { return invalidNumberOfParameters; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string UserInput
        {
            get { return userInput; }
            set { userInput = value; }
        }

        public List<int> ParameterList
        {
            get { return parameterList; }
            set { parameterList = value; }
        }

        public Canvas DrawingCanvas
        {
            get { return drawingCanvas; }
            set { drawingCanvas = value; }
        }

        public List<string> Errors
        {
            get { return errors; }
            set { errors = value; }
        }
    }
}
