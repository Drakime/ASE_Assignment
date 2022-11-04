using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASE_Assignment
{
    /// <summary>
    /// A class that loads a program from a text file.
    /// </summary>
    public class Load : Command
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="userInput">The input of the user.</param>
        public Load(List<string> parameters)
        {
            Name = "load";
            Parameters = parameters;
            VerifyParameters();
        }

        /// <summary>
        /// Parses the user input.
        /// 
        /// If criteria is not met, adds to a list collection named
        /// 'errors'.
        /// </summary>
        /// <param name="userInput">The input of the user to be parsed.</param>
        public override void VerifyParameters()
        {
            

            if (Parameters.Count != 0)
            {
                Errors.Add(InvalidNumberOfParameters);
                return;
            }
        }

        /// <summary>
        /// Outputs an error message if there are any.
        /// 
        /// Otherwise, saves the program in the programTextBox
        /// to a text file.
        /// </summary>
        public override void Operation()
        {
            if (Errors.Count != 0)
            {
                Console = new ConsoleDisplayError(Errors);
                Console.PrintErrorToConsole();
                return;
            }

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Set up load dialog
                openFileDialog.Filter = "Text File | *.txt";
                openFileDialog.RestoreDirectory = true;

                // Get the programTextBox from the form
                TextBox t = Application.OpenForms["Form1"].Controls["programTextBox"] as TextBox;

                // Write text from file to textbox
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    StreamReader reader = new StreamReader(openFileDialog.OpenFile());

                    t.Text = reader.ReadToEnd();

                    reader.Close();
                } 
            }
        }
    }
}
