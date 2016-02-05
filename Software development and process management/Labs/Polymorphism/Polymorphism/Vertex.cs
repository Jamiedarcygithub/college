using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
    class Vertex
    {
        private int x;
        private int y;

        public int X
        {
            get; set; 
            
        }

        public int Y
        {
            get; set;
        }

        public Vertex(int x, int y)
        {
            this.X = x;
            this.Y = y;

        }
    }
}
