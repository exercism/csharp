using System;
using System.Linq;

public class Binary
{
    private readonly string value;

    public Binary(string value)
    {
        this.value = value;
    }

    public int ToDecimal()
    {
        if (IsNotValidBinary()) return 0;

        return value
            .Select((c, i) => int.Parse(c.ToString()) * TwoToThePowerOf(value.Length - i - 1))
            .Sum();
    }

    private bool IsNotValidBinary()
    {
        return !value.All(x => char.IsDigit(x) && int.Parse(x.ToString()) < 2);
    }

    private static int TwoToThePowerOf(int power)
    {
        return (int)Math.Pow(2, power);
    }
}