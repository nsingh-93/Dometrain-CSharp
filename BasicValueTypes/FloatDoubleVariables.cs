namespace BasicValueTypes;

public class FloatDoubleVariables
{
    public static void RunFloatDoubles()
    {
        // FLOAT & DOUBLE
        Console.WriteLine();
        // Declare
        float myFloat;
        float my_float;
        float MyFloat;

        double myDouble;
        double my_double;
        double MyDouble;

        // Assign
        myFloat = 5.5f;
        myDouble = 5.5;

        // Declare and assign
        float coolFloat = 5.5f;
        double coolDouble = 5.5;

        // Reassign
        coolFloat = 10.5f;
        coolDouble = 10.5;

        // Do math
        float sumF = 10.5f + 5.5f;
        float differenceF = 10.5f - 5.5f;
        float productF = 10.5f * 5.5f;
        float quotientF = 5.5f / 10.5f;

        Console.WriteLine($"10.5 + 5.5 = {sumF}");
        Console.WriteLine($"10.5 - 5.5 = {differenceF}");
        Console.WriteLine($"10.5 * 5.5 = {productF}");
        Console.WriteLine($"5.5 / 10.5 = {quotientF}");
    }
}