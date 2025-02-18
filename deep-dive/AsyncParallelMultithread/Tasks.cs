namespace AsyncParallelMultithread;

public class Tasks
{
    public static void RunTasks()
    {
        Console.WriteLine($"Main Thread Id: { Thread.CurrentThread.ManagedThreadId }");

        Task task1 = Task.Run(() =>
        {
            Console.WriteLine($"Task 1 Thread Id: { Thread.CurrentThread.ManagedThreadId }");
        });

        Task task2 = Task.Run(() =>
        {
            Console.WriteLine($"Task 2 Thread Id: { Thread.CurrentThread.ManagedThreadId }");
        });

        Task task3 = Task.Run(() =>
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Task 3 Thread Id: { Thread.CurrentThread.ManagedThreadId } ({ i })");
                Thread.Sleep(1000);
            }
        });

        // Need to wait for all tasks to finish
        Task.WaitAll(task1, task2, task3);
        Console.WriteLine("Tasks 1, 2, and 3 have finished");


        // Wait for 3 tasks to finish then run 4th task
        Task task4 = Task.Run(() =>
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Task 4 Thread Id: { Thread.CurrentThread.ManagedThreadId } ({ i })");
                Thread.Sleep(500);
            }
        });

        task4.Wait();
        Console.WriteLine("Task 4 has finished");


        // Also have builder patterns to chain tasks -  can be used to construct pipelines
        Task task5 = Task.Run(() =>
        {
            Console.WriteLine($"Task 5 Thread Id: { Thread.CurrentThread.ManagedThreadId }");
        }).ContinueWith((prevTask) =>
        {
            Console.WriteLine($"Task 5 Continuation Thread Id: { Thread.CurrentThread.ManagedThreadId }");
        });

        task5.Wait();



        Task task6 = Task.Run(() =>
        {
            Console.WriteLine($"Task 6 Thread Id: { Thread.CurrentThread.ManagedThreadId }");
        }).ContinueWith((prevTask) =>
        {
            Console.WriteLine($"Task 6 Continuation Thread Id: { Thread.CurrentThread.ManagedThreadId }");
            throw new Exception("Meant to do this");
        }).ContinueWith((prevTask) =>
        {
            Console.WriteLine($"Task 6 Continuation 2 Thread Id: { Thread.CurrentThread.ManagedThreadId }");
            Console.WriteLine($"{ prevTask.Exception.GetType().Name }: { prevTask.Exception.Message }");
        }, TaskContinuationOptions.OnlyOnFaulted);

        task6.Wait();


        // Aggregate exceptions are a way to handle multiple exceptions that can happen with tasks
        AggregateException aggregateException = new(
            "This is the aggregate exception message",
            new InvalidOperationException("This is the first inner exception"),
            new ArgumentException("This is the second inner exception")
        );

        try
        {
            throw aggregateException;
        }
        catch (AggregateException e)
        {
            Console.WriteLine($"{ e.GetType().Name }: { e.Message }");
            
            foreach (Exception innerEx in e.InnerExceptions)
            {
                Console.WriteLine($"\t{ innerEx.GetType().Name }: { innerEx.Message }");
            }
        }
    }
}
