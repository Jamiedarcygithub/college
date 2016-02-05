using System;

// default (global) namespace

public abstract class Shape
{
	// auto-implemented property
	public String Id
	{
		get; 				
		set;
	}
	
	// read only abstract property - virtual implied
	public abstract double Area				// Shape must be abstract,  similiar syntax to auto property
	{
		get;
		// set not appropriate here
	}
	
	// constructor 
	protected Shape(String id)
	{
		this.Id = id;		// use auto property
	}
	
}

public class Square : Shape
{
	// auto property
	public double Side
	{
		get;
		set;
	}
	
	// implement Area calculation for a Square
	public override double Area
	{
		get
		{
			return Side * Side; 
		}
	}
	
	// default constructor
	public Square(String id, double side): base(id)
	{
		Side = side;
	}
}


// test class
public class Test
{
	static void Main()				// private
	{
		Square s = new Square("Square 1", 10);
		Console.WriteLine(s.Area);
	}
}