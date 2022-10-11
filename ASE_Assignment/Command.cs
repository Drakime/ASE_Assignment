using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    public abstract class Command
    {
        private string name = "";
        private string userInput = "";
        private List<int> parameterList = new List<int>();
        protected Canvas drawingCanvas;
        private Color toolColour = new Color();

        public abstract void ParseParameters(string userInput);

        public abstract void Operation();

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

        protected Canvas DrawingCanvas
        {
            get { return drawingCanvas; }
            set { drawingCanvas = value; }
        }

        private Color ToolColour
        {
            get { return toolColour; }
            set { toolColour = value; }
        }
    }
}
