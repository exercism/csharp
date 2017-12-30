using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class Hexadecimal
{
    private static readonly Dictionary<char, int> AlphaValues = new Dictionary<char, int>
        {
            { 'a', 10 },
            { 'b', 11 },
            { 'c', 12 },
            { 'd', 13 },
            { 'e', 14 },
            { 'f', 15 }
        };

    public static int ToDecimal(string value)
    {
        if (IsNotValidHexadecimal(value)) return 0;

        return value.Select((c, i) => GetNumericValue(c) * SixteenToThePowerOf(value.Length - i - 1)).Sum();
    }

    private static bool IsNotValidHexadecimal(string value)
    {
        return Regex.IsMatch(value, "[^0-9abcdef]", RegexOptions.IgnoreCase);
    }

    private static int GetNumericValue(char value)
    {
        if (char.IsNumber(value))
            return (int)char.GetNumericValue(value);
        return AlphaValues[value];
    }

    private static int SixteenToThePowerOf(int power)
    {
        return (int)Math.Pow(16, power);
    }
}