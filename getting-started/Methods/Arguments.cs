namespace Methods;

public class Arguments
{
    public static void RunArguments()
    {
        void MyMethod(string name, int age)
        {

        }

        MyMethod("Neil", 31);

        void PrintSeparator()
        {
            Console.WriteLine("-------");
        }

        void PrintHeader(string name)
        {
            PrintSeparator();
            Console.WriteLine(name);
            PrintSeparator();
        }

        PrintHeader("Example 1:");
        PrintHeader("Example 2:");
        PrintHeader("Example 3:");
    }
}
