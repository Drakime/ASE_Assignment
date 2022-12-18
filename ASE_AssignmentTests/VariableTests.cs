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
    /// A test class for testing the 'Variable' class.
    /// </summary>
    [TestClass]
    public class VariableTests
    {
        List<string> parameters;


        [TestInitialize]
        public void SetUp()
        {
            parameters= new List<string>();
        }

        /// <summary>
        /// Asserts that a created variable returns the correct
        /// value when the property of the variable object is invoked.
        /// </summary>
        [TestMethod]
        public void Variable_StoresCorrectValue_WhenParsingUserInput()
        {
            // Arrange
            string userInput = "var x = 5";
            parameters = Parser.ParseParameters(userInput);
            int expected = 5;

            // Act
            Variable v = new Variable(parameters);

            // Assert
            Assert.AreEqual(expected, v.Value);
        }

        /// <summary>
        /// Asserts that an error string is added to the 'Error' list
        /// collection when the user input has invalid parameter types.
        /// </summary>
        [TestMethod]
        public void Variable_AddsToErrorsListCollection_WhenInvalidTypeOfParameters()
        {
            // Arrange
            string userInput = "var x = string";
            parameters = Parser.ParseParameters(userInput);

            // Act
            Variable v = new Variable(parameters);

            // Assert
            Assert.IsTrue(v.Errors.Count != 0);
        }

        /// <summary>
        /// Asserts that an error string is added to the 'Error' list
        /// collection when the user input has no parameters.
        /// </summary>
        [TestMethod]
        public void Variable_AddsToErrorsListCollection_WhenEmptyUserInput()
        {
            // Arrange
            string userInput = "var";
            parameters = Parser.ParseParameters(userInput);

            // Act
            Variable v = new Variable(parameters);

            // Assert
            Assert.IsTrue(v.Errors.Count != 0);
        }
    }
}
