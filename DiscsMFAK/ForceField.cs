using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscsMFAK
{
    public class ForceField
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Mass { get; set; }
        public float GravityConstant { get; set; }

        public ForceField(float x, float y, float mass, float gravityConstant)
        {
            X = x;
            Y = y;
            Mass = mass;
            GravityConstant = gravityConstant;
        }

    }
}
