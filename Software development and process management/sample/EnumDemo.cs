// demo of enumerations - enums are value types
// System.Enum is base class for enumerations, enums behave as value types, System.Enum superclass is System.ValueType

using System;

// RGB colors
public enum Color				                    // underlying type is int
{
    Red, Green, Blue                                // 0, 1, 2
}

// days of the week
public enum Day                           
{
    Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday         
}

class Test
{
    public static void Main()
    {
        Color c1 = Color.Red;
        Color c2 = c1;                          // enums are alue types, this is a copy
        c2 = Color.Green;
        Console.WriteLine(c1);                  // still Red
        Console.WriteLine(c2);                  // Green
        Console.WriteLine((int)Color.Blue);     // 2

        Day d1 = Day.Wednesday;
        short dayNo = (short) d1;               // 2
        Console.WriteLine("Day " + dayNo);
        dayNo++;
        d1 = (Day)dayNo;                        // Thursday is day 3
        Console.WriteLine(d1);
    }
}