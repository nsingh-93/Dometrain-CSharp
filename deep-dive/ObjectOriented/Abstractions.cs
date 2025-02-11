namespace ObjectOriented;

public class Abstractions
{
    interface IMyInterface
    {
        void PrintInterface();
    }
    abstract class MyBaseClass
    {
        public void Print()
        {
            Console.WriteLine("Print() in MyBaseClass");
        }

        public abstract void PrintAbstract();
    }

    abstract class MyDerivedAbstractClass : MyBaseClass, IMyInterface
    {
        public abstract void PrintInterface();
    }

    class MyDerivedClass : MyBaseClass
    {
        // *MUST* implement the abstract method when deriving from an abstract class
        // Have to have override keyword as well
        public override void PrintAbstract()
        {
            Console.WriteLine("PrintAbstract() in MyDerivedClass");
        }
    }

    class MyDerivedClass2 : MyDerivedAbstractClass
    {
        // Have to implement both the abstract methods
        public override void PrintAbstract()
        {
            Console.WriteLine("PrintAbstract() in MyDerivedAbstractClass2");
        }

        public override void PrintInterface()
        {
            Console.WriteLine("PrintInterface() in MyDerivedAbstractClass2");
        }
    }

    public static void RunAbstractions()
    {
        // Cannot instantiate abstract classes
        // MyBaseClass myBaseClass = new MyBaseClass();

        MyDerivedClass myDerivedClass = new MyDerivedClass();
        myDerivedClass.Print();
        myDerivedClass.PrintAbstract();
    }
}
