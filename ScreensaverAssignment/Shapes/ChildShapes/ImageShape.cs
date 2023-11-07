using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreensaverAssignment.Shapes.ChildShapes
{
    public class ImageShape : Shape
    {

        char travel;

        public int X;
        public int Y;
        private int XVelocity;
        private int YVelocity;
        private Random random = new Random();
        private Image newImage;
        private PictureBox pictureBox;


        public ImageShape(int x, int y)
        {
            this.X = x;
            this.Y = y;
            pictureBox = new PictureBox();
            int ran = random.Next(0, 4);
            newImage = Image.FromFile("..\\..\\dancingGirl.gif");
            pictureBox.Image = newImage;
            pictureBox.Size = newImage.Size;
            pictureBox.Location = new Point(x, y);

        }

        public override void Draw(PaintEventArgs e, Form form)

        {          
            Console.WriteLine("Draw Image");
            PointF ulCorner = new PointF(X, Y); //upper-left corner of image.
            e.Graphics.DrawImage(newImage, ulCorner);

        }
        public override void Move(Form form)
        {
            XVelocity = random.Next(-30, 30);
            YVelocity = random.Next(-30, 30);

            // Get the current location of the PictureBox
            Point currentLocation = pictureBox.Location;

            // Calculate the new location based on the velocity
            this.X += XVelocity;
            this.Y += YVelocity;

            // Check for collisions with the form boundaries
            if (X < 0 || X + pictureBox.Width > form.ClientRectangle.Right)
            {
                XVelocity = -XVelocity; // Reverse horizontal velocity on collision with left or right wall
            }

            if (Y < 0 || Y + pictureBox.Height > form.ClientRectangle.Bottom)
            {
                YVelocity = -YVelocity; // Reverse vertical velocity on collision with top or bottom wall
            }

            // Set the new location for the PictureBox
            //pictureBox.Location = new Point(X, Y);

        }

        public override void CheckWalls(Form form)
        {

        }


        public void FlipX()
        {
            XVelocity *= -1;
        }

        public void FlipY()
        {
            YVelocity *= -1;
        }
    }
}

