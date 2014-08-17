using System;
using System.Linq;

public class Luhn
{
    private readonly long number;

    public long CheckDigit { get { return number % 10; } }
    public int[] Addends { get; private set; }
    public int Checksum { get { return Addends.Sum(); } }
    public bool Valid { get { return Checksum % 10 == 0; } }

    public Luhn(long number)
    {
        this.number = number;
        Addends = GenerateAddends();
    }

    private int[] GenerateAddends()
    {
        var reversedIntArray = SplitToReversedIntArray(number);
        for (int i = 1; i < reversedIntArray.Length; i++)
        {
            if (i % 2 != 0)
                reversedIntArray[i] = ConvertDigitForAddend(reversedIntArray[i]);
        }
        Array.Reverse(reversedIntArray);
        return reversedIntArray;
    }

    private static int[] SplitToReversedIntArray(long value)
    {
        return value.ToString().Select(c => int.Parse(c.ToString())).Reverse().ToArray();
    }

    private static int ConvertDigitForAddend(int value)
    {
        var doubled = value * 2;
        return doubled < 10 ? doubled : doubled - 9;
    }

    public static long Create(long number)
    {
        var zeroCheckDigitNumber = number * 10;
        var luhn = new Luhn(zeroCheckDigitNumber);

        if (luhn.Valid)
            return zeroCheckDigitNumber;

        return zeroCheckDigitNumber + CreateCheckDigit(luhn.Checksum);
    }

    private static int CreateCheckDigit(int value)
    {
        var nearestTen = (int)(Math.Ceiling(value / 10.0m) * 10);
        return nearestTen - value;
    }
}