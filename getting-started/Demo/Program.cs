using System.ComponentModel;

Calculator calc = new("Welcome to the Calculator");
calc.Start();

public class Calculator
{
    private string _greeting;

    public Calculator(string greeting)
    {
        _greeting = greeting;
    }

    public void Start()
    {
        Console.WriteLine(_greeting);

        Dictionary<string, string> supportedOps = new()
        {
            { "+", "Add" },
            { "-", "Subtraction" },
            { "/", "Divide" },
            { "*", "Multiplication" },
            { "e", "Exit" },
            { "E", "Exit" }
        };

        while (true)
        {
            Console.WriteLine("Operator choices are:");
            foreach (var op in supportedOps)
            {
                Console.WriteLine($"{op.Value}: {op.Key}");
            }

            Console.WriteLine("Enter an operator:");
            string opChoice = Console.ReadLine();

            if (!supportedOps.TryGetValue(opChoice,  out var selectedOpDesc))
            {
                Console.WriteLine("Invalid operator choice.");
                continue;
            }

            Console.WriteLine($"You selected: {selectedOpDesc}");
            Console.WriteLine();

            if (opChoice.Equals("e", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Exiting program\n");
                break;
            }

            Console.WriteLine($"Doubles are in the range  {double.MinValue} to {double.MaxValue}");
            Console.WriteLine();

            double firstNum = EnterInput("Enter first double:");

            if (double.IsNaN(firstNum))
            {
                continue;
            }

            double secondNum = EnterInput("Enter second double:");

            if (double.IsNaN(secondNum))
            {
                continue;
            }

            double result;

            try
            {
                result = opChoice switch
                {
                    "+" => firstNum + secondNum,
                    "-" => firstNum - secondNum,
                    "/" => Divide(firstNum, secondNum),
                    "*" => firstNum * secondNum,
                    _ => throw new NotSupportedException($"Not currently supported for operator {opChoice}\n")
                };
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("You cannot divide by zero\n");
                continue;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There was an unhandled exception: {ex.Message}\n");
                continue;
            }

            Console.WriteLine($"Result is: {result}\n");
        }
    }

    private double EnterInput(string message)
    {
        Console.WriteLine($"{message}");

        string input = Console.ReadLine();

        if (!double.TryParse(input, out double inputVal))
        {
            Console.WriteLine($"{input} could not be parsed");
            return double.NaN;
        }

        return inputVal;
    }

    private double Divide(double numerator, double denominator)
    {
        if (denominator == 0)
        {
            throw new DivideByZeroException();
        }

        return numerator / denominator;
    }
}