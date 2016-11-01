using static System.Console;

// I think this is good code, but maybe HasPermutedMultiples() can improve...
class PermutedMultiples
{
    static void Main()
    {
        WriteLine(GetPermutedMultiplesNum());
        WriteLine("Press enter to exit...");
        Read();
    }

    static int GetPermutedMultiplesNum()
    {
        int FirstNum = 10; // First 2 digit number
        int LastNum = 16; // Last 2 digit number that can have the same digit count as 6 times itself. 6 * 17 = 102
        while (true)
        {
            for (int Num = FirstNum; Num <= LastNum; Num++)
            {
                if (HasPermutedMultiples(Num)) return Num;
            }
            FirstNum *= 10; // 10...0
            LastNum = LastNum * 10 + 6; // 16...6
        }
    }

    // Pre: Num has the same number of digits as 6 * Num
    // Returns true if Num has the same
    static bool HasPermutedMultiples(int Num)
    {
        int[] NumDigitCounters = GetDigitCounter(Num);
        for (int i = 2; i <= 6; i++)
        {
            int Multiple = i * Num;
            int[] MultipleDigitCounters = GetDigitCounter(Multiple);
            for (int j = 0; j < MultipleDigitCounters.Length; j++)
            {
                if (NumDigitCounters[j] != MultipleDigitCounters[j]) return false;
            }
        }
        return true;
    }

    // Returns int[10] where index i indicates the number of digits i in Num
    static int[] GetDigitCounter(int Num)
    {
        int[] DigitCounters = new int[10];
        while (Num != 0)
        {
            int Digit = Num % 10;
            DigitCounters[Digit]++;
            Num /= 10;
        }
        return DigitCounters;
    }
}