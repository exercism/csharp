// This file was auto-generated based on version 1.1.0 of the canonical data.

using Xunit;

public class PangramTest
{
    [Fact]
    public void Sentence_empty()
    {
        var input = "";
        Assert.False(Pangram.IsPangram(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Pangram_with_only_lower_case()
    {
        var input = "the quick brown fox jumps over the lazy dog";
        Assert.True(Pangram.IsPangram(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Missing_character_x()
    {
        var input = "a quick movement of the enemy will jeopardize five gunboats";
        Assert.False(Pangram.IsPangram(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Another_missing_character_x()
    {
        var input = "the quick brown fish jumps over the lazy dog";
        Assert.False(Pangram.IsPangram(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Pangram_with_underscores()
    {
        var input = "the_quick_brown_fox_jumps_over_the_lazy_dog";
        Assert.True(Pangram.IsPangram(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Pangram_with_numbers()
    {
        var input = "the 1 quick brown fox jumps over the 2 lazy dogs";
        Assert.True(Pangram.IsPangram(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Missing_letters_replaced_by_numbers()
    {
        var input = "7h3 qu1ck brown fox jumps ov3r 7h3 lazy dog";
        Assert.False(Pangram.IsPangram(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Pangram_with_mixed_case_and_punctuation()
    {
        var input = "\"Five quacking Zephyrs jolt my wax bed.\"";
        Assert.True(Pangram.IsPangram(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Upper_and_lower_case_versions_of_the_same_character_should_not_be_counted_separately()
    {
        var input = "the quick brown fox jumps over with lazy FX";
        Assert.False(Pangram.IsPangram(input));
    }
}