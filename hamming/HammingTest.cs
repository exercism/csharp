using NUnit.Framework;

[TestFixture]
public class HammingTest
{
    [Test]
    public void No_difference_between_empty_strands()
    {
        Assert.That(Hamming.Compute("",""), Is.EqualTo(0));
    }

    [Ignore]
    [Test]
    public void No_difference_between_identical_strands()
    {
        Assert.That(Hamming.Compute("GGACTGA","GGACTGA"), Is.EqualTo(0));
    }

    [Ignore]
    [Test]
    public void Complete_hamming_distance_in_small_strand()
    {
        Assert.That(Hamming.Compute("ACT","GGA"), Is.EqualTo(3));
    }

    [Ignore]
    [Test]
    public void Hamming_distance_is_off_by_one_strand()
    {
        Assert.That(Hamming.Compute("GGACGGATTCTG","AGGACGGATTCT"), Is.EqualTo(9));
    }

    [Ignore]
    [Test]
    public void Smalling_hamming_distance_in_middle_somewhere()
    {
        Assert.That(Hamming.Compute("GGACG","GGTCG"), Is.EqualTo(1));
    }

    [Ignore]
    [Test]
    public void Larger_distance()
    {
        Assert.That(Hamming.Compute("ACCAGGG","ACTATGG"), Is.EqualTo(2));
    }

    [Ignore]
    [Test]
    public void Ignores_extra_length_on_other_strand_when_longer()
    {
        Assert.That(Hamming.Compute("AAACTAGGGG","AGGCTAGCGGTAGGAC"), Is.EqualTo(3));
    }

    [Ignore]
    [Test]
    public void Ignores_extra_length_on_original_strand_when_longer()
    {
        Assert.That(Hamming.Compute("GACTACGGACAGGGTAGGGAAT","GACATCGCACACC"), Is.EqualTo(5));
    }
}