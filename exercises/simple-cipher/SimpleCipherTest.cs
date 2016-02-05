using NUnit.Framework;

[TestFixture]
public class RandomKeyCipherTest
{
    private Cipher cipher;

    [SetUp]
    public void Setup()
    {
        cipher = new Cipher();
    }

    [Test]
    public void Cipher_key_is_made_of_letters()
    {
        Assert.That(cipher.Key, Does.Match("[a-z]+"));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Default_cipher_key_is_100_characters()
    {
        Assert.That(cipher.Key, Has.Length.EqualTo(100));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Cipher_keys_are_randomly_generated()
    {
        Assert.That(cipher.Key, Is.Not.EqualTo(new Cipher().Key));
    }

    // Here we take advantage of the fact that plaintext of "aaa..." doesn't output
    // the key. This is a critical problem with shift ciphers, some characters
    // will always output the key verbatim.
    [Ignore("Remove to run test")]
    [Test]
    public void Cipher_can_encode()
    {
        Assert.That(cipher.Encode("aaaaaaaaaa"), Is.EqualTo(cipher.Key.Substring(0, 10)));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Cipher_can_decode()
    {
        Assert.That(cipher.Decode(cipher.Key.Substring(0, 10)), Is.EqualTo("aaaaaaaaaa"));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Cipher_is_reversible()
    {
        const string PLAINTEXT = "abcdefghij";
        Assert.That(cipher.Decode(cipher.Encode(PLAINTEXT)), Is.EqualTo(PLAINTEXT));
    }
}

[TestFixture]
public class IncorrectKeyCipherTest
{
    [Ignore("Remove to run test")]
    [Test]
    public void Cipher_throws_with_an_all_caps_key()
    {
        Assert.That(() => new Cipher("ABCDEF"), Throws.ArgumentException);
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Cipher_throws_with_any_caps_key()
    {
        Assert.That(() => new Cipher("abcdEFg"), Throws.ArgumentException);
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Cipher_throws_with_numeric_key()
    {
        Assert.That(() => new Cipher("12345"), Throws.ArgumentException);
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Cipher_throws_with_any_numeric_key()
    {
        Assert.That(() => new Cipher("abcd345ef"), Throws.ArgumentException);
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Cipher_throws_with_empty_key()
    {
        Assert.That(() => new Cipher(""), Throws.ArgumentException);
    }
}

[TestFixture]
public class SubstitutionCipherTest
{
    private const string KEY = "abcdefghij";
    private Cipher cipher;

    [Ignore("Remove to run test")]
    [SetUp]
    public void Setup()
    {
        cipher = new Cipher(KEY);
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Cipher_keeps_the_submitted_key()
    {
        Assert.That(cipher.Key, Is.EqualTo(KEY));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Cipher_can_encode_with_given_key()
    {
        Assert.That(cipher.Encode("aaaaaaaaaa"), Is.EqualTo("abcdefghij"));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Cipher_can_decode_with_given_key()
    {
        Assert.That(cipher.Decode("abcdefghij"), Is.EqualTo("aaaaaaaaaa"));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Cipher_is_reversible_given_key()
    {
        const string PLAINTEXT = "abcdefghij";
        Assert.That(cipher.Decode(cipher.Encode(PLAINTEXT)), Is.EqualTo(PLAINTEXT));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Cipher_can_double_shift_encode()
    {
        const string PLAINTEXT = "iamapandabear";
        Assert.That(new Cipher(PLAINTEXT).Encode(PLAINTEXT), Is.EqualTo("qayaeaagaciai"));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Cipher_can_wrap_encode()
    {
        Assert.That(cipher.Encode("zzzzzzzzzz"), Is.EqualTo("zabcdefghi"));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Cipher_can_encode_a_message_that_is_shorter_than_the_key()
    {
        Assert.That(cipher.Encode("aaaaa"), Is.EqualTo("abcde"));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Cipher_can_decode_a_message_that_is_shorter_than_the_key()
    {
        Assert.That(cipher.Decode("abcde"), Is.EqualTo("aaaaa"));
    }
}