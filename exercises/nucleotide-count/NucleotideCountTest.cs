using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
public class NucleoTideCountTest
{
    [Test]
    public void Has_no_nucleotides()
    {
        var dna = new DNA("");
        var expected = new Dictionary<char, int> { { 'A', 0 }, { 'T', 0 }, { 'C', 0 }, { 'G', 0 } };
        Assert.That(dna.NucleotideCounts, Is.EqualTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Has_no_adenosine()
    {
        var dna = new DNA("");
        Assert.That(dna.Count('A'), Is.EqualTo(0));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Repetitive_cytidine_gets_counts()
    {
        var dna = new DNA("CCCCC");
        Assert.That(dna.Count('C'), Is.EqualTo(5));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Repetitive_sequence_has_only_guanosine()
    {
        var dna = new DNA("GGGGGGGG");
        var expected = new Dictionary<char, int> { { 'A', 0 }, { 'T', 0 }, { 'C', 0 }, { 'G', 8 } };
        Assert.That(dna.NucleotideCounts, Is.EqualTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Counts_only_thymidine()
    {
        var dna = new DNA("GGGGTAACCCGG");
        Assert.That(dna.Count('T'), Is.EqualTo(1));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Counts_a_nucleotide_only_once()
    {
        var dna = new DNA("GGTTGG");
        dna.Count('T');
        Assert.That(dna.Count('T'), Is.EqualTo(2));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Validates_nucleotides()
    {
        var dna = new DNA("GGTTGG");
        Assert.Throws<InvalidNucleotideException>(() => dna.Count('X'));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Counts_all_nucleotides()
    {
        var dna = new DNA("AGCTTTTCATTCTGACTGCAACGGGCAATATGTCTCTGTGTGGATTAAAAAAAGAGTGTCTGATAGCAGC");
        var expected = new Dictionary<char, int> { { 'A', 20 }, { 'T', 21 }, { 'C', 12 }, { 'G', 17 } };
        Assert.That(dna.NucleotideCounts, Is.EqualTo(expected));
    }
}
