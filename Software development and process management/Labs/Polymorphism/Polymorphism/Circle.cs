using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
    class Circle:Shape
    {
        private Vertex origin;

        public Circle(int x, int y, double radius, ShapeColor color)
            :base(color)
        {
            this.Raduis = radius;
            this.X = x;
            this.Y = y;


        }

        public double Raduis { get; set; }
        public int X
        {
            get
            {
                return origin.X;
            }

            set
            {
                origin.X = value;
            }
        }


        public int Y
        {
            get
            {
                return origin.Y;
            }

            set
            {
                origin.Y = value;
            }
        }

        public override string ToString()
        {
            return "I am a circle my raduis is " + this.Raduis + " and my area is " + area();
        }

        // move the circle
        public override void Translate(Vertex amount)
        {
            origin.X += amount.X;
            origin.Y += amount.Y;
        }

        public double area()
        {
            return Math.PI * this.Raduis * this.Raduis;
        }


    }
}

 

