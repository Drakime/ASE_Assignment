using System.Drawing;
using ASE_Assignment;

namespace ASE_AssignmentTests
{
    /// <summary>
    /// A test class for testing the 'Canvas' class.
    /// </summary>
    [TestClass]
    public class CanvasTests
    {   
        /// <summary>
        /// Instatiates new canvas object and checks that default attributes
        /// are correct.
        /// </summary>
        [TestMethod]
        public void Canvas_ReturnDefaultValues_UsingProperties()
        {
            // Arrange and Act
            Bitmap bitmap = new Bitmap(100, 100);
            Canvas canvas = new Canvas(bitmap);

            // Assert
            Assert.AreEqual(100, canvas.Bitmap.Width);
            Assert.AreEqual(100, canvas.Bitmap.Height);
            Assert.AreEqual(0, canvas.PointX);
            Assert.AreEqual(0, canvas.PointY);
            Assert.AreEqual(Color.Black, canvas.ToolColour);
            Assert.IsFalse(canvas.HasShapeFilled);
        }
    }
}