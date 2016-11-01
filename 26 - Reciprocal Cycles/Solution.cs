using System;
using System.Collections.Generic;
using static System.Console;

class ReciprocalCycles
{
    static void Main()
    {
        int MaxCycleLength = 0;
        int Num = 0;
        for (int i = 2; i < 1000; i++)
        {
            int CycleLength = GetReciprocalCycleLength(i);
            if (CycleLength > MaxCycleLength)
            {
                MaxCycleLength = CycleLength;
                Num = i;
            }
        }
        WriteLine(MaxCycleLength);
        Read();
    }

    // returns the length of the repeating cycle
    static int GetReciprocalCycleLength(int Divisor)
    {
        int CycleLength = 0;
        int Dividend = 1;
        List<int> PreviousDividends = new List<int>() { 0 };

        while (!PreviousDividends.Contains(Dividend))
        {
            if (Dividend < Divisor)
            {
                Dividend *= 10;
            }
            else
            {
                PreviousDividends.Add(Dividend);
                Dividend = Dividend % Divisor;
            }
        }
        if (Dividend != 0)
        {
            CycleLength = PreviousDividends.Count - PreviousDividends.IndexOf(Dividend);
        }
        return CycleLength;
    }
}