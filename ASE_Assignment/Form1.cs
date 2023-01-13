using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
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
        Canvas cursorCanvas;
        Cursor cursor;

        /// <summary>
        /// Initialises an instance of the form.    
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            // Setting the background colour of the cursor canvas as transparent will only
            // result in the canvas being the same colour as the form.
            // Setting the parent of the cursor canvas as the drawing canvas will allow the background 
            // to be fully transparent, displaying the bitmap on the canvas below.
            drawingCanvas.BackColor = Color.Gray;
            cursorDrawingCanvas.BackColor = Color.Transparent;
            cursorDrawingCanvas.Parent = drawingCanvas;
            cursorDrawingCanvas.Location = new Point(cursorDrawingCanvas.Location.X - drawingCanvas.Location.X,
                cursorDrawingCanvas.Location.Y - drawingCanvas.Location.Y);

            runButton.Enabled = false;

            // Creates new bitmaps in canvas classes, the same size as the picturebox.
            canvas = new Canvas(new Bitmap(drawingCanvas.Width, drawingCanvas.Height));
            cursorCanvas = new Canvas(new Bitmap(drawingCanvas.Width, drawingCanvas.Height));
            factory = new CommandFactory();
            cursor = ASE_Assignment.Cursor.Instance;
        }

        /// <summary>
        /// An event listener that draws the cursor in the default position when the
        /// form is first shown.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Shown(object sender, EventArgs e)
        {
            cursor.UpdateCursor(cursorCanvas, canvas);
            cursorDrawingCanvas.Image = cursorCanvas.Bitmap;
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

            cursor.UpdateCursor(cursorCanvas, canvas);
            cursorDrawingCanvas.Image = cursorCanvas.Bitmap;
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

                cursor.UpdateCursor(cursorCanvas, canvas);
                cursorDrawingCanvas.Image = cursorCanvas.Bitmap;
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