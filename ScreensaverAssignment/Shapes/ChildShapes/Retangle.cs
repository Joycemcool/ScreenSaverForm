using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreensaverAssignment.Shapes.ChildShapes
{
    public class Retangle : Shape
    {
        public int width = 74; 
        public int height = 64; 
        public int topX { get; set; }
        public int topY { get; set; }
        private Random random = new Random();
        private Color color;
        private int XVelocity;
        private int YVelocity;
        public Color GradientColor1 { get; set; }
        public Color GradientColor2 { get; set; }

        public Retangle(int x, int y): base (x, y)
        {
            // Initialize the position of the retangle
            this.topX = x;
            this.topY = y;
            XVelocity = random.Next(-30, 30); 
            YVelocity = random.Next(-30, 30);
        }
        public override void Draw(PaintEventArgs e, Form form)
        {
            // SolidBrush brush = new SolidBrush(color);
            GradientColor1 = Color.FromArgb(random.Next(152), random.Next(256), random.Next(256), random.Next(256));
            GradientColor2 = Color.FromArgb(random.Next(152), random.Next(256), random.Next(256), random.Next(256));

            // Calculate the bounding rectangle for the circle
            Rectangle boundingRect = new Rectangle(topX, topY, width, height);
            LinearGradientBrush brush = new LinearGradientBrush(boundingRect, GradientColor1, GradientColor2, LinearGradientMode.Horizontal);
            //color = Color.FromArgb(random.Next(152), random.Next(255), random.Next(255), random.Next(255));

            //// Draw the circle using the Graphics object from PaintEventArgs
            e.Graphics.FillRectangle(brush, boundingRect);

        }

        public override void Move(Form form)
        {
            topX += XVelocity;
            topY += YVelocity;

        }

        public override void CheckWalls(Form form)
        {
            // Check for collisions with the form boundaries
            if (topX <= form.ClientRectangle.Left || (topX + width) >= form.ClientRectangle.Right)
            {
                FlipX();
                Move(form);
            }

            if (topY <= form.ClientRectangle.Top || (topY + height) >= form.ClientRectangle.Bottom)
            {
                FlipY();
                Move(form);

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
