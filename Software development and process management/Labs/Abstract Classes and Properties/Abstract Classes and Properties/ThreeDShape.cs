using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Classes_and_Properties
{
    public abstract class ThreeDShape
    {
        public string shapeType;

        private string ShapeType
        {
            get;set;        
        }

        protected ThreeDShape(String shapeType)
        {
            this.shapeType = shapeType;       // use auto property
        }

        // read only abstract property - virtual implied
        public abstract double volume            // Shape must be abstract,  similiar syntax to auto property
        {
            get;
            // set not appropriate here
        }

        // public virtual string ToString() in System.Object, virtual => can be overriden in subclasses 
        public override string ToString()
        {
            return "ShapeType: " + this.shapeType + " volume " + this.volume ;
        }


    }
}
