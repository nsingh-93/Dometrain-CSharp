namespace ReferenceAndValueTypes;

public class EqualityChecks
{
    public class MyClass
    {
        public int NumericValue { get; set; }

        public required string StringValue { get; set; }
    }

    public struct MyStruct
    {
        public int NumericValue { get; set; }

        public string StringValue { get; set; }
    }

    public class MyClassWithEquality
    {
        public int NumericValue { get; set; }

        public required string StringValue { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var other = (MyClassWithEquality)obj;
            return NumericValue == other.NumericValue && StringValue == other.StringValue;
        }

        public override int GetHashCode()
        {
            return NumericValue.GetHashCode() ^ StringValue.GetHashCode();
        }
    }

    public class MyClassWithEqualityAndOperator
    {
        public int NumericValue { get; set; }

        public required string StringValue { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var other = (MyClassWithEqualityAndOperator)obj;
            return NumericValue == other.NumericValue && StringValue == other.StringValue;
        }

        public override int GetHashCode()
        {
            return NumericValue.GetHashCode() ^ StringValue.GetHashCode();
        }

        public static bool operator ==(MyClassWithEqualityAndOperator left, MyClassWithEqualityAndOperator right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(MyClassWithEqualityAndOperator left, MyClassWithEqualityAndOperator right)
        {
            return !left.Equals(right);
        }
    }

    public static void RunEqualityChecks()
    {
        // Class equlity
        var myClass1 = new MyClass { NumericValue = 123, StringValue = "ABC" };
        var myClass2 = new MyClass { NumericValue = 123, StringValue = "ABC" };

        Console.WriteLine("myClass1 equal to myClass2:");
        Console.WriteLine(myClass1 == myClass2);                // False
        Console.WriteLine(myClass1.Equals(myClass2));           // False
        Console.WriteLine(object.Equals(myClass1, myClass2));   // False

        
        // Struct equality
        var myStruct1 = new MyStruct { NumericValue = 123, StringValue = "ABC" };
        var myStruct2 = new MyStruct { NumericValue = 123, StringValue = "ABC" };

        Console.WriteLine("myStruct1 equal to myStruct2:");
        //Console.WriteLine(myStruct1 == myStruct2);                // Doesn't compile
        Console.WriteLine(myStruct1.Equals(myStruct2));             // True
        Console.WriteLine(object.Equals(myStruct1, myStruct2));     // True


        // Class with override equality
        var myClassWithEquality1 = new MyClassWithEquality { NumericValue = 123, StringValue = "ABC" };
        var myClassWithEquality2 = new MyClassWithEquality { NumericValue = 123, StringValue = "ABC" };

        Console.WriteLine("myClassWithEquality1 equal to myClassWithEquality2:");
        Console.WriteLine(myClassWithEquality1 == myClassWithEquality2);                // False
        Console.WriteLine(myClassWithEquality1.Equals(myClassWithEquality2));           // True
        Console.WriteLine(object.Equals(myClassWithEquality1, myClassWithEquality2));   // True


        // Class with override and operator equality
        var myClassWithEqualityAndOperator1 = new MyClassWithEqualityAndOperator { NumericValue = 123, StringValue = "ABC" };
        var myClassWithEqualityAndOperator2 = new MyClassWithEqualityAndOperator { NumericValue = 123, StringValue = "ABC" };

        Console.WriteLine("myClassWithEqualityAndOperator1 equal to myClassWithEqualityAndOperator2:");
        Console.WriteLine(myClassWithEqualityAndOperator1 == myClassWithEqualityAndOperator2);                  // True
        Console.WriteLine(myClassWithEqualityAndOperator1.Equals(myClassWithEqualityAndOperator2));             // True
        Console.WriteLine(object.Equals(myClassWithEqualityAndOperator1, myClassWithEqualityAndOperator2));     // True
    }
}
