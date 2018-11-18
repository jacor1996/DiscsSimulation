using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DiscsMFAK
{
    public class Liquid
    {
        public RectangleF Rectangle { get; set; }
        public Color Color { get; set; }
        public float C;

        public Liquid(RectangleF rectangle, Color color, float c)
        {
            Rectangle = rectangle;
            Color = color;
            C = c;
        }
    }
}
