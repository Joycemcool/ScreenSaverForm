using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreensaverAssignment.Shapes
{
    public class Triangle : Shape
    {
        //MAKE RETANGLE 
        //public int topX { get; set; }
        //public int topY { get; set; }
        public int leftX;
        public int leftY;
        public int rightX;
        public int rightY;
        public int sizeVal=50;

        private Random random = new Random();
        private Color color;

        private int XVelocity;
        private int YVelocity;
        public Triangle triangle;

        public Triangle(int x, int y) : base(x, y)
        {
            //ranVar = random.Next(-100, 100);
            topX = x;
            topY = y;
            leftX = x - sizeVal;
            leftY = y + sizeVal;
            rightX = x + sizeVal;
            rightY = y + sizeVal;
            //CHANGE THE SIZE OF TRIANGLE
            XVelocity = random.Next(-100, 100); // Adjust the range as needed
            YVelocity = random.Next(-100, 100);
            //Triangle width 100 height 50
        }

        public override void Draw(PaintEventArgs e, Form form)
        {
            color = Color.FromArgb(random.Next(152), random.Next(255), random.Next(255), random.Next(255));
            SolidBrush brush = new SolidBrush(color);
            e.Graphics.FillPolygon(brush, new Point[] {

                new Point(topX, topY),
                new Point(leftX, leftY),
                new Point(rightX, rightY)

        });

        }

        //TODO: IMPLEMENT MOVE FUNCTION FOR TRIANGLE AND RETANGLE
        public override void Move(Form form)
        {
  // Update the triangle's points based on the velocity
            topX += XVelocity;
            topY += YVelocity;
            leftX += XVelocity;
            leftY += YVelocity;
            rightX += XVelocity;
            rightY += YVelocity;


            // Call Invalidate to trigger a repaint of the form
            form.Invalidate();
        }

        public override void CheckWalls(Form form)
        {
            // Check for collisions with the form boundaries
            if (leftX <= form.ClientRectangle.Left)
            { 
                FlipX();
                Move(form);

            }
            else if(rightX >= form.ClientRectangle.Right)
            {

                FlipX();
                Move(form);

            }
            if (topY <= form.ClientRectangle.Top)
            {

                FlipY();
                Move(form);

            }
            else if (rightY >= form.ClientRectangle.Bottom)
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



    }//end class
}

