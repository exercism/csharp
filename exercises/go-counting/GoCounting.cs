using System;
using System.Collections.Generic;

public enum GoPlayer
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

    public Tuple<GoPlayer, IEnumerable<Tuple<int, int>>> TerritoryFor(Tuple<int, int> coord)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public Dictionary<GoPlayer, IEnumerable<Tuple<int, int>>> Territories()
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}