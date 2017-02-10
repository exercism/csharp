using Xunit;

public class CryptoSquareTest
{
    [Fact]
    public void Strange_characters_are_stripped_during_normalization()
    {
        var crypto = new Crypto("s#$%^&plunk");
        Assert.Equal("splunk", crypto.NormalizePlaintext);
    }

    [Fact]
    public void Letters_are_lowercased_during_normalization()
    {
        var crypto = new Crypto("WHOA HEY!");
        Assert.Equal("whoahey", crypto.NormalizePlaintext);
    }

    [Fact]
    public void Numbers_are_kept_during_normalization()
    {
        var crypto = new Crypto("1, 2, 3, GO!");
        Assert.Equal("123go", crypto.NormalizePlaintext);
    }

    [Fact]
    public void Smallest_square_size_is_2()
    {
        var crypto = new Crypto("1234");
        Assert.Equal(2, crypto.Size);
    }

    [Fact]
    public void Size_of_text_whose_length_is_a_perfect_square_is_its_square_root()
    {
        var crypto = new Crypto("123456789");
        Assert.Equal(3, crypto.Size);
    }

    [Fact]
    public void Size_of_text_whose_length_is_not_a_perfect_square_is_next_biggest_square_root()
    {
        var crypto = new Crypto("123456789abc");
        Assert.Equal(4, crypto.Size);
    }

    [Fact]
    public void Size_is_determined_by_normalized_text()
    {
        var crypto = new Crypto("Oh hey, this is nuts!");
        Assert.Equal(4, crypto.Size);
    }

    [Fact]
    public void Segments_are_split_by_square_size()
    {
        var crypto = new Crypto("Never vex thine heart with idle woes");
        Assert.Equal(new[] { "neverv", "exthin", "eheart", "withid", "lewoes" }, crypto.PlaintextSegments());
    }

    [Fact]
    public void Segments_are_split_by_square_size_until_text_runs_out()
    {
        var crypto = new Crypto("ZOMG! ZOMBIES!!!");
        Assert.Equal(new[] { "zomg", "zomb", "ies" }, crypto.PlaintextSegments());
    }

    [Fact]
    public void Ciphertext_combines_text_by_column()
    {
        var crypto = new Crypto("First, solve the problem. Then, write the code.");
        Assert.Equal("foeewhilpmrervrticseohtottbeedshlnte", crypto.Ciphertext());
    }

    [Fact]
    public void Ciphertext_skips_cells_with_no_text()
    {
        var crypto = new Crypto("Time is an illusion. Lunchtime doubly so.");
        Assert.Equal("tasneyinicdsmiohooelntuillibsuuml", crypto.Ciphertext());
    }

    [Fact]
    public void Normalized_ciphertext_is_split_by_height_of_square()
    {
        var crypto = new Crypto("Vampires are people too!");
        Assert.Equal("vrel aepe mset paoo irpo", crypto.NormalizeCiphertext());
    }

    [Fact]
    public void Normalized_ciphertext_not_exactly_divisible_by_5_spills_into_a_smaller_segment()
    {
        var crypto = new Crypto("Madness, and then illumination.");
        Assert.Equal("msemo aanin dnin ndla etlt shui", crypto.NormalizeCiphertext());
    }

    [Fact]
    public void Normalized_ciphertext_is_split_into_segements_of_correct_size()
    {
        var crypto = new Crypto("If man was meant to stay on the ground god would have given us roots");
        Assert.Equal("imtgdvs fearwer mayoogo anouuio ntnnlvt wttddes aohghn sseoau", crypto.NormalizeCiphertext());
    }

    [Fact]
    public void Normalized_ciphertext_is_split_into_segements_of_correct_size_with_punctuation()
    {
        var crypto = new Crypto("Have a nice day. Feed the dog & chill out!");
        Assert.Equal("hifei acedl veeol eddgo aatcu nyhht", crypto.NormalizeCiphertext());
    }

    [Fact]
    public void Normalized_ciphertext_is_split_into_segements_of_correct_size_when_just_less_than_full_square()
    {
        var crypto = new Crypto("I am");
        Assert.Equal("im a", crypto.NormalizeCiphertext());
    }
}