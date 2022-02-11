using System;

public static class Darts
{
    public static int Score(double x, double y)
    {
        var diff = Math.Pow(x, 2) + Math.Pow(y, 2);
        if (diff > 100) // outside the radius 10 squared
            return 0;
        if (diff <= 100 && diff > 25) // outer circle radius of 10 squared
            return 1;
        if (diff <= 25 && diff > 1) // middle circle radius of 5 squared
            return 5;
        if (diff <= 1) // in circle radius of 1 squared
            return 10;

        return 0;
    }
}
