namespace ObjectOriented;

public class FieldsAndProperties
{
    public static void RunFieldsAndProperties()
    {
        Person2 john = new Person2();
        // john._name = "John"; // this will not work because _name is private


        Person3 johnWithMethod = new Person3();


        Person4 johnWithProperty = new Person4();

        Console.WriteLine(johnWithProperty.Name);
        Console.WriteLine(johnWithProperty.Name2);
        Console.WriteLine(johnWithProperty.Name3);

        Console.WriteLine("Setting the name...");

        johnWithProperty.MutableName = "John Doe";
        
        Console.WriteLine(johnWithProperty.MutableName);
        Console.WriteLine(johnWithProperty.Name);
        Console.WriteLine(johnWithProperty.Name2);
        Console.WriteLine(johnWithProperty.Name3);
    }

    class Person
    {
        private string? _name; // made nullable
    }

    class Person2
    {
        private string _name = "John";
    }

    class Person3
    {
        private string _name = "John";

        public string GetName()
        {
            return _name;
        }
    }

    class Person4
    {
        private string _name = "John";

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public string Name2 => _name;

        public string Name3 { get; } = "John";

        public string MutableName
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}
