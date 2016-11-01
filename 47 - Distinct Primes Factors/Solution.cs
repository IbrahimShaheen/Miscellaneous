using static System.Console;

// Needs some speeding up...
class DistinctPrimesFactors
{
    static PrimesList Primes = new PrimesList();
    const int FACTORS = 4; // The number of factors AND the number of consecutive integers needed

    static void Main()
    {
        int TheNum = 0;
        int Num = 0;
        int Consecutives = 0;
        while (Consecutives != FACTORS)
        {
            if (Factors(Num) == FACTORS)
            {
                Consecutives++;
            }
            else
            {
                Consecutives = 0;
                TheNum = Num + 1;
            }
            Num++;
        }
        WriteLine(TheNum);
        Write("Press enter to exit...");
        Read();
    }

    // Returns the number of distinct factors of Num
    static int Factors(int Num)
    {
        int Factors = 0;
        if (Primes.Contains(Num))
        {
            Factors = 1;
        }
        else
        {
            foreach (int Prime in Primes.GetPrimes(Num / 2))
            {
                if (Num % Prime == 0) Factors++;
            }
        }
        return Factors;
    }
}
