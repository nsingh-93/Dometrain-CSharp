namespace AdvancedMethods;

public static class MyLinq
{
    public static IEnumerable<T> FancyLinqMethod<T>(this IEnumerable<T> source, Func<T, T> selector)
    {
        foreach (T item in source)
        {
            Console.WriteLine($"Applying selector to { item }");
            yield return selector(item);
        }
    }
}

public class Linq
{
    public static void RunLinq()
    {
        List<string> rawNumbers = ["1", "2", "3", "4", "5"];

        List<int> numbers = new();
        foreach (string rawNumber in rawNumbers)
        {
            numbers.Add(int.Parse(rawNumber));
        }

        var numbers2 = rawNumbers
            .Select(num => int.Parse(num))
            .ToList();


        List<int> evenNumbers = new();
        foreach (int number in numbers)
        {
            if (number % 2 == 0)
            {
                evenNumbers.Add(number);
            }
        }

        var evenNumbers2 = evenNumbers
            .Where(num => num % 2 == 0)
            .ToList();

        
        // Without LINQ
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        double average = sum / (double)numbers.Count;

        // Use Average() from LINQ:
        var averageByLinq = numbers.Average();


        List<string> biggerListOfRawNumbers = [ "0", "9", "1", "8", "2", "7", "3", "6", "4", "5"];

        var magicNumber = biggerListOfRawNumbers
            .Select(int.Parse) // converts to integers
            .OrderByDescending(num => num)
            .TakeLast(5) // should only take 4 to 0
            .Where(num => num % 2 == 0) // evens
            .Average(); // should be 2

        Console.WriteLine($"Magic number is { magicNumber }");
        
        // LINQ methods are lazy because they are iterators
        Console.WriteLine("Press enter to start the lazy example.");
        Console.ReadLine();
        Console.WriteLine("Before the LINQ line for lazyNumbersAsStrings");

        var lazyNumbersAsStrings = numbers
            .Select(number =>
            {
                Console.WriteLine($"Transforming { number } to a string");
                return number.ToString();
            });

        Console.WriteLine("After the LINQ line for lazyNumbersAsStrings");

        // Force enumeration
        Console.WriteLine("Before forcing enumeration of lazyNumbersAsStrings");

        lazyNumbersAsStrings.ToArray();

        Console.WriteLine("After forcing enumeration of lazyNumbersAsStrings");
                
                
        Console.WriteLine("Press enter to start expensive operation");
        Console.ReadLine();

        var expensiveToCalculate = numbers
            .Select(number =>
            {
                Console.WriteLine($"Transforming { number } to a string");
                Thread.Sleep(1000);
                return number.ToString();
            });

        Console.WriteLine("Before first enumeration of expensive operation");

        foreach (var numberAsString in expensiveToCalculate)
        {
            Console.WriteLine(numberAsString);
        }

        Console.WriteLine("After first enumeration of expensive operation");

        Console.WriteLine("Before second enumeration of expensive operation");

        foreach (var numberAsString in expensiveToCalculate)
        {
            Console.WriteLine(numberAsString);
        }

        Console.WriteLine("After second enumeration of expensive operation");
        
        // Custom LINQ functions
        var myLinqResult = numbers
            .FancyLinqMethod(num => num * 2);

        foreach (var number in myLinqResult)
        {
            Console.WriteLine(number);
        }
    }
}
