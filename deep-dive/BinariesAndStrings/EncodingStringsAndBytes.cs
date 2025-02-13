using System.Text;

namespace BinariesAndStrings;

public class EncodingStringsAndBytes
{
    public static void RunEncoding()
    {
        string helloWorld = "Hello World!";
        byte[] bytesForHelloWorldAsAscii = Encoding.ASCII.GetBytes(helloWorld);

        string helloWorldConvertedBack = Encoding.ASCII.GetString(bytesForHelloWorldAsAscii);

        Console.WriteLine($"Converting '{ helloWorld }' to bytes and back with ASCII");
        Console.WriteLine($" Original: { helloWorld }");
        Console.WriteLine($"Converted: { helloWorldConvertedBack }");
        Console.WriteLine();

        // Unsupported characters in string
        string unsupportedAsciiString = "😀 I'm in danger!";
        byte[] unsupportedAsciiBytes = Encoding.ASCII.GetBytes(unsupportedAsciiString);
        string convertedBackFromUnsupportedAscii = Encoding.ASCII.GetString(unsupportedAsciiBytes);

        Console.WriteLine("Converting to ASCII and back with unsupported characters");
        Console.WriteLine($" Original: { unsupportedAsciiString }");
        Console.WriteLine($"Converted: { convertedBackFromUnsupportedAscii }");
        Console.WriteLine($" Original String Length: { unsupportedAsciiString.Length }");
        Console.WriteLine($"Converted String Length: { convertedBackFromUnsupportedAscii.Length }");
        Console.WriteLine($"     ASCII Bytes Length: { unsupportedAsciiBytes.Length }");
        Console.WriteLine($"Strings Equal: { unsupportedAsciiString == convertedBackFromUnsupportedAscii }");
        Console.WriteLine($"First Chars Equal: { unsupportedAsciiString[0] == convertedBackFromUnsupportedAscii[0] }");
        Console.WriteLine();

        // Unicode to take care of that
        byte[] unsupportedStringAsUtf8Bytes = Encoding.UTF8.GetBytes(unsupportedAsciiString);
        string unsupportedStringAsUtf8 = Encoding.UTF8.GetString(unsupportedStringAsUtf8Bytes);

        Console.WriteLine("Converting to UTF-8 and back with the original characters");
        Console.WriteLine($" Original: { unsupportedAsciiString }");
        Console.WriteLine($"Converted: { unsupportedStringAsUtf8 }");
        Console.WriteLine($"   Original Length: { unsupportedAsciiString.Length }");
        Console.WriteLine($"  Converted Length: { unsupportedStringAsUtf8.Length }");
        Console.WriteLine($"ASCII Bytes Length: { unsupportedAsciiBytes.Length }");
        Console.WriteLine($" UTF8 Bytes Length: { unsupportedStringAsUtf8Bytes.Length }");
        Console.WriteLine($"Strings Equal: { unsupportedAsciiString == unsupportedStringAsUtf8 }");
        Console.WriteLine($"First Chars Equal: { unsupportedAsciiString[0] == unsupportedStringAsUtf8[0] }");
        Console.WriteLine();
    }
}
