// This file was auto-generated based on version 1.3.0 of the canonical data.

using System;
using System.Collections.Generic;
using Xunit;

public class NucleotideCountTests
{
    [Fact]
    public void Empty_strand()
    {
        var expected = new Dictionary<char, int>
        {
            ['A'] = 0,
            ['C'] = 0,
            ['G'] = 0,
            ['T'] = 0
        };
        Assert.Equal(expected, NucleotideCount.Count(""));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Can_count_one_nucleotide_in_single_character_input()
    {
        var expected = new Dictionary<char, int>
        {
            ['A'] = 0,
            ['C'] = 0,
            ['G'] = 1,
            ['T'] = 0
        };
        Assert.Equal(expected, NucleotideCount.Count("G"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Strand_with_repeated_nucleotide()
    {
        var expected = new Dictionary<char, int>
        {
            ['A'] = 0,
            ['C'] = 0,
            ['G'] = 7,
            ['T'] = 0
        };
        Assert.Equal(expected, NucleotideCount.Count("GGGGGGG"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Strand_with_multiple_nucleotides()
    {
        var expected = new Dictionary<char, int>
        {
            ['A'] = 20,
            ['C'] = 12,
            ['G'] = 17,
            ['T'] = 21
        };
        Assert.Equal(expected, NucleotideCount.Count("AGCTTTTCATTCTGACTGCAACGGGCAATATGTCTCTGTGTGGATTAAAAAAAGAGTGTCTGATAGCAGC"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Strand_with_invalid_nucleotides()
    {
        Assert.Throws<ArgumentException>(() => NucleotideCount.Count("AGXXACT"));
    }
}