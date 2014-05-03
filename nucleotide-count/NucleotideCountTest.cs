using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
public class NucleoTideCountTest
{
    [Test]
    public void HasNoNucleotides()
    {
        var dna = new DNA("");
        var expected = new Dictionary<char, int> { { 'A', 0 }, { 'T', 0 }, { 'C', 0 }, { 'G', 0 } };
        Assert.That(dna.NucleotideCounts, Is.EquivalentTo(expected));
    }

    [Test]
    public void HasNoAdenosine()
    {
        var dna = new DNA("");
        Assert.That(dna.Count('A'), Is.EqualTo(0));
    }

    [Test]
    public void RepetitiveCytidineGetsCounts()
    {
        var dna = new DNA("CCCCC");
        Assert.That(dna.Count('C'), Is.EqualTo(5));
    }

    [Test]
    public void RepetitiveSequenceHasOnlyGuanosine()
    {
        var dna = new DNA("GGGGGGGG");
        var expected = new Dictionary<char, int> { { 'A', 0 }, { 'T', 0 }, { 'C', 0 }, { 'G', 8 } };
        Assert.That(dna.NucleotideCounts, Is.EquivalentTo(expected));
    }

    [Test]
    public void CountsOnlyThymidine()
    {
        var dna = new DNA("GGGGTAACCCGG");
        Assert.That(dna.Count('T'), Is.EqualTo(1));
    }

    [Test]
    public void CountsANucleotideOnlyOnce()
    {
        var dna = new DNA("GGTTGG");
        dna.Count('T');
        Assert.That(dna.Count('T'), Is.EqualTo(2));
    }

    [Test]
    public void HasNoUracil()
    {
        var dna = new DNA("GGTTGG");
        Assert.That(dna.Count('U'), Is.EqualTo(0));
    }

    [Test]
    public void ValidatesNucleotides()
    {
        var dna = new DNA("GGTTGG");
        Assert.Throws<InvalidNucleotideException>(() => dna.Count('X'));
    }

    [Test]
    public void CountsAllNucleotides()
    {
        var dna = new DNA("AGCTTTTCATTCTGACTGCAACGGGCAATATGTCTCTGTGTGGATTAAAAAAAGAGTGTCTGATAGCAGC");
        var expected = new Dictionary<char, int> { { 'A', 20 }, { 'T', 21 }, { 'C', 12 }, { 'G', 17 } };
        Assert.That(dna.NucleotideCounts, Is.EquivalentTo(expected));
    }
}