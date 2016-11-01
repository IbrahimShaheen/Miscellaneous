// TODO: make this class make sense, pref-wise

using System.Collections.Generic;

class PentagonNumberTester
{
    private HashSet<int> PentagonNumbersCache = new HashSet<int>();
    private int MaxPentagonNumberCached = 0;

    // Returns true if Num is pentagonal
    public bool IsPentagonal(int Num)
    {
        while (Num > MaxPentagonNumberCached)
        {
            int n = PentagonNumbersCache.Count;
            int NewPentagonNumber = (3 * n * n + 5 * n + 2) / 2;
            MaxPentagonNumberCached = NewPentagonNumber;
            PentagonNumbersCache.Add(NewPentagonNumber);
        }
        return PentagonNumbersCache.Contains(Num);
    }

    // Returns the pentagonal number with index i
    public int GetPentNum(int i)
    {
        int NewPentagonNumber = (3 * i * i + 5 * i + 2) / 2;
        IsPentagonal(NewPentagonNumber);
        return NewPentagonNumber;
    }
}