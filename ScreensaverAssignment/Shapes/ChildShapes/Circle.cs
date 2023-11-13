using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace ScreensaverAssignment.Shapes.ChildShapes
{
    public class Circle : Shape
    {

        public int radius;
        public Rectangle circleBox;
        public int topX { get; set; }
        public int topY { get; set; }
        public int size;
        private int XVelocity;
        private int YVelocity;
        private Color color;
        private Random random = new Random();
        private bool bouncing = false;

        public int Size { get { return size; } }

        public Circle(int x, int y) :base(x, y)
        {
            this.topX = x;
            this.topY = y;
            radius = 100;
            circleBox = new Rectangle(topX, topY, radius, radius);
            size = circleBox.Width;
            XVelocity = random.Next(-100,100);
            YVelocity = random.Next(-100, 100);


        }
        public override void Draw(PaintEventArgs e, Form form)
        {
            //color = Color.FromArgb(random.Next(152), random.Next(255), random.Next(255), random.Next(255));
            if (bouncing)
            {
                color = Color.Blue;
            }
            else
            {
                color = Color.Red;
            }
            SolidBrush brush = new SolidBrush(color);
            e.Graphics.FillEllipse(brush, circleBox);

            CheckWalls(form);

        }

        public override void Move(Form form)
        {
            this.circleBox.X += XVelocity;
            this.circleBox.Y += YVelocity;

        }

        private void ChangeBallColor()
        {
            // Change the ball color to a new color
            Random random = new Random();
            color = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
        }
        public override void CheckWalls(Form form)
        {
            if (circleBox.Left <= form.ClientRectangle.Left || circleBox.Right >= form.ClientRectangle.Right)
            {
                FlipX();
                Move(form);
                bouncing = !bouncing;
            }

            if (circleBox.Top <= form.ClientRectangle.Top || circleBox.Bottom >= form.ClientRectangle.Bottom)
            {
                FlipY();
                Move(form);
                bouncing = !bouncing;
            }
        }

        public override void FlipX()
        {
            XVelocity *= -1;
        }

        public override void FlipY()
        {
            YVelocity *= -1;
        }
        public int GetTopX()
        {
            return topX;
        }

        public int GetTopY()
        {
            return topY;
        }



    }
}
