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
        public int topX;
        public int topY;
        public PictureBox pentagonBox;
        private int XVelocity;
        private int YVelocity;
        public Point[] points;   
        public Polygon(int x, int y)
        {
            this.topX = x;
            this.topY = y;
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
            color = Color.FromArgb(255, random.Next(255), random.Next(255), random.Next(255));
            SolidBrush brush = new SolidBrush(color);
            e.Graphics.FillPolygon(brush, points);
            pentagonBox = new PictureBox();

        }

        public override void Move(Form form)
        {
            XVelocity = random.Next(-30, 30); // Adjust the range as needed
            YVelocity = random.Next(-30, 30);

            this.topX += XVelocity;
            this.topY += YVelocity;

        }

    }
}
