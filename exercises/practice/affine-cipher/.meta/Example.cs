using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class AffineCipher
{
    private static int m = 26;

    public static string Encode(string plainText, int a, int b)
    {
        var inverse = FindInverse(a, m);

        var source = plainText.Where(p => char.IsLetterOrDigit(p)).Select(p => Encrypt(p, a, b)).ToList();

        var sb = new StringBuilder();

        for (int i = 0; i < source.Count; i++)
        {
            if (i > 0 && i % 5 == 0)
            {
                sb.Append(' ');
            }

            sb.Append(source[i]);
        }

        return sb.ToString();
    }

    public static string Decode(string cipheredText, int a, int b)
    {
        var inv = FindInverse(a, m);

        var source = cipheredText.Where(p => char.IsLetterOrDigit(p)).Select(p => Decrypt(p, inv, b)).ToList();

        var sb = new StringBuilder();

        for (int i = 0; i < source.Count; i++)
        {
            sb.Append(source[i]);
        }

        return sb.ToString();
    }

    private static Char Decrypt(Char c, int a, int b)
    {
        if (!char.IsLetter(c))
        {
            return c;
        }

        if (char.IsUpper(c))
        {
            c = char.ToLower(c);
        }


        int x = c - 97;
        int mod = ((x - b) * a) % m;

        if (mod < 0)
        {
            mod = mod + m;
        }

        return (Char)(mod + 97);
    }

    private static Char Encrypt(Char c, int a, int b)
    {
        if (!char.IsLetter(c))
        {
            return c;
        }

        if (char.IsUpper(c))
        {
            c = char.ToLower(c);
        }


        int x = c - 97;
        int mod = (a * x + b) % m;

        if (mod < 0)
        {
            mod = mod + m;
        }

        return (Char)(mod + 97);
    }

    private static int FindInverse(int a, int b)
    {
        var (x0, x1, y0, y1) = (1, 0, 0, 1);

        while (a != 0)
        {
            var q = b / a;
            (b, a) = (a, b % a);
            (x0, x1) = (x1, x0 - q * x1);
            (y0, y1) = (y1, y0 - q * y1);
        }

        if (b > 1)
        {
            throw new ArgumentException("a and m must be coprime.");
        }

        return y0;
    }
}
