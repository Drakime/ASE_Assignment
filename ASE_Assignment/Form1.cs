using System.Text.RegularExpressions;

namespace ASE_Assignment
{
    public partial class Form1 : Form
    {
        Canvas canvas;
        CommandFactoryFactory factory;

        public Form1()
        {
            InitializeComponent();
            drawingCanvas.BackColor = Color.Gray;
            runButton.Enabled = false;

            // Creates new bitmap in canvas class, the same size as the picturebox.
            canvas = new Canvas(new Bitmap(drawingCanvas.Width, drawingCanvas.Height));
            factory = new CommandFactory();
        }

        // Disables run button if program textbox is empty
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

        private void runButton_Click(object sender, EventArgs e)
        {
            factory.Command(canvas, "run");
        }

        private void commandLine_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                string userInput = commandLine.Text.Trim().ToLower();

                factory.Command(canvas, userInput);
                drawingCanvas.Image = canvas.Bitmap;
                commandLine.Clear();
            }
        }

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