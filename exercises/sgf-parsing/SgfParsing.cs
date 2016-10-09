using System.Collections.Generic;

public class SgfTree
{
    public IDictionary<string, string[]> Data { get; }
    public SgfTree[] Children { get; }

    public SgfTree(IDictionary<string, string[]> data, params SgfTree[] children)
    {
        Data = data;
        Children = children;
    }
}