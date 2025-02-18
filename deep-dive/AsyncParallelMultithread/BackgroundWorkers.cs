using System.ComponentModel;

namespace AsyncParallelMultithread;

public class BackgroundWorkers
{
    public static void RunBackgroundWorkers()
    {
        BackgroundWorker worker1 = new BackgroundWorker();

        // Can subscribe the DoWork event
        worker1.DoWork += (object sender, DoWorkEventArgs e) =>
        {
            //while (true)
            while (!worker1.CancellationPending)
            {
                Console.WriteLine("Worker 1: Working in the background");
                Thread.Sleep(1000);
            }

            Console.WriteLine("Worker 1: DoWork has completed");
        };

        worker1.WorkerSupportsCancellation = true;
        worker1.RunWorkerAsync();


        // Can pass parameters to background worker
        BackgroundWorker worker2 = new BackgroundWorker();

        worker2.DoWork += (sender, e) =>
        {
            int iter = (int)e.Argument;

            for (int i = 0; i< iter; i++)
            {
                Console.WriteLine($"Worker 2: Working in the background on iteration { i }");
                Thread.Sleep(1000);
            }

            //Console.WriteLine("Worker 2: DoWork has completed");
        };


        // Can also subscribe to RunWorkerCompleted
        /*
        worker2.RunWorkerCompleted += (sender, e) =>
        {
            Console.WriteLine("Worker 2: DoWork has completed");
        };
        */

        // Can also cancel background worker
        worker2.RunWorkerCompleted += (sender, e) =>
        {
            Console.WriteLine("Background Worker 2 has completed");
            worker1.CancelAsync();
        };

        Console.WriteLine("Press enter to exit");
        Console.ReadLine();
    }
}
