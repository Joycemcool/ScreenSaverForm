using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreensaverAssignment.Shapes.ChildShapes
{
    public class Polygon : Shape
    {

        private System.Drawing.Point[] points; // Array to store the vertices of the polygon
        private Random random = new Random();

        public Polygon(Point[] polygonPoints)
        {
            // Initialize the vertices of the polygon
            this.points = polygonPoints;
        }

        public override void Draw(PaintEventArgs e, Form form)
        {
            int minX = points.Min(p => p.X);
            int minY = points.Min(p => p.Y);
            int maxX = points.Max(p => p.X);
            int maxY = points.Max(p => p.Y);

            // Calculate the width and height of the bounding box around the polygon
            int width = maxX - minX;
            int height = maxY - minY;

            // Randomly choose new X and Y coordinates within the bounds of the form
            int newX = random.Next(0, form.Width - width);
            int newY = random.Next(0, form.Height - height);

            // Calculate the translation vector to move the polygon to the new position
            int deltaX = newX - minX;
            int deltaY = newY - minY;

            // Translate the polygon's vertices to the new position
            for (int i = 0; i < points.Length; i++)
            {
                points[i] = new Point(points[i].X + deltaX, points[i].Y + deltaY);
            }

            // Draw the polygon using the Graphics object from PaintEventArgs
            e.Graphics.FillPolygon(Brushes.DarkBlue, points);
        }

        public override void Move(Form form)
        {

        }

    }
}
