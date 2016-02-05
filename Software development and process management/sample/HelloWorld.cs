using System;						// System namespace

// unicode source file
// an assembly application (.exe), not a library (.dll)
// assemblies are applications or libraries

// in default (global) namespace

// class name does not have to match file name

class HelloWorld : Object				// : System.Object, internal is default (within assembly visibility)
{
    // convention is CAPS to start a method name
    private static void Main()			// access modifier can be anything
    {

        string message = "Hello there C# and .NET World !";
        // alias for System.String, a reference type (on the heap)

        Console.WriteLine("{0}", message);	// placeholder, use comma	
        //Console.WriteLine("" + message);	// concat version, use +

        // System.Console.WriteLine.... if haven't said using System;
    }
}


// csc HelloWorld.cs - produces HelloWorld.exe (a .NET PE)
// run & managed by the CLR - JITs IL into native code
