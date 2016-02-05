using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
    class Shape
    {
        public Shape(string color)
        {
            this.Color = color;
        }

        private string color;

        public string Color
        {
            get
            {
                return color;
            }
            set
            {
                if(!String.IsNullOrWhiteSpace(value))
                {
                    color = value;
                }
                else
                {
                    throw new ArgumentException("Color is invalid");

                }

            }
        }

        public override string ToString()
        {
            return "Shape Details" + this.color;
        }

        public virtual string translate()
        {
            return "tanslate";
        }

    }
}
