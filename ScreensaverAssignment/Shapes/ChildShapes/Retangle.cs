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
        public int width = 100; 
        public int height = 100;
        public int widthChanged = 50;
        public int heightChanged = 50;
        public int topX { get; set; }
        public int topY { get; set; }
        private Random random = new Random();
        private Color color;
        private int XVelocity;
        private int YVelocity;
        public Color GradientColor1 { get; set; }
        public Color GradientColor2 { get; set; }
        private bool bouncing = false;
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

            if (bouncing)
            {
                GradientColor1 = Color.FromArgb(random.Next(152), random.Next(256), random.Next(256), random.Next(256));
                GradientColor2 = Color.FromArgb(random.Next(152), random.Next(256), random.Next(256), random.Next(256));
                Rectangle boundingRect = new Rectangle(topX, topY, width, height);
                LinearGradientBrush brush = new LinearGradientBrush(boundingRect, GradientColor1, GradientColor2, LinearGradientMode.Horizontal);
                e.Graphics.FillRectangle(brush, boundingRect);
            }
            else
            {
                Color color = new Color();
                color = Color.FromArgb(random.Next(152), random.Next(256), random.Next(256), random.Next(256));
                Rectangle boundingRect = new Rectangle(topX, topY, widthChanged, heightChanged);
                SolidBrush brush =new SolidBrush(color);
                e.Graphics.FillRectangle(brush, boundingRect);

            }

            // Calculate the bounding rectangle for the circle

            //color = Color.FromArgb(random.Next(152), random.Next(255), random.Next(255), random.Next(255));

            //// Draw the circle using the Graphics object from PaintEventArgs

            CheckWalls(form);
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
                bouncing = !bouncing;
            }

            if (topY <= form.ClientRectangle.Top || (topY + height) >= form.ClientRectangle.Bottom)
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
