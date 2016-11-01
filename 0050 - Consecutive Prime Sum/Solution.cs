using System.Linq;
using static System.Console;

// Don't visit each prime idiot!! Only check the sums... (Thanx PE thread!!)
class ConsectivePrimeSum
{
    const int MAX_NUM = 1000 * 1000;
    static int[] Primes = new PrimesList().GetPrimes(MAX_NUM).ToArray();
    static void Main()
    {
        int MaxSumLength = 0;
        for (int i = 0; i < Primes.Length; i++)
        {
            int NewSum = GetMaxSum(i);
            if (NewSum > MaxSumLength)
            {
                MaxSumLength = NewSum;
                WriteLine("For {0} the max sum is {1}", Primes[i], MaxSumLength);
            }
        }
        Write("Press enter to exit...");
        Read();
    }

    // Returns the max number of consecutive primes that can sum up to Prime
    static int GetMaxSum(int PrimeIndex)
    {
        int Prime = Primes[PrimeIndex];
        int MaxSumLength = 0;
        for (int i = 0; i + MaxSumLength < PrimeIndex + 1; i++)
        {
            int CurrSum = 0;
            int CurrSumLength = 0;
            while (CurrSum < Prime) // Sum up the subprimes till we get to or pass Prime
            {
                CurrSum += Primes[i + CurrSumLength]; // Never out of bounds since last element == Prime
                CurrSumLength++;
            }
            if (CurrSum == Prime && CurrSumLength > MaxSumLength)
            {
                MaxSumLength = CurrSumLength;
            }
        }
        return MaxSumLength;
    }
}