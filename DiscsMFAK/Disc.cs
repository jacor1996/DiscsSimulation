using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DiscsMFAK
{
    public class Disc
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float VelocityX { get; set; }
        public float VelocityY { get; set; }
        public float Radius { get; set; }
        public float Mass { get; set; }
        public float ForceX { get; set; }
        public float ForceY { get; set; }
        public RectangleF Rectangle { get; set; }
        public Color DiscColor { get; set; }

        public Disc()
        {
        }

        public Disc(float x, float y, float velocityX, float velocityY, float radius, float mass, Color discColor)
        {
            X = x;
            Y = y;
            VelocityX = velocityX;
            VelocityY = velocityY;
            Radius = radius;
            DiscColor = discColor;

            ForceX = 0;
            ForceY = 0;
            Mass = mass;

            UpdateRectangle();
        }

        public void UpdatePosition(int width, int height, int left, int top, ForceField centerField)
        {
            /*
            if (Rectangle.Right + VelocityX >= width || Rectangle.Left + VelocityX <= left)
            {
                VelocityX = VelocityX * -1;
            }

            if (Rectangle.Bottom + VelocityY >= height || Rectangle.Top + VelocityY <= top)
            {
                VelocityY = VelocityY * -1;
            }
             */


            VelocityX += 0.05f;
            VelocityY = VelocityY + 0.05f;

            X = X + VelocityX;
            Y = Y + VelocityY;

            CheckEdges(width,height, left, top);

            UpdateRectangle();
        }

        public void CheckEdges(int width, int height, int left, int top)
        {
            if (Rectangle.Right + VelocityX >= width)
            {
                X = width - Radius;
                VelocityX = VelocityX * -1;
            }

            else if (Rectangle.Left + VelocityX <= left)
            {
                X = left;
                VelocityX = VelocityX * -1;
            }

            if (Rectangle.Bottom + VelocityY >= height)
            {
                Y = height - Radius;
                VelocityY = VelocityY * -1;
            }

            else if (Rectangle.Top + VelocityY <= top)
            {
                Y = top;
                VelocityY = VelocityY * -1;
            }
        }

        public void UpdateRectangle()
        {
            Rectangle = new RectangleF(
                X - Radius,
                Y - Radius,
                Radius * 2,
                Radius * 2
            );
        }

        public void ComputeForceField(ForceField centerField)
        {
            // f = (Gm1m2 / |xa - xb|^2) * ((xa - xb) / |xa - xb|) 
            if (centerField != null)
            {
                //double fx = ((centerField.GravityConstant * centerField.Mass * Mass) * (centerField.X - X)) /
                            //(Math.Pow(Math.Abs(centerField.X - X), 2) * Math.Abs(centerField.X - X));

                //double fy = ((centerField.GravityConstant * centerField.Mass * Mass) * (centerField.Y - Y)) /
                            //(Math.Pow(Math.Abs(centerField.Y - Y), 2) * Math.Abs(centerField.Y - Y));

                //ForceX += (float)fx;
                //ForceY += (float)fy;

                

            }
            
        }


    }
}
