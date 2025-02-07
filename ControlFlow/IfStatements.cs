public class IfStatements
{
    public static void RunIfStatements()
    {
        if (true)
        {
            Console.WriteLine("This always prints");
        }

        if (false)
        {
            Console.WriteLine("This never prints");
        }

        bool condition = true;
        if (condition)
        {
            Console.WriteLine("Prints when the condition is true!");
        }

        if (condition)
        {
            Console.WriteLine("Prints when the condition is true!");
        }
        else
        {
            Console.WriteLine("Prints when the condition is false!");
        }

        if (condition)
        {
            Console.WriteLine("Prints when condition is true");
        }
        else if (!condition)
        {
            Console.WriteLine("Prints when condition is false");
        }
        else
        {
            Console.WriteLine("Trick");
        }

        int number = 6;

        if (number < 5)
        {
            Console.WriteLine("Number is less than 5");
        }
        else if (number == 5)
        {
            Console.WriteLine("Number is equal to 5");
        }
        else
        {
            Console.WriteLine("Number is greater than 5");
        }

        number = 6;
        if (number >= 1 && number <= 5)
        {
            Console.WriteLine("Number is between 1 and 5");
        }
        else
        {
            Console.WriteLine("Number is not between 1 and 5");
        }

        if (number < 1 || number > 5)
        {
            Console.WriteLine("Number is not between 1 and 5");
        }
        else
        {
            Console.WriteLine("Number is between 1 and 5");
        }
    }
}