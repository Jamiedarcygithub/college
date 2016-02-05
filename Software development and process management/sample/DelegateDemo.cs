// demo of delegates (like function pointers in C)

using System;

delegate string GreetingDelegate();			// a delegate referring to a method which returns a string taking no params

class Person
{
    string Name { get; set; }

    // method which adheres to GreetingDelegate definition
    public string SayHello()
    {
        return "Hello " + Name;
    }

    // method which adheres to GreetingDelegate definition
    public string SayGoodBye()
    {
        return "Goodbye " + Name;
    }

    // entry point
    public static void Main()
    {
        Person p1 = new Person { Name = "Gary" };

        GreetingDelegate gd1 = null;
        gd1 += p1.SayHello;                                  // add method to delegate
        Console.WriteLine(gd1());                            // invoke method in delegate

        // alternative syntax to +=
        GreetingDelegate gd2 = new GreetingDelegate(p1.SayGoodBye);
        Console.WriteLine(gd2());

        // plug in a lamdba expression instead (i.e. an anonymous function)
        GreetingDelegate gd3 = new GreetingDelegate(() => { return "See you soon " + p1.Name; });
        Console.WriteLine(gd3());
    }
}
