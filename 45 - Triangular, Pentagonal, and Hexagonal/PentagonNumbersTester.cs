class PentagonNumberTester : SeriesTester
{
    protected override long GetFuncVal(long Index)
    {
        return (3 * Index * Index + 5 * Index + 2) / 2;
    }
}