using System;
using System.Collections.Generic;

public enum Owner
{
    None,
    Black,
    White
}

public class GoCounting
{
    public GoCounting(string input)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public Tuple<Owner, HashSet<(int, int)>> Territory((int, int) coord)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public Dictionary<Owner, HashSet<(int, int)>> Territories()
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}
