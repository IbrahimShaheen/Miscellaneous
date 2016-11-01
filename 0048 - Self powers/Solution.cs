using System.Numerics;
using static System.Numerics.BigInteger;
using static System.Console;

// #HolyWow computers are fast
class SelfPowers
{
    static void Main()
    {
        BigInteger Sum = new BigInteger();
        for (int i = 1; i <= 100000; i++)
        {
            Sum += ModPow(i, i, Pow(10, 10));
        }
        WriteLine(Sum % Pow(10, 10));
        Write("Press enter to exit...");
        Read();
    }
}
