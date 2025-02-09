namespace ObjectOriented;

public class StaticVsInstances
{
    public static void RunStaticVsInstances()
    {
        MyStaticClass.MyStaticMethod();

        MyNonStaticClass myNonStaticClass1 = new MyNonStaticClass();
        MyNonStaticClass myNonStaticClass2 = new MyNonStaticClass();

        Console.WriteLine("Before mutating properties on MyNonStaticClass...");

        myNonStaticClass1.MyInstanceMethod();
        myNonStaticClass2.MyInstanceMethod();
        
        MyNonStaticClass.MyStaticMethod();

        myNonStaticClass1.MyInstanceProperty = "Dev";
        myNonStaticClass2.MyInstanceProperty = "Leader";

        MyNonStaticClass.MyStaticProperty = "Neil Singh";

        Console.WriteLine("After mutating properties on MyNonStaticClass...");

        myNonStaticClass1.MyInstanceMethod();
        myNonStaticClass2.MyInstanceMethod();

        MyNonStaticClass.MyStaticMethod();
    }

    static class MyStaticClass
    {
        public static void MyStaticMethod()
        {
            Console.WriteLine("A static method");
        }
    }

    class MyNonStaticClass
    {
        public string MyInstanceProperty { get; set; } = "Neil";

        public static string MyStaticProperty { get; set; } = "Singh";

        public static void MyStaticMethod()
        {
            Console.WriteLine($"The static property value is: {MyStaticProperty}");

            // Won't work - MyInstanceProperty is not static
            //Console.WriteLine($"The instance property value is: {MyInstanceProperty}");
        }

        public void MyInstanceMethod()
        {
            Console.WriteLine($"The static property value is: {MyStaticProperty}");
            Console.WriteLine($"The instance property value is: {MyInstanceProperty}");
        }
    }
}
