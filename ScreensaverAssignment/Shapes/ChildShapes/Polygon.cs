using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreensaverAssignment.Shapes.ChildShapes
{
    public class Polygon : Shape
    {

        private Random random = new Random();
        private int radius = 50; 
        private int sides = 5;
        private Color color;
        //public int topX { get; set; }
        //public int topY { get; set; }
        public PictureBox pentagonBox;
        private int XVelocity;
        private int YVelocity;
        public Point[] points;   
        public Polygon(int x, int y):base(x, y)
        {
            this.topX = x;
            this.topY = y;
            XVelocity = random.Next(-30, 30);
            YVelocity = random.Next(-30, 30);
        }

        public override void Draw(PaintEventArgs e, Form form)
        {
            points = new Point[sides];

            for (int i = 0; i < sides; i++)
            {
                double angle = 2 * Math.PI * i / sides;
                int x1 = topX + (int)(radius * Math.Cos(angle));
                int y1 = topY + (int)(radius * Math.Sin(angle));
                points[i] = new Point(x1, y1);
            }
            //color = Color.FromArgb(random.Next(152), random.Next(255), random.Next(255), random.Next(255));
            color = Color.Gray;
            SolidBrush brush = new SolidBrush(color);
            e.Graphics.FillPolygon(brush, points);
            CheckWalls(form);

        }

        public override void Move(Form form)
        {
            this.topX += XVelocity;
            this.topY += YVelocity;

        }

        public override void CheckWalls(Form form)
        {
            
            if (topX <= form.ClientRectangle.Left){
                FlipX();
                Move(form);
            }
            else if (topX + radius/2 >= form.ClientRectangle.Right)
            {
                FlipX();
                Move(form);
            }
            if (topY <= form.ClientRectangle.Top)
            {
                FlipY();
                Move(form);
            }
            else if(topY + radius/2>= form.ClientRectangle.Bottom)
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
