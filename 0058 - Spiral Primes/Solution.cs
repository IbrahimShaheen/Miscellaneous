using static System.Console;

class Solution
{
    static void Main()
    {
        int UpRight = 1;
        int UpLeft = 1;
        int DownLeft = 1;
        // DownRight is not needed since it contains odd square, none of which can be prime

        int PrimesCount = 0;
        PrimesList Primes = new PrimesList();
        int i = 0;
        do
        {
            UpRight += 8 * i + 2;
            UpLeft += 8 * i + 4;
            DownLeft += 8 * i + 6; // Oh! look at those patterns, isn't the universe beautiful?

            if (Primes.Contains(UpRight)) PrimesCount++;
            if (Primes.Contains(UpLeft)) PrimesCount++;
            if (Primes.Contains(DownLeft)) PrimesCount++;
            WriteLine(DownLeft);

            i++;
            WriteLine(PrimesCount + " / " + (4 * i + 1) + " = " + (double)PrimesCount / (4 * i + 1));
        } while ((double)PrimesCount / (4 * i + 1) >= 0.1);

        WriteLine("Side length is {0}", 2 * i + 1);
        WriteLine("i is {0}", i);
        WriteLine("Press enter to exit...");
        Read();
    }
}