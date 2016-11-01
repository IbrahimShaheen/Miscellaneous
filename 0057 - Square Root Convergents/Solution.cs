using System.Numerics;
using static System.Numerics.BigInteger;
using static System.Console;

// No need to create a Fraction struct when the operations are this simple...
class Solution
{
    const int LIMIT = 1000;

    static void Main()
    {
        int MoreDigitNumerators = 0;
        BigInteger Numerator = 1;
        BigInteger Denominator = 2;
        for (int i = 0; i < LIMIT; i++)
        {
            WriteLine("{0} / {1}", Numerator + Denominator, Denominator);
            if (DigitCount(Numerator + Denominator) > DigitCount(Denominator)) MoreDigitNumerators++;
            BigInteger NewNumerator = Denominator;
            BigInteger NewDenominator = 2 * Denominator + Numerator;
            Numerator = NewNumerator;
            Denominator = NewDenominator;
        }
        WriteLine(MoreDigitNumerators);
        WriteLine("Press enter to exit...");
        Read();
    }

    // Returns the number of digits in Num
    static int DigitCount(BigInteger Num)
    {
        return (int)(Log10(Num) + 1);
    }
}