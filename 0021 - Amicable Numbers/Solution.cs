using System;
using static System.Math;
using static System.Console;

class AmicableNumbers
{
    static void Main()
    {
        int MaxNum = 10000;
        int TotalSum = 0;

        for (int Num1 = 1; Num1 < MaxNum; Num1++)
        {
            int Num2 = SumOfDivisors(Num1);
            if(Num2 > Num1 && Num2 < MaxNum)
            {
                if (SumOfDivisors(Num2) == Num1)
                {
                    TotalSum = TotalSum + Num1 + Num2;
                }
            }
        }
        Write(TotalSum);
        Read();
    }

    // returns the sum of all the proper divisors starting from and including one
    static int SumOfDivisors(int Num)
    {
        int Sum = 1; // One is always a proper divisors of all positive ints
        for (int i = 2; i <= Num / 2; i++)
        {
            if (Num % i == 0) Sum += i;
        }
        return Sum;
    }
}