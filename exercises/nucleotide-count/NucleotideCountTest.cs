// This file was auto-generated based on version 1.3.0 of the canonical data.

using Xunit;
using System.Collections.Generic;

public class NucleotideCountTest
{
    [Fact]
    public void Empty_strand()
    {
        var sut = new NucleotideCount("");
        var expected = new Dictionary<char, int>
        {
            ['A'] = 0,
            ['C'] = 0,
            ['G'] = 0,
            ['T'] = 0
        };
        Assert.Equal(expected, sut.NucleotideCounts);
    }

    [Fact(Skip = "Remove to run test")]
    public void Can_count_one_nucleotide_in_single_character_input()
    {
        var sut = new NucleotideCount("G");
        var expected = new Dictionary<char, int>
        {
            ['A'] = 0,
            ['C'] = 0,
            ['G'] = 1,
            ['T'] = 0
        };
        Assert.Equal(expected, sut.NucleotideCounts);
    }

    [Fact(Skip = "Remove to run test")]
    public void Strand_with_repeated_nucleotide()
    {
        var sut = new NucleotideCount("GGGGGGG");
        var expected = new Dictionary<char, int>
        {
            ['A'] = 0,
            ['C'] = 0,
            ['G'] = 7,
            ['T'] = 0
        };
        Assert.Equal(expected, sut.NucleotideCounts);
    }

    [Fact(Skip = "Remove to run test")]
    public void Strand_with_multiple_nucleotides()
    {
        var sut = new NucleotideCount("AGCTTTTCATTCTGACTGCAACGGGCAATATGTCTCTGTGTGGATTAAAAAAAGAGTGTCTGATAGCAGC");
        var expected = new Dictionary<char, int>
        {
            ['A'] = 20,
            ['C'] = 12,
            ['G'] = 17,
            ['T'] = 21
        };
        Assert.Equal(expected, sut.NucleotideCounts);
    }

    [Fact(Skip = "Remove to run test")]
    public void Strand_with_invalid_nucleotides()
    {
        Assert.Throws<InvalidNucleotideException>(() => new NucleotideCount("AGXXACT"));
    }
}