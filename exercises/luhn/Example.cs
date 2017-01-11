using System;
using System.Linq;

public static class Luhn
{
    public static bool IsValid(string number)
    {
        number = number.Replace(" ", "");

        if (number.Length < 2 || number.Any(c => c < '0' || c > '9'))
        {
            return false;
        }

        var checksum = GenerateChecksum(number);

        return checksum % 10 == 0;
    }

    private static int GenerateChecksum(string number)
    {
        var reversedIntArray = SplitToReversedIntArray(number);
        for (int i = 1; i < reversedIntArray.Length; i++)
        {
            if (i % 2 != 0)
                reversedIntArray[i] = ConvertDigitForAddend(reversedIntArray[i]);
        }
        Array.Reverse(reversedIntArray);
        return reversedIntArray.Sum();
    }

    private static int[] SplitToReversedIntArray(string value)
    {
        return value.Select(c => int.Parse(c.ToString())).Reverse().ToArray();
    }

    private static int ConvertDigitForAddend(int value)
    {
        var doubled = value * 2;
        return doubled < 10 ? doubled : doubled - 9;
    }
}