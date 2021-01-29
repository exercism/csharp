using System;
using System.Collections.Generic;

public class Tree
{
    public Tree(string value, params Tree[] children)
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}

public static class Pov
{
    public static Tree FromPov(Tree tree, string from)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public static IEnumerable<string> PathTo(string from, string to, Tree tree)
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}