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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System.Net.NetworkInformation;
using ScreensaverAssignment.Shapes;
using ScreensaverAssignment.Shapes.ChildShapes;

namespace ScreensaverAssignment
{
    public partial class ScreenSaverForm : Form
    {

        List<Shape> shapeList = new List<Shape>();

        System.Timers.Timer timer = new System.Timers.Timer(50);
        // Define a PictureBox control to display an image (or shape)
        private PictureBox pictureBox;

        private Random rand = new Random();

        private int formWidth = 500;
        private int formHeigh = 500;
        private Retangle retangle;



        public ScreenSaverForm()
        {
            //Initialize and configure the pictureBox
            pictureBox = new PictureBox();

            retangle = new Retangle(formWidth, formHeigh);

            InitializeComponent();
            this.Paint += new PaintEventHandler(ScreenSaverForm_Paint);


        }
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {

            foreach (Shape shape in shapeList)
            {
                shape.Move(this);
            }

            foreach (Shape shapeA in shapeList)
            {
                foreach (Shape shapeB in shapeList)
                {
                    if (shapeA !=shapeB)// && (shapeB.topX == shapeA.topX || shapeB.topY == shapeA.topY) )
                     {
                        
                        int rangeX = 20; 
                        int rangeY = 20;
                        int negRangX = -20;
                        int negRangY = -20;

                        bool meetOnX = Math.Abs(shapeB.topX - shapeA.topX) >=negRangX ||Math.Abs(shapeB.topX - shapeA.topX) <= rangeX;
                        bool meetOnY = Math.Abs(shapeB.topY - shapeA.topY) >= negRangY || Math.Abs(shapeB.topY - shapeA.topY) <= rangeY;

                        if (meetOnX && meetOnY)
                        {
                            Console.WriteLine("Shapes meet: shapeA and shapeB");
                            shapeA.FlipX();shapeA.FlipY();
                            shapeB.FlipY();shapeB.FlipX();
                            shapeA.Move(this);
                            shapeB.Move(this);
                        }

                    }

                }
            }
 


            foreach (Shape shape in shapeList)
            {
                shape.CheckWalls(this);
            }


            this.Invalidate();

        }

        private void ScreenSaverForm_Load(object sender, EventArgs e)
        {           
            timer.Interval = 500;
            timer.Elapsed += OnTimedEvent;
            this.MouseClick += (System.Windows.Forms.MouseEventHandler)MouseClickHandler;     
            this.Size = new Size(formWidth, formHeigh);
            timer.Start();
        }

        //Draw custom shapes on the form
        private void ScreenSaverForm_Paint(object sender, PaintEventArgs e)
        {
            //Polymorphic processing (late binding with timing) using an array list with all casting operations being explicit.
            for (int i = 0; i < shapeList.Count; i++)
                shapeList[i].Draw(e, this);
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            // Handle the click event of the PictureBox (e.g., change the image or shape)
            // Change position

            int newX = rand.Next(0, this.ClientSize.Width - pictureBox.Width);
            int newY = rand.Next(0, this.ClientSize.Height - pictureBox.Height);
            pictureBox.Location = new Point(newX, newY);

            // Change the PictureBox's background color to a random color
            Color randomColor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
            pictureBox.BackColor = randomColor;
        }

        private void MouseClickHandler(object sender, MouseEventArgs e)
        {
            
            
            Random random = new Random();
            int ran = random.Next(0, 6);
            int mouseX = e.X;
            int mouseY = e.Y;

            if (ran == 0)
                shapeList.Add(new Triangle(mouseX, mouseY));
            //else if (ran == 1)
            //    shapeList.Add(new ImageShape(mouseX, mouseY));
            else if (ran == 2)
                shapeList.Add(new Circle(mouseX, mouseY));
            else if (ran == 3)
                shapeList.Add(new Retangle(mouseX, mouseY));
            else if (ran == 4)
                shapeList.Add(new Polygon(mouseX, mouseY));
            else if (ran == 5)
                shapeList.Add(new PictureBoxShape(mouseX, mouseY));

        }
        private void panel1_Paint(object sender, PaintEventArgs e) { }



    } //End class form

   
}//End namespace
