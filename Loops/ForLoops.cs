public class ForLoops
{
    public static void RunForLoops()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(i);
        }

        for (int i = 0; i < 10; i++)
        {
            if (i == 5)
            {
                Console.WriteLine("Out of here");
                break;
            }

            Console.WriteLine(i);
        }

        for (int i = 0; i < 10; i++)
        {
            if (i == 5)
            {
                Console.WriteLine("Skipping 5");
                continue;
            }

            Console.WriteLine(i);
        }
    }
}