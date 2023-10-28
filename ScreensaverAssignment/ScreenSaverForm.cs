using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Runtime.CompilerServices;
using System.Diagnostics.Eventing.Reader;
using System.Diagnostics;

namespace ScreensaverAssignment
{
    public partial class ScreenSaverForm : Form
    {
        System.Timers.Timer timer = new System.Timers.Timer(50);

        List<Shape> shapeList = new List<Shape>();

        // Define a PictureBox control to display an image (or shape)
        private PictureBox pictureBox;

        public ScreenSaverForm()
        {
            //Initialize and configure the pictureBox
            pictureBox = new PictureBox();
            pictureBox.Location = new Point(100, 100);
            pictureBox.Size = new Size(200, 200);
            pictureBox.BackColor = Color.White;

            // Add the PictureBox to the form
            this.Controls.Add(pictureBox);

            InitializeComponent();
            this.Paint += new PaintEventHandler(ScreenSaverForm_Paint);
            pictureBox.Click += new EventHandler(PictureBox_Click);

            timer.Interval = 50;
            timer.Elapsed += OnTimedEvent;
            timer.Start();
            this.MouseClick += (System.Windows.Forms.MouseEventHandler)MouseClickHandler;
        }
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("Tick");
            Invalidate();

        }

        private void ScreenSaverForm_Load(object sender, EventArgs e)
        {

        }

        //Draw custom shapes on the form
        private void ScreenSaverForm_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < shapeList.Count; i++)
                shapeList[i].Draw(e, this);

        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            // Handle the click event of the PictureBox (e.g., change the image or shape)
            // You can add code here to update the PictureBox when it's clicked
            pictureBox.BackColor = Color.Beige;
        }

        private void MouseClickHandler(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Random random = new Random();
            int ran = random.Next(0, 4);
            int mouseX = e.X;
            int mouseY = e.Y;

            Point[] polygonPoints = new Point[]
            {
                new Point(mouseX, mouseY),
                new Point(150, 50),
                new Point(200, 100),
                new Point(150, 150)
            };

            Console.WriteLine(mouseX + " " + mouseY + " " + ran);

            if (ran == 0)
                shapeList.Add(new MyPolyTriangle(mouseX, mouseY));
            else if (ran == 1)
                shapeList.Add(new MyPolyCircle(mouseX, mouseY));
            else if (ran == 2)
                shapeList.Add(new MyPolyRectangle(mouseX, mouseY));
            else if (ran == 3)
                shapeList.Add(new MyPolyPolygon(polygonPoints));
        }

        private void panel1_Paint(object sender, PaintEventArgs e) { }


    } //End class form

    public abstract class Shape
    {
        public abstract void Draw(PaintEventArgs e, Form form);

    }//end class shape
    public class MyPolyTriangle : Shape
    {

        public int topX = 400;
        public int topY = 5000;

        public int leftX = 350;
        public int leftY = 150;

        public int rightX = 450;
        public int rightY = 150;

        public MyPolyTriangle(int x, int y)
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

        }//End Draw method

    }//end MyPolyTriangle class


    public class MyPolyCircle : Shape
    {
        public int radius = 40;
        public int topX = 400;
        public int topY = 5000;

        public MyPolyCircle(int x, int y)
        {
            // Initialize the position of the circle
            this.topX = x;
            this.topY = y;
        }
        public override void Draw(PaintEventArgs e, Form form)
        {
            // Calculate the bounding rectangle for the circle
            Rectangle boundingRect = new Rectangle(topX - radius, topY - radius, 2 * radius, 2 * radius);

            // Draw the circle using the Graphics object from PaintEventArgs
            e.Graphics.FillEllipse(Brushes.DarkRed, boundingRect);
        }

    }

    public class MyPolyRectangle : Shape
    {
        public int width = 80; // Adjust the width as needed
        public int height = 40; // Adjust the height as needed
        public int topX = 400;
        public int topY = 5000;

        public MyPolyRectangle(int x, int y)
        {
            // Initialize the position of the circle
            this.topX = x;
            this.topY = y;
        }
        public override void Draw(PaintEventArgs e, Form form)
        {
            // Calculate the bounding rectangle for the circle
            Rectangle boundingRect = new Rectangle(topX, topY, width, height);

            // Draw the circle using the Graphics object from PaintEventArgs
            e.Graphics.FillEllipse(Brushes.DarkOliveGreen, boundingRect);
        }

    }

    public class MyPolyPolygon : Shape
    {
        private Point[] points; // Array to store the vertices of the polygon

        public MyPolyPolygon(Point[] polygonPoints)
        {
            // Initialize the vertices of the polygon
            this.points = polygonPoints;
        }

        public override void Draw(PaintEventArgs e, Form form)
        {
            // Draw the polygon using the Graphics object from PaintEventArgs
            e.Graphics.FillPolygon(Brushes.DarkBlue, points);
        }
    }
}//End namespace
