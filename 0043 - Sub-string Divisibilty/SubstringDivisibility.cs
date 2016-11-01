using System;
using System.Text;
using static System.Console;

class SubstringDivisibility
{
    static int[] Primes = { 2, 3, 5, 7, 11, 13, 17 };
    static void Main()
    {
        WriteLine(SumOfDivisiblePandigitals(new StringBuilder()));
        Write("Done!"); Read();
    }

    // returns the sum of the Pandigitals that have the divisibility property
    static long SumOfDivisiblePandigitals(StringBuilder Num)
    {
        if (Num.Length == 10)
        {
            return HasDivisiblityProperty(Num) ? Int64.Parse(Num.ToString()) : 0;
        }
        else
        {
            int DigitPossibilities = Num.Length == 0 ? 9 : 10;
            long Sum = 0;
            for (int i = 10 - DigitPossibilities; i < 10; i++)
            {
                if (!Num.ToString().Contains(i + ""))
                {
                    Sum += SumOfDivisiblePandigitals(Num.Append(i));
                    Num.Remove(Num.Length - 1, 1);
                }
            }
            return Sum;
        }
    }

    // Checks the substring divisibility property specified by problem 43
    static bool HasDivisiblityProperty(StringBuilder Num)
    {
        for (int i = 0; i < 7; i++)
        {
            if (Int64.Parse(Num.ToString().Substring(i + 1, 3)) % Primes[i] != 0)
            {
                return false;
            }
        }
        WriteLine(Num);
        return true;
    }
}