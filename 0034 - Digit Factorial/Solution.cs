using System.
using static System.Console;

class DigitFactorial
{
    // 2540161 cannot be obtained by the DigitFactorial of any 7 digit number
    const int UPPER_LIMIT = 2540160;
    readonly static int[] FACTORIAL = new int[] { 1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880 };
    static void Main()
    {
        int Sum = 0;
        for (int Num = 3; Num <= UPPER_LIMIT; Num++)
        {
            if (Num == FactorialDigitSum(Num))
            {
                Sum += Num;
                WriteLine(Num);
            }
        }
        WriteLine(Sum);
    }

    // returns the sum of the factorials of the digits of Num
    static int FactorialDigitSum(int Num)
    {
        int Sum = 0;
        while (Num != 0)
        {
            int Digit = Num % 10;
            Sum += FACTORIAL[Digit];
            Num /= 10;
        }
        return Sum;
    }

    // COMPARISON METHOD
    // returns the factorial of Num
    static int Factorial(int Num)
    {
        int Factorial = 1;
        if (Num > 1)
        {
            for (int i = Num; i > 1; i--)
            {
                Factorial *= i;
            }
        }
        return Factorial;
    }
}