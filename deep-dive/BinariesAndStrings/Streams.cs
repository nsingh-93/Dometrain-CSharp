using System.Text;

namespace BinariesAndStrings;

public class Streams
{
    public static void RunStreams()
    {
        MemoryStream memoryStream = new MemoryStream();

        Console.WriteLine("Writing data to memory stream");
        Console.WriteLine($"Stream Position Before: { memoryStream.Position }");
        Console.WriteLine($"Stream Length Before: { memoryStream.Length }");
        Console.WriteLine($"Stream Capacity Before: { memoryStream.Capacity }");


        byte[] data = Encoding.UTF8.GetBytes("Hello, world From Neil");

        memoryStream.Write(data, 0, data.Length);

        Console.WriteLine($"Stream Position After: { memoryStream.Position }");
        Console.WriteLine($"Stream Length After: { memoryStream.Length }");
        Console.WriteLine($"Stream Capacity After: { memoryStream.Capacity }\n");


        Console.WriteLine("Repositioning memory stream");
        memoryStream.Seek(0, SeekOrigin.Begin);
        // or
        memoryStream.Position = 0;

        Console.WriteLine($"Stream Position After: {memoryStream.Position}");

        byte[] readBuffer = new byte[memoryStream.Length];

        Console.WriteLine("Reading data from memory stream");

        int numberOfBytesRead = memoryStream.Read(readBuffer, 0, readBuffer.Length);

        Console.WriteLine($"Number of bytes read: { numberOfBytesRead }");

        string readString = Encoding.UTF8.GetString(readBuffer);

        Console.WriteLine($"Read string: {readString}\n");

        Console.WriteLine("Reading data from memory stream using ToArray()");

        byte[] memoryStreamBytes = memoryStream.ToArray();
        readString = Encoding.UTF8.GetString(memoryStreamBytes);

        Console.WriteLine($"Read string: { readString }");
    }
}
