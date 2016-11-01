using static System.Console;

class PentaSolution
{
    static void Main()
    {
        TriangleNumbersTester TriNums = new TriangleNumbersTester();
        PentagonNumberTester PentNums = new PentagonNumberTester();
        HexagonNumberTester HexNums = new HexagonNumberTester();

        long Index = 0;
        long TriNum = TriNums.GetNumAt(Index);
        for (int i = 0; i < 3; i++) // Get the first 3 numbers that are Triangular, Pentagonal, and Hexagonal
        {
            while (!(PentNums.InSeries(TriNum) && HexNums.InSeries(TriNum)))
            {
                TriNum = TriNums.GetNumAt(++Index);
            }
            WriteLine("{0} is triangular, pentagonal, and hexagonal", TriNum);
            TriNum = TriNums.GetNumAt(++Index);
        }

        Write("Press enter to exit..."); Read();
    }
}