using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreensaverAssignment.Shapes.ChildShapes
{
    public class Circle : Shape
    {

        public int radius = 40;
        public Rectangle circleBox;
        public int X;
        public int Y;
        private int XVelocity;
        private int YVelocity;
        private Color color;
        private Random random = new Random(); // Initialize a random number generator

        public Circle(int x, int y)
        {
            this.X = x;
            this.Y = y;
            // Initialize the velocities randomly within a range

            circleBox = new Rectangle(X, Y, 2 * radius, 2 * radius);
        }
        public override void Draw(PaintEventArgs e, Form form)
        {
            // Calculate the bounding rectangle for the circle


            // Draw the circle using the Graphics object from PaintEventArgs
            //set the ball's color random
            color = Color.FromArgb(255, random.Next(255), random.Next(255), random.Next(255));
            SolidBrush brush = new SolidBrush(color);
            e.Graphics.FillEllipse(brush, circleBox);

        }

        public override void Move(Form form)
        {
            XVelocity = random.Next(-30, 30); // Adjust the range as needed
            YVelocity = random.Next(-30,30);
            this.circleBox.X += XVelocity;
            this.circleBox.Y += YVelocity;
            // Check for collisions with the form boundaries
            if (circleBox.Left < 0 || circleBox.Right > form.ClientRectangle.Right)
            {
                XVelocity = -XVelocity; // Reverse horizontal velocity on collision with left or right wall
            }

            if (circleBox.Top < 0 || circleBox.Bottom > form.ClientRectangle.Bottom)
            {
                YVelocity = -YVelocity; // Reverse vertical velocity on collision with top or bottom wall
            }


        }

    }
}
