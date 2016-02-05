using NUnit.Framework;

[TestFixture]
public class ComplementTest
{
    [Test]
    public void Rna_complement_of_cytosine_is_guanine()
    {
        Assert.That(Complement.OfDna("C"), Is.EqualTo("G"));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Rna_complement_of_guanine_is_cytosine()
    {
        Assert.That(Complement.OfDna("G"), Is.EqualTo("C"));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Rna_complement_of_thymine_is_adenine()
    {
        Assert.That(Complement.OfDna("T"), Is.EqualTo("A"));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Rna_complement_of_adenine_is_uracil()
    {
        Assert.That(Complement.OfDna("A"), Is.EqualTo("U"));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Rna_complement()
    {
        Assert.That(Complement.OfDna("ACGTGGTCTTAA"), Is.EqualTo("UGCACCAGAAUU"));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Dna_complement_of_cytosine_is_guanine()
    {
        Assert.That(Complement.OfRna("C"), Is.EqualTo("G"));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Dna_complement_of_guanine_is_cytosine()
    {
        Assert.That(Complement.OfRna("G"), Is.EqualTo("C"));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Dna_complement_of_uracil_is_adenine()
    {
        Assert.That(Complement.OfRna("U"), Is.EqualTo("A"));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Dna_complement_of_adenine_is_thymine()
    {
        Assert.That(Complement.OfRna("A"), Is.EqualTo("T"));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Dna_complement()
    {
        Assert.That(Complement.OfRna("UGAACCCGACAUG"), Is.EqualTo("ACTTGGGCTGTAC"));
    }
}