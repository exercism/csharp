// This file was auto-generated based on version 2.0.0 of the canonical data.

using System;
using Xunit;

public class AffineCipherTest
{
    [Fact]
    public void Encode_yes()
    {
        Assert.Equal("xbt", AffineCipher.Encode("yes", 5, 7));
    }

    [Fact(Skip = "Remove to run test")]
    public void Encode_no()
    {
        Assert.Equal("fu", AffineCipher.Encode("no", 15, 18));
    }

    [Fact(Skip = "Remove to run test")]
    public void Encode_omg()
    {
        Assert.Equal("lvz", AffineCipher.Encode("OMG", 21, 3));
    }

    [Fact(Skip = "Remove to run test")]
    public void Encode_o_m_g()
    {
        Assert.Equal("hjp", AffineCipher.Encode("O M G", 25, 47));
    }

    [Fact(Skip = "Remove to run test")]
    public void Encode_mindblowingly()
    {
        Assert.Equal("rzcwa gnxzc dgt", AffineCipher.Encode("mindblowingly", 11, 15));
    }

    [Fact(Skip = "Remove to run test")]
    public void Encode_numbers()
    {
        Assert.Equal("jqgjc rw123 jqgjc rw", AffineCipher.Encode("Testing,1 2 3, testing.", 3, 4));
    }

    [Fact(Skip = "Remove to run test")]
    public void Encode_deep_thought()
    {
        Assert.Equal("iynia fdqfb ifje", AffineCipher.Encode("Truth is fiction.", 5, 17));
    }

    [Fact(Skip = "Remove to run test")]
    public void Encode_all_the_letters()
    {
        Assert.Equal("swxtj npvyk lruol iejdc blaxk swxmh qzglf", AffineCipher.Encode("The quick brown fox jumps over the lazy dog.", 17, 33));
    }

    [Fact(Skip = "Remove to run test")]
    public void Encode_with_a_not_coprime_to_m()
    {
        Assert.Throws<ArgumentException>(() => AffineCipher.Encode("This is a test.", 6, 17));
    }

    [Fact(Skip = "Remove to run test")]
    public void Decode_exercism()
    {
        Assert.Equal("exercism", AffineCipher.Decode("tytgn fjr", 3, 7));
    }

    [Fact(Skip = "Remove to run test")]
    public void Decode_a_sentence()
    {
        Assert.Equal("anobstacleisoftenasteppingstone", AffineCipher.Decode("qdwju nqcro muwhn odqun oppmd aunwd o", 19, 16));
    }

    [Fact(Skip = "Remove to run test")]
    public void Decode_numbers()
    {
        Assert.Equal("testing123testing", AffineCipher.Decode("odpoz ub123 odpoz ub", 25, 7));
    }

    [Fact(Skip = "Remove to run test")]
    public void Decode_all_the_letters()
    {
        Assert.Equal("thequickbrownfoxjumpsoverthelazydog", AffineCipher.Decode("swxtj npvyk lruol iejdc blaxk swxmh qzglf", 17, 33));
    }

    [Fact(Skip = "Remove to run test")]
    public void Decode_with_no_spaces_in_input()
    {
        Assert.Equal("thequickbrownfoxjumpsoverthelazydog", AffineCipher.Decode("swxtjnpvyklruoliejdcblaxkswxmhqzglf", 17, 33));
    }

    [Fact(Skip = "Remove to run test")]
    public void Decode_with_too_many_spaces()
    {
        Assert.Equal("jollygreengiant", AffineCipher.Decode("vszzm    cly   yd cg    qdp", 15, 16));
    }

    [Fact(Skip = "Remove to run test")]
    public void Decode_with_a_not_coprime_to_m()
    {
        Assert.Throws<ArgumentException>(() => AffineCipher.Decode("Test", 13, 5));
    }
}