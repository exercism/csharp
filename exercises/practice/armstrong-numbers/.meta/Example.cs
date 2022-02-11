using System;

public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number)
    {
        var numString = number.ToString();
        var length = numString.Length;

        double total = 0;
        for (int i = 0; i < length; i++)
        {
            total += Math.Pow(int.Parse(numString[i].ToString()), length);
        }

        return number == (int)total;
    }
}