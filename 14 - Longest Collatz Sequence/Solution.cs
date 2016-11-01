using System;
using System.Collections.Generic;

class CollatzSequence
{
    static void Main()
    {
        int MaxSeqLength = 1;
        long NumOfMaxSeq = -1;
        for (int i = 1; i < 1000 * 1000; i++)
        {
            long Num = i;
            int SeqLength = 1;
            while (Num != 1)
            {
                Num = Num % 2 == 0 ? Num / 2 : 3 * Num + 1;
                SeqLength++;
            }
            if (SeqLength > MaxSeqLength)
            {
                MaxSeqLength = SeqLength;
                NumOfMaxSeq = i;
            }
        }
        Console.WriteLine("Longest is: " + NumOfMaxSeq);
        Console.Read();
    }
}