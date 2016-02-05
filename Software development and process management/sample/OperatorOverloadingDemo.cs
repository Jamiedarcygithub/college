// demo of operator overloading

using System;

namespace OperatorOverloading
{
    // Time stores an accumulated amount of time in terms of hours, minutes and seconds
    public struct Time
    {
        int hours;              // >=0
        int minutes;            // 0 .. 59
        int seconds;            // 0 .. 59

        // non-default constructor, must initialise all fields
        public Time(int hours, int minutes, int seconds)
            : this()
        {
            // validate

            if ((hours >= 0))                   // no negatives
            {
                this.hours = hours;
            }
            else
            {
                throw new ArgumentException("Invalid value specified for hour: " + hours);
            }

            if ((minutes >= 0) && (minutes <= 59))
            {
                this.minutes = minutes;
            }
            else
            {
                throw new ArgumentException("Invalid value specified for minute: " + minutes);
            }

            if ((seconds >= 0) && (seconds <= 59))
            {
                this.seconds = seconds;
            }
            else
            {
                throw new ArgumentException("Invalid value specified for seocnd: " + seconds);
            }
        }


        // read only properties

        public int Hours
        {
            get
            {
                return hours;
            }
        }

        public int Minutes
        {
            get
            {
                return minutes;
            }
        }

        public int Seconds
        {
            get
            {
                return seconds;
            }
        }

        // parse a integer containing a quantity of seconds to hours, minutes, and seconds
        public static Time Parse(int totalSeconds)
        {
            int hours = totalSeconds / (60 * 60);
            totalSeconds -= hours * 60 * 60;
            int minutes = totalSeconds / 60;
            int seconds = totalSeconds - (minutes * 60);

            return new Time(hours, minutes, seconds);
        }

        // overload + operator
        // operator overloads always static, no polymorphism
        static public Time operator +(Time lhs, Time rhs)                                   // + is binary so overload must be binary
        {
            int seconds1 = (lhs.Hours * 60 * 60) + (lhs.Minutes * 60) + lhs.Seconds;
            int seconds2 = (rhs.Hours * 60 * 60) + (rhs.Minutes * 60) + rhs.Seconds;
            int totalSeconds = seconds1 + seconds2;
            return Parse(totalSeconds);
        }

        // for VB.Net etc. which does not support operator overloading
        public static Time Add(Time lhs, Time rhs)
        {
            return lhs + rhs;
        }

        // overload - operator
        static public Time operator -(Time lhs, Time rhs)                                   // - is binary so overload must be binary
        {
            int seconds1 = (lhs.Hours * 60 * 60) + (lhs.Minutes * 60) + lhs.Seconds;
            int seconds2 = (rhs.Hours * 60 * 60) + (rhs.Minutes * 60) + rhs.Seconds;
            int totalSeconds = seconds1 - seconds2;
            if (totalSeconds < 0)
            {
                return Parse(0);                            // zero the time i.e. to 00:00:00
            }
            else
            {
                return Parse(totalSeconds);
            }
        }

        // for VB.Net
        public static Time Subtract(Time lhs, Time rhs)
        {
            return lhs - rhs;
        }

        // inherited from Object, customise behavour of .Equals (for referene types by the way it tests for reference equality rather than value equality)
        public override bool Equals(Object obj)
        {
            Time t = (Time)obj;

            if (t == null)
            {
                return false;
            }

            // does t have the same data as this ?
            if ((t.Hours == this.Hours) && (t.Minutes == this.Minutes) && (t.Seconds == this.Seconds))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // good practice to override this if overriding Equals
        public override int GetHashCode()
        {
            // return a hash (key) value for this object
            // object with same content should return same hash value

            return Hours.GetHashCode() ^ Minutes.GetHashCode() ^ Minutes.GetHashCode();			// simple hash
        }

        // overload ==
        public static bool operator ==(Time lhs, Time rhs)
        {
            return lhs.Equals(rhs);
        }

        // overload !=
        public static bool operator !=(Time lhs, Time rhs)
        {
            return !lhs.Equals(rhs);
        }

        // inherited from System.Object
        public override string ToString()
        {
            return Hours.ToString("D2") + ":" + Minutes.ToString("D2") + ":" + Seconds.ToString("D2");
        }

    }

    // test class
    class Test
    {
        static void Main()
        {
            Time t1 = new Time(11, 59, 59);
            Time t2 = new Time(00, 00, 01);

            Console.WriteLine(t1 + t2);                     // overloaded op +
            Console.WriteLine(t1 - t2);                     // overloaded op -

            t2 = new Time(11, 59, 59);
            Time t3 = t2;                                   // copy
            Console.WriteLine(t1.Equals(t2));
            Console.WriteLine(t1 == t2);
            Console.WriteLine(t2 == t3);

            // .Equals by default tests reference equality for reference types and value equality (based on binary representation) for value types
            // == is overriden in Time struct to do same as .Equals
            // similiar thing happens in String class (a reference type) - .Equals customised to do value comparison and == overloaded to call it
        }
    }
}