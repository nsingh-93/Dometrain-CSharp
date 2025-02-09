namespace ObjectOriented;

public class ReferenceTypes
{
    public static void RunReferenceTypes()
    {
        OurClass object1 = new OurClass();
        OurClass object2 = new OurClass();
        OurClass object3 = object1;

        Console.WriteLine("object1 == object2:");
        Console.WriteLine(object1 == object2); // false
        Console.WriteLine("object1 == object3:");
        Console.WriteLine(object1 == object3); // true

        // collections are very much the same!
        List<int> myNumbers1 = new List<int> { 1, 2, 3 };
        List<int> myNumbers2 = new List<int> { 1, 2, 3 };

        Console.WriteLine("myNumbers1 == myNumbers2:");
        Console.WriteLine(myNumbers1 == myNumbers2); // false

        void ChangeValue(int value)
        {
            value = 42;
        }

        int myValue = 1337;

        Console.WriteLine("myValue before ChangeValue:");
        Console.WriteLine(myValue); // 1337

        ChangeValue(myValue);

        Console.WriteLine("myValue after ChangeValue:");
        Console.WriteLine(myValue); // 1337

        void ChangeReference(List<string> words)
        {
            words = new List<string>();
            words.Add("from");
            words.Add("Dev");
            words.Add("Leader");
        }

        List<string> myWords = new List<string> { "Hello", "World" };

        Console.WriteLine("myWords before ChangeReference:");
        Console.WriteLine(string.Join(" ", myWords)); // Hello World

        ChangeReference(myWords);

        Console.WriteLine("myWords after ChangeReference:");
        Console.WriteLine(string.Join(" ", myWords)); // Hello World from Dev Leader
    }

    class OurClass
    {

    }
}
