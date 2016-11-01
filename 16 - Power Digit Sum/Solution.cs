using System;
using System.Numerics;

class PowerDigitSum
{
    static void Main()
    {
        BigInteger Num = 1;
        for (int i = 0; i < 1000; i++)
        {
            Num *= 2;
        }

        long Sum = 0;
        while (Num != 0)
        {
            Sum += (int)BigInteger.Remainder(Num, 10);
            Num /= 10;
        }

        Console.WriteLine(Sum);
        Console.Read();
    }
}