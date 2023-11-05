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
        public int topX = 400;
        public int topY = 5000;

        public int leftX = 350;
        public int leftY = 150;

        public int rightX = 450;
        public int rightY = 150;

        public Triangle(int x, int y)
        {
            topX = x;
            topY = y;
            leftX = x - 50;
            leftY = y + 100;
            rightX = x + 50;
            rightY = y + 100;
        }

        public override void Draw(PaintEventArgs e, Form form)
        {
            e.Graphics.FillPolygon(Brushes.Aquamarine, new Point[] {

                new Point(topX, topY),
                new Point(leftX, leftY),
                new Point(rightX, rightY)

            });

        }

        public override void Move(Form form)
        {
        topY++; // Move the triangle down

        // Update the positions of the left and right vertices accordingly
        leftY++;
        rightY++;

        // Optionally, you can add boundary checks to keep the triangle within the form
        // For example, you can check if the triangle has reached the bottom of the form
        if (topY >= form.Height)
        {
            // Reset the triangle to the top of the form
            topY = 0;
            leftY = 20;
            rightY = 20;
        }

        // Call Invalidate to trigger a repaint of the form
        form.Invalidate();
        }


    }//end class
}

