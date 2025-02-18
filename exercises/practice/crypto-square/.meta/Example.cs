using System;
using System.Collections.Generic;
using System.Linq;

public static class CryptoSquare
{
    public static string NormalizedPlaintext(string plaintext) => new string(plaintext.ToLowerInvariant().Where(char.IsLetterOrDigit).ToArray());

    public static IEnumerable<string> PlaintextSegments(string plaintext)
    {
        var normalizedPlaintext = NormalizedPlaintext(plaintext);
        return Chunks(normalizedPlaintext, Size(normalizedPlaintext));
    }

    public static string Encoded(string plaintext) => string.Join("", Transpose(PlaintextSegments(plaintext)));

    public static string Ciphertext(string plaintext) => string.Join(" ", Transpose(PlaintextSegments(plaintext).Select(x => x.PadRight(Size(NormalizedPlaintext(plaintext))))));

    private static int Size(string normalizedPlaintext) => (int)Math.Ceiling(Math.Sqrt(normalizedPlaintext.Length));

    private static IEnumerable<string> Chunks(string str, int chunkSize)
    {
        if (str.Length == 0)
            return Enumerable.Empty<string>();

        return Enumerable
            .Range(0, (int) Math.Ceiling(str.Length / (double) chunkSize))
            .Select(i => str.Substring(i * chunkSize, Math.Min(str.Length - i * chunkSize, chunkSize)));
    }

    private static IEnumerable<string> Transpose(IEnumerable<string> input) 
        => input
            .SelectMany(s => s.Select((c, i) => Tuple.Create(i, c)))
            .GroupBy(x => x.Item1)
            .Select(g => new string(g.Select(t => t.Item2).ToArray()));
}