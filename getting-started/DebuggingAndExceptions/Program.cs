// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

int IntegerDivision(int x, int y)
{
    return x / y;
}

// throws exception
//int result = IntegerDivision(10, 0);


try
{
    IntegerDivision(10, 0);
}
catch (Exception e)
{
    Console.WriteLine("Exception was thrown");
    Console.WriteLine(e.Message);
}



try
{
    IntegerDivision(10, 0);
}
catch (DivideByZeroException e)
{
    Console.WriteLine("Can't divide by zero");
}
catch (Exception e)
{
    Console.WriteLine("Exception was thrown");
    Console.WriteLine(e.Message);
}


// Exception filtering
try
{
    IntegerDivision(10, 0);
}
catch (Exception e) when (e.Message.Contains("divide by zero"))
{
    Console.WriteLine("Can't divide by zero");
}
catch (Exception e)
{
    Console.WriteLine("Exception was thrown");
    Console.WriteLine(e.Message);
}



try
{
    IntegerDivision(10, 0);
}
catch (Exception e)
{
    Console.WriteLine("Exception was thrown");
    Console.WriteLine(e.Message);
}
finally
{
    Console.WriteLine("This code always runs");
}