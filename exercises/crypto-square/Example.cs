using System;
using System.Collections.Generic;
using System.Linq;

public class Crypto
{
    public Crypto(string input)
    {
        this.NormalizePlaintext = GetNormalizedPlaintext(input);
        this.Size = this.CalculateSize();
    }

    public int Size { get; private set; }

    public string NormalizePlaintext { get; private set; }

    public string NormalizeCiphertext()
    {
        return string.Join(" ", Transpose(this.PlaintextSegments()));
    }

    public string Ciphertext()
    {
        return string.Join("", Transpose(this.PlaintextSegments()));
    }

    public IEnumerable<string> PlaintextSegments()
    {
        return Chunks(this.NormalizePlaintext, this.Size);
    }

    private int CalculateSize()
    {
        return (int) Math.Ceiling(Math.Sqrt(this.NormalizePlaintext.Length));
    }

    private static string GetNormalizedPlaintext(string input)
    {
        return new string(input.ToLowerInvariant().Where(char.IsLetterOrDigit).ToArray());
    }

    private static IEnumerable<string> Chunks(string str, int chunkSize)
    {
        return Enumerable.Range(0, (int)Math.Ceiling(str.Length / (double)chunkSize))
                            .Select(i => str.Substring(i * chunkSize, Math.Min(str.Length - i * chunkSize, chunkSize)));
    }
    
    private static IEnumerable<string> Transpose(IEnumerable<string> input)
    {
        return input.SelectMany(s => s.Select((c, i) => Tuple.Create(i, c)))
                    .GroupBy(x => x.Item1)
                    .Select(g => new string(g.Select(t => t.Item2).ToArray()));
    }
}