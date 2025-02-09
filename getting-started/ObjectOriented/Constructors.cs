namespace ObjectOriented;

public class Constructors
{
    public static void RunConstructors()
    {
        ExplicitConstructor expCtor = new();

        ConstructorWithParameter ctorWithParam = new("Hello there");

        CollectionOfWords coll = new();

        coll.Add("First");
        coll.Add("Second");
        coll.Add("Third");

        coll.Print();

        var t1 = new StaticConstructor();
        var t2 = new StaticConstructor();

        ClassWithAHiddenConstructor hiddenCtor = new(1214);
        Console.ReadLine();
    }

    // Has unseen constructor
    class ImplicitConstructor
    {
    }

    // Has parameterless constructor
    class ExplicitConstructor
    {
        public ExplicitConstructor()
        {
            Console.WriteLine("ExplicitConstructor constructor called");
        }
    }

    // Has constructor that takes value
    class ConstructorWithParameter
    {
        public ConstructorWithParameter(string message)
        {
            Console.WriteLine(message);
        }
    }

    // Multiple constructors "chained" together by using : this() syntax
    class MultipleConstructors
    {
        public MultipleConstructors()
            : this("Default message")
        {
        }

        public MultipleConstructors(string message)
        {
            Console.WriteLine(message);
        }
    }

    class CollectionOfWords
    {
        private List<string> _strings;

        public CollectionOfWords()
        {
            _strings = new List<string>();
        }

        public void Add(string word)
        {
            _strings.Add(word);
        }

        public void Print()
        {
            foreach (var word in _strings)
            {
                Console.WriteLine(word);
            }
        }
    }

    class CollectionOfWords2
    {
        private List<string> _strings;

        public CollectionOfWords2(List<string> words)
        {
            _strings = new List<string>();

            foreach (var word in words)
            {
                _strings.Add(word);
            }
        }
        public void Print()
        {
            foreach (var word in _strings)
            {
                Console.WriteLine(word);
            }
        }
    }

    class StaticConstructor
    {
        static StaticConstructor()
        {
            Console.WriteLine("StaticConstructor constructor called");
        }
    }

    class ClassWithAHiddenConstructor
    {
        public ClassWithAHiddenConstructor(int value) : this()
        {
            Console.WriteLine($"Public constructor and we received value {value}");
        }

        private ClassWithAHiddenConstructor() : this("Test message for chaining constructors")
        {
            Console.WriteLine("Nobody can call this constructor directly from outside");
        }

        private ClassWithAHiddenConstructor(string message)
        {
            Console.WriteLine($"{message}");
        }
    }
}
