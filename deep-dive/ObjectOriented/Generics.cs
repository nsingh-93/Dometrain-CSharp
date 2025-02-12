namespace ObjectOriented;

public class Generics
{
    public interface IGenericInterface<T>
    {
    }

    public class GenericClass<T> : IGenericInterface<T>
    {
    }

    public class ImplementationWithIntegerType : IGenericInterface<int>
    {
    }

    public class ClassWithGenericMethod
    {
        public void GenericMethod<T>(T value)
        {
            Console.WriteLine($"The type of the value is { value!.GetType().Name } and the value is { value }");
        }

        public T GenericFunction<T>(T value)
        {
            Console.WriteLine($"The type of the value is { value!.GetType().Name } and the value is { value }");
            return value;
        }
    }

    public interface IAnimal
    {
        double Weight { get; }

        double Height { get; }

        bool HasFur { get; }
    }

    public record Cat(double Weight, double Height, bool HasFur) : IAnimal;

    public record Dog(double Weight, double Height) : IAnimal
    {
        public bool HasFur => true;
    }

    public record Fish(double Weight, double Height) : IAnimal
    {
        public bool HasFur => false;
    }

    public static void RunGenerics()
    {
        GenericClass<int> myNumericInstance = new GenericClass<int>();
        GenericClass<string> myStringInstance = new GenericClass<string>();
        // GenericClass instanceWithoutType = new GenericClass();       Does not compile without Type

        ImplementationWithIntegerType instanceOfImplementationWithIntegerType = new();

        ClassWithGenericMethod instanceOfClassWithGenericMethod = new();
        instanceOfClassWithGenericMethod.GenericMethod("This is a string");
        instanceOfClassWithGenericMethod.GenericMethod(42);
        instanceOfClassWithGenericMethod.GenericMethod(3.14);

        int genericFunctionResult1 = instanceOfClassWithGenericMethod.GenericFunction(42);
        string genericFunctionResult2 = instanceOfClassWithGenericMethod.GenericFunction("This is a string");
        double genericFunctionResult3 = instanceOfClassWithGenericMethod.GenericFunction(3.14);

        // Collections are generics
        List<int> numericList = new List<int>();
        List<string> stringList = new List<string>();

        double CalculateWeight<T>(IEnumerable<T> animals) where T : IAnimal
        {
            var total = animals.Sum(a => a.Weight);
            return total;
        }

        double CalculateHeight<T>(IEnumerable<T> animals) where T : IAnimal
        {
            var total = animals.Sum(a => a.Height);
            return total;
        }

        IEnumerable<T> OnlyWithFur<T>(IEnumerable<T> animals) where T : IAnimal
        {
            return animals.Where(a => a.HasFur);
        }

        Dog frank = new(
            Weight: 50,
            Height: 24);

        Dog spot = new(
            Weight: 35,
            Height: 18);

        Cat whiskers = new(
            Weight: 10,
            Height: 12,
            HasFur: true);

        Cat pharoah = new(
            Weight: 12,
            Height: 14,
            HasFur: false);

        Fish goldie = new(
            Weight: 0.5,
            Height: 2);

        var animals = new IAnimal[] { frank, spot, whiskers, pharoah, goldie };

        var totalWeight = CalculateWeight(animals);
        //var totalWeight = CalculateWeight(new int[] { 1, 2, 3 });     Doesn't compile
        var totalHeight = CalculateHeight(animals);
        var onlyFur = OnlyWithFur(animals);

        var cats = new Cat[] { whiskers, pharoah };
        var dogs = new Dog[] { frank, spot };
        var fish = new Fish[] { goldie };

        var totalWeightCats = CalculateWeight(cats);
        var totalWeightDogs = CalculateWeight(dogs);
        var totalWeightFish = CalculateWeight(fish);
    }
}
