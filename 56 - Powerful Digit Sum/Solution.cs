using System.Numerics;
using static System.Console;
using static System.Numerics.BigInteger;

class Solution
{
    const int LIMIT = 100;

    static void Main()
    {
        int MaxDigitalSum = 0;
        for (int i = 0; i < LIMIT; i++)
        {
            for (int j = 0; j < LIMIT; j++)
            {
                int DigitalSum = GetDigitalSum(Pow(i, j));
                if (DigitalSum > MaxDigitalSum) MaxDigitalSum = DigitalSum;
            }
        }
        WriteLine(MaxDigitalSum);
        WriteLine("Press enter to exit...");
        Read();
    }

    // Returns the sum of the digits of Num
    static int GetDigitalSum(BigInteger Num)
    {
        int DigitalSum = 0;
        while (Num > 0)
        {
            DigitalSum += (int)(Num % 10);
            Num /= 10;
        }
        return DigitalSum;
    }
}