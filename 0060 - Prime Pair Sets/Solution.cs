using System;
using System.Collections.Generic;
using static System.String;
using static System.Console;

// Please close your eyes as you read the following code.
// It might hurt.
// You have been warned.


// Actually, I might return to this and tidy it up a bit

class Problem60
{
    static PrimesList Primes = new PrimesList();
    static int SUB_SET_SIZE = 5;
    static List<int> Set = new List<int>();

    static void Main()
    {
        int[] SubSet = new int[SUB_SET_SIZE];
        for (int i = 0; i < SUB_SET_SIZE; i++)
        {
            Set.Add(Primes.NextPrime());
            SubSet[i] = i;
        }
        while (!PairsConcatToPrimes(PI2P(SubSet)))
        {
            SubSetAfter(SubSet);
        }
        WriteLine(Join(", ", PI2P(SubSet)));
        Write("Press enter to exit...");
        Read();
    }

    // Returns a set of Primes given a set of prime indices
    private static int[] PI2P(int[] SubSet)
    {
        int[] Result = new int[SubSet.Length];
        for (int i = 0; i < SubSet.Length; i++)
        {
            Result[i] = Set[SubSet[i]];
        }
        return Result;
    }

    // Changes SubSet to the next SubSet in the lexicographical order
    // If all possible combinations of Set have been generated, expands Set, and generates new SubSets
    // If two numbers in Set can't generate pairs, then it skips them
    private static void SubSetAfter(int[] SubSet)
    {
        if (SubSet[SubSet.Length - 1] - SubSet[0] == SUB_SET_SIZE - 1)
        {
            for (int i = 0; i < SubSet.Length - 1; i++)
            {
                SubSet[i] = i;
            }
            Set.Add(Primes.NextPrime());
            SubSet[SubSet.Length - 1]++;
        }
        else
        {
            int Prev = 0;
            int Curr = 1;
            while (SubSet[Curr] - SubSet[Prev] == 1)
            {
                Prev++;
                Curr++;
            }
            SubSet[Prev]++;
            if (IsPossibleSubSet(SubSet, Prev))
            {
                for (int i = 0; i < Prev; i++)
                {
                    SubSet[i] = i;
                }
            }
            else
            {
                for (int i = Prev - 1; i >= 0; i--)
                {
                    SubSet[i] = SubSet[i + 1] - 1;
                }
            }
        }
    }

    // Checks to see if the new int Prev can be used with the SubSet or not
    private static bool IsPossibleSubSet(int[] SubSet, int Prev)
    {
        for (int i = Prev + 1; i < SubSet.Length; i++)
        {
            if(!PrimePairConcatsToPrimes(Set[SubSet[Prev]], Set[SubSet[i]])) return false;
        }
        return true;
    }

    // Returns true if all possible concatenations of pairs of primes in Set are primes
    static bool PairsConcatToPrimes(int[] Set)
    {
        for (int i = 0; i < Set.Length; i++)
        {
            for (int j = i + 1; j < Set.Length; j++)
            {
                if (!Primes.Contains(Int32.Parse("" + Set[i] + Set[j])) ||
                   !Primes.Contains(Int32.Parse("" + Set[j] + Set[i])))
                {
                    return false;
                }
            }
        }
        return true;
    }

    // Returns true if Prime0 and Prime1 concatenate to two new primes
    static bool PrimePairConcatsToPrimes(int Prime0, int Prime1)
    {
        return Primes.Contains(Int32.Parse("" + Prime0 + Prime1)) &&
               Primes.Contains(Int32.Parse("" + Prime1 + Prime0));
    }
}