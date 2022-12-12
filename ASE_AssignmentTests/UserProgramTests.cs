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
    /// A test class for testing the 'Run' class.
    /// </summary>
    [TestClass]
    public class UserProgramTests
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
        /// Asserts that the correct command objects are stored in an arraylist when
        /// setting the program lines.
        /// </summary>
        [TestMethod]
        public void UserProgam_ReturnsCorrectFactoryObjects_WhenSettingProgramLines()
        {
            // Arrange
            string userInput = "circle 10\r\nrect 100,150\r\nmoveto 45,90\r\npen blue\r\ntriangle 45,30 90,165 85,59";
            UserProgram program = new UserProgram(canvas);

            // Act
            program.SetProgramLines(userInput);

            // Assert
            Assert.IsTrue(program.ProgramLines[0].GetType() == typeof(Circle));
            Assert.IsTrue(program.ProgramLines[1].GetType() == typeof(Rect));
            Assert.IsTrue(program.ProgramLines[2].GetType() == typeof(MoveTo));
            Assert.IsTrue(program.ProgramLines[3].GetType() == typeof(Colour));
            Assert.IsTrue(program.ProgramLines[4].GetType() == typeof(Triangle));
        }
    }
}
