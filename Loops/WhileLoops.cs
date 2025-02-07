namespace Loops;

public class WhileLoops
{
    public static void RunWhileLoops()
    {
        int count = 0;

        while (count < 5)
        {
            Console.WriteLine(count);
            count++;
        }

        Console.WriteLine($"Total count is {count}!");


        count = 0;

        do
        {
            Console.WriteLine(count);
            count++;
        } while (count < 5);

        Console.WriteLine($"Total count is {count}!");


        count = 0;

        while (count > 5)
        {
            Console.WriteLine(count);
            count++;
        }

        Console.WriteLine($"Total count is {count}!");


        count = 0;

        do
        {
            Console.WriteLine(count);
            count++;
        } while (count > 5);

        Console.WriteLine($"Total count is {count}!");


        count = 0;

        while (count < 50)
        {
            if (count == 3)
            {
                count++;
                Console.WriteLine("I'm skipping 3");
                continue;
            }

            Console.WriteLine(count);
            count++;

            if (count == 5)
            {
                Console.WriteLine("Out of here");
                break;
            }
        }
    }
}
