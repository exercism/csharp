using System;
using System.Linq;

public class Binary
{
    public static int ToDecimal(string binary)
    {
        if (IsNotValidBinary(binary)) return 0;

        return binary
            .Select((c, i) => int.Parse(c.ToString()) * TwoToThePowerOf(binary.Length - i - 1))
            .Sum();
    }

    private static bool IsNotValidBinary(string binary)
    {
        return !binary.All(x => char.IsDigit(x) && int.Parse(x.ToString()) < 2);
    }

    private static int TwoToThePowerOf(int power)
    {
        return (int)Math.Pow(2, power);
    }
}