public class IntegerVariables
{
    public void RunIntegers()
    {
        // INTEGERS
        Console.WriteLine();
        // Declare
        int myInt;
        int my_int;
        int MyInt;

        // Assign
        myInt = 5;

        //Declare and assign
        int coolInt = 5;

        // Reassign
        coolInt = 10;

        // Do math
        int sum = 10 + 5;
        int difference = 10 - 5;
        int product = 10 * 5;
        int quotient = 5 / 10;

        // String interpolation
        Console.WriteLine($"10 + 5 = {sum}");
        Console.WriteLine($"10 - 5 = {difference}");
        Console.WriteLine($"10 * 5 = {product}");
        Console.WriteLine($"5 / 10 = {quotient}");
    }
}