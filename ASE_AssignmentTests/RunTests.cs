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
    public class RunTests
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
        /// Asserts that there are no error strings added to the
        /// 'Error' list collection when the user input is correct.
        /// </summary>
        [TestMethod]
        public void Run_HasEmptyErrorsListCollection_WhenValidNumberOfParameters()
        {
            // Act
            Run run = new Run(canvas, "");

            // Assert
            Assert.IsTrue(run.Errors.Count == 0);
        }

        /// <summary>
        /// Asserts that an error string is added to the 'Error' list
        /// collection when the user input has an invalid number of parameters.
        /// </summary>
        /// <param name="userInput">An incorrect 'Run' command input</param>
        [DataTestMethod]
        [DataRow("run x")]
        [DataRow("run 98")]
        [DataRow("run 200")]
        public void Run_AddsToErrorsListCollection_WhenInvalidNumberOfParameters(string userInput)
        {
            // Arrange
            parameters = Parser.ParseParameters(userInput);

            // Act
            Clear clear = new Clear(canvas, parameters);

            // Assert
            Assert.IsTrue(clear.Errors.Count != 0);
        }
    }
}
