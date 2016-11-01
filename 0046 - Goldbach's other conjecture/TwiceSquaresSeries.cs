class TwiceSquaresSeries : SeriesTester
{
    protected override long GetFuncVal(long Index)
    {
        return 2 * (Index + 1) * (Index + 1);
    }
}