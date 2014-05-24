using System;
using System.Linq;

public class Binary
{
    private readonly string number;

    public Binary(string number)
    {
        this.number = number;
    }

    public int ToDecimal()
    {
        if (IsNotANumber()) return 0;

        return number
            .Select((c, i) => int.Parse(c.ToString()) * TwoToThePowerOf(number.Length - i - 1))
            .Sum();
    }

    private bool IsNotANumber()
    {
        return !number.All(char.IsDigit);
    }

    private static int TwoToThePowerOf(int power)
    {
        return (int)Math.Pow(2, power);
    }
}