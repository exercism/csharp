using System;
using System.Collections.Generic;

public class SgfTree
{
    public SgfTree(IDictionary<string, string[]> data, params SgfTree[] children)
    {
        Data = data;
        Children = children;
    }

    public IDictionary<string, string[]> Data { get; }
    public SgfTree[] Children { get; }
}

public class SgfParser
{
    public static SgfTree ParseTree(string input)
    {
        throw new NotImplementedException();
    }
}