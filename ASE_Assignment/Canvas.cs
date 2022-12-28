using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    /// <summary>
    /// A class that stores details of the current canvas drawing area.
    /// </summary>
    public class Canvas
    {
        /// <summary>
        /// A bitmap to be drawn on.
        /// </summary>
        private Bitmap bitmap;

        /// <summary>
        /// The x-coordinate of the drawing tool.
        /// </summary>
        private int pointX = 0;

        /// <summary>
        /// The y-coordinate of the drawing tool.
        /// </summary>
        private int pointY = 0;

        /// <summary>
        /// The colour of the drawing tool.
        /// </summary>
        Color toolColour = Color.Black;

        /// <summary>
        /// A value indicating whether the shape being drawn by the drawing tool
        /// is filled.
        /// </summary>
        private bool hasShapeFilled = false;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="bitmap">The bitmap that is to be drawn on.</param>
        public Canvas(Bitmap bitmap)
        {
            this.bitmap = bitmap;
        }

        /// <summary>
        /// Gets the bitmap of the canvas.
        /// </summary>
        public Bitmap Bitmap { get { return bitmap; } }

        /// <summary>
        /// Gets or sets the x-coordinate of the drawing tool.
        /// </summary>
        public int PointX
        {
            get { return pointX; }
            set { pointX = value; }
        }

        /// <summary>
        /// Gets or sets the y-coordinate of the drawing tool.
        /// </summary>
        public int PointY
        {
            get { return pointY; }
            set { pointY = value; }
        }

        /// <summary>
        /// Gets or sets the colour of the drawing tool.
        /// </summary>
        public Color ToolColour
        {
            get { return toolColour; }
            set { toolColour = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether drawn shapes are filled.
        /// </summary>
        public bool HasShapeFilled
        {
            get { return hasShapeFilled; }
            set { hasShapeFilled = value; }
        }
    }
}
