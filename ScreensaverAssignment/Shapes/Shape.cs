using ScreensaverAssignment.Shapes.ChildShapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreensaverAssignment.Shapes
{

    public abstract class Shape
    {
        internal object IntersectWith;

        public int topX { get; set; }
        public int topY { get; set; }

        //public int XVelocity { get; set; }
        //public int YVelocity { get; set; }
        public Shape(int x, int y)
        {
            topX = x;
            topY = y;
        }

        public abstract void Draw(PaintEventArgs e, Form form);
        public abstract void Move(Form form);

        public abstract void CheckWalls(Form form);

        public abstract void FlipX();


        public abstract void FlipY();

    }
}
