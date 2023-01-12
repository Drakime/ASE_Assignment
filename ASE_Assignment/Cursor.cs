using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    /// <summary>
    /// A class that displays and updates a cursor on a canvas.
    /// </summary>
    public sealed class Cursor
    {
        /// <summary>
        /// The colour of the cursor.
        /// </summary>
        private Pen pen = new Pen(Color.Red);

        /// <summary>
        /// Constructor.
        /// </summary>
        private Cursor()
        {
        }

        public static Cursor Instance { get { return Nested.instance; } }

        private class Nested
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested()
            {
            }

            internal static readonly Cursor instance = new Cursor();
        }

        /// <summary>
        /// Updates the cursor based on the most recent drawing command.
        /// </summary>
        /// <param name="cursorCanvas">The canvas that the cursor is drawn on.</param>
        /// <param name="drawingCanvas">The canvas that the user draws on.</param>
        public void UpdateCursor(Canvas cursorCanvas, Canvas drawingCanvas)
        {
            // Update cursor drawing here
            Graphics g = Graphics.FromImage(cursorCanvas.Bitmap);

            g.Clear(Color.Transparent);

            g.DrawEllipse(pen, drawingCanvas.PointX, drawingCanvas.PointY, 5, 5);

            g.Dispose();
        }
    }
}
