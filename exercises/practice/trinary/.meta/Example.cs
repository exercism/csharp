using System;
using System.Linq;

public class Trinary
{
    public static int ToDecimal(string trinary)
    {
        if (IsNotValidTrinary(trinary)) return 0;

        return trinary
            .Select((c, i) => int.Parse(c.ToString()) * ThreeToThePowerOf(trinary.Length - i - 1))
            .Sum();
    }

    private static bool IsNotValidTrinary(string trinary)
    {
        return !trinary.All(x => char.IsDigit(x) && int.Parse(x.ToString()) < 3);
    }

    private static int ThreeToThePowerOf(int power)
    {
        return (int)Math.Pow(3, power);
    }
}