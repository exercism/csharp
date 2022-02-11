using System;
using System.Collections.Generic;
using System.Linq;

public static class Say
{
    public static string InEnglish(long number)
    {
        if (number < 0L || number >= 1000000000000L)
        {
            throw new ArgumentOutOfRangeException("Number out of range.");
        }

        if (number == 0L)
        {
            return "zero";
        }
        
        return string.Join(" ", Parts(number));
    }

    private static IEnumerable<string> Parts(long number)
    {
        var counts = Counts(number);
        var billionsCount = counts.Item1;
        var millionsCount = counts.Item2;
        var thousandsCount = counts.Item3;
        var remainder = counts.Item4;
        
        var billions = Billions(billionsCount);
        var millions = Millions(millionsCount);
        var thousands = Thousands(thousandsCount);
        var hundreds = Hundreds(remainder);

        return new[] { billions, millions, thousands, hundreds }.Where(x => x != null);
    }

    private static string Bases(long number)
    {
        var values = new[]
        {
            "one",
            "two",
            "three",
            "four",
            "five",
            "six",
            "seven",
            "eight",
            "nine",
            "ten",
            "eleven",
            "twelve",
            "thirteen",
            "fourteen",
            "fifteen",
            "sixteen",
            "seventeen",
            "eighteen",
            "nineteen"
        };

        return number > 0 && number <= values.Length ? values[number - 1] : null;
    }

    private static string Tens(long number)
    {
        if (number < 20L)
        {
            return Bases(number);
        }

        var values = new[]
        {
            "twenty",
            "thirty",
            "forty",
            "fifty",
            "sixty",
            "seventy",
            "eighty",
            "ninety"
        };

        var count = number / 10L;
        var remainder = number % 10L;
        var bases = Bases(remainder);

        var countStr = values[count - 2];
        var basesStr = bases == null ? "" : $"-{bases}";

        return $"{countStr}{basesStr}";
    }

    private static string Hundreds(long number)
    {
        if (number < 100L)
        {
            return Tens(number);
        }
        
        var count = number / 100L;
        var remainder = number % 100L;
        var bases = Bases(count);
        var tens = Tens(remainder);
        var tensStr = tens == null ? "" : $" {tens}";
        
        return $"{bases} hundred{tensStr}";
    }

    private static string Chunk(string str, long number)
    {
        var hundreds = Hundreds(number);
        return hundreds == null ? null : $"{hundreds} {str}";
    }

    private static string Thousands(long number) => Chunk("thousand", number);
    private static string Millions(long number) => Chunk("million", number);
    private static string Billions(long number) => Chunk("billion", number);

    private static Tuple<long, long, long, long> Counts(long number)
    {
        var billionsCount = number / 1000000000L;
        var billionsRemainder = number % 1000000000L;

        var millionsCount = billionsRemainder / 1000000L;
        var millionsRemainder = billionsRemainder % 1000000L;

        var thousandsCount = millionsRemainder / 1000L;
        var thousandsRemainder = millionsRemainder % 1000L;

        return Tuple.Create(billionsCount, millionsCount, thousandsCount, thousandsRemainder);
    }
}