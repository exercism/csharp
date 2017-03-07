using System;
using System.Collections.Generic;

public enum Plant
{
    Violets,
    Radishes,
    Clover,
    Grass
}

public class Garden
{
    public Garden(IEnumerable<string> children, string windowSills)
    {
    }

    public IEnumerable<Plant> GetPlants(string child)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public static Garden DefaultGarden(string windowSills)
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}