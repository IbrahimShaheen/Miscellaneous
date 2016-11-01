using System;
using System.Text;
using static System.Console;
using static System.Math;

// There is some room for improvement here, perhaps even a complete overhaul
class PrimeDigitReplacements
{
    static PrimesList Primes = new PrimesList();
    const int FAMILY_SIZE = 9; // Size of the family needed

    static void Main()
    {
        RunMain();
        WriteLine("Press enter to exit...");
        Read();
    }

    static void RunMain()
    {
        int Digits = 1;
        int MaxFamSize = 0;
        while (true)
        {
            foreach (int Prime in Primes.GetPrimes((int)Pow(10, Digits) - 1, (int)Pow(10, Digits - 1)))
            {
                for (int i = 1; i < (int)Pow(2, Digits); i++) // i is the index of the permutation
                {
                    int CurrFamSize = GetFamSize(Prime, i);
                    if (CurrFamSize > MaxFamSize)
                    {
                        MaxFamSize = CurrFamSize;
                        if (MaxFamSize == FAMILY_SIZE)
                        {
                            WriteLine("{0} is the smallest in a family of {1} with {2} digits", Prime, MaxFamSize, Digits);
                            return;
                        }
                    }
                }
            }
            Digits++;
        }
    }

    // Returns the prime family size of Num given the index, Index, of a permutation
    // The index of the permutation represents, in binary, the configuration of replacements
    // Ex: i = 5 -> 101 in binary -> replace the first and last digit
    // Returns -1 if the digits to be replaced are not the same digit
    static int GetFamSize(int Num, int Index)
    {
        int FamSize = 0;
        StringBuilder NumFamily = new StringBuilder("" + Num);
        string Permutation = Convert.ToString(Index, 2);
        int DigitToBeReplaced = -1;
        for (int i = 0; i < Permutation.Length; i++)
        {
            if (Permutation[i] == '1')
            {
                int ReplacementIndex = i + NumFamily.Length - Permutation.Length;
                if (DigitToBeReplaced == -1)
                {
                    DigitToBeReplaced = NumFamily[ReplacementIndex];
                }
                else if (DigitToBeReplaced != NumFamily[ReplacementIndex])
                {
                    return -1; // Num has different digits being replaced
                }
                NumFamily[ReplacementIndex] = '*';
            }
        }
        StringBuilder Number = new StringBuilder(NumFamily.ToString());
        for (int i = 0; i < 10; i++)
        {
            if (i == 0 && Number[0] == '*') continue; // Add more conditions
            int NumFamilyMember = int.Parse(Number.Replace("*", "" + i).ToString());
            if (Primes.Contains(NumFamilyMember)) FamSize++;
            Number.Clear().Append(NumFamily);
        }
        return FamSize;
    }
}