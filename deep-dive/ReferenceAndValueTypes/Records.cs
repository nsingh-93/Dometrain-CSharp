namespace ReferenceAndValueTypes;

public class Records
{
    public record MyRecord(int NumericValue, string StringValue);

    public record MyRecord2
    {
        public int NumericValue { get; init; }
        public required string StringValue { get; init; }
    }

    // Goes on stack instead of heap - performance boost when using many of these
    public record struct MyRecordStruct(int NumericValue, string StringValue);

    public record MyRecordWithExtraProperties(int NumericValue, string StringValue)
    {
        public required string ExtraProperty { get; set; }
    }

    public static void RunRecords()
    {
        MyRecord myRecord1 = new(123, "ABC");
        MyRecord2 myRecord2 = new()
        {
            NumericValue = 123,
            StringValue = "ABC"
        };

        // In both cases, properties cannot be changed because they are "init" only:
        // Don't compile
        //myRecord1.NumericValue = 456;
        //myRecord2.NumericValue = 456;

        MyRecord recordA = new(123, "ABC");
        MyRecord recordB = new(123, "ABC");

        Console.WriteLine("recordA equal to recordB:");
        Console.WriteLine(recordA == recordB);                  // True
        Console.WriteLine(recordA.Equals(recordB));             // True
        Console.WriteLine(object.Equals(recordA, recordB));     // True


        // Using "with" keyword to create new record with change
        MyRecord recordC = recordA with { NumericValue = 456 };

        Console.WriteLine(recordA);
        Console.WriteLine(recordB);
        Console.WriteLine(recordC);

        // Deconstructing record to its properties - order matters
        var (numericValue, stringValue) = recordA;

        
        MyRecordWithExtraProperties recordWithExtraProperties = new(123, "ABC")
        {
            ExtraProperty = "DEF"
        };

        Console.WriteLine("recordWithExtraProperties.ExtraProperty (before):");
        Console.WriteLine(recordWithExtraProperties.ExtraProperty);

        recordWithExtraProperties.ExtraProperty = "AAA BBB CCC";
        
        Console.WriteLine("recordWithExtraProperties.ExtraProperty (after):");
        Console.WriteLine(recordWithExtraProperties.ExtraProperty);
    }
}
