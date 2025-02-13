namespace BinariesAndStrings;

public class UsingAndDisposing
{
    public class MyDisposable : IDisposable
    {
        public void Dispose()
        {
            // Release resources owned by object
        }
    }

    public static void RunUsingDisposing()
    {
        // An exception could happen and not let code get to Dispose function
        Stream readmeStream = File.Open("readme.txt", FileMode.Open, FileAccess.Read);

        readmeStream.Dispose();


        // Need to make sure we release resources after doing work
        readmeStream = File.Open("readme.txt", FileMode.Open, FileAccess.Read);
        try
        {

        }
        catch
        {

        }
        finally
        {
            readmeStream.Dispose();
        }

        // Can use Using statement to clean up having to use try catch finally blocks
        using (Stream myUsingStream = File.Open("readme.txt", FileMode.Open, FileAccess.Read))
        {

        }

        // Can aso do it like this
        using Stream myUsingStream2 = File.Open("readme.txt", FileMode.Open, FileAccess.Read);
    }
}
