using System;
using System.Linq;
using static System.Console;

//TODO: Generate the permutations, then check if they're prime
// I felt like such a naughty rule breaking bad boy, writing this ugly code ;)
class SelfPowers
{
    static void Main()
    {
        int[] Primes = new PrimesList(10 * 1000).GetPrimes(10 * 1000, 1000).ToArray<int>();
        for (int i = 0; i < Primes.Length; i++)
        {
            int Prime0 = Primes[i];
            for (int j = i + 1; j < Primes.Length; j++)
            {
                int Prime1 = Primes[j];
                for (int k = j + 1; k < Primes.Length; k++)
                {
                    int Prime2 = Primes[k];
                    if (Prime0 != Prime1 && Prime1 != Prime2
                        && Prime1 - Prime0 == Prime2 - Prime1
                        && ArePermutations(Prime0, Prime1, Prime2))
                    {
                        WriteLine("{0}, {1}, and {2}", Prime0, Prime1, Prime2);
                    }
                }
            }
        }
        Write("Press enter to exit...");
        Read();
    }
}
