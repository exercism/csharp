using System;

public struct Clock
{
    public Clock(int hours, int minutes = 0)
    {
        Hours = Mod((hours * 60 + minutes) / 60.0, 24);
        Minutes = Mod(minutes, 60);
    }
    
    public int Hours { get; }

    public int Minutes { get; }

    public Clock Add(int minutesToAdd)
    {
        return new Clock(Hours, Minutes + minutesToAdd);
    }

    public Clock Subtract(int minutesToSubtract)
    {
        return new Clock(Hours, Minutes - minutesToSubtract);
    }

    public override string ToString()
    {
        return $"{Hours:00}:{Minutes:00}";
    }

    private static int Mod(double x, double y)
    {
        return (int)((x % y + y) % y);
    }
}