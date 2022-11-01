using ASE_Assignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_AssignmentTests
{
    /// <summary>
    /// A test class for testing the 'Colour' class.
    /// </summary>
    [TestClass]
    public class ColourTests
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
        /// Asserts that the argument of a correct 'Colour' command input
        /// stores the correct 'toolColour' within the instanced class.
        /// 
        /// Also checks that this 'toolColour' is passed to the same attribute
        /// in the referenced canvas.
        /// </summary>
        /// <param name="userInput">A correct 'Pen' command input</param>
        /// <param name="colorKey"></param>
        [DataTestMethod]
        [DataRow("pen orange", 0)]
        [DataRow("pen red", 1)]
        [DataRow("pen green", 2)]
        [DataRow("pen blue", 3)]
        public void Pen_StoresCorrectParameters_WhenParsingUserInput(string userInput, int colorKey)
        {
            // Arrange
            parameters = Parser.ParseParameters(userInput);

            Color[] colourArray = { Color.Orange, Color.Red, Color.Green, Color.RoyalBlue };    // Add possible colours to array

            // Act
            Colour toolColour = new Colour(canvas, parameters);
            toolColour.Operation();

            // Assert
            Assert.AreEqual(colourArray[colorKey], toolColour.ToolColour);
            Assert.AreEqual(toolColour.ToolColour, canvas.ToolColour);
        }

        /// <summary>
        /// Asserts that an error string is added to the 'Error' list
        /// collection when the user input has an invalid number of parameters.
        /// </summary>
        /// <param name="userInput">An incorrect 'Pen' command input</param>
        [DataTestMethod]
        [DataRow("pen purple")]
        [DataRow("pen off")]
        [DataRow("pen 15")]
        public void Pen_AddsToErrorsListCollection_WhenInvalidTypeOfParameters(string userInput)
        {
            // Arrange
            parameters = Parser.ParseParameters(userInput);

            // Act
            Colour toolColour = new Colour(canvas, parameters);

            // Assert
            Assert.IsTrue(toolColour.Errors.Count != 0);
        }

        /// <summary>
        /// Asserts that an error string is added to the 'Error' list
        /// collection when the user input has invalid parameter types.
        /// </summary>
        /// <param name="userInput">An incorrect 'Pen' command input</param>
        [DataTestMethod]
        [DataRow("pen purple yes")]
        [DataRow("pen off nice hello")]
        [DataRow("pen 15 32 5 33")]
        public void Pen_AddsToErrorsListCollection_WhenInvalidNumberOfParameters(string userInput)
        {
            // Arrange
            parameters = Parser.ParseParameters(userInput);

            // Act
            Colour toolColour = new Colour(canvas, parameters);

            // Assert
            Assert.IsTrue(toolColour.Errors.Count != 0);
        }
    }
}
