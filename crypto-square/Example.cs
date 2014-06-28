using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Crypto
{
    public string NormalizePlaintext { get; private set; }
    public int Size { get; private set; }

    public Crypto(string value)
    {
        NormalizePlaintext = NormalizeText(value);
        Size = GetSquareSize(NormalizePlaintext);
    }

    private static string NormalizeText(string text)
    {
        return string.Concat(text.ToLower().Where(char.IsLetterOrDigit));
    }

    private static int GetSquareSize(string text)
    {
        return (int)Math.Ceiling(Math.Sqrt(text.Length));
    }

    public string[] PlaintextSegments()
    {
        return SegmentText(NormalizePlaintext, Size);
    }

    private static string[] SegmentText(string text, int size)
    {
        var segments = new List<string>();
        var idx = 0;
        while (idx < text.Length)
        {
            if (idx + size < text.Length)
                segments.Add(text.Substring(idx, size));
            else
                segments.Add(text.Substring(idx));
            idx += size;
        }
        return segments.ToArray();
    }

    public string Ciphertext()
    {
        var ciphertext = new StringBuilder(NormalizePlaintext.Length);

        for (int i = 0; i < Size; i++)
        {
            foreach (var segment in PlaintextSegments())
            {
                if (i < segment.Length)
                    ciphertext.Append(segment[i]);
            }
        }
        return ciphertext.ToString();
    }

    public string NormalizeCiphertext()
    {
        return string.Join(" ", SegmentText(Ciphertext(), 5));
    }
}