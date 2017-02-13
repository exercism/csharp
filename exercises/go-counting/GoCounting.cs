using System;
using System.Collections.Generic;

public class GoCounting
{
    public enum Player
    {
        None,
        Black,
        White
    }

    public GoCounting(string input)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public Tuple<Player, IEnumerable<Tuple<int, int>>> TerritoryFor(Tuple<int, int> coord)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public Dictionary<Player, IEnumerable<Tuple<int, int>>> Territories()
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}