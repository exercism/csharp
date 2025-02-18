using System;
using System.Collections.Generic;
using System.Linq;

public static class VariableLengthQuantity
{
    private const uint SevenBitsMask = 0x7fu;
    private const uint EightBitMask = 0x80u;

    public static uint[] Encode(uint[] numbers) => numbers.SelectMany(EncodeSingle).ToArray();

    private static IEnumerable<uint> EncodeSingle(uint number)
    {
        if (number == 0)
        {
            return new[] { 0u };
        }

        var bytes = new List<uint>(4);

        while (number > 0)
        {
            var tmp = number & SevenBitsMask;
            number >>= 7;

            if (bytes.Any())
            {
                tmp |= EightBitMask;
            }

            bytes.Add(tmp);
        }

        bytes.Reverse();
        return bytes;
    }

    public static uint[] Decode(uint[] bytes)
    {
        var numbers = new List<uint>();
        var tmp = 0u;

        for (var index = 0; index < bytes.Length; index++)
        {
            if ((tmp & 0xfe000000u) > 0)
            {
                throw new InvalidOperationException("Overflow exception.");
            }

            var b = bytes[index];
            tmp = (tmp << 7) | (b & 0x7fu);

            if ((b & 0x80) == 0)
            {
                numbers.Add(tmp);
                tmp = 0;
            }
            else if (index == bytes.Length - 1)
            {
                throw new InvalidOperationException("Incomplete byte sequence.");
            }
        }
        
        return numbers.ToArray();
    }
}