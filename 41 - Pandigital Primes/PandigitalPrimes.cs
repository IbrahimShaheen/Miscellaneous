using System.Collections.Generic;
using static System.Console;

// TODO: Recursively generate the pandigitals instead of checking if a number is pandigital
class PandigitalPrimes
{
    const int MAX_PANDIGITAL_PRIME = 7654321; // Max 7 digit pandigital, 8 and 9 digit pandigitals are all composites

    static void Main()
    {
        List<bool> Primes = GetPrimes(MAX_PANDIGITAL_PRIME);
        int MaxPandigitalPrimeFound = 0;
        for (int i = 2; i <= MAX_PANDIGITAL_PRIME; i++)
        {
            if (Primes[i - 2] && IsPandigital(i))
            {
                MaxPandigitalPrimeFound = i;
            }
        }
        Write(MaxPandigitalPrimeFound); Read();
    }

    // Returns a bool list where true is prime with count == Limit - 1
    static List<bool> GetPrimes(int Limit)
    {
        List<bool> Primes = new List<bool>();
        Primes.Capacity = Limit - 1;
        for (int i = 0; i < Limit - 1; i++) Primes.Add(true);
        for (int i = 0; i < Primes.Count; i++)
        {
            if (Primes[i])
            {
                int Num = i + 2;
                int SieveStartIndex = Num * Num - 2 < 0 ? Primes.Count : Num * Num - 2; // avoid integer overflow
                for (int j = SieveStartIndex; j < Primes.Count; j += Num) Primes[j] = false;
            }
        }
        return Primes;
    }

    // Returns true if Num is pandigital upto the digit count of Num
    static bool IsPandigital(int Num)
    {
        string Number = "" + Num;
        for (int i = 1; i <= Number.Length; i++)
        {
            if (!Number.Contains("" + i)) return false;
        }
        return true;
    }
}