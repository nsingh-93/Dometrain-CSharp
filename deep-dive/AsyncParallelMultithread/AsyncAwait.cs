using System.Threading.Tasks;

namespace AsyncParallelMultithread;

public class AsyncAwait
{
    public static async Task RunAsyncAwait()
    {
        async Task FirstAsyncMethod()
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
        }

        // Task<T> to return data
        async Task<int> SecondAsyncMethod()
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            return 2;
        }

        Console.WriteLine("awaiting first async method");

        await FirstAsyncMethod();


        Console.WriteLine("awaiting first async method again");

        Task firstAsyncMethod = FirstAsyncMethod();
        await firstAsyncMethod;


        // Able to run many async methods
        async Task<string> ThirdAsyncMethod(TimeSpan timeToWait, string messageToWrite)
        {
            await Task.Delay(timeToWait);
            Console.WriteLine(messageToWrite);

            return messageToWrite;
        }

        Console.WriteLine("Starting 3 async methods");

        Task<string> task1 = ThirdAsyncMethod(TimeSpan.FromSeconds(1), "Task 1 has finished");
        Task<string> task2 = ThirdAsyncMethod(TimeSpan.FromSeconds(3), "Task 2 has finished");
        Task<string> task3 = ThirdAsyncMethod(TimeSpan.FromSeconds(6), "Task 3 has finished");

        Console.WriteLine("Waiting for all 3 async methods");

        await Task.WhenAll(task1, task2, task3);

        Console.WriteLine("All 3 async methods have finished");

        // When only the first one completed is needed
        // Task<string> firstTaskToComplete = await Task.WhenAny(task1, task2, task3);


        // Async doesn't make everything asynchronous automatically
        async Task NotActuallyAsync()
        {
            Console.WriteLine("Entering NotActuallyAsync");
            Thread.Sleep(1000); // This blocks it from running async

            Console.WriteLine("Exiting NotActuallyAsync");
            // Not actually awaiting for anything
        }

        Console.WriteLine("Calling NotActuallyAsync");
        Task notActuallyAsyncTask = NotActuallyAsync();   

        Console.WriteLine("awaiting NotActuallyAsync");  
        await notActuallyAsyncTask;  
        
        Console.WriteLine("Finished awaiting NotActuallyAsync");


        async Task LeverageTaskYield()
        {
            Console.WriteLine("Entering LeverageTaskYield");
            await Task.Yield();

            Console.WriteLine("Continuing from LeverageTaskYield");
            Thread.Sleep(1000);

            Console.WriteLine("Exiting LeverageTaskYield");
        }

        // The yield allows the scheduler to run other things while running the task
        Console.WriteLine("Calling LeverageTaskYield");
        Task leverageTaskYieldTask = LeverageTaskYield();

        Console.WriteLine("awaiting LeverageTaskYield");
        await leverageTaskYieldTask;

        Console.WriteLine("Finished awaiting LeverageTaskYield");


        // Introducing async await needs to be used all the way through
        async Task TestCatchingExceptions()
        {
            Console.WriteLine("TestCatchingExceptions ThisIsNotATask");
            await Task.Delay(TimeSpan.FromSeconds(1));

            Console.WriteLine("Finished delay inside TestCatchingExceptions");

            Console.WriteLine("Calling async method");

            try
            {
                await ThisIsATask();

                // Cannot await even though it is async because it does not return a Task
                // await ThisIsNotATask();  Does not work
                ThisIsNotATask();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Caught exception from async method: { ex.Message }");
            }
        }

        async Task ThisIsATask()
        {
            // Can await in here because it's async
            Console.WriteLine("Entering ThisIsATask");
            await Task.Delay(TimeSpan.FromSeconds(1));

            Console.WriteLine("Finished delay inside ThisIsATask");

            throw new Exception("ThisIsATask has thrown an exception");
        }

        async void ThisIsNotATask()
        {
            // Can await in here because it's async
            Console.WriteLine("Entering ThisIsNotATask");
            await Task.Delay(TimeSpan.FromSeconds(1));

            Console.WriteLine("Finished delay inside ThisIsNotATask");

            // Program finishes before it can even get here
            throw new Exception("ThisIsNotATask has thrown an exception");
        }

        await TestCatchingExceptions();

        // This lets the program run long enough to fully run the ThisIsNotATask function
        Console.ReadLine();

        // async void shouldn't be used in situations except for a select few, like event handlers
        // Use try-catch in async void functions
    }
}
