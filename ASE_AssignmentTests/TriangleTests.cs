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
    public class TriangleTests
    {
        /// <summary>
        /// Asserts that the correct arguments are stored correctly
        /// in an instanced 'Triangle' class, following a correct input.
        /// </summary>
        /// <param name="userInput">A correct 'Triangle' command input</param>
        /// <param name="pointX1">The x-coordinate of the first point</param>
        /// <param name="pointY1">The y-coordinate of the first point</param>
        /// <param name="pointX2">The x-coordinate of the second point</param>
        /// <param name="pointY2">The y-coordinate of the second point</param>
        /// <param name="pointX3">The x-coordinate of the third point</param>
        /// <param name="pointY3">The y-coordinate of the third point</param>
        [DataTestMethod]
        [DataRow("triangle 1,2 4,5 9,2", 1, 2, 4, 5, 9, 2)]
        [DataRow("triangle 70,40 192,55 92,48", 70, 40, 192, 55, 92, 48)]
        [DataRow("triangle 7,73 97,22 64,8", 7, 73, 97, 22, 64, 8)]
        public void Triangle_StoresCorrectParameters_WhenParsingUserInput(
            string userInput,
            int pointX1, int pointY1,
            int pointX2, int pointY2,
            int pointX3, int pointY3
            )
        {
            // Expected values, as Point array
            Point pt1 = new Point(pointX1, pointY1);
            Point pt2 = new Point(pointX2, pointY2);
            Point pt3 = new Point(pointX3, pointY3);
            Point[] expectedPointsArray = {pt1, pt2, pt3};

            // Arrange
            Bitmap bitmap = new Bitmap(100, 100);
            Canvas canvas = new Canvas(bitmap);

            // Act
            Triangle triangle = new Triangle(canvas, userInput);
            Point[] actualPointsArray = triangle.Points.ToArray();

            // Assert
            Assert.AreEqual(expectedPointsArray.ToString(), actualPointsArray.ToString()); ;
        }

        /// <summary>
        /// Asserts that an error string is added to the 'Error' list
        /// collection when the user input has an invalid number of parameters.
        /// </summary>
        /// <param name="userInput">An incorrect 'Triangle' command input</param>
        [DataTestMethod]
        [DataRow("triangle")]
        [DataRow("triangle 50")]
        [DataRow("triangle 100,100,200")]
        [DataRow("triangle 200,200 400,250 300,90 208,101")]
        public void Triangle_AddsToErrorsListCollection_WhenInvalidNumberOfParameters(string userInput)
        {
            // Arrange
            Bitmap bitmap = new Bitmap(100, 100);
            Canvas canvas = new Canvas(bitmap);

            // Act
            Triangle triangle = new Triangle(canvas, userInput);

            // Assert
            Assert.IsTrue(triangle.Errors.Count != 0);
        }

        /// <summary>
        /// Asserts that an error string is added to the 'Error' list
        /// collection when the user input has invalid parameter types.
        /// </summary>
        /// <param name="userInput">An incorrect 'Rectangle' command input</param>
        [DataTestMethod]
        [DataRow("triangle hey,nice")]
        [DataRow("triangle 50,fifty")]
        [DataRow("triangle 100,/")]
        [DataRow("triangle plot,10")]
        public void Triangle_AddsToErrorsListCollection_WhenInvalidTypeOfParameters(string userInput)
        {
            // Arrange
            Bitmap bitmap = new Bitmap(100, 100);
            Canvas canvas = new Canvas(bitmap);

            // Act
            Triangle triangle = new Triangle(canvas, userInput);


            // Assert
            Assert.IsTrue(triangle.Errors.Count != 0);
        }
    }
}
