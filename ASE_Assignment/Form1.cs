using System.Text.RegularExpressions;

namespace ASE_Assignment
{
    /// <summary>
    /// A class that displays the application as a form.
    /// </summary>
    public partial class Form1 : Form
    {
        Canvas canvas;
        CommandFactoryFactory factory;

        /// <summary>
        /// Initialises an instance of the form.    
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            drawingCanvas.BackColor = Color.Gray;
            runButton.Enabled = false;

            // Creates new bitmap in canvas class, the same size as the picturebox.
            canvas = new Canvas(new Bitmap(drawingCanvas.Width, drawingCanvas.Height));
            factory = new CommandFactory();
        }

        /// <summary>
        /// An event listener that disables the "run" button if the program textbox is empty
        /// </summary>
        /// <param name="sender">The event source.</param>
        /// <param name="e">An instance of the event data.</param>
        private void programTextBox_TextChanged(object sender, EventArgs e)
        {
            if (programTextBox.Text.Equals(""))
            {
                runButton.Enabled = false;
            }
            else
            {
                runButton.Enabled = true;
            }
        }

        /// <summary>
        /// An event listener that executes the "run" command if the button is clicked.
        /// </summary>
        /// <param name="sender">The event source.</param>
        /// <param name="e">An instance of the event data.</param>
        private void runButton_Click(object sender, EventArgs e)
        {
            string userProgram = programTextBox.Text;

            factory.Command(canvas, "run" + " " + userProgram);
        }

        /// <summary>
        /// An event listener that checks the syntax of the program if the button is clicked.
        /// </summary>
        /// <param name="sender">The event source.</param>
        /// <param name="e">An instance of the event data.</param>
        private void syntax_button_Click(object sender, EventArgs e)
        {
            string userProgram = programTextBox.Text;

            factory.Command(canvas, "syntax" + " " + userProgram);
        }

        /// <summary>
        /// An event listener that executes the command in the command line textbox.
        /// </summary>
        /// <param name="sender">The event source.</param>
        /// <param name="e">An instance of the event data (the "enter" key).</param>
        private void commandLine_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                e.Handled = true;

                string userInput = commandLine.Text.Trim().ToLower();

                if (userInput == "run")
                {
                    runButton_Click(sender, e);
                }
                else if (userInput == "syntax")
                {
                    syntax_button_Click(sender, e);
                }
                else
                {
                    factory.Command(canvas, userInput);
                    drawingCanvas.Image = canvas.Bitmap;
                }
                commandLine.Clear();
            }
        }

        // MenuStrip - ToolStrip items
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            factory.Command(canvas, "load");
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            factory.Command(canvas, "save");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}