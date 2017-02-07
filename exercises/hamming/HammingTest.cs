using Xunit;

public class HammingTest
{
    [Fact]
    public void No_difference_between_empty_strands()
    {
        Assert.That(Hamming.Compute("",""), Is.EqualTo(0));
    }

    [Fact(Skip="Remove to run test")]
    public void No_difference_between_identical_strands()
    {
        Assert.That(Hamming.Compute("GGACTGA","GGACTGA"), Is.EqualTo(0));
    }

    [Fact(Skip="Remove to run test")]
    public void Complete_hamming_distance_in_small_strand()
    {
        Assert.That(Hamming.Compute("ACT","GGA"), Is.EqualTo(3));
    }

    [Fact(Skip="Remove to run test")]
    public void Hamming_distance_is_off_by_one_strand()
    {
        Assert.That(Hamming.Compute("GGACGGATTCTG","AGGACGGATTCT"), Is.EqualTo(9));
    }

    [Fact(Skip="Remove to run test")]
    public void Smalling_hamming_distance_in_middle_somewhere()
    {
        Assert.That(Hamming.Compute("GGACG","GGTCG"), Is.EqualTo(1));
    }

    [Fact(Skip="Remove to run test")]
    public void Larger_distance()
    {
        Assert.That(Hamming.Compute("ACCAGGG","ACTATGG"), Is.EqualTo(2));
    }
}