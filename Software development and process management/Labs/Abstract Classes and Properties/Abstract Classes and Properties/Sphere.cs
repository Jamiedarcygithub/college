using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Classes_and_Properties
{
    class Sphere:ThreeDShape
    {
        private int radius;
        private double pie = 3.14159; //set pie

        // default constructor
        public Sphere(String shapeType, int radius): base(shapeType)
	    {
            Radius = radius;
        }

        public int Radius
        {
            get
            {
                return radius;
            }

            set
            {
                if(value > 0)
                {
                   radius = value; 

                }else
                {
                    throw new ArgumentException("index is out of bounds: " + radius);
                }
            }


        }

        public override double volume           // Shape must be abstract,  similiar syntax to auto property
        {
            get
            { 
            return this.Radius * this.Radius * this.radius * pie; 
    }

        }


    }
}
