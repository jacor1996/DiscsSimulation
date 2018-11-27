using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace DiscsMFAK
{
    public class Disc
    {

        public Vector Location { get; set; }
        public Vector Velocity { get; set; }
        public Vector Acceleration { get; set; }

        public float Radius { get; set; }
        public float Mass { get; set; }

        public RectangleF Rectangle { get; set; }
        public Color DiscColor { get; set; }

        private const float MaxSpeed = 7.5f;

        public Disc()
        {
        }

        public Disc(Vector location, Vector velocity, float radius, float mass, Color discColor)
        {
            Location = location;
            Velocity = velocity;
            Acceleration = new Vector(0,0);
            Radius = radius;
            DiscColor = discColor;
            Mass = mass;

            UpdateRectangle();
        }

        public void UpdatePosition(int width, int height, int left, int top)
        {

            Velocity.Add(Acceleration);
            Velocity.Limit(MaxSpeed);
            // Dodać krok czasowy
            Location.Add(Velocity);
            

            CheckEdges(width,height, left, top);

            UpdateRectangle();
            Acceleration.Multiply(0);
        }

        public void CheckEdges(int width, int height, int left, int top)
        {
            if (Rectangle.Right + Velocity.X >= width)
            {
                Location.X = width - Radius;
                Velocity.X = Velocity.X * -1;
            }

            else if (Rectangle.Left + Velocity.X <= left)
            {
                Location.X = left + Radius;
                Velocity.X = Velocity.X * -1;
            }

            if (Rectangle.Bottom + Velocity.Y >= height)
            {
                Location.Y = height - Radius;
                Velocity.Y = Velocity.Y * -1;
            }

            else if (Rectangle.Top + Velocity.Y <= top)
            {
                Location.Y = top + Radius;
                Velocity.Y = Velocity.Y * -1;
            }
        }

        public void ApplyForce(Vector force)
        {
            Vector f = force;
            f.Divide(Mass);
            Acceleration.Add(f);
        }

        public void UpdateRectangle()
        {
            Rectangle = new RectangleF(
                Location.X - Radius,
                Location.Y - Radius,
                Radius * 2,
                Radius * 2
            );
        }

        public bool IsInside(Liquid liquid)
        {
            return Rectangle.IntersectsWith(liquid.Rectangle);
        }

        public void Drag(Liquid liquid)
        {
            float speed = Velocity.Magnitude();
            float dragMagnitude = liquid.C * speed * speed;

            Vector drag = Velocity;
            drag.Multiply(-1);
            drag.Normalize();
            drag.Multiply(dragMagnitude);

            ApplyForce(drag);
        }

    }
}
