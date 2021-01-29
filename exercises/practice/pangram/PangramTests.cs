// This file was auto-generated based on version 2.0.0 of the canonical data.

using Xunit;

public class PangramTests
{
    [Fact]
    public void Empty_sentence()
    {
        Assert.False(Pangram.IsPangram(""));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Perfect_lower_case()
    {
        Assert.True(Pangram.IsPangram("abcdefghijklmnopqrstuvwxyz"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Only_lower_case()
    {
        Assert.True(Pangram.IsPangram("the quick brown fox jumps over the lazy dog"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Missing_the_letter_x()
    {
        Assert.False(Pangram.IsPangram("a quick movement of the enemy will jeopardize five gunboats"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Missing_the_letter_h()
    {
        Assert.False(Pangram.IsPangram("five boxing wizards jump quickly at it"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void With_underscores()
    {
        Assert.True(Pangram.IsPangram("the_quick_brown_fox_jumps_over_the_lazy_dog"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void With_numbers()
    {
        Assert.True(Pangram.IsPangram("the 1 quick brown fox jumps over the 2 lazy dogs"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Missing_letters_replaced_by_numbers()
    {
        Assert.False(Pangram.IsPangram("7h3 qu1ck brown fox jumps ov3r 7h3 lazy dog"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Mixed_case_and_punctuation()
    {
        Assert.True(Pangram.IsPangram("\"Five quacking Zephyrs jolt my wax bed.\""));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Case_insensitive()
    {
        Assert.False(Pangram.IsPangram("the quick brown fox jumps over with lazy FX"));
    }
}