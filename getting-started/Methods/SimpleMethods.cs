namespace Methods;

public class SimpleMethods
{
    public static void RunSimpleMethods()
    {
        void ThisIsAMethod()
        {
            // method body
        }

        ThisIsAMethod();

        Console.WriteLine("-----------");
        Console.WriteLine("New Example");
        Console.WriteLine("-----------");

        void PrintSeparator()
        {
            Console.WriteLine("-----------");
        }

        PrintSeparator();
        Console.WriteLine("New Example");
        PrintSeparator();

        void PrintHeader()
        {
            PrintSeparator();
            Console.WriteLine("New Example");
            PrintSeparator();
        }

        PrintHeader();
    }
}
