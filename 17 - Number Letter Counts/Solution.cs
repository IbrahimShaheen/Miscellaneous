using System;

class NumberLetterCount
{
    // zero (0 letters), one, two, three, four, five, six, seven, eight, nine
    readonly static int[] SingleDigitsLetters = new int[] { 0, 3, 3, 5, 4, 4, 3, 5, 5, 4 };

    // ten, eleven, twelve, thirteen, fourteen, 
    // fifteen, sixteen, seventeen, eighteen, nineteen
    readonly static int[] TenToNineteenLetters = new int[] { 3, 6, 6, 8, 8, 7, 7, 9, 8, 8 };

    // 0, 0, twenty, thirty, forty, fifty, sixty, seventy, eighty, ninety
    readonly static int[] DoubleDigitsLetters = new int[] { 0, 0, 6, 6, 5, 5, 5, 7, 6, 6 };

    const int Hundred = 7;
    const int And = 3;
    const int OneThousand = 11;

    static void Main()
    {
        int Sum = 0;
        for (int i = 1; i <= 10; i++)
        {
            Sum += GetNumLetters(i);
        }
        Console.WriteLine(Sum);
        Console.ReadLine();
    }

    // pre: 1 <= Num <= 1000
    // returns the number of letters in the English writing of the number
    static int GetNumLetters(int Num)
    {
        if (Num < 10)
        {
            return SingleDigitsLetters[Num];
        }
        else if (Num < 100)
        {
            return GetDoubleDigitsLetters(Num);
        }
        else if (Num < 1000)
        {
            return GetHundredLetters(Num);
        }
        else // Num == 1000
        {
            return OneThousand;
        }
    }

    // returns the number of letters in the triple digit number
    static int GetHundredLetters(int Num)
    {
        int Letters = 0;
        Letters += SingleDigitsLetters[Num / 100];
        Letters += Hundred;
        if (Num % 100 != 0)
        {
            Letters += And + GetNumLetters(Num % 100);
        }
        return Letters;
    }

    // returns the number of letters in the double digit number
    static int GetDoubleDigitsLetters(int Num)
    {
        if (Num < 20)
        {
            return TenToNineteenLetters[Num % 10];
        }
        else
        {
            return DoubleDigitsLetters[Num / 10] + SingleDigitsLetters[Num % 10];
        }
    }
}