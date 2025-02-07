namespace BasicValueTypes;

public class DateTimeVariables
{
    public static void RunDateTimes()
    {
        // DATETIME
        Console.WriteLine();
        // Declare
        DateTime myDateTime;
        DateOnly myDate;
        TimeOnly myTime;

        // Assign
        myDateTime = DateTime.Now;
        myDate = new DateOnly(2025, 2, 6);
        myTime = new TimeOnly(16, 22);

        // Declare and assign
        DateTime myDateTime2 = DateTime.Now;
        DateOnly myDate2 = new DateOnly(2025, 2, 6);
        TimeOnly myTime2 = new TimeOnly(16, 24);

        // Combining
        DateTime dateTimeFromCombination = new DateTime(myDate2, myTime2);

        Console.WriteLine($"Date Only: {myDate2}");
        Console.WriteLine($"Time Only: {myTime2}");
        Console.WriteLine($"Date and Time: {dateTimeFromCombination}");
    }
}