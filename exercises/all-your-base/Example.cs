using System;
using System.Collections.Generic;
using System.Linq;

public static class Base
{
    public static int[] Rebase(int inputBase, int[] inputDigits, int outputBase)
    {
        if (inputBase < 2) throw new ArgumentException("Invalid input base.");
        if (outputBase < 2) throw new ArgumentException("Invalid output base.");
        if (inputDigits.Length == 0) throw new ArgumentException("Empty input digits.");

        return ToDigits(outputBase, FromDigits(inputBase, inputDigits));
    }

    private static int FromDigits(int fromBase, int[] fromDigits)
    {
        return fromDigits.Aggregate(0, (acc, x) =>
        {
            if (x < 0 || x >= fromBase || (x == 0 & acc == 0)) throw new ArgumentException("Invalid input digit");

            return acc*fromBase + x;
        });
    }

    private static int[] ToDigits(int toBase, int x)
    {
        var digits = new List<int>();
        var remainder = x;
        var multiplier = 1;

        while (remainder > 0)
        {
            multiplier *= toBase;

            var value = remainder % multiplier;
            var digit = value/(multiplier/toBase);

            digits.Add(digit);
            remainder -= value;
        }

        digits.Reverse();
        return digits.ToArray();
    }
}