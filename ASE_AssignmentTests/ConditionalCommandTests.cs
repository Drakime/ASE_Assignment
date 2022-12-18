using ASE_Assignment;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ASE_AssignmentTests
{
    /// <summary>
    /// A test class for testing the 'Run' class.
    /// </summary>
    [TestClass]
    public class ConditionalCommandTests
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
        /// Asserts that a conditional command correctly parses the condition
        /// as true and returns the corresponding boolean value.
        /// </summary>
        [TestMethod]
        public void ConditionalCommand_ParsesConditionCorrectlyAsTrue_InConditionalCommand()
        {
            // Arrange and Act
            string condition = "x == 100";
            ConditionalCommand command = new ConditionalCommand(canvas, condition);
            Dictionary<string, int> variables = new Dictionary<string, int>();
            variables.Add("x", 100);
            command.Variables = variables;

            // Assert
            Assert.IsTrue(command.ParseCondition());
        }

        /// <summary>
        /// Asserts that a conditional command correctly parses the condition
        /// as false and returns the corresponding boolean value.
        /// </summary>
        [TestMethod]
        public void ConditionalCommand_ParsesConditionCorrectlyAsFalse_InConditionalCommand()
        {
            // Arrange and Act
            string condition = "x == 100";
            ConditionalCommand command = new ConditionalCommand(canvas, condition);
            Dictionary<string, int> variables = new Dictionary<string, int>();
            variables.Add("x", 200);
            command.Variables = variables;

            // Assert
            Assert.IsFalse(command.ParseCondition());
        }
    }
}
