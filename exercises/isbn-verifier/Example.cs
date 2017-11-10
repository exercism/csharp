using System;
using System.Text.RegularExpressions;

public static class IsbnVerifier
{
    public static bool IsValid(string number)
    {
        number = number.Replace("-", "");

        if (!Regex.IsMatch(number, @"^(\d{9}[\dX])$"))
        {
            return false;
        }

        var sum = 0;
        var weight = 10;
        var digit = 0;
        for (int i = 0; i < number.Length; i++)
        {
            digit = (number[i] == 'X' && i == 9) ? 10 : (int)Char.GetNumericValue(number[i]);

            sum += digit * weight;
            weight--;
        }
        return sum % 11 == 0;
    }
}