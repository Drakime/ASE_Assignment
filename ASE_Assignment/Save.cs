﻿using System;
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
        /// <param name="userInput">The input of the user.</param>
        public Save(string userInput)
        {
            Name = "save";
            ParseParameters(userInput);
        }

        /// <summary>
        /// Parses the user input.
        /// 
        /// If criteria is not met, adds to a list collection named
        /// 'errors'.
        /// </summary>
        /// <param name="userInput">The input of the user to be parsed.</param>
        public override void ParseParameters(string userInput)
        {
            string[] splitUserInput = userInput.Split(" ");

            if (splitUserInput.Length != 1)
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
                foreach (string error in Errors)
                {
                    MessageBox.Show(error);
                    return;
                }
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
