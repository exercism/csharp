using NUnit.Framework;

public class RunLengthEncodingTest
{
    [Test]
    public void Encode_simple()
    {
        const string input = "AABBBCCCC";
        const string expected = "2A3B4C";
        Assert.That(RunLengthEncoding.Encode(input), Is.EqualTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Decode_simple()
    {
        const string input = "2A3B4C";
        const string expected = "AABBBCCCC";
        Assert.That(RunLengthEncoding.Decode(input), Is.EqualTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Encode_with_single_values()
    {
        const string input = "WWWWWWWWWWWWBWWWWWWWWWWWWBBBWWWWWWWWWWWWWWWWWWWWWWWWB";
        const string expected = "12WB12W3B24WB";
        Assert.That(RunLengthEncoding.Encode(input), Is.EqualTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Decode_with_single_values()
    {
        const string input = "12WB12W3B24WB";
        const string expected = "WWWWWWWWWWWWBWWWWWWWWWWWWBBBWWWWWWWWWWWWWWWWWWWWWWWWB";
        Assert.That(RunLengthEncoding.Decode(input), Is.EqualTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Encode_and_then_decode()
    {
        const string input = "zzz ZZ  zZ";
        const string expected = "zzz ZZ  zZ";
        Assert.That(RunLengthEncoding.Decode(RunLengthEncoding.Encode(input)), Is.EqualTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Encode_unicode()
    {
        const string input = "⏰⚽⚽⚽⭐⭐⏰";
        const string expected = "⏰3⚽2⭐⏰";
        Assert.That(RunLengthEncoding.Encode(input), Is.EqualTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Decode_unicode()
    {
        const string input = "⏰3⚽2⭐⏰";
        const string expected = "⏰⚽⚽⚽⭐⭐⏰";
        Assert.That(RunLengthEncoding.Decode(input), Is.EqualTo(expected));
    }
}