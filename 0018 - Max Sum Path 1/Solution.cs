using System;
using System.IO;
using System.Math;
using System.Collections.Generic;

class TriangleSum
{
    static string ProgramDataDir = "ProblemDataLarge.txt";

    static void Main()
    {
        TriangleNode Root = LoadTree();
        int MaxSum = GetMaxSum(Root);
        Console.Write("The best path sums up to {0}. Press enter to exit...", MaxSum);
        Console.Read();
    }

    // Loads the tree from the file in the specified directory
    static TriangleNode LoadTree()
    {
        TriangleNode Root = new TriangleNode(-1);
        List<TriangleNode> PrevNodes = new List<TriangleNode>(); // each line of nodes needs to know the line before it
        foreach (string Line in File.ReadAllLines(ProgramDataDir))
        {
            int[] NodeValues = Array.ConvertAll(Line.Split(' '), int.Parse);
            if (Root.Value == -1)
            {
                Root.Value = NodeValues[0];
                PrevNodes.Add(Root);
            }
            else
            {
                List<TriangleNode> TempPrevNodes = new List<TriangleNode>();
                for (int i = 0; i < PrevNodes.Count; i++)
                {
                    TriangleNode ParentNode = PrevNodes[i];
                    TriangleNode ChildNodeLeft = null;
                    if (i == 0)
                    {
                        ChildNodeLeft = new TriangleNode(NodeValues[0]);
                        TempPrevNodes.Add(ChildNodeLeft);
                    }
                    else
                    {
                        ChildNodeLeft = TempPrevNodes[i];
                    }
                    TriangleNode ChildNodeRight = new TriangleNode(NodeValues[i + 1]);
                    ParentNode.Left = ChildNodeLeft;
                    ParentNode.Right = ChildNodeRight;
                    TempPrevNodes.Add(ChildNodeRight);
                }
                PrevNodes = TempPrevNodes;
            }
        }
        return Root;
    }

    // Navigates the tree and returns the maximum sum
    static int GetMaxSum(TriangleNode Curr)
    {
        bool LeafNode = Curr.Left == null && Curr.Right == null;
        bool Memoized = Curr.MaxSum != -1;

        if (LeafNode)
        {
            Curr.MaxSum = Curr.Value;
        }
        else if (!Memoized)
        {
            Curr.MaxSum = Max(GetMaxSum(Curr.Left), GetMaxSum(Curr.Right)) + Curr.Value;
        }
        return Curr.MaxSum;
    }
}
