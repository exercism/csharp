using Xunit;

public class ComplementTest
{
    [Fact]
    public void Rna_complement_of_cytosine_is_guanine()
    {
        Assert.That(Complement.OfDna("C"), Is.EqualTo("G"));
    }

    [Fact(Skip="Remove to run test")]
    public void Rna_complement_of_guanine_is_cytosine()
    {
        Assert.That(Complement.OfDna("G"), Is.EqualTo("C"));
    }

    [Fact(Skip="Remove to run test")]
    public void Rna_complement_of_thymine_is_adenine()
    {
        Assert.That(Complement.OfDna("T"), Is.EqualTo("A"));
    }

    [Fact(Skip="Remove to run test")]
    public void Rna_complement_of_adenine_is_uracil()
    {
        Assert.That(Complement.OfDna("A"), Is.EqualTo("U"));
    }

    [Fact(Skip="Remove to run test")]
    public void Rna_complement()
    {
        Assert.That(Complement.OfDna("ACGTGGTCTTAA"), Is.EqualTo("UGCACCAGAAUU"));
    }
}