using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;

namespace ScreensaverAssignment.Shapes.ChildShapes
{
    public class PictureBoxShape : Shape
    {
        public int width = 74;
        public int height = 64;
        public int topX { get; set; }
        public int topY { get; set; }
        private Random random = new Random();
        private Color color;
        private int XVelocity;
        private int YVelocity;
        private Image newImage = Image.FromFile("..\\..\\greenApple.jpg");
        public PictureBox PictureBox { get; private set; }
        Image wallImage = Image.FromFile("..\\..\\apple.jpg");

        public PictureBoxShape(int x, int y) : base(x, y)
        {
            topX = x;
            topY = y;
            PictureBox = new PictureBox();
            PictureBox.Size = new Size(50, 50);
            PictureBox.Image =newImage;
            PictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            XVelocity = random.Next(-30, 30); 
            YVelocity = random.Next(-30, 30);
        }

        public override void Draw(PaintEventArgs e, Form form)
        {
            if (form.InvokeRequired)
            {
                form.Invoke(new MethodInvoker(() => form.Controls.Add(PictureBox)));
            }
            else
            {
                form.Controls.Add(PictureBox);
            }

            CheckWalls(form);
        }

        public override void Move(Form form)
        {
            topX += XVelocity;
            topY += YVelocity;
            if (PictureBox.InvokeRequired)
            {
                PictureBox.Invoke(new MethodInvoker(() => PictureBox.Location = new Point(topX, topY)));
            }
            else
            {
                PictureBox.Location = new Point(topX, topY);
            }

        }

        public override void CheckWalls(Form form)
        {

            if (topX <= form.ClientRectangle.Left || (topX + width) >= form.ClientRectangle.Right)
            {
                
                FlipX();
                Move(form);
                ChangeImage(wallImage);
            }

            if (topY <= form.ClientRectangle.Top || (topY + height) >= form.ClientRectangle.Bottom)
            {
                FlipY();
                Move(form);
                ChangeImage(newImage);
                if (form.InvokeRequired)
                {
                    form.Invoke(new MethodInvoker(() => PictureBox.Size = new Size(50, 50)));
                }
                else
                {
                    PictureBox.Size = new Size(50, 50);
                }


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

        private void ChangeImage(Image image)
        {

            if (PictureBox.InvokeRequired)
            {
                PictureBox.Invoke(new MethodInvoker(() =>

              {
                  PictureBox.Image = image;
                  PictureBox.BackColor = Color.Pink;
                  PictureBox.Size = new Size(40, 40);
              }));
            }
            else
            {
                PictureBox.Size = new Size(40, 40);
                PictureBox.BackColor = Color.Pink;
                PictureBox.Image = image;
            }


        }

    }
}
