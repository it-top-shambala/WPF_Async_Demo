using System.Threading;
using System.Threading.Tasks;

namespace WPF_Async_Demo.App;

public static class Calculator
{
    public static long Factorial(int number)
    {
        long factorial = 1;
        for (int i = 1; i <= number; i++)
        {
            factorial *= i;
            Thread.Sleep(1000);
        }

        return factorial;
    }

    public static async Task<long> FactorialAsync(int number)
    {
        return await Task.Run(() => Factorial(number));
    }
}