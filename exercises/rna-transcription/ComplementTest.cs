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
}