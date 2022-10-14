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
        private Bitmap bitmap;
        private int pointX = 0;
        private int pointY = 0;
        Color toolColour = Color.Black;
        private bool hasShapeFilled = false;

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
