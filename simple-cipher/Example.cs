using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public class Cipher
{
    private const string ALPHABET = "abcdefghijklmnopqrstuvwxyz";
    private static readonly Random Rand = new Random();

    public string Key { get; private set; }

    public Cipher()
    {
        Key = new string(Enumerable.Range(0, 100).Select(x => ALPHABET[Rand.Next(ALPHABET.Length)]).ToArray());
    }

    public Cipher(string key)
    {
        if (!IsValidKey(key)) throw new ArgumentException("Invalid key");
        Key = key;
    }

    private static bool IsValidKey(string key)
    {
        return Regex.IsMatch(key, "^[a-z]+$");
    }

    public string Encode(string plaintext)
    {
        var ciphertext = new StringBuilder(plaintext.Length);

        for (int i = 0; i < Math.Min(plaintext.Length, Key.Length); i++)
            ciphertext.Append(EncodeCharacter(plaintext, i));

        return ciphertext.ToString();
    }

    private char EncodeCharacter(string plaintext, int idx)
    {
        var alphabetIdx = ALPHABET.IndexOf(plaintext[idx]) + ALPHABET.IndexOf(Key[idx]);
        if (alphabetIdx >= ALPHABET.Length)
            alphabetIdx -= ALPHABET.Length;
        return ALPHABET[alphabetIdx];
    }

    public string Decode(string ciphertext)
    {
        var plaintext = new StringBuilder(ciphertext.Length);

        for (int i = 0; i < ciphertext.Length; i++)
            plaintext.Append(DecodeCharacter(ciphertext, i));

        return plaintext.ToString();
    }

    private char DecodeCharacter(string ciphertext, int idx)
    {
        var alphabetIdx = ALPHABET.IndexOf(ciphertext[idx]) - ALPHABET.IndexOf(Key[idx]);
        if (alphabetIdx < 0)
            alphabetIdx += ALPHABET.Length;
        return ALPHABET[alphabetIdx];
    }
}