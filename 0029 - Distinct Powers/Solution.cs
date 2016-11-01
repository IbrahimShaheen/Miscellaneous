using System.Numerics;
using System.Collections.Generic;
using static System.Console;
using static System.Numerics.BigInteger;

class DistinctPowers
{
    static void Main()
    {
        HashSet<BigInteger> DistinctPowers = new HashSet<BigInteger>();
        int Range = 100;
        for (int a = 2; a <= Range; a++)
        {
            for (int b = 2; b <= Range; b++)
            {
                BigInteger Power = Pow(a, b);
                DistinctPowers.Add(Power);
            }
        }
        WriteLine(DistinctPowers.Count);
        Read();
    }
}