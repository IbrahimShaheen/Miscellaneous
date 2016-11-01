using System.Diagnostics;
using static System.Console;
using static System.Math;

class CircularPrimes
{
    const int MAX_NUM = 1000 * 1000;

    static void Main()
    {
        bool[] Primes = GetPrimesUnderMax();
        int CircularPrimesCount = 0;

        for (int i = 0; i < Primes.Length; i++)
        {
            if (Primes[i])
            {
                CircularDigits Num = new CircularDigits(i + 2);
                bool AllNumsPrime = true;
                for (int j = 0; j < Num.Length; j++)
                {
                    int CanidatePrime = Num.GetNum(j);
                    if (!Primes[CanidatePrime - 2]) AllNumsPrime = false;
                }
                if (AllNumsPrime) CircularPrimesCount++;
            }
        }

        WriteLine(CircularPrimesCount);
        Read();
    }

    // returns a bool[] with true for primes
    static bool[] GetPrimesUnderMax()
    {
        bool[] Primes = new bool[MAX_NUM - 1];
        for (int i = 0; i < Primes.Length; i++) Primes[i] = true;

        for (int i = 0; i < Primes.Length; i++)
        {
            if (Primes[i])
            {
                int Num = i + 2;
                for (int j = i + Num; j < Primes.Length; j += Num) Primes[j] = false;
            }
        }
        return Primes;
    }
}