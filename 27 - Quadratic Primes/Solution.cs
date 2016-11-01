using System;
using System.Collections.Generic;
using static System.Console;

class QuadraticPrimes
{
    static int Range = 20000;
    static List<bool> Primes = new List<bool>() { true }; // First Prime is 2
    // analyze List<QuadFxn> found???

    static void Main()
    {
        QuadraticFxn BestFxn = new QuadraticFxn(0, 0);
        BestFxn.Score = -1;

        for (int a = -Range; a <= Range; a++)
        {
            for (int b = -Range; b <= Range; b++)
            {
                QuadraticFxn Fxn = new QuadraticFxn(a, b);
                AssignScore(Fxn);
                if (Fxn.Score > BestFxn.Score)
                {
                    BestFxn = Fxn;
                }
            }
        }
        WriteLine(BestFxn);
        WriteLine(BestFxn.A * BestFxn.B);
        Read();
    }

    // Assigns Fxn.Score the number of consecutive primes produced by the Fxn
    static void AssignScore(QuadraticFxn Fxn)
    {
        int N = 0;
        while (IsPrime(Fxn.GetPrime(N)))
        {
            N++;
        }
        Fxn.Score = N;
    }

    // Returns if Num is a prime or not
    static bool IsPrime(int Num)
    {
        if (Num < 2) return false;
        while (Primes.Count + 1 < Num) // Ensures we know enough primes
        {
            DoublePrimes();
        }
        return Primes[Num - 2];
    }

    // Doubles the size of the list of known Primes (can be optimized by starting the sieve where the oldprime list ended)
    static void DoublePrimes()
    {
        int OldPrimes = Primes.Count;
        for (int i = 0; i < OldPrimes; i++) Primes.Add(true);

        for (int i = 0; i < OldPrimes; i++)
        {
            if (Primes[i])
            {
                int Prime = i + 2;
                for (int j = i + Prime; j < Primes.Count; j += Prime)
                {
                    Primes[j] = false;
                }
            }
        }
    }
}