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
            Vertex v = new Vertex(1, 10);
            Console.WriteLine(v.ToString());

            Shape s = new Shape("blue");
            Console.WriteLine(s.Color);
            Circle Ci = new Circle(10, 10, 15, "red");
            Console.WriteLine("the circle shape colour is: " + Ci.Color);
            Console.WriteLine("the circle translation message is: " + Ci.translate());
            Console.WriteLine("the circle details: " + Ci.ToString()+ Ci.area());
            Console.ReadLine();

        }
    }
}
