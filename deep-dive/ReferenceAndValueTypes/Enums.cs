namespace ReferenceAndValueTypes;

public class Enums
{
    enum DaysOfWeek
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }

    enum DaysOfWeek2
    {
        Monday = 1,
        Tuesday = 2,
        Wednesday = 3,
        Thursday = 4,
        Friday = 5,
        Saturday = 6,
        Sunday = 7
    }

    [Flags]
    // Flags are in powers of 2
    enum Permissions
    {
        None = 0,   // 0000 0000
        Read = 1,   // 0000 0001
        Write = 2,  // 0000 0010
        Execute = 4 // 0000 0100
    }

    public static void RunEnums()
    {
        int monday = (int)DaysOfWeek.Monday;

        Console.WriteLine($"Enum Value Directly: {DaysOfWeek.Monday}");
        Console.WriteLine($"Enum Value Casted: {(int)DaysOfWeek.Monday}");

        // Cannot cast enum to string, must use ToString()
        string stringMonday = DaysOfWeek.Monday.ToString();

        // Going from string to enum
        DaysOfWeek mondayEnum = (DaysOfWeek)Enum.Parse(typeof(DaysOfWeek), "Monday");
        DaysOfWeek mondayEnum2 = Enum.Parse<DaysOfWeek>("Monday");

        DaysOfWeek mondayEnum3;
        bool parseSucceeded = Enum.TryParse("Monday", out mondayEnum3);

        Console.WriteLine($"Enum { (parseSucceeded ? "Parsed" : "Not Parsed") }: { mondayEnum3 }");


        Console.WriteLine("All Enum Values:");
        foreach (DaysOfWeek day in Enum.GetValues(typeof(DaysOfWeek)))
        {
            Console.WriteLine($"Enum Value: { (int)day }");
        }

        Console.WriteLine("All Enum Names:");
        foreach (string day in Enum.GetNames(typeof(DaysOfWeek)))
        {
            Console.WriteLine($"Enum Name: { day }");
        }

        DaysOfWeek invalidDay = (DaysOfWeek)8;

        Console.WriteLine($"Invalid Enum Value: { invalidDay }");

        // Combining flags
        Permissions readWrite = Permissions.Read | Permissions.Write;
        // Creates a comma separated list of the flags when ToString() is used on it
        Console.WriteLine($"RW: {readWrite}");

        bool canRead = (readWrite & Permissions.Read) == Permissions.Read;
        bool canWrite = (readWrite & Permissions.Write) == Permissions.Write;
        bool canExecute = (readWrite & Permissions.Execute) == Permissions.Execute;

        Console.WriteLine($"Can Read: {canRead}");
        Console.WriteLine($"Can Write: {canWrite}");
        Console.WriteLine($"Can Execute: {canExecute}");
    }
}
