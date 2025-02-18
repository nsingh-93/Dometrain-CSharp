using System.Threading.Tasks;

namespace AsyncParallelMultithread;

public class CancellationTokens
{
    public static async Task RunCancellationTokens()
    {
        CancellationTokenSource cts = new CancellationTokenSource();
        var cancellationToken = cts.Token;

        async Task LoopUntilCancelledAsync(CancellationToken cancellationToken)
        {
            await Task.Yield();

            Console.WriteLine("Looping until cancelled");

            while (!cancellationToken.IsCancellationRequested)
            {
                Console.WriteLine("Waiting");

                // Cancellation causes an exception so should wrap this in try catch
                //await Task.Delay(3000, cancellationToken);

                try
                {
                    await Task.Delay(3000, cancellationToken);
                }
                catch (OperationCanceledException)
                {
                    break;
                }
            }

            Console.WriteLine("Cancelled");
        }

        Console.WriteLine("Press enter to cancel the loop");

        Task loopTask = LoopUntilCancelledAsync(cancellationToken);

        Console.ReadLine();
        cts.Cancel();

        await loopTask;


        // Chaining cancellations together
        CancellationTokenSource cts2 = new CancellationTokenSource();
        var cancellationToken2 = cts2.Token;

        var linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken2);
        var linkedToken = linkedTokenSource.Token;

        Console.WriteLine("Using a linked token source");
        Console.WriteLine("Press enter to cancel the loop");

        Task loopTask2 = LoopUntilCancelledAsync(linkedToken);

        Console.ReadLine();
        cts2.Cancel();

        await loopTask2;
    }
}
