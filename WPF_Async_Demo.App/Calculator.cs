using System;
using System.Threading;
using System.Threading.Tasks;

namespace WPF_Async_Demo.App;

public static class Calculator
{
    public static long Factorial(int number, IProgress<int> progress, CancellationToken token)
    {
        long factorial = 1;
        for (int i = 1; i <= number; i++)
        {
            if (token.IsCancellationRequested)
            {
                return 0;
            }
            
            factorial *= i;
            Thread.Sleep(1000);
            
            progress?.Report(i);
        }

        return factorial;
    }

    public static async Task<long> FactorialAsync(int number, IProgress<int> progress, CancellationToken token)
    {
        return await Task.Run(() => Factorial(number, progress, token), token);
    }
}