using System;

// nullable types represent value types which can additionally have the value null
// useful when the type does not have a defined value (i.e. is null) e.g. in a database


namespace NullableTypes
{
    class Nullable
    {
        static void Main(string[] args)
        {
            Nullable<Int32> i;          //  shorthand: int? i, Nullable<T> is a struct, value types
            i = null;
            i = 10;
             
            if (i.HasValue)             // not null, HasValue and Value read-only properties of Nullable<T>
            {
                // cant cast directly to int must use Value property
                int j = i.Value;        // throws InvalidOperationException if HasValue false
                Console.WriteLine(j);
            }

            bool? flag = null;          // Nullable<bool>, flag is undefined

            // String? stuff invalid, must be a value type
            
        }
    }
}
