using System;
using System.Linq;

public class Octal
{
    public static int ToDecimal(string octal)
    {
        if (IsNotValidOctal(octal)) return 0;

        return octal
            .Select((c, i) => int.Parse(c.ToString()) * EightToThePowerOf(octal.Length - i - 1))
            .Sum();
    }

    private static bool IsNotValidOctal(string octal)
    {
        return !octal.All(x => char.IsDigit(x) && int.Parse(x.ToString()) < 8);
    }

    private static int EightToThePowerOf(int power)
    {
        return (int)Math.Pow(8, power);
    }
}