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
    /// A test class for testing the 'Fill' class.
    /// </summary>
    [TestClass]
    public class FillTests
    {
        Bitmap bitmap;
        List<string> userInputOn;
        List<string> userInputOff;
        Canvas canvas1;
        Canvas canvas2;

        /// <summary>
        /// Instantiates a bitmap, canvases, and lists to store parameters.
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            bitmap = new Bitmap(100, 100);
            userInputOn = new List<string>();
            userInputOff = new List<string>();
            canvas1 = new Canvas(bitmap);
            canvas2 = new Canvas(bitmap);
        }

        /// <summary>
        /// Asserts that the argument of a correct 'Fill' command input
        /// is stored correctly as the boolean 'shapeFill' within the 
        /// instanced class.
        /// </summary>
        [TestMethod]
        public void Fill_StoresCorrectParameters_WhenParsingUserInput()
        {
            // Arrange
            userInputOn = Parser.ParseParameters("fill on");
            userInputOff = Parser.ParseParameters("fill off");

            // Act
            Fill fillOn = new Fill(canvas1, userInputOn);   // Pass "on" argument in user input
            fillOn.Operation();
            
            Fill fillOff = new Fill(canvas2, userInputOff);     // Pass "off" argument in user input
            fillOff.Operation();

            // Assert
            Assert.AreEqual("on", fillOn.ShapeFill);
            Assert.AreEqual("off", fillOff.ShapeFill);
            // Assert that canvas attribute has also updated
            Assert.IsTrue(canvas1.HasShapeFilled);
            Assert.IsFalse(canvas2.HasShapeFilled);
        }

        /// <summary>
        /// Asserts that an error string is added to the 'Error' list
        /// collection when the user input has an invalid number of parameters.
        /// </summary>
        /// <param name="userInput">An incorrect 'Fill' command input</param>
        [DataTestMethod]
        [DataRow("fill on another")]
        [DataRow("fill on off")]
        [DataRow("fill on ten")]
        public void Fill_AddsToErrorsListCollection_WhenInvalidNumberOfParameters(string userInput)
        {
            // Arrange
            List<string> parameters = new List<string>();
            parameters = Parser.ParseParameters(userInput);

            // Act
            Fill fill = new Fill(canvas1, parameters);

            // Assert
            Assert.IsTrue(fill.Errors.Count != 0);
        }

        /// <summary>
        /// Asserts that an error string is added to the 'Error' list
        /// collection when the user input has invalid parameter types.
        /// </summary>
        /// <param name="userInput">An incorrect 'Fill' command input</param>
        [DataTestMethod]
        [DataRow("fill 1")]
        [DataRow("fill 15")]
        [DataRow("fill 25")]
        public void Fill_AddsToErrorsListCollection_WhenInvalidTypeOfParameters(string userInput)
        {
            // Arrange
            List<string> parameters = new List<string>();
            parameters = Parser.ParseParameters(userInput);

            // Act
            Fill fill = new Fill(canvas1, parameters);

            // Assert
            Assert.IsTrue(fill.Errors.Count != 0);
        }
    }
}
