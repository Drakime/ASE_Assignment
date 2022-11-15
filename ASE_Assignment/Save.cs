using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASE_Assignment
{
    /// <summary>
    /// A class that writes a program to a text file.
    /// </summary>
    public class Save : Command
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="parameters">The parameters of the user input.</param>
        public Save(List<string> parameters)
        {
            Name = "save";
            Parameters = parameters;
            VerifyParameters();
        }

        /// <summary>
        /// Parses the user input.
        /// 
        /// If criteria is not met, adds to a list collection named
        /// 'errors'.
        /// </summary>
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

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                // Set up save dialog
                saveFileDialog.Filter = "Text File | *.txt";
                saveFileDialog.RestoreDirectory = true;

                // Get the programTextBox from the form
                TextBox t = Application.OpenForms["Form1"].Controls["programTextBox"] as TextBox;

                // Write text from textbox to file
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter writer = new StreamWriter(saveFileDialog.OpenFile());

                    writer.WriteLine(t.Text);

                    writer.Dispose();

                    writer.Close();
                }
            }
        }
    }
}
