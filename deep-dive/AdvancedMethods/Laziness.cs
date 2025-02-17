namespace AdvancedMethods;

// Lazy class gives us singleton like behavior not visible gloabally
public class Laziness
{
    public static void RunLaziness()
    {
        Lazy<int> lazyValue = new(() =>
        {
            Console.WriteLine("This will run only once.");
            Console.WriteLine("Finding max value");

            int[] numbers = [35, 20, 30, 40, 50];

            int max = int.MinValue;

            foreach (var num in numbers)
            {
                if (num > max)
                {
                    max = num;
                }

                // Just to make this seem expensive
                Thread.Sleep(1000);
            }

            Console.WriteLine($"The max value is { max }");

            return max;
        });

        Console.WriteLine($"The value of lazyValue is { lazyValue.Value }");
        // Computes once and the others are already stored - This also makes it thread safe
        Console.WriteLine($"The value of lazyValue is { lazyValue.Value }");
        Console.WriteLine($"The value of lazyValue is { lazyValue.Value }");
        Console.WriteLine($"The value of lazyValue is { lazyValue.Value }");
        Console.WriteLine($"The value of lazyValue is { lazyValue.Value }");
    }
}
