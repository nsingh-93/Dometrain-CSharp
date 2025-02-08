namespace ObjectOriented;

public class Classes
{
    public void RunClasses()
    {
        OurClass ourObject = new OurClass();

        // Short form
        OurClass ourObject2 = new();

        // New instance
        OurSecondClass ourSecondObject = new();
        ourSecondObject.ExampleMethod();

        int result = ourSecondObject.ExampleFunction();

        Console.WriteLine("Method on the Console class");
    }

    class OurClass
    {

    }

    public class OurSecondClass
    {
        public void ExampleMethod()
        {
            Console.WriteLine("Hello from method");
        }

        public int ExampleFunction()
        {
            return 42;
        }
    }
}
