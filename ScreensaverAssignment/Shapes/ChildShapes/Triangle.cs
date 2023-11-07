﻿using System;
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
        //MAKE RETANGLE 
        public int topX;
        public int topY;
        public int leftX;
        public int leftY;
        public int rightX;
        public int rightY;
        private int ranVar;
        private Random random = new Random();
        private Color color;
        private int XVelocity;
        private int YVelocity;
        public Triangle triangle;

        public Triangle(int x, int y)
        {
            ranVar = random.Next(-100, 100);
            topX = x;
            topY = y;
            leftX = x - ranVar;
            leftY = y + ranVar;
            rightX = x + ranVar;
            rightY = y + ranVar;
            //CHANGE THE SIZE OF TRIANGLE
            color = Color.FromArgb(255, random.Next(255), random.Next(255), random.Next(255));
            

        }

        public override void Draw(PaintEventArgs e, Form form)
        {
            SolidBrush brush = new SolidBrush(color);
            e.Graphics.FillPolygon(brush, new Point[] {

                new Point(topX, topY),
                new Point(leftX, leftY),
                new Point(rightX, rightY)

        });

        }

        //TODO: IMPLEMENT MOVE FUNCTION FOR TRIANGLE AND RETANGLE
        public override void Move(Form form)
        {
            XVelocity = random.Next(-30, 30); // Adjust the range as needed
            YVelocity = random.Next(-30, 30);

            // Update the triangle's points based on the velocity
            topX += XVelocity;
            topY += YVelocity;
            leftX += XVelocity;
            leftY += YVelocity;
            rightX += XVelocity;
            rightY += YVelocity;

          // Check for collisions with the form boundaries
            if (topX < 0 || rightX > form.ClientRectangle.Right)
            {
                XVelocity = -XVelocity; // Reverse horizontal velocity on collision with left or right wall
            }

            if (topY < 0 || leftY > form.ClientRectangle.Bottom)
            {
                YVelocity = -YVelocity; // Reverse vertical velocity on collision with top or bottom wall
            }

            // Call Invalidate to trigger a repaint of the form
            form.Invalidate();
        }


    }//end class
}
