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
    /// A test class for testing the 'DrawTo' class.
    /// </summary>
    [TestClass]
    public class DrawToTests
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
        /// Asserts that the arguments of a correct 'DrawTo' command
        /// is stored correctly as an x and y coordinate within the
        /// instanced class.
        /// </summary>
        /// <param name="userInput">A correct 'DrawTo' command input</param>
        /// <param name="expectedX">The expected x-coordinate to be stored</param>
        /// <param name="expectedY">The expected y-coordinate to be stored</param>
        [DataTestMethod]
        [DataRow("drawto 10,15", 10, 15)]
        [DataRow("drawto 67,90", 67, 90)]
        [DataRow("drawto 132,48", 132, 48)]
        public void DrawTo_StoresCorrectParameters_WhenParsingUserInput(string userInput, int expectedX, int expectedY)
        {
            // Arrange
            parameters = Parser.ParseParameters(userInput);

            // Act
            DrawTo drawto = new DrawTo(canvas, parameters);

            // Assert
            Assert.AreEqual(expectedX, drawto.X);
            Assert.AreEqual(expectedY, drawto.Y);
        }

        /// <summary>
        /// Asserts that an error string is added to the 'Error' list
        /// collection when the user input has an invalid number of parameters.
        /// </summary>
        /// <param name="userInput">An incorrect 'DrawTo' command input</param>
        [DataTestMethod]
        [DataRow("drawto 189,29,142")]
        [DataRow("drawto 136 42 168")]
        [DataRow("drawto 178,80 191")]
        public void DrawTo_AddsToErrorsListCollection_WhenInvalidNumberOfParameters(string userInput)
        {
            // Arrange
            parameters = Parser.ParseParameters(userInput);

            // Act
            DrawTo drawto = new DrawTo(canvas, parameters);

            // Assert
            Assert.IsTrue(drawto.Errors.Count != 0);
        }

        /// <summary>
        /// Asserts that an error string is added to the 'Error' list
        /// collection when the user input has invalid parameter types.
        /// </summary>
        /// <param name="userInput">An incorrect 'DrawTo' command input</param>
        [DataTestMethod]
        [DataRow("drawto 48,x")]
        [DataRow("drawto here,again")]
        [DataRow("drawto fifty,5")]
        public void DrawTo_AddsToErrorsListCollection_WhenInvalidTypeOfParameters(string userInput)
        {
            // Arrange
            parameters = Parser.ParseParameters(userInput);

            // Act
            DrawTo drawto = new DrawTo(canvas, parameters);

            // Assert
            Assert.IsTrue(drawto.Errors.Count != 0);
        }

        [DataTestMethod]
        [DataRow("drawto 10,15", 10, 15)]
        [DataRow("drawto 67,90", 67, 90)]
        [DataRow("drawto 132,48", 132, 48)]
        public void DrawTo_UpdatesCanvasCoordinates_WhenParsingInput(string userInput, int expectedX, int expectedY)
        {
            // Arrange
            parameters = Parser.ParseParameters(userInput);

            // Act
            DrawTo drawto = new DrawTo(canvas, parameters);
            drawto.Operation();

            // Assert
            Assert.AreEqual(expectedX, canvas.PointX);
            Assert.AreEqual(expectedY, canvas.PointY);
        }
    }
}
