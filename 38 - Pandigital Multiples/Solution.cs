using System;
using static System.Console;

class Solution
{
    const int MAX = 98765; // ConcatProd is more than 987654321
    static void Main()
    {
        int MaxConcatProductFound = 0;
        for (int Num = 1; Num <= MAX; Num++)
        {
            //if(Num % 10000 == 0) WriteLine("Checking: " + Num);
            int ConcatProduct = GetPandigitalConcatProduct(Num);
            if (ConcatProduct > MaxConcatProductFound)
            {
                MaxConcatProductFound = ConcatProduct;
                WriteLine("Found a new one: " + MaxConcatProductFound);
            }
        }
        Write("Done"); Read();
    }

    // returns the concatenated product of Num with consecutive integers beginning with 1 and 2
    // returns -1 if concatenated product is not pandigital
    static int GetPandigitalConcatProduct(int Num)
    {
        int ConcatProduct = -1;
        int Factor = 3;
        string ProductSoFar = "" + Num + "" + Num * 2;
        while (ProductSoFar.Length < 9)
        {
            ProductSoFar += Num * Factor;
            Factor++;
        }
        if (IsPandigital(ProductSoFar))
        {
            ConcatProduct = Int32.Parse(ProductSoFar);
        }
        return ConcatProduct;
    }

    // Pre: Num is 9 digits long
    // Post: returns true if Num is 1-9 pandigital
    static bool IsPandigital(String Num)
    {
        if (Num.Length != 9) return false;
        for (int i = 1; i <= 9; i++)
        {
            if (!Num.Contains("" + i)) return false;
        }
        return true;
    }
}