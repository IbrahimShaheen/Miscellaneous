class TriangleNumbersTester : SeriesTester
{
    protected override long GetFuncVal(long Index)
    {
        return (Index * Index + 3 * Index + 2) / 2;
    }
}