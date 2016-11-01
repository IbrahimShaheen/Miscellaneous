using System;
using System.Numerics;

class FactorialDigitSum
{
    static void Main()
    {
        BigInteger BigFactorial = 1;
        for(int i = 1; i <= 100; i++)
        {
            BigFactorial *= i;
        }

        int DigitsSum = 0;
        while (BigFactorial != 0)
        {
            DigitsSum += (int)(BigFactorial % 10);
            BigFactorial /= 10;
        }

        Console.WriteLine(DigitsSum);
        Console.Read();
    }
}