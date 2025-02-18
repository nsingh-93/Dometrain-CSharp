namespace AsyncParallelMultithread;

public class Threads
{
    public record ThreadContext(
        string Name,
        string Message
    );

    public static void RunThreads()
    {
        Thread thread = new Thread(() =>
        {
            // Do something here
        });

        thread.Start();


        // Passing parameters to threads
        ThreadContext thread1Context = new(
            Name: "Thread 1",
            Message: "Hello from thread 1"
        );

        Thread thread1 = new Thread(new ParameterizedThreadStart(o =>
        {
            ThreadContext context = (ThreadContext)o;

            Thread.CurrentThread.Name = context.Name;
            Console.WriteLine($"{ Thread.CurrentThread.Name }: { context.Message }");
        }));

        thread1.Start(thread1Context);


        // Threads can help run work in the background
        ThreadContext thread2Context = new(
            Name: "Thread 2",
            Message: "Hello from thread 2"
        );

        Thread thread2 = new Thread(new ParameterizedThreadStart(o =>
        {
            ThreadContext context = (ThreadContext)o;

            Thread.CurrentThread.Name = context.Name;

            while (true)
            {
                Console.WriteLine($"{ Thread.CurrentThread.Name }: { context.Message }");
                Thread.Sleep(1000);
            }
        }));

        thread2.Start(thread2Context);


        // Threads can be set to background which stop when main thread stops
        ThreadContext thread3Context = new(
            Name: "Thread 3",
            Message: "Hello from thread 3"
        );

        Thread thread3 = new Thread(new ParameterizedThreadStart(o =>
        {
            ThreadContext context = (ThreadContext)o;

            Thread.CurrentThread.Name = context.Name;

            while (true)
            {
                Console.WriteLine($"{ Thread.CurrentThread.Name }: { context.Message }");
                Thread.Sleep(1000);
            }
        }));

        thread3.IsBackground = true;
        thread3.Start(thread3Context);

        Console.WriteLine("Press enter to stop thread3");
        Console.ReadLine();
    }
}
