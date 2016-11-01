using System;
using System.Collections.Generic;
using static System.Console;

class LexicographicPermutations
{
    static readonly List<int> DigitsToUse = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
    static void Main()
    {
        int PermsOfDigits = Factorial(DigitsToUse.Count);
        for (int i = 0; i < PermsOfDigits; i++)
        {
            WriteLine(GetLexiPerm(i));
        }
        Read();
    }

    // returns the lexicographic permutation of the digits at the given Position
    static string GetLexiPerm(int Position)
    {
        List<int> DigitsGiven = new List<int>(DigitsToUse);
        return GetLexiPermHelper(Position, DigitsGiven);
    }

    static string GetLexiPermHelper(int PositionsLeft, List<int> DigitsLeft)
    {
        if (DigitsLeft.Count == 0)
        {
            return "";
        }
        else
        {
            int PositionsPerDigit = Factorial(DigitsLeft.Count - 1);
            int DigitIndex = PositionsLeft / PositionsPerDigit;
            int DigitUsed = DigitsLeft[DigitIndex];

            PositionsLeft -= DigitIndex * PositionsPerDigit;
            DigitsLeft.RemoveAt(DigitIndex);
            return DigitUsed + GetLexiPermHelper(PositionsLeft, DigitsLeft);
        }
    }

    // Pre: Num > -1, else throw ArgumentException
    // returns the factorial of Num
    static int Factorial(int Num)
    {
        if (Num < 0)
        {
            throw new ArgumentException();
        }
        int Factorial = 1;
        for (int i = 0; i < Num; i++)
        {
            Factorial *= i + 1;
        }
        return Factorial;
    }
}