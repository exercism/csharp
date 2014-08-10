using System;
using System.Linq;
using System.Text;

public class Cipher
{
    private const string ALPHABET = "abcdefghijklmnopqrstuvwxyz";
    private static readonly Random Rand = new Random();

    public string Key { get; private set; }

    public Cipher()
    {
        Key = new string(Enumerable.Range(0, 100).Select(x => ALPHABET[Rand.Next(ALPHABET.Length - 1)]).ToArray());
    }

    public Cipher(string key)
    {
        ThrowIfInvalidKey(key);
        Key = key;
    }

    private static void ThrowIfInvalidKey(string key)
    {
        if (string.IsNullOrWhiteSpace(key))
            throw new ArgumentException("Key cannot be null or empty");
        if (key.All(char.IsDigit))
            throw new ArgumentException("Key cannot be numeric");
        if (key.ToUpper() == key)
            throw new ArgumentException("Key cannot be all caps");
    }

    public string Encode(string plaintext)
    {
        var ciphertext = new StringBuilder(plaintext.Length);

        for (int i = 0; i < plaintext.Length; i++)
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