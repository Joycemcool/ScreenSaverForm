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
        public int X;
        public int Y;
        public int size;
        private int XVelocity;
        private int YVelocity;
        private Color color;
        private Random random = new Random();
        public int CurrentX { get { return circleBox.X; } }
        public int CurrentY { get { return circleBox.Y; } }
        public int Size { get { return size; } }

        public Circle(int x, int y)
        {
            this.X = x;
            this.Y = y;


            // Initialize the velocities randomly within a range
            radius = random.Next(15, 80);
            circleBox = new Rectangle(X, Y, radius, radius);
            size = circleBox.Width;

            color = Color.FromArgb(255, random.Next(255), random.Next(255), random.Next(255));

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
            XVelocity = random.Next(-30, 30); 
            YVelocity = random.Next(-30,30);
            this.circleBox.X += XVelocity;
            this.circleBox.Y += YVelocity;

        }

        public override void CheckWalls(Form form)
        {
            // Check for collisions with the form boundaries
            if (circleBox.Left <= form.ClientRectangle.Left || circleBox.Right >= form.ClientRectangle.Right)
            {
                XVelocity = -XVelocity; // Reverse horizontal velocity on collision with left or right wall
            }

            if (circleBox.Top <= form.ClientRectangle.Top || circleBox.Bottom > form.ClientRectangle.Bottom)
            {
                YVelocity = -YVelocity; 
                // Reverse vertical velocity on collision with top or bottom wall
            }
        }

    }
}
