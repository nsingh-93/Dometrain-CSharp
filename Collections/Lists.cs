public class Lists
{
    public static void RunLists()
    {
        List<string> words = new List<string>();

        words.Add("one");
        words.Add("two");
        words.Add("three");

        string firstWord = words[0];
        string secondWord = words[1];
        string thirdWord = words[2];

        words[0] = "four";
       
        List<int> numbers = new List<int>
        {
            1,
            2,
            3,
            4,
        };

        int count = numbers.Count;

        numbers.Remove(1);
        numbers.Remove(2);
        numbers.Remove(3);

        numbers.Insert(0, 1);
        numbers.Insert(0, 2);
        numbers.Insert(1, 3);

        numbers.Clear();
        
        words.Sort();
    }
}