using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            //Vertex v = new Vertex(1, 10);
            //Console.WriteLine(v.ToString());

            //Circle Ci = new Circle(10, 10, 15, ShapeColor.Red);
            //Console.WriteLine("the circle shape colour is: " + Ci.Color);
            //Console.WriteLine("the Circle details before vertex: " + Ci.ToString());
            //Ci.Translate(new Vertex(10, 10));
            //Console.WriteLine("the line details after vertex: " + Ci.ToString());

            //Line line = new Line(10, 10, 10, 15, ShapeColor.Green);
            //Console.WriteLine("the line shape colour is: " + line.Color);
            //Console.WriteLine("the line details before vertex: " + line.ToString());
            //line.Translate(new Vertex(10, 10));
            //Console.WriteLine("the line details after vertex: " + line.ToString());


            Shape[] shapes = { new Line(2, 2, 3, 3, ShapeColor.Green), new Circle(5, 5, 50, ShapeColor.Blue) };

            foreach (Shape s in shapes)
            {
                Console.WriteLine("before : " + s);             // ToString()
                s.Translate(new Vertex(10, 10));
                Console.WriteLine("after : " + s);              // ToString()
            }

            Console.ReadLine();

        }
    }
}
