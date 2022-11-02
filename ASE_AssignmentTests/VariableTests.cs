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
        /// <summary>
        /// Asserts that a created variable returns the correct
        /// value when the property of the variable object is invoked.
        /// </summary>
        [TestMethod]
        public void Variable_StoresCorrectValue_WhenParsingUserInput()
        {
            // Arrange
            Bitmap bitmap = new Bitmap(100, 100);
            Canvas canvas = new Canvas(bitmap);
            string userInput = "variable x = 5";

            int variable = 0;
            variable = Parser.ParseVariable(userInput);

            int expected = 5;

            // Act
            Variable v = new Variable(variable);

            // Assert
            Assert.AreEqual(expected, v.Value);
        }

        /// <summary>
        /// Asserts that a FormatException is thrown when the
        /// variable being created has an invalid value.
        /// </summary>
        [TestMethod]
        public void Variable_ThrowsException_WhenInvalidUserInput()
        {
            // Arrange
            Bitmap bitmap = new Bitmap(100, 100);
            Canvas canvas = new Canvas(bitmap);
            string userInput = "variable x = string";

            int variable = 0;
            variable = Parser.ParseVariable(userInput);

            // Act
            Variable v = new Variable(variable);

            // Assert
            Assert.ThrowsException<FormatException>( () => v.VerifyParameters() );
        }

        /// <summary>
        /// Asserts that a FormatException is thrown when the
        /// variable being created has an invalid value.
        /// </summary>
        [TestMethod]
        public void Variable_ThrowsException_WhenEmptyUserInput()
        {
            // Arrange
            Bitmap bitmap = new Bitmap(100, 100);
            Canvas canvas = new Canvas(bitmap);
            string userInput = "";

            int variable = 0;
            variable = Parser.ParseVariable(userInput);

            // Act
            Variable v = new Variable(variable);

            // Assert
            Assert.ThrowsException<FormatException>(() => v.VerifyParameters());
        }
    }
}
