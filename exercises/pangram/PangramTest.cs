// This file was auto-generated based on version 1.4.0 of the canonical data.

using Xunit;

public class PangramTest
{
    [Fact]
    public void Sentence_empty()
    {
        Assert.False(Pangram.IsPangram(""));
    }

    [Fact(Skip = "Remove to run test")]
    public void Recognizes_a_perfect_lower_case_pangram()
    {
        Assert.True(Pangram.IsPangram("abcdefghijklmnopqrstuvwxyz"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Pangram_with_only_lower_case()
    {
        Assert.True(Pangram.IsPangram("the quick brown fox jumps over the lazy dog"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Missing_character_x()
    {
        Assert.False(Pangram.IsPangram("a quick movement of the enemy will jeopardize five gunboats"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Another_missing_character_e_g_h()
    {
        Assert.False(Pangram.IsPangram("five boxing wizards jump quickly at it"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Pangram_with_underscores()
    {
        Assert.True(Pangram.IsPangram("the_quick_brown_fox_jumps_over_the_lazy_dog"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Pangram_with_numbers()
    {
        Assert.True(Pangram.IsPangram("the 1 quick brown fox jumps over the 2 lazy dogs"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Missing_letters_replaced_by_numbers()
    {
        Assert.False(Pangram.IsPangram("7h3 qu1ck brown fox jumps ov3r 7h3 lazy dog"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Pangram_with_mixed_case_and_punctuation()
    {
        Assert.True(Pangram.IsPangram("\"Five quacking Zephyrs jolt my wax bed.\""));
    }

    [Fact(Skip = "Remove to run test")]
    public void Upper_and_lower_case_versions_of_the_same_character_should_not_be_counted_separately()
    {
        Assert.False(Pangram.IsPangram("the quick brown fox jumps over with lazy FX"));
    }
}