using Microsoft.VisualStudio.TestTools.UnitTesting;
using ASE_Assignment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms.VisualStyles;

namespace ASE_AssignmentTests
{
    [TestClass]
    public class MoveToTests
    {
        /// <summary>
        /// Asserts that the arguments of a correct 'MoveTo' command input
        /// are stored correctly as x and y coordinates within the instanced class.
        /// </summary>
        /// <param name="userInput">A correct 'MoveTo' command input</param>
        /// <param name="expectedX">The expected x-coordinate to be stored</param>
        /// <param name="expectedY">The expected y-coordinate to be stored</param>
        [DataTestMethod]
        [DataRow("moveto 10,15", 10, 15)]
        [DataRow("moveto 67,90", 67, 90)]
        [DataRow("moveto 132,48", 132, 48)]
        public void MoveTo_StoresCorrectParameters_WhenParsingUserInput(string userInput, int expectedX, int expectedY)
        {
            // Arrange
            Bitmap bitmap = new Bitmap(100, 100);
            Canvas canvas = new Canvas(bitmap);

            // Act
            MoveTo moveto = new MoveTo(canvas, userInput);
            // Sets coordinates of canvas
            moveto.Operation();
            
            // Assert
            Assert.AreEqual(expectedX, moveto.X);
            Assert.AreEqual(expectedY, moveto.Y);
            // Should be equal if 'Operation' method was successful
            Assert.AreEqual(moveto.X, canvas.PointX);
            Assert.AreEqual(moveto.Y, canvas.PointY);
        }

        /// <summary>
        /// Asserts that an error string is added to the 'Error' list
        /// collection when the user input has an invalid number of parameters.
        /// </summary>
        /// <param name="userInput">An incorrect 'MoveTo' command input</param>
        [DataTestMethod]
        [DataRow("moveto 189,29,142")]
        [DataRow("moveto 136 42 168")]
        [DataRow("moveto 178,80 191")]
        public void MoveTo_AddsToErrorsListCollection_WhenInvalidNumberOfParameters(string userInput)
        {
            // Arrange
            Bitmap bitmap = new Bitmap(100, 100);
            Canvas canvas = new Canvas(bitmap);

            // Act
            MoveTo moveto = new MoveTo(canvas, userInput);

            // Assert
            Assert.IsTrue(moveto.Errors.Count != 0);
            Assert.IsFalse(moveto.Errors.Count == 0);
        }

        /// <summary>
        /// Asserts that an error string is added to the 'Error' list
        /// collection when the user input has invalid parameter types.
        /// </summary>
        /// <param name="userInput">An incorrect 'MoveTo' command input</param>
        [DataTestMethod]
        [DataRow("moveto 48,x")]
        [DataRow("moveto here,again")]
        [DataRow("moveto fifty,5")]
        public void MoveTo_AddsToErrorsListCollection_WhenInvalidTypeOfParameters(string userInput)
        {
            // Arrange
            Bitmap bitmap = new Bitmap(100, 100);
            Canvas canvas = new Canvas(bitmap);

            // Act
            MoveTo moveto = new MoveTo(canvas, userInput);

            // Assert
            Assert.IsTrue(moveto.Errors.Count != 0);
            Assert.IsFalse(moveto.Errors.Count == 0);
        }
    }
}