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
        //public int topX { get; set; }
        //public int topY{ get; set; }
        private int XVelocity;
        private int YVelocity;
        private Random random = new Random();
        private Image newImage;
        private PictureBox pictureBox;

        public ImageShape(int x, int y) : base(x, y)
        {
            this.topX = x;
            this.topY = y;
            pictureBox = new PictureBox();
            int ran = random.Next(0, 4);
            newImage = Image.FromFile("..\\..\\dancingGirl.gif");
            pictureBox.Image = newImage;
            pictureBox.Size = newImage.Size;
            pictureBox.Location = new Point(x, y);
            XVelocity = random.Next(-100, 100);
            YVelocity = random.Next(-100, 100);

        }

        public override void Draw(PaintEventArgs e, Form form)
        {          
            PointF ulCorner = new PointF(topX, topY); //upper-left corner of image.
            e.Graphics.DrawImage(newImage, ulCorner);

        }
        public override void Move(Form form)
        {
            this.topX += XVelocity;
            this.topY += YVelocity;
        }

        public override void CheckWalls(Form form)
        {
            // Check for collisions with the form boundaries
            if (this.topX <= form.ClientRectangle.Left || this.topX >= form.ClientRectangle.Right)
            {
                FlipX();
                Move(form);
            }

            if (this.topY <= form.ClientRectangle.Top || this.topY >= form.ClientRectangle.Bottom)
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

