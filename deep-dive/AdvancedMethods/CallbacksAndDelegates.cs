namespace AdvancedMethods;

public class CallbacksAndDelegates
{
    delegate int CalculateDelegate(int firstNumber, int secondNumber);

    public static void RunCallbacksDelegates()
    {
        // Return type has to be void for these
        Action action = NeilAction;
        Action<int> action2 = NeilAction2;

        // Can do either way
        action();
        action.Invoke();

        action2(34);

        void NeilAction()
        {
            Console.WriteLine("Hello world from Neil");
        }

        void NeilAction2(int number)
        {
            Console.WriteLine($"Number passed in was { number }");
        }

        // Func has return type, Action does not
        Func<int, int, int> addFunction = AddFunction;
        Func<int, int, int> subtractFunction = SubtractFunction;

        int AddFunction(int a, int b)
        {
            return a + b;
        }

        int SubtractFunction(int a, int b)
        {
            return a - b;
        }

        Console.WriteLine($"Adding 2 and 6 = { addFunction(2, 6) }");
        Console.WriteLine($"Subtracting 4 from 6 = { subtractFunction(6, 4) }");


        // Callbacks
        // THis can be done for instance when someone pushes a button, then a function is called
        void DoSomethingAfterUserPressesEnter(Action callback)
        {
            Console.WriteLine("Press enter");
            Console.ReadLine();
            callback();
        }

        DoSomethingAfterUserPressesEnter(NeilAction);


        void Calculate(Func<int, int, int> calculateCallback)
        {
            Console.WriteLine("Enter the first integer: ");
            int a = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the second integer: ");
            int b = int.Parse(Console.ReadLine());

            int result = calculateCallback(a, b);
            Console.WriteLine($"The result is: { result }");
        }

        Console.WriteLine("Addition Example:");
        Calculate(addFunction);

        Console.WriteLine("Subtraction Example:");
        Calculate(subtractFunction);


        // Delegates
        CalculateDelegate addDelegate = AddFunction;
        CalculateDelegate subtractDelegate = SubtractFunction;

        void Calculate2(CalculateDelegate calculateCallback)
        {
            Console.WriteLine("Enter the first integer: ");
            int a = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the second integer: ");
            int b = int.Parse(Console.ReadLine());

            int result = calculateCallback(a, b);
            Console.WriteLine($"The result is: { result }");
        }
    }
}
