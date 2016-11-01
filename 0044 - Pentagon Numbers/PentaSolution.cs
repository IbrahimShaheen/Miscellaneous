using static System.Console;

class PentaSolution
{
    static PentagonNumberTester PentNums = new PentagonNumberTester();
    static void Main()
    {
        WriteLine(Do());
        Write("Press enter to exit..."); Read();
    }

    static string Do()
    {
        for (int j = 0; j < 10000; j++)
        {
            int LargePentNum = PentNums.GetPentNum(j);
            for (int i = 0; i < j; i++)
            {
                int SmallPentNum = PentNums.GetPentNum(i);
                if (PentNums.IsPentagonal(LargePentNum + SmallPentNum) &&
                    PentNums.IsPentagonal(LargePentNum - SmallPentNum))
                {
                    return "" + LargePentNum + " - " + SmallPentNum;
                }
            }
        }
        return "not found";
    }
}