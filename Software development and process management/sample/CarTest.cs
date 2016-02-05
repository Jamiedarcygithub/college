using System;
using Garage;

// application assembly i.e. .exe
// csc /reference:Car.dll CarTest.cs

// default (global) namespace

class CarTest
{
    // can have several Mains
    public static void Main()
    {
        // constructor needs to be public, internal no good, different assembly
        Car c = new Car("Mazerati", "Ghibli", "141 MH 44");		// Garage.Car....

        Console.WriteLine(c);                                   // c.ToString()
    }
}