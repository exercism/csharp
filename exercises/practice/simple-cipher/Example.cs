using System;
using System.Linq;
using System.Text;

public class SimpleCipher
{
    private const string Alphabet = "abcdefghijklmnopqrstuvwxyz";

    private static readonly Random Rand = new Random();

    public string Key { get; }

    public SimpleCipher()
    {
        Key = new string(Enumerable.Range(0, 100).Select(x => Alphabet[Rand.Next(Alphabet.Length)]).ToArray());
    }

    public SimpleCipher(string key)
    {
        Key = key;
    }

    public string Encode(string plaintext)
    {
        var ciphertext = new StringBuilder(plaintext.Length);

        for (var i = 0; i < plaintext.Length; i++)
            ciphertext.Append(EncodeCharacter(plaintext, i));

        return ciphertext.ToString();
    }

    private char EncodeCharacter(string plaintext, int idx)
    {
        var alphabetIdx = Alphabet.IndexOf(plaintext[idx]) + Alphabet.IndexOf(Key[idx % Key.Length]);
        if (alphabetIdx >= Alphabet.Length)
            alphabetIdx -= Alphabet.Length;
        return Alphabet[alphabetIdx];
    }

    public string Decode(string ciphertext)
    {
        var plaintext = new StringBuilder(ciphertext.Length);

        for (var i = 0; i < ciphertext.Length; i++)
            plaintext.Append(DecodeCharacter(ciphertext, i));

        return plaintext.ToString();
    }

    private char DecodeCharacter(string ciphertext, int idx)
    {
        var alphabetIdx = Alphabet.IndexOf(ciphertext[idx]) - Alphabet.IndexOf(Key[idx % Key.Length]);
        if (alphabetIdx < 0)
            alphabetIdx += Alphabet.Length;
        return Alphabet[alphabetIdx];
    }
}