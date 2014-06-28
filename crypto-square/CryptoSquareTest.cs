using NUnit.Framework;

[TestFixture]
public class CryptoSquareTest
{
    [Test]
    public void Strange_characters_are_stripped_during_normalization()
    {
        var crypto = new Crypto("s#$%^&plunk");
        Assert.That(crypto.NormalizePlaintext, Is.EqualTo("splunk"));
    }

    [Ignore]
    [Test]
    public void Letters_are_lowercased_during_normalization()
    {
        var crypto = new Crypto("WHOA HEY!");
        Assert.That(crypto.NormalizePlaintext, Is.EqualTo("whoahey"));
    }

    [Ignore]
    [Test]
    public void Numbers_are_kept_during_normalization()
    {
        var crypto = new Crypto("1, 2, 3, GO!");
        Assert.That(crypto.NormalizePlaintext, Is.EqualTo("123go"));
    }

    [Ignore]
    [Test]
    public void Smallest_square_size_is_2()
    {
        var crypto = new Crypto("1234");
        Assert.That(crypto.Size, Is.EqualTo(2));
    }

    [Ignore]
    [Test]
    public void Size_of_text_whose_length_is_a_perfect_square_is_its_square_root()
    {
        var crypto = new Crypto("123456789");
        Assert.That(crypto.Size, Is.EqualTo(3));
    }

    [Ignore]
    [Test]
    public void Size_of_text_whose_length_is_not_a_perfect_square_is_next_biggest_square_root()
    {
        var crypto = new Crypto("123456789abc");
        Assert.That(crypto.Size, Is.EqualTo(4));
    }

    [Ignore]
    [Test]
    public void Size_is_determined_by_normalized_text()
    {
        var crypto = new Crypto("Oh hey, this is nuts!");
        Assert.That(crypto.Size, Is.EqualTo(4));
    }

    [Ignore]
    [Test]
    public void Segments_are_split_by_square_size()
    {
        var crypto = new Crypto("Never vex thine heart with idle woes");
        Assert.That(crypto.PlaintextSegments(), Is.EqualTo(new[] { "neverv", "exthin", "eheart", "withid", "lewoes" }));
    }

    [Ignore]
    [Test]
    public void Segments_are_split_by_square_size_until_text_runs_out()
    {
        var crypto = new Crypto("ZOMG! ZOMBIES!!!");
        Assert.That(crypto.PlaintextSegments(), Is.EqualTo(new[] { "zomg", "zomb", "ies" }));
    }

    [Ignore]
    [Test]
    public void Ciphertext_combines_text_by_column()
    {
        var crypto = new Crypto("First, solve the problem. Then, write the code.");
        Assert.That(crypto.Ciphertext(), Is.EqualTo("foeewhilpmrervrticseohtottbeedshlnte"));
    }

    [Ignore]
    [Test]
    public void Ciphertext_skips_cells_with_no_text()
    {
        var crypto = new Crypto("Time is an illusion. Lunchtime doubly so.");
        Assert.That(crypto.Ciphertext(), Is.EqualTo("tasneyinicdsmiohooelntuillibsuuml"));
    }

    [Ignore]
    [Test]
    public void Normalized_ciphertext_is_split_by_5()
    {
        var crypto = new Crypto("Vampires are people too!");
        Assert.That(crypto.NormalizeCiphertext(), Is.EqualTo("vrela epems etpao oirpo"));
    }

    [Ignore]
    [Test]
    public void Normalized_ciphertext_not_exactly_divisible_by_5_spills_into_a_smaller_segment()
    {
        var crypto = new Crypto("Madness, and then illumination.");
        Assert.That(crypto.NormalizeCiphertext(), Is.EqualTo("msemo aanin dninn dlaet ltshu i"));
    }
}