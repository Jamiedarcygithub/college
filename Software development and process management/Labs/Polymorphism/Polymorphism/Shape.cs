using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
    public abstract class Shape
    {
        public ShapeColor Color { get; set; }
        public Shape(ShapeColor color)
        {
            Color = color;
        }

        public override string ToString()
        {
            return "Shape Details" + Color;
        }

        public abstract void Translate(Vertex amount);
    }
}
