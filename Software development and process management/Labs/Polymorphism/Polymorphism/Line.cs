using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
    class Line:Shape
    {
        protected Line (int x1, int y1, int x2, int y2, string color) 
            : base(color)
        {
            this.Color = color;

        }

        private int x1;
        private int x2;
        private int y2;
        private int y1;


        public int X1 { get; set; }
        public int X2 { get; set; }

        public int Y1 { get; set; }
        public int Y2 { get; set; }

    }
}
