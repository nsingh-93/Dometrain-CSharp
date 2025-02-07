namespace BasicValueTypes;

public class Casting
{
    public static void RunCastings()
    {
        // CASTING/PARSING
        Console.WriteLine();
        // Implicit casting
        int myInt = 6;
        double myDouble = myInt;
        Console.WriteLine("Implicit Cast");
        Console.WriteLine($"myInt = {myInt}");
        Console.WriteLine($"myDouble = {myDouble}");

        // Explicit casting
        double myDouble2 = 5.5;
        int myInt2 = (int)myDouble2;
        Console.WriteLine("Explicit Cast");
        Console.WriteLine($"myDouble2 = {myDouble2}");
        Console.WriteLine($"myInt2 = {myInt2}");

        // String casting
        string myString = "5";

        myInt = int.Parse(myString);
        Console.WriteLine("Parsing");
        Console.WriteLine($"myString = {myString}");
        Console.WriteLine($"myInt = {myInt}");

        myString = "5.7";

        myDouble = double.Parse(myString);
        Console.WriteLine("Parsing");
        Console.WriteLine($"myString = {myString}");
        Console.WriteLine($"myDouble = {myDouble}");
    }
}