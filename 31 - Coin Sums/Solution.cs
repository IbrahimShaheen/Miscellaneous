using System;
using static System.Console;

class CoinSums
{
    static void Main()
    {
        int[] CoinVals = new int[] { 1, 2, 5, 10, 20, 50, 100, 200 };
        WriteLine(WaysToGet200(CoinVals));
        Read();
    }

    static int WaysToGet200(int[] CoinVals)
    {
        return WaysToGet200Helper(CoinVals, 0, 0);
    }

    static int WaysToGet200Helper(int[] CoinVals, int ValSoFar, int LastCoinTried)
    {
        if (ValSoFar == 200)
        {
            return 1;
        }
        else if (ValSoFar < 200)
        {
            int CountBranch = 0;
            for (int i = LastCoinTried; i < CoinVals.Length; i++)
            {
                CountBranch += WaysToGet200Helper(CoinVals, ValSoFar + CoinVals[i], i);
            }
            return CountBranch;
        }
        return 0;
    }
}