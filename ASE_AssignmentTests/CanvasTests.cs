using System.Drawing;
using ASE_Assignment;

namespace ASE_AssignmentTests
{
    [TestClass]
    public class CanvasTests
    {
        [TestMethod]
        public void Canvas_ReturnDefaultValues_UsingProperties()
        {
            Bitmap bitmap = new Bitmap(100, 100);
            Canvas canvas = new Canvas(bitmap);

            Assert.AreEqual(100, canvas.Bitmap.Width);
            Assert.AreEqual(100, canvas.Bitmap.Height);
            Assert.AreEqual(0, canvas.PointX);
            Assert.AreEqual(0, canvas.PointY);
            Assert.AreEqual(Color.Black, canvas.ToolColour);
            Assert.IsFalse(canvas.HasShapeFilled);
        }
    }
}