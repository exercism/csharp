// This file was auto-generated based on version 2.0.0 of the canonical data.

using System;
using Xunit;

public class AffineCipherTest
{
    [Fact]
    public void Encode_yes()
    {
        var ac = new AffineCipher();
        Assert.Equal("xbt", ac.Encode("yes",5,7));
    }

    [Fact]
    public void Encode_no()
    {
        var ac = new AffineCipher();
        Assert.Equal("fu", ac.Encode("no",15,18));
    }

    [Fact]
    public void Encode_omg()
    {
        var ac = new AffineCipher();
        Assert.Equal("lvz", ac.Encode("OMG",21,3));
    }

    [Fact]
    public void Encode_o_m_g()
    {
        var ac = new AffineCipher();
        Assert.Equal("hjp", ac.Encode("O M G",25,47));
    }

    [Fact]
    public void Encode_mindblowingly()
    {
        var ac = new AffineCipher();
        Assert.Equal("rzcwa gnxzc dgt", ac.Encode("mindblowingly",11,15));
    }

    [Fact]
    public void Encode_numbers()
    {
        var ac = new AffineCipher();
        Assert.Equal("jqgjc rw123 jqgjc rw", ac.Encode("Testing,1 2 3, testing.",3,4));
    }

    [Fact]
    public void Encode_deep_thought()
    {
        var ac = new AffineCipher();
        Assert.Equal("iynia fdqfb ifje", ac.Encode("Truth is fiction.",5,17));
    }

    [Fact]
    public void Encode_all_the_letters()
    {
        var ac = new AffineCipher();
        Assert.Equal("swxtj npvyk lruol iejdc blaxk swxmh qzglf", ac.Encode("The quick brown fox jumps over the lazy dog.",17,33));
    }

    [Fact]
    public void Encode_with_a_not_coprime_to_m()
    {
        var ac = new AffineCipher();
        Exception ex = Assert.Throws<ArgumentException>(() => ac.Encode("This is a test.",6,17));
        Assert.Equal("a and m must be coprime.", ex.Message);
    }

    [Fact]
    public void Decode_exercism()
    {
        var ac = new AffineCipher();
        Assert.Equal("exercism", ac.Decode("tytgn fjr",3,7));
    }

    [Fact]
    public void Decode_a_sentence()
    {
        var ac = new AffineCipher();
        Assert.Equal("anobstacleisoftenasteppingstone", ac.Decode("qdwju nqcro muwhn odqun oppmd aunwd o",19,16));
    }

    [Fact]
    public void Decode_numbers()
    {
        var ac = new AffineCipher();
        Assert.Equal("testing123testing", ac.Decode("odpoz ub123 odpoz ub",25,7));
    }

    [Fact]
    public void Decode_all_the_letters()
    {
        var ac = new AffineCipher();
        Assert.Equal("thequickbrownfoxjumpsoverthelazydog", ac.Decode("swxtj npvyk lruol iejdc blaxk swxmh qzglf",17,33));
    }

    [Fact]
    public void Decode_with_no_spaces_in_input()
    {
        var ac = new AffineCipher();
        Assert.Equal("thequickbrownfoxjumpsoverthelazydog", ac.Decode("swxtjnpvyklruoliejdcblaxkswxmhqzglf",17,33));
    }

    [Fact]
    public void Decode_with_too_many_spaces()
    {
        var ac = new AffineCipher();
        Assert.Equal("jollygreengiant", ac.Decode("vszzm    cly   yd cg    qdp",15,16));
    }

    [Fact]
    public void Decode_with_a_not_coprime_to_m()
    {
        var ac = new AffineCipher();
        Exception ex = Assert.Throws<ArgumentException>(() => ac.Decode("Test",13,5));
        Assert.Equal("a and m must be coprime.", ex.Message);
    }
}