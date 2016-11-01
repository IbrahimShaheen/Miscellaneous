using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;

class TwoSidedPrimes
{
    static char[] FirstDigs = { '2', '3', '5', '7' }, MiddleDigs = { '1', '3', '7', '9' }, LastDigs = { '3', '7' };
    static List<bool> PrimesKnown = new List<bool>() { true }; // the number two is the first prime

    static void Main()
    {
        int DigitCount = 2; // 2, 3, 5, 7 are not considered two sided primes
        int TPrimesSum = 0;
        int Found = 0;
        while (Found != 11 || DigitCount == 8) // given that that there are 11 two sided primes
        {
            List<int> TPrimes = GetTPrimeCanidates(DigitCount);
            foreach (int TPrime in TPrimes)
            {
                if (IsTPrime(TPrime))
                {
                    WriteLine(TPrime);
                    TPrimesSum += TPrime;
                    Found++;
                }
            }
            DigitCount++;
        }
        WriteLine("Sum is: " + TPrimesSum);
        Write("Done!"); Read();
    }

    // Returns a list of possible two sided primes with the DigitCount digits
    private static List<int> GetTPrimeCanidates(int DigitCount)
    {
        List<int> TPrimes = new List<int>();
        GetTPrimeCanidatesHelper(DigitCount, "", TPrimes);
        return TPrimes;
    }

    private static void GetTPrimeCanidatesHelper(int DigitCount, string DigitsSoFar, List<int> TPrimes)
    {
        if (DigitCount == 2) // when the only two digits left are the first and the last ones
        {
            foreach (char FirstDig in FirstDigs)
            {
                foreach (char LastDig in LastDigs)
                {
                    TPrimes.Add(Int32.Parse(FirstDig + DigitsSoFar + LastDig));
                }
            }
        }
        else
        {
            foreach (char MiddleDig in MiddleDigs)
            {
                GetTPrimeCanidatesHelper(DigitCount - 1, DigitsSoFar + MiddleDig, TPrimes);
            }
        }
    }

    // Returns true if Num is both a left and a right truncatable prime
    static bool IsTPrime(int CanidateTwoSidedPrime)
    {
        string Num = CanidateTwoSidedPrime.ToString();
        for (int i = 0; i < Num.Length; i++)
        {
            int RightSubNum = Int32.Parse(Num.Substring(i));
            int LeftSubNum = Int32.Parse(Num.Substring(0, Num.Length - i));
            while (RightSubNum - 1 > PrimesKnown.Count || LeftSubNum - 1 > PrimesKnown.Count)
            {
                DoubleKnownPrimesCount();
            }
            if (!PrimesKnown[RightSubNum - 2] || !PrimesKnown[LeftSubNum - 2])
            {
                return false;
            }
        }
        return true;
    }

    // Doubles the number of known primes in the PrimesKnown list
    static void DoubleKnownPrimesCount()
    {
        int OldCount = PrimesKnown.Count;
        for (int i = 0; i < OldCount; i++) PrimesKnown.Add(true);

        for (int i = 0; i < PrimesKnown.Count; i++)
        {
            if (PrimesKnown[i])
            {
                int Prime = i + 2;
                int SieveStartingIndex = Prime * Prime - 2;
                if (SieveStartingIndex >= 0) // prevents integer overflow
                {
                    for (int j = SieveStartingIndex; j < PrimesKnown.Count; j += Prime)
                    {
                        PrimesKnown[j] = false;
                    }
                }
            }
        }
    }
}