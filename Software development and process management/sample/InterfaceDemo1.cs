// demo of interfaces - part 1

using System;

public interface IDrawable                          // interface names usually contain verbs
{
    void Draw();					                // public and abstract method
}

// Circle has an origin (X, Y)
class Circle : IDrawable 				            // implements an interface, but inherits from Object
{
    public int X { get; set; }                      // x coordinate in 2D space
    public int Y { get; set; }                      // y coordinate in 2D space

    public void Draw()
    {
        Console.WriteLine("Drawing a circle at (" + X + ", " + Y + ")");
    }
}

// test class
class Test
{
    public static void Main()
    {
        Circle c = new Circle { X = 10, Y = 20 };
        c.Draw();
    }
}