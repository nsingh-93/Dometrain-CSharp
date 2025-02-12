namespace ObjectOriented;

// 1. System.Tuple:
//    - reference type
//    - immutable
//    - values are properties
// 2. System.ValueTuple: a value type
//    - value type
//    - mutable
//    - values are fields

public class Tuples
{
    public static void RunTuples()
    {
        // System.Tuple
        Tuple<int, string> tuple = new Tuple<int, string>(1, "one");

        // System.ValueTuple
        ValueTuple<int, string> valueTuple = new ValueTuple<int, string>(1, "one");
        ValueTuple<int, string> valueTuple2 = new(1, "one");
        ValueTuple<int, string> valueTuple3 = (1, "one");
        var valueTuple4 = (1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);


        // Returning multiple values using out parameter
        int GetMinAndMaxWithOutParam(int[] numbers, out int max)
        {
            if (numbers.Length == 0)
            {
                throw new ArgumentException("Cannot have an empty array");
            }

            int min = numbers[0];
            max = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] < min)
                {
                    min = numbers[i];
                }
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
            }

            return min;
        }

        int[] numbers = { 1, 2, 3, 4, 5 };
        int min = GetMinAndMaxWithOutParam(numbers, out int max);


        // Returning multiple values using tuples
        (int, int) GetMinAndMaxWithTuple(int[] numbers)
        {
            if (numbers.Length == 0)
            {
                throw new ArgumentException("Cannot have an empty array");
            }

            int min = numbers[0];
            int max = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] < min)
                {
                    min = numbers[i];
                }
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
            }

            return (min, max);
        }

        Console.WriteLine("Min and Max tuple:");

        var minAndMaxTuple = GetMinAndMaxWithTuple(numbers);

        Console.WriteLine($"Min: { minAndMaxTuple.Item1 }, Max: { minAndMaxTuple.Item2 }");
        Console.WriteLine($"The tuple: { minAndMaxTuple }");


        // Using named tuples
        (int Min, int Max) GetMinAndMaxWithNamedTuple(int[] numbers)
        {
            if (numbers.Length == 0)
            {
                throw new ArgumentException("Cannot have an empty array");
            }

            int min = numbers[0];
            int max = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] < min)
                {
                    min = numbers[i];
                }
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
            }

            return (Min: min, Max: max);
            //return (min, max);    This works
        }

        Console.WriteLine("Min and Max with named tuple:");

        var minAndMaxNamedTuple = GetMinAndMaxWithNamedTuple(numbers);

        Console.WriteLine($"Min: { minAndMaxNamedTuple.Min }, Max: { minAndMaxNamedTuple.Max }");
        Console.WriteLine($"The tuple: { minAndMaxNamedTuple }");


         // Deconstruct tuples
        (int firstThing, string secondThing) = (1, "this is second thing");
        //(int minVal, _) = GetMinAndMaxWithNamedTuple(numbers);

        // Keyword var out at the front to infer type at compile time
        var (firstThing2, secondThing2) = (1, "this is second thing");


        (int, string, int) tupleA = (123, "hello", 456);
        (int, int) tupleB = (123, 456);
        (float, float) tupleC = (FirstNumber: 123, SecondNumber: 456);
        (byte, string, float) tupleD = (FirstNumber: 123, Name: "hello", SecondNumber: 456);
        (int, int) tupleE = (456, 789);
        (byte, string, float) tupleF = (123, "world", 456);
        (string, string) tupleG = ("hello", "world");

        // These won't compile
        // Need to have same number of elements and compatible types
        //Console.WriteLine($"tupleA == tupleB: {tupleA == tupleB}");  diff counts
        //Console.WriteLine($"tupleA == tupleC: {tupleA == tupleC}");  diff counts
        //Console.WriteLine($"tupleB == tupleG: {tupleB == tupleG}");  same counts, incpmpatible types

        Console.WriteLine($"tupleA == tupleD: { tupleA == tupleD }"); // true
        Console.WriteLine($"tupleA == tupleF: { tupleA == tupleF }"); // false
        Console.WriteLine($"tupleB == tupleC: { tupleB == tupleC }"); // true
        Console.WriteLine($"tupleB == tupleE: { tupleB == tupleE }"); // false

        // .Equals not supported for this comparison - all of these are false
        Console.WriteLine($"tupleA.Equals(tupleD): { tupleA.Equals(tupleD) }");
        Console.WriteLine($"tupleB.Equals(tupleC): { tupleB.Equals(tupleC) }");
        Console.WriteLine($"tupleA.Equals(tupleF): { tupleA.Equals(tupleF) }");
        Console.WriteLine($"tupleB.Equals(tupleE): { tupleB.Equals(tupleE) }");
    }
}
