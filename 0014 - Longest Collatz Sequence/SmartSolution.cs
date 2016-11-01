using System;
using System.Collections.Generic;

class CollatzSequence
{
    static void Main()
    {
        int MaxSeqLength = 1;
        Dictionary<long, int> MemoizedSeqs = new Dictionary<long, int>() { { 1, 1} };
        for (int i = 1; i < 10 * 1000 * 1000; i++)
        {
            long Num = i;
            int SeqLength = 0;
            List<long> Seq = new List<long>();
            while (Num != 1)
            {
                if (MemoizedSeqs.ContainsKey(Num))
                {
                    SeqLength = Seq.Count + MemoizedSeqs[Num];
                    Num = 1;
                }
                else
                {
                    Seq.Add(Num);
                    Num = Num % 2 == 0 ? Num / 2 : 3 * Num + 1;
                }
            }
            if (SeqLength == 0) SeqLength = Seq.Count + 1;
            if (SeqLength > MaxSeqLength) MaxSeqLength = SeqLength;
            MemoizeSeq(MemoizedSeqs, Seq);
        }
        Console.WriteLine("Longest is: " + MaxSeqLength);
        Console.Read();
    }

    // Takes in a dictionary of memoized sequences and adds the new collatz sequence
    // Gives each sub seq in Seq the appropriate length
    static void MemoizeSeq(Dictionary<long, int> MemoizedSeqs, List<long> Seq)
    {
        for (int i = 0; i < Seq.Count; i++)
        {
            MemoizedSeqs.Add(Seq[i], Seq.Count - i);
        }
    }
}