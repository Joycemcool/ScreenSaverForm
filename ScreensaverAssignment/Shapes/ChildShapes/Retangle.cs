using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreensaverAssignment.Shapes.ChildShapes
{
    public class Retangle : Shape
    {
        public int width; // Adjust the width as needed
        public int height; // Adjust the height as needed
        public int topX;
        public int topY;
        private Random random = new Random();
        private Color color;
        private int XVelocity;
        private int YVelocity;

        public Retangle(int x, int y)
        {
            // Initialize the position of the retangle
            this.topX = x;
            this.topY = y;
            width=random.Next(20,80);
            height = random.Next(20, 80);
            color = Color.FromArgb(255, random.Next(255), random.Next(255), random.Next(255));

        }
        public override void Draw(PaintEventArgs e, Form form)
        {
            SolidBrush brush = new SolidBrush(color);
            // Calculate the bounding rectangle for the circle
            Rectangle boundingRect = new Rectangle(topX, topY, width, height);

            //// Draw the circle using the Graphics object from PaintEventArgs
            e.Graphics.FillRectangle(brush, boundingRect);

        }

        public override void Move(Form form)
        {
            XVelocity = random.Next(-30, 30); // Adjust the range as needed
            YVelocity = random.Next(-30, 30);

            topX += XVelocity;
            topY += YVelocity;

            // Check for collisions with the form boundaries
            if (topX < 0 ||(topX+width) > form.ClientRectangle.Right)
            {
                XVelocity = -XVelocity; // Reverse horizontal velocity on collision with left or right wall
            }

            if (topY < 0 || (topY+height) > form.ClientRectangle.Bottom)
            {
                YVelocity = -YVelocity; // Reverse vertical velocity on collision with top or bottom wall
            }

            // Call Invalidate to trigger a repaint of the form
            form.Invalidate();
        }
    }
}
