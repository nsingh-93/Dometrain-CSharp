namespace AdvancedMethods;

// The requirements are:
// - Static class
// - Static method on the class
// - Need"this" keyword on the parameter that we are "extending"
// - Parameter marked with "this" must be the first parameter
public static class Extensions
{
    public static string Reverse(this string str)
    {
        var reversedChars = str
                        .Reverse<char>()
                        .ToArray();

        var reversed = new string(reversedChars);

        return reversed;
    }
}

public class ExtensionMethods
{
    public static void RunExtensions()
    {
        // Class name only matters if calling staticly
        var reversedStr = Extensions.Reverse("Hello World");

        // Looks built in to string class
        var forwardStr = reversedStr.Reverse();

        // LINQ uses extension methods
        IEnumerable<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
        var evenNumbers = numbers.Where(n => n % 2 == 0);
    }
}
