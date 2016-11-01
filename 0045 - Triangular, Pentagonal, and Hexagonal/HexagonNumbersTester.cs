class HexagonNumberTester : SeriesTester
{
    protected override long GetFuncVal(long Index)
    {
        return 2 * Index * Index + 3 * Index + 1;
    }
}