using System;

class TriangleNode
{
    public int Value { get; set; }
    public TriangleNode Left { get; set; }
    public TriangleNode Right { get; set; }
    public int MaxSum { get; set; }

    public TriangleNode(int Value)
    {
        this.Value = Value;
        this.MaxSum = -1;
    }
}
