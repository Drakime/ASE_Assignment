using ASE_Assignment;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_AssignmentTests
{
    [TestClass]
    public class CircleTests
    {
        Bitmap bitmap;
        Canvas canvas;
        List<string> parameters;

        [TestInitialize]
        public void SetUp()
        {
            bitmap = new Bitmap(100, 100);
            canvas = new Canvas(bitmap);
            parameters = new List<string>();
        }

        /// <summary>
        /// Asserts that the argument of a correct 'Circle' command input
        /// is stored correctly as 'radius' within the instanced class.
        /// </summary>
        /// <param name="userInput">A correct 'Circle' command input</param>
        /// <param name="expected">The expected radius to be stored</param>
        [DataTestMethod]
        [DataRow("circle 50", 50)]
        [DataRow("circle 100", 100)]
        [DataRow("circle 200", 200)]
        public void Circle_StoresCorrectParameters_WhenParsingUserInput(string userInput, int expected)
        {
            // Arrange
            /*Bitmap bitmap = new Bitmap(100, 100);
            Canvas canvas = new Canvas(bitmap);
            List<string> parameters = new List<string>();*/
            parameters = Parser.ParseParameters(userInput);

            // Act
            Circle circle = new Circle(canvas, parameters);

            // Assert
            Assert.AreEqual(expected, circle.Radius);
        }

        /// <summary>
        /// Asserts that an error string is added to the 'Error' list
        /// collection when the user input has an invalid number of parameters.
        /// </summary>
        /// <param name="userInput">An incorrect 'Circle' command input</param>
        [DataTestMethod]
        [DataRow("")]
        [DataRow("circle 50,50")]
        [DataRow("circle 100,100")]
        [DataRow("circle 200,200")]
        public void Circle_AddsToErrorsListCollection_WhenInvalidNumberOfParameters(string userInput)
        {
            // Arrange
            /*Bitmap bitmap = new Bitmap(100, 100);
            Canvas canvas = new Canvas(bitmap);
            List<string> parameters = new List<string>();*/
            parameters = Parser.ParseParameters(userInput);

            // Act
            Circle circle = new Circle(canvas, parameters);

            // Assert
            Assert.IsTrue(circle.Errors.Count != 0);
        }

        /// <summary>
        /// Asserts that an error string is added to the 'Error' list
        /// collection when the user input has invalid parameter types.
        /// </summary>
        /// <param name="userInput">An incorrect 'Circle' command input</param>
        [DataTestMethod]
        [DataRow("circle y")]
        [DataRow("circle big")]
        [DataRow("circle fifteen")]
        [DataRow("circle 15m")]
        public void Circle_AddsToErrorsListCollection_WhenInvalidTypeOfParameters(string userInput)
        {
            // Arrange
            /*Bitmap bitmap = new Bitmap(100, 100);
            Canvas canvas = new Canvas(bitmap);
            List<string> parameters = new List<string>();*/
            parameters = Parser.ParseParameters(userInput);

            // Act
            Circle circle = new Circle(canvas, parameters);

            // Assert
            Assert.IsTrue(circle.Errors.Count != 0);
        }
    }
}
