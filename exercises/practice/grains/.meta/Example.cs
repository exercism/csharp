using System;

public static class Grains
{
    public static ulong Square(int n)
    {
        if (n <= 0 || n > 64)
        {
            throw new ArgumentOutOfRangeException(nameof(n));
        }

        return n == 1
            ? 1
            : 2 * Square(n - 1);
    }

    public static ulong Total()
    {
        ulong total = 0;

        for (int i = 1; i <= 64; i++)
        {
            total += Square(i);
        }

        return total;
    }
}