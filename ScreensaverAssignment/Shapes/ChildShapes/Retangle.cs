using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreensaverAssignment.Shapes.ChildShapes
{
    public class Retangle : Shape
    {
        public int width = 50; // Adjust the width as needed
        public int height = 80; // Adjust the height as needed
        public int topX;
        public int topY;

        public Retangle(int x, int y)
        {
            // Initialize the position of the retangle
            this.topX = x;
            this.topY = y;
        }
        public override void Draw(PaintEventArgs e, Form form)
        {

            // Calculate the bounding rectangle for the circle
            Rectangle boundingRect = new Rectangle(topX, topY, width, height);

            //// Draw the circle using the Graphics object from PaintEventArgs
            e.Graphics.FillRectangle(Brushes.DarkOliveGreen, boundingRect);

            //Image myImage = Image.FromFile("MyTexture.bmp");
            //TextureBrush myTextureBrush = new TextureBrush(myImage);
            //myGraphics.FillEllipse(myTextureBrush, 0, 0, 100, 50);
        }

        public override void Move(Form form)
        {

        }
    }
}
