using Xunit;

public class RunLengthEncodingTest
{
    [Fact]
    public void Encode_simple()
    {
        const string input = "AABBBCCCC";
        const string expected = "2A3B4C";
        Assert.Equal(expected, RunLengthEncoding.Encode(input));
    }

    [Fact]
    public void Decode_simple()
    {
        const string input = "2A3B4C";
        const string expected = "AABBBCCCC";
        Assert.Equal(expected, RunLengthEncoding.Decode(input));
    }

    [Fact]
    public void Encode_with_single_values()
    {
        const string input = "WWWWWWWWWWWWBWWWWWWWWWWWWBBBWWWWWWWWWWWWWWWWWWWWWWWWB";
        const string expected = "12WB12W3B24WB";
        Assert.Equal(expected, RunLengthEncoding.Encode(input));
    }

    [Fact]
    public void Decode_with_single_values()
    {
        const string input = "12WB12W3B24WB";
        const string expected = "WWWWWWWWWWWWBWWWWWWWWWWWWBBBWWWWWWWWWWWWWWWWWWWWWWWWB";
        Assert.Equal(expected, RunLengthEncoding.Decode(input));
    }

    [Fact]
    public void Encode_and_then_decode()
    {
        const string input = "zzz ZZ  zZ";
        const string expected = "zzz ZZ  zZ";
        Assert.Equal(expected, RunLengthEncoding.Decode(RunLengthEncoding.Encode(input)));
    }

    [Fact]
    public void Encode_unicode()
    {
        const string input = "⏰⚽⚽⚽⭐⭐⏰";
        const string expected = "⏰3⚽2⭐⏰";
        Assert.Equal(expected, RunLengthEncoding.Encode(input));
    }

    [Fact]
    public void Decode_unicode()
    {
        const string input = "⏰3⚽2⭐⏰";
        const string expected = "⏰⚽⚽⚽⭐⭐⏰";
        Assert.Equal(expected, RunLengthEncoding.Decode(input));
    }
}