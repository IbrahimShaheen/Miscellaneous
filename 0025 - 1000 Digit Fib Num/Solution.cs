using System;
using System.Numerics;
using System.Collections.Generic;
using static System.Console;

class BigFibNum
{
    static List<BigInteger> FibonacciNums = new List<BigInteger>() { 1, 1 };
    static void Main()
    {
        int Index = 0;
        int DigitCount = 1;
        while (DigitCount < 1000)
        {
            DigitCount = CountDigits(GetFibonacciNum(Index));
            Index++;
        } ;
        WriteLine(Index);
        Read();
    }

    // returns the FibNum at Index
    // indices must be called in order: 2, 3, and so on
    static BigInteger GetFibonacciNum(int Index)
    {
        if (Index < FibonacciNums.Count)
        {
            return FibonacciNums[Index];
        }
        else
        {
            BigInteger FibNum = GetFibonacciNum(Index - 1) + GetFibonacciNum(Index - 2);
            FibonacciNums.Add(FibNum);
            return FibNum;
        }
    }

    // returns the number of digits in Num
    static int CountDigits(BigInteger Num)
    {
        int Digits = 0;
        while(Num != 0)
        {
            Num /= 10;
            Digits++;
        }
        return Digits++;
    }
}