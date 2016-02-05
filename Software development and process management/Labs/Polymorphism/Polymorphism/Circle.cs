using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
    class Circle:Shape
    {
        public Circle(int x, int y, double radius, string color)
            :base(color)
        {
            this.Raduis = radius;
            this.X = x;
            this.Y = y;


        }

        private double raduis;
        private int x;
        private int y;

        public double Raduis { get; set; }
        public int X { get; set; }

        public int Y { get; set; }

        public override string ToString()
        {
            return "I am a circle";
        }

        public override string translate()
        {
            return "the circle is translated";
        }

        public double area()
        {
            return (3.14) * raduis * raduis;
        }


    }
}

 

