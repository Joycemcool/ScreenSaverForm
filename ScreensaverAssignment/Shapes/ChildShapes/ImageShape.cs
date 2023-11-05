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
        int x = 0;
        int y = 0;
        char travel;


        public ImageShape(int x, int y)
        {
            Random random = new Random();
            this.x = x;
            this.y = y;
            int ran = random.Next(0, 4);
            if (ran == 0) { travel = 'N'; }
            if (ran == 1) { travel = 'S'; }
            if (ran == 2) { travel = 'E'; }
            if (ran == 3) { travel = 'W'; }

        }



        public override void Draw(PaintEventArgs e, Form form)

        {
            Image newImage = Image.FromFile("..\\..\\dancingGirl.gif");

            Console.WriteLine(travel);
            if (travel == 'N') { y--; }
            if (travel == 'S') { y++; }
            if (travel == 'E') { x++; }
            if (travel == 'W') { x--; }

            if (x == 0)
            { // met west go east
                x += 40;
                travel = 'E';
            }
            if (x == form.Width - (newImage.Width + 16)) // met east go west
            {
                x -= 40;
                travel = 'W';
            }
            if (y == 0)// met north go south
            {
                y++;
                travel = 'S';
            }
            if (y == form.Height)// met south go north
            {
                y--;
                travel = 'N';
            }

            Console.WriteLine(x + " " + y);

            PointF ulCorner = new PointF(x, y); //upper-left corner of image.
            e.Graphics.DrawImage(newImage, ulCorner);

        }
        public override void Move(Form form)
        {

        }

    }
}

