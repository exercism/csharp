// This file was auto-generated based on version 2.3.0 of the canonical data.

using System;
using Xunit;

public class HammingTests
{
    [Fact]
    public void Empty_strands()
    {
        Assert.Equal(0, Hamming.Distance("", ""));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Single_letter_identical_strands()
    {
        Assert.Equal(0, Hamming.Distance("A", "A"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Single_letter_different_strands()
    {
        Assert.Equal(1, Hamming.Distance("G", "T"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Long_identical_strands()
    {
        Assert.Equal(0, Hamming.Distance("GGACTGAAATCTG", "GGACTGAAATCTG"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Long_different_strands()
    {
        Assert.Equal(9, Hamming.Distance("GGACGGATTCTG", "AGGACGGATTCT"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Disallow_first_strand_longer()
    {
        Assert.Throws<ArgumentException>(() => Hamming.Distance("AATG", "AAA"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Disallow_second_strand_longer()
    {
        Assert.Throws<ArgumentException>(() => Hamming.Distance("ATA", "AGTG"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Disallow_left_empty_strand()
    {
        Assert.Throws<ArgumentException>(() => Hamming.Distance("", "G"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Disallow_right_empty_strand()
    {
        Assert.Throws<ArgumentException>(() => Hamming.Distance("G", ""));
    }
}