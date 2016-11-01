using System.Numerics;
using static System.Console;

class CombinatoricSelections
{
    static void Main()
    {
        int Total = 0;
        for (int n = 23; n <= 100; n++)
        {
            int r = 0;
            while (Combinations(n, r) <= 1000 * 1000) r++;
            Total += n + 1 - 2 * r;
        }
        WriteLine(Total);
        WriteLine("Press enter to exit...");
        Read();
    }

    static long Combinations(int n, int r)
    {
        return Permutations(n, r) / Factorial(r);
    }

    static long Permutations(int n, int r)
    {
        long Permutations = 1;
        for (int i = n - r + 1; i <= n; i++)
        {
            Permutations *= i;
        }
        return Permutations;
    }

    static long Factorial(int r)
    {
        long Factorial = 1;
        for (int i = 2; i <= r; i++)
        {
            Factorial *= i;
        }
        return Factorial;
    }
}