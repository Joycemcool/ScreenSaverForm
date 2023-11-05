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
        public abstract void Draw(PaintEventArgs e, Form form);
        public abstract void Move(Form form);
    }
}
