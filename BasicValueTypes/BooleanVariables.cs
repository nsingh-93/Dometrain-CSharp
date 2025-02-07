public class BooleanVariables
{
    public static void RunBooleans()
    {
        // BOOLEAN
        Console.WriteLine();
        //Declare
        bool myBool;
        bool my_bool;
        bool MyBool;

        // Assign
        myBool = true;
        myBool = false;

        // Declare and assign
        bool coolBool = true;

        // Reassign
        coolBool = false;

        // Boolean logic
        bool trueAndFalse = true && false;
        bool trueAndTrue = true && true;
        bool falseAndFalse = false && false;

        bool trueOrFalse = true || false;
        bool trueOrTrue = true || true;
        bool falseOrFalse = false || false;

        bool notTrue = !true;
        bool notFalse = !false;

        Console.WriteLine($"true && false: {trueAndFalse}");
        Console.WriteLine($"true && true: {trueAndTrue}");
        Console.WriteLine($"false && false: {falseAndFalse}");
        Console.WriteLine($"true || false: {trueOrFalse}");
        Console.WriteLine($"true || true: {trueOrTrue}");
        Console.WriteLine($"false || false: {falseOrFalse}");
        Console.WriteLine($"!true: {notTrue}");
        Console.WriteLine($"!false: {notFalse}");
    }
}