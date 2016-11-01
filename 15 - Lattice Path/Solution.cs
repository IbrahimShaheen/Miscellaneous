using System;
using System.Numerics;

class Lattice
{

    static void Main()
    {
        BigInteger FourtyFactOverTwentyFact = 1;
        for (int i = 21; i <= 40; i++)
        {
            FourtyFactOverTwentyFact *= i;
        }

        BigInteger TwentyFact = 1;
        for (int i = 1; i <= 20; i++)
        {
            TwentyFact *= i;
        }

        Console.WriteLine(FourtyFactOverTwentyFact / TwentyFact);
        Console.Read();
    }
}