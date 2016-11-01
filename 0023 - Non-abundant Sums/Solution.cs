using System;
using System.Collections.Generic;
using static System.Console;

// Def: a positive int that can be written as a sum of two abundant numbers is biabundant
class NonabundantSums
{
    // All numbers over this limit are biabundant, provable through real analysis
    const int UpperLimit = 28123;

    static void Main()
    {
        List<int> AbundantNums = GetAbundantNums();

        bool[] BiabundantNums = GetBiabundantNums(AbundantNums);

        int Num = 1;
        int SumOfNonBiabundants = 0;
        int SumOfBiabundants = 0;
        foreach (bool BiabundantNum in BiabundantNums)
        {
            if (BiabundantNum)
            {
                WriteLine(Num);
                SumOfBiabundants += Num;
            }
            else
            {
                SumOfNonBiabundants += Num;
            }
            Num++;
        }
        WriteLine("SumOfNonBiabundants: " + SumOfNonBiabundants);
        WriteLine("SumOfBiabundants: " + SumOfBiabundants);
        WriteLine("SumOfAll" + (SumOfBiabundants + SumOfNonBiabundants));

        Read();
    }

    // returns Biabundant nums less than the upper limit.
    static bool[] GetBiabundantNums(List<int> AbundantNums)
    {
        bool[] BiabundantNums = new bool[UpperLimit];
        for (int i = 0; i < AbundantNums.Count; i++)
        {
            for (int j = i; j < AbundantNums.Count; j++)
            {
                int Num1 = AbundantNums[i];
                int Num2 = AbundantNums[j];
                int BiabundantNum = Num1 + Num2;
                if (BiabundantNum <= BiabundantNums.Length)
                {
                    BiabundantNums[BiabundantNum - 1] = true;
                }
            }
        }
        return BiabundantNums;
    }

    // returns a list of abundant nums under upper limit sorted from smallest to largest
    static List<int> GetAbundantNums()
    {
        List<int> AbundantNums = new List<int>();
        for (int i = 1; i < UpperLimit; i++)
        {
            if (i < SumOfDivisors(i)) // is i abundant?
            {
                AbundantNums.Add(i);
            }
        }
        return AbundantNums;
    }

    // returns the sum of all the proper divisors starting from and including one
    static int SumOfDivisors(int Num)
    {
        int Sum = 1;
        for (int i = 2; i <= Num / 2; i++)
        {
            if (Num % i == 0) Sum += i;
        }
        return Sum;
    }
}