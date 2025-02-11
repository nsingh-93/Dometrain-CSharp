namespace ReferenceAndValueTypes;

// Struct is stored on the stack, and a class is stored on the heap
// Struct is copied when passed to a method, and a class is passed by reference


// Use a struct when you have a small, simple object that you want to pass by value
// Use a struct when you want to avoid the overhead of heap allocation, garbage collecting, etc...

// Default to class if unsure
public class Structs
{
    public struct Point
    {
        public int X;
        public int Y;
    }

    public struct PointWithProperties
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public struct PointWithConstructor
    {
        public PointWithConstructor(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
    }

    public struct PointWithMethod
    {
        public int X;
        public int Y;

        public void Move(int x, int y)
        {
            X += x;
            Y += y;
        }
    }

    public static void RunStructs()
    {
        void DoSomethingWithPoint(Point p)
        {
            p.X = 111;
            p.Y = 222;
        }

        void DoSomethingWithPointByRef(ref Point p)
        {
            p.X = 444;
            p.Y = 555;
        }

        var ourPoint = new Point()
        {
            X = 123,
            Y = 456
        };

        Console.WriteLine($"ourPoint before DoSomethingWithPoint: { ourPoint.X }, { ourPoint.Y }");

        DoSomethingWithPoint(ourPoint);
        
        Console.WriteLine($"ourPoint after DoSomethingWithPoint: { ourPoint.X }, { ourPoint.Y }");

        DoSomethingWithPointByRef(ref ourPoint);

        Console.WriteLine($"ourPoint after DoSomethingWithPointByRef: { ourPoint.X }, { ourPoint.Y }");
    }
}
