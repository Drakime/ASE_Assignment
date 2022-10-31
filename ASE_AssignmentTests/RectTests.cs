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
    public class RectTests
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
        /// Asserts that the arguments of a correct 'Rect' command input
        /// are stored correctly as as 'width' and 'height' within the instanced class.
        /// </summary>
        /// <param name="userInput">A correct 'Rect' command input</param>
        /// <param name="expectedWidth">The expected width to be stored</param>
        /// <param name="expectedHeight">The expected height to be stored</param>
        [DataTestMethod]
        [DataRow("rect 45,45", 45, 45)]
        [DataRow("rect 150,72", 150, 72)]
        [DataRow("rect 74,209", 74, 209)]
        public void Rectangle_StoresCorrectParameters_WhenParsingUserInput(string userInput, int expectedWidth, int expectedHeight)
        {
            // Arrange
            /*Bitmap bitmap = new Bitmap(100, 100);
            Canvas canvas = new Canvas(bitmap);*/
            parameters = Parser.ParseParameters(userInput);

            // Act
            Rect rectangle = new Rect(canvas, parameters);

            // Assert
            Assert.AreEqual(expectedWidth, rectangle.Width);
            Assert.AreEqual(expectedHeight, rectangle.Height);
        }

        /// <summary>
        /// Asserts that an error string is added to the 'Error' list
        /// collection when the user input has an invalid number of parameters.
        /// </summary>
        /// <param name="userInput">An incorrect 'Rectangle' command input</param>
        [DataTestMethod]
        [DataRow("rectangle")]
        [DataRow("rectangle 50")]
        [DataRow("rectangle 100,100,200")]
        [DataRow("rectangle 200,200,400")]
        public void Rect_AddsToErrorsListCollection_WhenInvalidNumberOfParameters(string userInput)
        {
            // Arrange
            /*Bitmap bitmap = new Bitmap(100, 100);
            Canvas canvas = new Canvas(bitmap);*/
            parameters = Parser.ParseParameters(userInput);

            // Act
            Rect rectangle = new Rect(canvas, parameters);

            // Assert
            Assert.IsTrue(rectangle.Errors.Count != 0);
        }

        /// <summary>
        /// Asserts that an error string is added to the 'Error' list
        /// collection when the user input has invalid parameter types.
        /// </summary>
        /// <param name="userInput">An incorrect 'Rectangle' command input</param>
        [DataTestMethod]
        [DataRow("rectangle hey,nice")]
        [DataRow("rectangle 50,fifty")]
        [DataRow("rectangle 100,/")]
        [DataRow("rectangle plot,10")]
        public void Rect_AddsToErrorsListCollection_WhenInvalidTypeOfParameters(string userInput)
        {
            // Arrange
            /*Bitmap bitmap = new Bitmap(100, 100);
            Canvas canvas = new Canvas(bitmap);*/
            parameters = Parser.ParseParameters(userInput);

            // Act
            Rect rectangle = new Rect(canvas, parameters);

            // Assert
            Assert.IsTrue(rectangle.Errors.Count != 0);
        }
    }
}
