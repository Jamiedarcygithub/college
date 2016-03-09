using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
    class Line:Shape
    {
        private Vertex v1, v2;

        public Line (int x1, int y1, int x2, int y2, ShapeColor color) 
            : base(color)
        {
            this.v1 = new Vertex(x1, y1);
            this.v2 = new Vertex(x2, y2);

        }

        public int X1
        {
            get
            {
                return v1.X;
            }

            set
            {
                v1.X = value;
            }
        }


        public int Y1
        {
            get
            {
                return v1.Y;
            }

            set
            {
                v1.Y = value;
            }
        }

        public int X2
        {
            get
            {
                return v2.X;
            }

            set
            {
                v2.X = value;
            }
        }

        public int Y2
        {
            get
            {
                return v2.Y;
            }

            set
            {
                v2.Y = value;
            }
        }

        public override string ToString()
        {
            return "I am a line my color is " + this.Color;
        }

        public override void Translate(Vertex amount)
        {
            v1.X += amount.X;
            v2.X += amount.X;
            v1.Y += amount.Y;
            v2.Y += amount.Y;
        }

    }
}
