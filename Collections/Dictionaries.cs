namespace Collections;

public class Dictionaries
{
    public static void RunDicts()
    {
        Dictionary<string, int> wordsToNumbers = new Dictionary<string, int>();
        Dictionary<int, string> numbersToWords = new Dictionary<int, string>();
        Dictionary<string, int> shorthand = new();

        wordsToNumbers.Add("one", 1);
        wordsToNumbers.Add("two", 2);
        wordsToNumbers.Add("three", 3);

        int one = wordsToNumbers["one"];
        int two = wordsToNumbers["two"];
        int three = wordsToNumbers["three"];

        wordsToNumbers["one"] = 111;
        wordsToNumbers["two"] = 222;

        Dictionary<int, string> numbersToWords2 = new Dictionary<int, string>
        {
            { 1, "one" },
            { 2, "two" },
            { 3, "three" },
            { 4, "four" },
        };

        Dictionary<int, string> numbersToWords3 = new Dictionary<int, string>
        {
            [1] = "one",
            [2] = "two",
            [3] = "three",
            [4] = "four",
        };

        Dictionary<int, string> numbersToWords4 = new()
        {
            [1] = "one",
            [2] = "two",
            [3] = "three",
            [4] = "four",
        };

        int count = numbersToWords2.Count;

        numbersToWords2.Remove(1);
        numbersToWords2.Remove(2);


        numbersToWords3.Clear();
        numbersToWords4.Clear();

        bool contains = numbersToWords2.ContainsKey(3);

        bool contains2 = numbersToWords2.TryGetValue(3, out string? value);

        // Error caused here
        wordsToNumbers["one"] = 1;
        numbersToWords2[1] = "one";
    }
}
