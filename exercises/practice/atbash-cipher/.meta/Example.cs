using System;
using System.Collections.Generic;
using System.Linq;

public static class AtbashCipher
{
    private const int BlockSize = 5;
    private const string Plain = "abcdefghijklmnopqrstuvwxyz0123456789";
    private const string Cipher = "zyxwvutsrqponmlkjihgfedcba0123456789";

    public static string Encode(string plainValue) 
        => string.Join(" ", EncodeInBlocks(GetEncodedCharacters(plainValue)));

    public static string Decode(string encodedValue)
        => new string(encodedValue.Replace(" ", "").Select(Decode).ToArray());

    private static IEnumerable<char> GetEncodedCharacters(string words) 
        => GetValidCharacters(words).Select(Encode);

    private static IEnumerable<char> GetValidCharacters(string words) 
        => words.ToLowerInvariant().Where(char.IsLetterOrDigit);

    private static char Encode(char c) => Cipher[Plain.IndexOf(c)];

    private static char Decode(char c) => Plain[Cipher.IndexOf(c)];

    private static IEnumerable<string> EncodeInBlocks(IEnumerable<char> value)
    {
        var valueAsString = new string(value.ToArray());

        for (var i = 0; i < valueAsString.Length; i += BlockSize)
            yield return valueAsString.Substring(i, Math.Min(BlockSize, valueAsString.Length - i));
    }
}