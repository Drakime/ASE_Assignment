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
    /// A test class for testing the 'Reset' class.
    /// </summary>
    [TestClass]
    public class ResetTests
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
        /// Asserts that canvas attributes are reset to 0
        /// with a correct 'Reset' command input.
        /// </summary>
        [TestMethod]
        public void Reset_SetsCanvasCoordinates_WhenExecutingOperation()
        {
            // Arrange
            string userInput = "reset";
            parameters = Parser.ParseParameters(userInput);

            // Act
            Reset reset = new Reset(canvas, parameters);

            // Assert
            Assert.AreEqual(0, canvas.PointX);
            Assert.AreEqual(0, canvas.PointY);
        }

        /// <summary>
        /// Asserts that an error string is added to the 'Error' list
        /// collection when the user input has an invalid number of parameters.
        /// </summary>
        /// <param name="userInput">An incorrectc 'Reset' command input</param>
        [DataTestMethod]
        [DataRow("reset this")]
        [DataRow("reset this and this")]
        [DataRow("reset this and this and also this")]
        public void Reset_AddsToErrorsListCollection_WhenInvalidNumberOfParameters(string userInput)
        {
            // Arrange
            parameters = Parser.ParseParameters(userInput);

            // Act
            Reset reset = new Reset(canvas, parameters);

            // Assert
            Assert.IsTrue(reset.Errors.Count != 0);
        }
    }
}
