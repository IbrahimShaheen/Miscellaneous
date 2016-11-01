using static System.Console;
using static System.Math;

class ChampernowneConstant
{
    static void Main()
    {
        //WriteLine(GetChampDig(10));



        //for (int i = 0; i < 1000; i++)
        //{
        //    WriteLine("i = {0}, Dig = {1}", i, GetChampDig(i));
        //}



        int Product = 1;
        for (int i = 0; i <= 6; i++)
        {
            Product *= GetChampDig((int)Pow(10, i));
        }
        Write(Product);
        Read();
    }

    // Returns the digit at the given one-based index in Champernowne's Constant
    static int GetChampDig(int Index)
    {
        int Limit = 9;
        int NumDigCount = 1; // The "Number" within Champ. Const.
        while (Index > Limit)
        {
            Index -= Limit;
            Limit = 9 * (int)Pow(10, NumDigCount) * (NumDigCount + 1); // 9 + 90 * 2 + 900 * 3 ...
            NumDigCount++;
        }

        Index--; // Going to zero-based index
        // Ex: NumDigCount == 3, Index == 4
        // This means 5th digit in the 3 digit numbers, ...100101102... which is 0
        
        int NumIndex = Index / NumDigCount; // Index of Num within Champ. Const
        int Num = NumIndex + (int)Pow(10, NumDigCount - 1);

        int DigitIndex = Index % NumDigCount; // Index of digit within Num
        int Digit = -1;
        for (int i = 0; i < NumDigCount - DigitIndex; i++)
        {
            Digit = Num % 10;
            Num /= 10;
        }
        return Digit;
    }
}