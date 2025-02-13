using System.Text;

namespace BinariesAndStrings;

public class ReadingWritingFiles
{
    public static void RunReadingWriting()
    {
        File.WriteAllText("some-file.txt", "Hello, World!");
        File.WriteAllBytes("some-file.txt", Encoding.UTF8.GetBytes("Hello world from Neil"));
        byte[] someFileBytes = File.ReadAllBytes("some-file.txt");
        string someFileString = File.ReadAllText("some-file.txt");


        FileStream fileStream = File.Open("some-file.txt", FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read);
        byte[] buffer = Encoding.UTF8.GetBytes("Hello, World!");
        fileStream.Write(buffer, 0, buffer.Length);

        Stream fileStreamAsStream = fileStream;
        fileStreamAsStream.Seek(0, SeekOrigin.Begin);
        fileStreamAsStream.Write(buffer, 0, buffer.Length);

        fileStream.Close();

        FileStream readingStream = File.Open("some-file.txt", FileMode.Open, FileAccess.Read, FileShare.None);


        byte[] bufferForReading = new byte[readingStream.Length];
        var bytesReadFromStream = readingStream.Read(bufferForReading, 0, bufferForReading.Length);

        // If the file is very large
        readingStream.Seek(0, SeekOrigin.Begin);
        StreamReader reader = new StreamReader(readingStream, encoding: Encoding.UTF8);

        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            Console.WriteLine(line);
        }


        // Reading in chunks
        int chunkSize = 7; // 1024;
        
        Console.WriteLine($"Reading chunks of size { chunkSize } of file");
        
        readingStream.Seek(0, SeekOrigin.Begin);
        byte[] bufferForChunking = new byte[chunkSize];
        
        while ((bytesReadFromStream = readingStream.Read(bufferForChunking, 0, bufferForChunking.Length)) > 0)
        {
            Console.WriteLine($"Read { bytesReadFromStream } bytes for this chunk");
        }
    }
}
