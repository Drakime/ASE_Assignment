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
    /// A test class for testing the 'Parser' class.
    /// </summary>
    [TestClass]
    public class ParserTests
    {
        // TODO: Implement unit tests.
        List<string> parameters;

        /// <summary>
        /// Instantiates a bitmap, canvas, and a list to store parameters.
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            parameters = new List<string>();
        }

        /// <summary>
        /// Asserts that the command is returned as a string from the user input.
        /// </summary>
        /// <param name="userInput">An input containing a command.</param>
        /// <param name="expected">The expected command to be returned.</param>
        [DataTestMethod]
        [DataRow("circle 10", "circle")]
        [DataRow("rect 50,25", "rect")]
        [DataRow("triangle 10,15 46,90 100,80", "triangle")]
        [DataRow("moveto 80,90", "moveto")]
        [DataRow("clear", "clear")]
        public void ParseCommand_ReturnsCommand_FromUserInput(string userInput, string expected)
        {
            // Arrange and Act
            string actual = Parser.ParseCommand(userInput);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Asserts that parameters are correctly parsed from the user input and
        /// returned as a list collection.
        /// </summary>
        /// <param name="userInput"></param>
        /// <param name="expected"></param>
        [DataTestMethod]
        [DataRow("circle 10", "10")]
        [DataRow("rect 50,25", "50,25")]
        [DataRow("moveto 80,90", "80,90")]
        public void ParseParameters_ReturnsCorrectListOfParameters_FromUserInput(string userInput, string expected)
        {
            // Arrange and Act
            parameters = Parser.ParseParameters(userInput);

            // Assert
            Assert.AreEqual(parameters[0], expected);
        }

        /// <summary>
        /// Asserts that the user program is returned from the user input.
        /// </summary>
        [TestMethod]
        public void ParseProgram_ReturnsProgram_FromUserInput()
        {
            // Arrange
            string userInput = "run circle 50\r\nrect 30,40\r\npen blue\r\nmoveto 100,100\r\ncircle 100";
            string expected = "circle 50\r\nrect 30,40\r\npen blue\r\nmoveto 100,100\r\ncircle 100";

            // Act
            string userProgram = Parser.ParseProgram(userInput);

            // Assert
            Assert.AreEqual(expected, userProgram);
        }
    }
}
