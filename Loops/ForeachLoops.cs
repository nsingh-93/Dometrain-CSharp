public class ForeachLoops
{
    public static void RunForeachLoops()
    {
        int[] numbers = [1, 2, 3, 4, 5];

        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }

        List<string> words = new List<string>
        {
            "red",
            "green",
            "blue",
        };

        foreach (string word in words)
        {
            Console.WriteLine(word);
        }

        Dictionary<string, int> ages = new()
        {
            { "Alice", 25 },
            { "Bob", 24 },
            { "Charlie", 26 },
        };

        foreach (var person in ages)
        {
            Console.WriteLine($"{person.Key} is {person.Value} years old");
        }

        foreach (int number in numbers)
        {
            if (number == 3)
            {
                break;
            }

            Console.WriteLine(number);
        }
    }
}