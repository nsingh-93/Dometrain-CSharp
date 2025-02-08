namespace Methods;

public class ReturnTypes
{
    public static void RunReturnTypes()
    {
        int Add(int a, int b)
        {
            return a + b;
        }

        int sum = Add(5, 3);

        int x = 5;
        int y = 3;
        int sum2 = Add(x, y);

        int sum3 = Add(Add(1, 2), Add(3, 4));

        Add(5, 3);
    }
}
