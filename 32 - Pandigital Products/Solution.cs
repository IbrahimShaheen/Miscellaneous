using System;
using System.Collections.Generic;
using static System.Console;

class PandigitalProducts
{
    const int UpperLimit = 9999; // The most lopsided Pandigital?Product is 9999 * 1 = 9999
    // 9999 * 2 = 19998, which is more than 9 digits
    static void Main()
    {
        int SumOfPandigitalProducts = 0;
        HashSet<int> PandigitalProducts = new HashSet<int>();

        for (int i = 1; i < UpperLimit; i++)
        {
            for (int j = i + 1; j < UpperLimit; j++)
            {
                int Product = i * j;
                if (ArePandigitals(i, j, Product) && !PandigitalProducts.Contains(Product))
                {
                    SumOfPandigitalProducts += Product;
                    PandigitalProducts.Add(Product);
                    WriteLine(i + " * " + j + " = " + Product);
                }
            }
        }
        WriteLine(SumOfPandigitalProducts);
        Read();
    }

    // Returns true if the Multiplicand, Multiplier, and Product are collectively Pandigital
    static bool ArePandigitals(int Multiplicand, int Multiplier, int Product)
    {
        String Num = "" + Multiplicand + Multiplier + Product;
        if (Num.Length != 9) return false;

        for (int i = 1; i <= 9; i++)
        {
            if (!Num.Contains("" + i))
            {
                return false;
            }
        }
        return true;
    }
}