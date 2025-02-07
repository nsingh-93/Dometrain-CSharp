namespace BasicValueTypes;

public class StringVariables
{
    public static void RunStrings()
    {
        // STRINGS
        Console.WriteLine();
        // Declare
        string myString;
        string my_string;
        string MyString;

        // Assign
        myString = "Hello, World!";

        // Declare and assign
        string coolString = "Hello, World!";

        // Reassign
        coolString = "Goodbye, World!";

        // Concatenate
        string firstName = "John";
        string lastName = "Doe";
        string fullName = firstName + " " + lastName;

        // Output
        Console.WriteLine(fullName);

        // Read line
        myString = Console.ReadLine();

        // Length
        Console.WriteLine(myString.Length);

        // Individual characters
        Console.WriteLine(myString[0]);


        // Characters
        char myChar = 'a';
    }
}