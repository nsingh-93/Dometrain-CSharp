namespace MultiProject.ClassLibrary;

public class NeilPublicClassWithInternalMembers
{
    public void PublicMethod()
    {
        Console.WriteLine("Hello from public method in public class");
    }

    internal void InternalMethod()
    {
        Console.WriteLine("Hello from internal method in public class");
    }
}
