using static System.Console;

class NumberSpiralDiagonals
{
    static void Main()
    {
        int SpiralSize = 1001;
        int Numbers = SpiralSize * SpiralSize;
        int SkipLength = 1;

        int SumOfDiagonals = 1;
        int CurrNum = 1;
        int NumsAdded = 0;
        while (CurrNum < Numbers)
        {
            CurrNum += SkipLength + 1;
            SumOfDiagonals += CurrNum;
            NumsAdded++;
            if (NumsAdded % 4 == 0)
            {
                SkipLength += 2;
            }
            WriteLine(CurrNum);
        }

        WriteLine(SumOfDiagonals);
        Read();
    }


}