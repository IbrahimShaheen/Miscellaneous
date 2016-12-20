using System.Linq;
using System.Collections.Generic;
using static System.String;
using static System.Console;
using System;

class P61
{
    static void Main()
    {
        List<int[]> FourDigFigSeqs = GetFourDigFigSeqs();
        GetCyclic(FourDigFigSeqs);
        WriteLine("Press enter to exit...");
        Read();
    }

    // Returns a List containing sequences of four digit figurate numbers
    static List<int[]> GetFourDigFigSeqs()
    {
        SequenceGenerator TriangleNums = new SequenceGenerator(x => (x + 1) * (x + 2) / 2);
        SequenceGenerator SquareNums = new SequenceGenerator(x => (x + 1) * (x + 1));
        SequenceGenerator PentagonalNums = new SequenceGenerator(x => (x + 1) * (3 * x + 2) / 2);
        SequenceGenerator HexagonalNums = new SequenceGenerator(x => (x + 1) * (2 * x + 1));
        SequenceGenerator HeptagonalNums = new SequenceGenerator(x => (x + 1) * (5 * x + 2) / 2);
        SequenceGenerator OctogonalNums = new SequenceGenerator(x => (x + 1) * (3 * x + 1));

        SequenceGenerator[] FigurateSequenceGenerators =
            { TriangleNums, SquareNums, PentagonalNums, HexagonalNums, HeptagonalNums, OctogonalNums};

        // Precomputed inclusive bounds for figurate nums so that the generators generate all and only 4-digit nums
        int[] MinBounds = { 44, 31, 25, 22, 20, 18 };
        int[] MaxBounds = { 139, 98, 80, 69, 62, 57 };

        List<int[]> FourDigitFigurateNums = new List<int[]>();
        for (int i = 0; i < FigurateSequenceGenerators.Length; i++)
        {
            SequenceGenerator FigurateSequenceGenerator = FigurateSequenceGenerators[i];
            int[] FourDigitNums = new int[MaxBounds[i] - MinBounds[i] + 1];
            for (int j = 0; j < FourDigitNums.Length; j++)
            {
                FourDigitNums[j] = FigurateSequenceGenerator.GetNumAt(MinBounds[i] + j);
            }
            FourDigitFigurateNums.Add(FourDigitNums);
        }

        return FourDigitFigurateNums;
    }

    // Prints cyclic seqs which includes one of each of the seqs in FourDigFigNums
    static void GetCyclic(List<int[]> FourDigFigSeqs)
    {
        int[] FirstSeq = FourDigFigSeqs[0];
        FourDigFigSeqs.RemoveAt(0);
        Stack<int> SoFar = new Stack<int>();
        foreach (int FirstNum in FirstSeq)
        {
            SoFar.Push(FirstNum);
            GetCyclicHelper(FourDigFigSeqs, SoFar);
            SoFar.Pop();
        }
    }

    static void GetCyclicHelper(List<int[]> FourDigFigSeqs, Stack<int> SoFar)
    {
        //WriteLine(Join(", ", SoFar.Select(x => "" + x).ToArray().Reverse()));
        if (FourDigFigSeqs.Count == 0)
        {
            if (SoFar.ElementAt(SoFar.Count - 1) / 100 == SoFar.Peek() % 100)
            {
                WriteLine(Join(", ", SoFar.Select(x => "" + x).ToArray().Reverse()));
                WriteLine("And the sum of that is: {0}", SoFar.Sum());
            }
        }
        else
        {
            for (int i = 0; i < FourDigFigSeqs.Count; i++)
            {
                int[] UsedSeq = FourDigFigSeqs[i];
                FourDigFigSeqs.RemoveAt(i);
                foreach (int Num in UsedSeq)
                {
                    if (SoFar.Peek() % 100 == Num / 100)
                    {
                        SoFar.Push(Num);
                        GetCyclicHelper(FourDigFigSeqs, SoFar);
                        SoFar.Pop();
                    }
                }
                FourDigFigSeqs.Insert(i, UsedSeq);
            }
        }
    }
}