using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    public class Canvas
    {
        private Bitmap bitmap;
        private int penPointX = 0;
        private int penPointY = 0;
        Color penColour = Color.Black;
        private Boolean shapeFill = false;

        public Canvas(Bitmap bitmap)
        {
            this.bitmap = bitmap;
        }

        public Bitmap Bitmap { get { return bitmap; } }

        public int PenPointX
        {
            get { return penPointX; }
            set { penPointX = value; }
        }

        public int PenPointY
        {
            get { return penPointY; }
            set { penPointY = value; }
        }

        public Color PenColour
        {
            get { return penColour; }
            set { penColour = value; }
        }

        public Boolean ShapeFill
        {
            get { return shapeFill; }
            set { shapeFill = value; }
        }
    }
}
