using ASE_Assignment;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_AssignmentTests
{
    /// <summary>
    /// A test class for testing the 'Run' class.
    /// </summary>
    [TestClass]
    public class ConditionalCommandTests
    {
        Bitmap bitmap;
        Canvas canvas;
        List<string> parameters;

        /// <summary>
        /// Instantiates a bitmap, canvas, and a list to store parameters.
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            bitmap = new Bitmap(100, 100);
            canvas = new Canvas(bitmap);
            parameters = new List<string>();
        }

        /// <summary>
        /// Asserts that a conditional command in the program lines
        /// contains the correct code block in the user program.
        /// </summary>
        [TestMethod]
        public void ConditionalCommand_ContainsCorrectCodeBlock_InUserProgram()
        {
            // Arrange
            string userInput = "rect 100,100\r\nvar x = 1\r\nif x == 1\r\ncircle 100\r\nrect 50,50\r\nendif";
            UserProgram program = new UserProgram(canvas);

            // Act
            program.SetProgramLines(userInput);
            ConditionalCommand command = (ConditionalCommand)program.ProgramLines[1];

            // Assert
            Assert.IsTrue(command.ProgramLines[0].GetType() == typeof(Circle));
            Assert.IsTrue(command.ProgramLines[1].GetType() == typeof(Rect));
        }
    }
}
