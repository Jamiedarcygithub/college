using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Classes_and_Properties
{
    class Program
    {
        static void Main(string[] args)
        {
            Sphere s = new Sphere("Sphere", 4);
            Console.WriteLine(s.volume);
            Console.WriteLine(s.ToString());
            Console.ReadLine();
        }
    }
}
