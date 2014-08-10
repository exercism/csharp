using System;
using System.Linq;

public class Octal
{
    private readonly string value;

    public Octal(string value)
    {
        this.value = value;
    }

    public int ToDecimal()
    {
        if (IsNotValidOctal()) return 0;

        return value
            .Select((c, i) => int.Parse(c.ToString()) * EightToThePowerOf(value.Length - i - 1))
            .Sum();
    }

    private bool IsNotValidOctal()
    {
        return !value.All(x => char.IsDigit(x) && int.Parse(x.ToString()) < 8);
    }

    private static int EightToThePowerOf(int power)
    {
        return (int)Math.Pow(8, power);
    }
}