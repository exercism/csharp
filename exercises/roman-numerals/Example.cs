using System.Collections.Generic;
using System.Text;

public static class RomanNumeralExtension
{
    private static readonly Dictionary<int, string> ArabicToRomanConversions = new Dictionary<int, string>
        {
            { 1000, "M" }, { 900, "CM" }, { 500, "D" }, { 400, "CD" }, { 100, "C" }, { 90, "XC" }, { 50, "L" },
            { 40, "XL" }, { 10, "X" }, { 9, "IX" }, { 5, "V" }, { 4, "IV" }, { 1, "I" }
        };

    public static string ToRoman(this int value)
    {
        var result = new StringBuilder();
        foreach (var conversion in ArabicToRomanConversions)
        {
            while (value / conversion.Key > 0)
            {
                value -= conversion.Key;
                result.Append(conversion.Value);
            }
        }
        return result.ToString();
    }
}