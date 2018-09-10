using System;
using System.Collections.Generic;

public enum Plant
{
    Violets,
    Radishes,
    Clover,
    Grass
}

public class KindergartenGarden
{    
    public KindergartenGarden(string diagram)
    {
    }

    public IEnumerable<Plant> Plants(string student)
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}