using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscsMFAK
{
    public class Attractor
    {
        public float Mass { get; set; }
        public Vector Location { get; set; }
        public float G { get; set; }

        public Attractor()
        {
            Location = new Vector(250, 150);
            Mass = 1500;
            G = 0.8f;
        }

        public void ChangeMass(float mass)
        {
            Mass = mass;
        }

        public void ChangeLocation(Point point)
        {
            Location = new Vector(point.X, point.Y);
        }

        public void ChangeGConstant(float g)
        {
            G = g;
        }

        public Vector Attract(Disc disc)
        {
            Vector force = Vector.Subtract(Location, disc.Location);
            float distance = force.Magnitude();

            int minDistance = 40;
            if (distance < minDistance)
            {
                distance = minDistance;
            }

            force.Normalize();
            float strength = (G * Mass * disc.Mass) / (distance * distance);
            force.Multiply(strength);
            return force;
        }
    }
}
