using static System.Math;
using static System.Console;
using System;

class DigitFifthPowers
{
    const int UpperLimit = 354294; // 5th power max = 6 * 9 ^ 5
    // Any num larger than this requires at least 7 digits in base 10

    static void Main()
    {
        int SumOfFifthLovingNums = 0;
        for (int i = 2; i <= UpperLimit; i++)
        {
            if (SumOfDigitsToTheFifth(i) == i)
            {
                SumOfFifthLovingNums += i;
                WriteLine(i);
            }
        }
        WriteLine(SumOfFifthLovingNums);
        Read();
    }

    // Returns the sum of the digits of Num each raised to the fifth power
    static int SumOfDigitsToTheFifth(int Num)
    {
        int SumOfDigitsToTheFifth = 0;
        while (Num != 0)
        {
            SumOfDigitsToTheFifth += (int)Pow(Num % 10, 5);
            Num /= 10;
        }
        return SumOfDigitsToTheFifth;
    }
}