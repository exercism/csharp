// This file was auto-generated based on version 1.0.0 of the canonical data.

using Xunit;

public class RunLengthEncodingTest
{
    [Fact]
    public void Encode_empty_string()
    {
        Assert.Equal("", RunLengthEncoding.Encode(""));
    }

    [Fact(Skip = "Remove to run test")]
    public void Encode_single_characters_only_are_encoded_without_count()
    {
        Assert.Equal("XYZ", RunLengthEncoding.Encode("XYZ"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Encode_string_with_no_single_characters()
    {
        Assert.Equal("2A3B4C", RunLengthEncoding.Encode("AABBBCCCC"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Encode_single_characters_mixed_with_repeated_characters()
    {
        Assert.Equal("12WB12W3B24WB", RunLengthEncoding.Encode("WWWWWWWWWWWWBWWWWWWWWWWWWBBBWWWWWWWWWWWWWWWWWWWWWWWWB"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Encode_multiple_whitespace_mixed_in_string()
    {
        Assert.Equal("2 hs2q q2w2 ", RunLengthEncoding.Encode("  hsqq qww  "));
    }

    [Fact(Skip = "Remove to run test")]
    public void Encode_lowercase_characters()
    {
        Assert.Equal("2a3b4c", RunLengthEncoding.Encode("aabbbcccc"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Decode_empty_string()
    {
        Assert.Equal("", RunLengthEncoding.Decode(""));
    }

    [Fact(Skip = "Remove to run test")]
    public void Decode_single_characters_only()
    {
        Assert.Equal("XYZ", RunLengthEncoding.Decode("XYZ"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Decode_string_with_no_single_characters()
    {
        Assert.Equal("AABBBCCCC", RunLengthEncoding.Decode("2A3B4C"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Decode_single_characters_with_repeated_characters()
    {
        Assert.Equal("WWWWWWWWWWWWBWWWWWWWWWWWWBBBWWWWWWWWWWWWWWWWWWWWWWWWB", RunLengthEncoding.Decode("12WB12W3B24WB"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Decode_multiple_whitespace_mixed_in_string()
    {
        Assert.Equal("  hsqq qww  ", RunLengthEncoding.Decode("2 hs2q q2w2 "));
    }

    [Fact(Skip = "Remove to run test")]
    public void Decode_lower_case_string()
    {
        Assert.Equal("aabbbcccc", RunLengthEncoding.Decode("2a3b4c"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Consistency_encode_followed_by_decode_gives_original_string()
    {
        Assert.Equal("zzz ZZ  zZ", RunLengthEncoding.Decode(RunLengthEncoding.Encode("zzz ZZ  zZ")));
    }
}