using System.Collections.Generic;
using Xunit;

public class NucleoTideCountTest
{
    [Fact]
    public void Has_no_nucleotides()
    {
        var dna = new DNA("");
        var expected = new Dictionary<char, int> { { 'A', 0 }, { 'T', 0 }, { 'C', 0 }, { 'G', 0 } };
        Assert.Equal(expected, dna.NucleotideCounts);
    }

    [Fact(Skip = "Remove to run test")]
    public void Has_no_adenosine()
    {
        var dna = new DNA("");
        Assert.Equal(0, dna.Count('A'));
    }

    [Fact(Skip = "Remove to run test")]
    public void Repetitive_cytidine_gets_counts()
    {
        var dna = new DNA("CCCCC");
        Assert.Equal(5, dna.Count('C'));
    }

    [Fact(Skip = "Remove to run test")]
    public void Repetitive_sequence_has_only_guanosine()
    {
        var dna = new DNA("GGGGGGGG");
        var expected = new Dictionary<char, int> { { 'A', 0 }, { 'T', 0 }, { 'C', 0 }, { 'G', 8 } };
        Assert.Equal(expected, dna.NucleotideCounts);
    }

    [Fact(Skip = "Remove to run test")]
    public void Counts_only_thymidine()
    {
        var dna = new DNA("GGGGTAACCCGG");
        Assert.Equal(1, dna.Count('T'));
    }

    [Fact(Skip = "Remove to run test")]
    public void Counts_a_nucleotide_only_once()
    {
        var dna = new DNA("GGTTGG");
        dna.Count('T');
        Assert.Equal(2, dna.Count('T'));
    }

    [Fact(Skip = "Remove to run test")]
    public void Validates_nucleotides()
    {
        var dna = new DNA("GGTTGG");
        Assert.Throws<InvalidNucleotideException>(() => dna.Count('X'));
    }

    [Fact(Skip = "Remove to run test")]
    public void Counts_all_nucleotides()
    {
        var dna = new DNA("AGCTTTTCATTCTGACTGCAACGGGCAATATGTCTCTGTGTGGATTAAAAAAAGAGTGTCTGATAGCAGC");
        var expected = new Dictionary<char, int> { { 'A', 20 }, { 'T', 21 }, { 'C', 12 }, { 'G', 17 } };
        Assert.Equal(expected, dna.NucleotideCounts);
    }
}
