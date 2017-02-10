using System;
using Xunit;

public class RandomKeyCipherTest
{
    private readonly Cipher cipher = new Cipher();

    [Fact]
    public void Cipher_key_is_made_of_letters()
    {
        Assert.Matches("[a-z]+", cipher.Key);
    }

    [Fact]
    public void Default_cipher_key_is_100_characters()
    {
        Assert.Equal(100, cipher.Key.Length);
    }

    [Fact]
    public void Cipher_keys_are_randomly_generated()
    {
        Assert.NotEqual(new Cipher().Key, cipher.Key);
    }

    // Here we take advantage of the fact that plaintext of "aaa..." doesn't output
    // the key. This is a critical problem with shift ciphers, some characters
    // will always output the key verbatim.
    [Fact]
    public void Cipher_can_encode()
    {
        Assert.Equal(cipher.Key.Substring(0, 10), cipher.Encode("aaaaaaaaaa"));
    }

    [Fact]
    public void Cipher_can_decode()
    {
        Assert.Equal("aaaaaaaaaa", cipher.Decode(cipher.Key.Substring(0, 10)));
    }

    [Fact]
    public void Cipher_is_reversible()
    {
        const string PLAINTEXT = "abcdefghij";
        Assert.Equal(PLAINTEXT, cipher.Decode(cipher.Encode(PLAINTEXT)));
    }
}


public class IncorrectKeyCipherTest
{
    [Fact]
    public void Cipher_throws_with_an_all_caps_key()
    {
        Assert.Throws<ArgumentException>(() => new Cipher("ABCDEF"));
    }

    [Fact]
    public void Cipher_throws_with_any_caps_key()
    {
        Assert.Throws<ArgumentException>(() => new Cipher("abcdEFg"));
    }

    [Fact]
    public void Cipher_throws_with_numeric_key()
    {
        Assert.Throws<ArgumentException>(() => new Cipher("12345"));
    }

    [Fact]
    public void Cipher_throws_with_any_numeric_key()
    {
        Assert.Throws<ArgumentException>(() => new Cipher("abcd345ef"));
    }

    [Fact]
    public void Cipher_throws_with_empty_key()
    {
        Assert.Throws<ArgumentException>(() => new Cipher(""));
    }
}


public class SubstitutionCipherTest
{
    private const string KEY = "abcdefghij";
    private readonly Cipher cipher = new Cipher(KEY);

    [Fact]
    public void Cipher_keeps_the_submitted_key()
    {
        Assert.Equal(KEY, cipher.Key);
    }

    [Fact]
    public void Cipher_can_encode_with_given_key()
    {
        Assert.Equal("abcdefghij", cipher.Encode("aaaaaaaaaa"));
    }

    [Fact]
    public void Cipher_can_decode_with_given_key()
    {
        Assert.Equal("aaaaaaaaaa", cipher.Decode("abcdefghij"));
    }

    [Fact]
    public void Cipher_is_reversible_given_key()
    {
        const string PLAINTEXT = "abcdefghij";
        Assert.Equal(PLAINTEXT, cipher.Decode(cipher.Encode(PLAINTEXT)));
    }

    [Fact]
    public void Cipher_can_double_shift_encode()
    {
        const string PLAINTEXT = "iamapandabear";
        Assert.Equal("qayaeaagaciai", new Cipher(PLAINTEXT).Encode(PLAINTEXT));
    }

    [Fact]
    public void Cipher_can_wrap_encode()
    {
        Assert.Equal("zabcdefghi", cipher.Encode("zzzzzzzzzz"));
    }

    [Fact]
    public void Cipher_can_encode_a_message_that_is_shorter_than_the_key()
    {
        Assert.Equal("abcde", cipher.Encode("aaaaa"));
    }

    [Fact]
    public void Cipher_can_decode_a_message_that_is_shorter_than_the_key()
    {
        Assert.Equal("aaaaa", cipher.Decode("abcde"));
    }
}