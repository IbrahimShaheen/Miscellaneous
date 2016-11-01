using System.Collections.Generic;

class TriangleNumberWordTester
{
    private HashSet<int> TriangleNumbersCache = new HashSet<int>();
    private int MaxTriangleNumberCached = 0;

    // Returns true if Word has a number value equal to any triangle number
    public bool IsTriangleNumberWord(string Word)
    {
        int NumVal = GetNumVal(Word);
        while (MaxTriangleNumberCached < NumVal)
        {
            int NewTriangleNumber = (TriangleNumbersCache.Count + 1) * (TriangleNumbersCache.Count + 2) / 2;
            MaxTriangleNumberCached = NewTriangleNumber;
            TriangleNumbersCache.Add(NewTriangleNumber);
        }
        return TriangleNumbersCache.Contains(NumVal);
    }

    // Returns the sum of the numerical value of the chars of Word. a = 1, b = 2 etc...
    private int GetNumVal(string Word)
    {
        Word = Word.ToLower();
        int NumVal = 0;
        foreach (char Character in Word)
        {
            NumVal += Character - ASCII_BEGIN_VALUE;
        }
        return NumVal;
    }
}
