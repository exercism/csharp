using Xunit;

public class ComplementTest
{
    [Fact]
    public void Rna_complement_of_cytosine_is_guanine()
    {
        Assert.Equal("G", Complement.OfDna("C"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Rna_complement_of_guanine_is_cytosine()
    {
        Assert.Equal("C", Complement.OfDna("G"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Rna_complement_of_thymine_is_adenine()
    {
        Assert.Equal("A", Complement.OfDna("T"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Rna_complement_of_adenine_is_uracil()
    {
        Assert.Equal("U", Complement.OfDna("A"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Rna_complement()
    {
        Assert.Equal("UGCACCAGAAUU", Complement.OfDna("ACGTGGTCTTAA"));
    }
}