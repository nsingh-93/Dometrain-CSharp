namespace ObjectOriented;

public class ProtectedAndVirtual
{
    abstract class AbstractBaseClass
    {
        protected void ProtectedPrintInBaseClass()
        {
            Console.WriteLine("ProtectedPrintInBaseClass");
        }

        protected abstract void ProtectedAbstractPrint();
    }

    class DerivedClass : AbstractBaseClass
    {
        public void PrintInDerivedClass()
        {
            Console.WriteLine("In the derived class");
            base.ProtectedPrintInBaseClass();
            Console.WriteLine("Leaving method in the derived class");
        }

        protected override void ProtectedAbstractPrint()
        {
            Console.WriteLine("ProtectedAbstractPrint");
        }
    }

    class BaseClass
    {
        protected void PrintInBaseClass()
        {
            Console.WriteLine("PrintInBaseClass");
        }

        // Virtual keyword gives us a hybrid between abstract and non-abstract
        public virtual void VirtualPrintInBaseClass()
        {
            Console.WriteLine("VirtualPrintInBaseClass");
        }
    }

    class DerivedClass2 : BaseClass
    {
        public void PrintInDerivedClass()
        {
            Console.WriteLine("PrintInDerivedClass then base");
            PrintInBaseClass();
        }

        public override void VirtualPrintInBaseClass()
        {
            Console.WriteLine("VirtualPrintInBaseClass in the derived class\nand now we'll call base class method");
            base.VirtualPrintInBaseClass();
            // base is needed here to call the actual base function
        }
    }

    public static void RunProtectedAdnVirtual()
    {
        DerivedClass derivedClass = new DerivedClass();
        derivedClass.PrintInDerivedClass();
        // ProtectedAbstractPrint is protected so can't be accessed outside

        DerivedClass2 derivedClass2 = new DerivedClass2();
        derivedClass2.PrintInDerivedClass();
        derivedClass2.VirtualPrintInBaseClass();
    }
}
