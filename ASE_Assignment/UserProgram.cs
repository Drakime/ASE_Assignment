using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace ASE_Assignment
{
    /// <summary>
    /// A class that stores the program written
    /// by the user.
    /// </summary>
    public class UserProgram
    {
        /// <summary>
        /// An instance of the <see cref=">CommandFactory"/> class to generate command objects.
        /// </summary>
        private CommandFactory factory;

        /// <summary>
        /// A collection of commands to be executed.
        /// </summary>
        private ArrayList programLines;

        /// <summary>
        /// The canvas to be drawn on.
        /// </summary>
        private Canvas drawingCanvas;

        /// <summary>
        /// A flag indicating if there are any syntax errors in the user program.
        /// </summary>
        private bool hasNoSyntaxError = true;

        /// <summary>
        /// A collection of variables in the user program.
        /// </summary>
        private Dictionary<string, int> variables = new Dictionary<string, int>();

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="drawingCanvas">The canvas that is to be drawn on.</param>
        public UserProgram(Canvas drawingCanvas)
        {
            factory = new CommandFactory();
            programLines = new ArrayList();
            this.drawingCanvas = drawingCanvas;
        }

        /// <summary>
        /// Adds each line in the user program as a 'Command' object to
        /// an arraylist.
        /// </summary>
        public void SetProgramLines(string userInput)
        {
            string[] userProgram = Regex.Split(userInput.Trim().ToLower(), @"\r\n");

            for (int index = 0; index < userProgram.Length; index++)
            {
                var command = factory.CreateCommand(drawingCanvas, userProgram[index]);

                // Add command to variables list if variable
                if (command is Variable)
                {
                    Variable variable = new Variable();
                    variable.Parameters = Parser.ParseParameters(userProgram[index]);
                    variable.Variables = variables;
                    variable.VerifyParameters();

                    int value = variable.VariableValue;
                    string variableName = variable.VariableName;

                    if (variables.ContainsKey(variableName))
                    {
                        variables[variableName] = value;
                    }
                    else
                    {
                        variables.Add(variableName, value);
                        programLines.Add(variable);
                    }
                    continue;
                }

                // Add conditional command to program lines if conditional command
                if (command is ConditionalCommand)
                {
                    ConditionalCommand conditionalCommand = (ConditionalCommand)command;
                    conditionalCommand.Variables = variables;

                    List<string> codeBlock = new List<string>();

                    for (int j = index + 1; j < userProgram.Length; j++)
                    {
                        var tempCommand = factory.CreateCommand(drawingCanvas, userProgram[j]);

                        if (tempCommand is EndConditional)
                        {
                            index = j;
                            break;
                        }

                        codeBlock.Add(userProgram[j]);
                    }
                    conditionalCommand.CodeBlockProgram = string.Join("\r\n", codeBlock.ToArray());

                    programLines.Add(conditionalCommand);
                    continue;
                }

                // Add loop command to program lines if loop command
                if (command is LoopCommand)
                {
                    LoopCommand loopCommand = (LoopCommand)command;
                    loopCommand.Variables = variables;

                    List<string> codeBlock = new List<string>();

                    for (int j = index + 1; j < userProgram.Length; j++)
                    {
                        var tempCommand = factory.CreateCommand(drawingCanvas, userProgram[j]);

                        if (tempCommand is EndWhile)
                        {
                            index = j;
                            break;
                        }

                        codeBlock.Add(userProgram[j]);
                    }
                    loopCommand.CodeBlockProgram = string.Join("\r\n", codeBlock.ToArray());

                    programLines.Add(loopCommand);
                    continue;
                }

                // Substitute variables into command if needed
                string checkedVariableLine = CheckVariables(userProgram[index]);

                programLines.Add(factory.CreateCommand(drawingCanvas, checkedVariableLine));
            }
        }

        /// <summary>
        /// Checks if the command requires any existing variables
        /// to be substituted into the program line.
        /// </summary>
        /// <param name="line">The command to be checked.</param>
        /// <returns>The command as a string with variables substituted in.</returns>
        public string CheckVariables(string line)
        {
            string[] tokens = line.Split(" ");

            // Variable substitution for multiple parameter commands
            for (int i = 0; i < tokens.Length; i++)
            {
                if (tokens[i].Contains(","))
                {
                    string[] splitParameters = tokens[i].Split(",");

                    for (int j = 0; j < splitParameters.Length; j++)
                    {
                        if (variables.ContainsKey(splitParameters[j]))
                        {
                            splitParameters[j] = variables[splitParameters[j]].ToString();
                        }
                    }

                    string rejoinedParameters = string.Join(",", splitParameters);
                    tokens[i] = rejoinedParameters;
                }

                // Variable substitution for single parameter commands
                if (variables.ContainsKey(tokens[i]))
                {
                    tokens[i] = variables[tokens[i]].ToString();
                }
            }

            return string.Join(" ", tokens);
        }

        /// <summary>
        /// Checks each 'Command' object in an arraylist for errors, printing them
        /// to the console if there are any.
        /// </summary>
        public void CheckSyntax()
        {
            foreach (Command line in programLines)
            {
                if (line.Errors.Count != 0)
                {
                    ConsoleDisplayError console = new ConsoleDisplayError(line.Errors);
                    console.PrintProgramErrorToConsole(programLines.IndexOf(line) + 1);
                    hasNoSyntaxError = false;
                    break;
                }
            }
        }

        /// <summary>
        /// Executes the drawing method of each object in an arraylist.
        /// </summary>
        public void Execute()
        {
            foreach (Command line in programLines)
            {
                line.Operation();
            }
        }

        /// <summary>
        /// Gets or sets a flag indicating whether the user program has syntax errors.
        /// </summary>
        public bool HasNoSyntaxError
        {
            get { return hasNoSyntaxError; }
            set { hasNoSyntaxError = value; }
        }

        /// <summary>
        /// Gets or sets the program lines of the user program.
        /// </summary>
        public ArrayList ProgramLines
        {
            get { return programLines; }
            set { programLines = value; }
        }

        /// <summary>
        /// Gets or sets the variables of the user program.
        /// </summary>
        public Dictionary<string, int> Variables
        {
            get { return variables; }
            set { variables = value; }
        }
    }
}
