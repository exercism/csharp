using Xunit;

public class HammingTest
{
    [Fact]
    public void No_difference_between_empty_strands()
    {
        Assert.Equal(0, Hamming.Compute("",""));
    }

    [Fact(Skip = "Remove to run test")]
    public void No_difference_between_identical_strands()
    {
        Assert.Equal(0, Hamming.Compute("GGACTGA","GGACTGA"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Complete_hamming_distance_in_small_strand()
    {
        Assert.Equal(3, Hamming.Compute("ACT","GGA"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Hamming_distance_is_off_by_one_strand()
    {
        Assert.Equal(9, Hamming.Compute("GGACGGATTCTG","AGGACGGATTCT"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Smalling_hamming_distance_in_middle_somewhere()
    {
        Assert.Equal(1, Hamming.Compute("GGACG","GGTCG"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Larger_distance()
    {
        Assert.Equal(2, Hamming.Compute("ACCAGGG","ACTATGG"));
    }
}