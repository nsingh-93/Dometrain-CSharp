namespace ControlFlow;

public class TernaryOperators
{
    public static void RunTernary()
    {
        int x = 10;

        string result = x > 5 ? "x is greater than 5" : "x is less than 5";

        Console.WriteLine(result);

        result = x == 10 ? "x is equal to 10" : "x is not equal to 10";

        Console.WriteLine(result);

        result = x < 20 ? "x is less than 20" : "x is greater than 20";

        Console.WriteLine(result);
    }
}
