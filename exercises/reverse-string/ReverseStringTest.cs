// This file was auto-generated based on version 1.1.0 of the canonical data.

using Xunit;

public class ReverseStringTest
{
    [Fact]
    public void An_empty_string()
    {
        Assert.Equal("", ReverseString.Reverse(""));
    }

    [Fact(Skip = "Remove to run test")]
    public void A_word()
    {
        Assert.Equal("tobor", ReverseString.Reverse("robot"));
    }

    [Fact(Skip = "Remove to run test")]
    public void A_capitalized_word()
    {
        Assert.Equal("nemaR", ReverseString.Reverse("Ramen"));
    }

    [Fact(Skip = "Remove to run test")]
    public void A_sentence_with_punctuation()
    {
        Assert.Equal("!yrgnuh m'I", ReverseString.Reverse("I'm hungry!"));
    }

    [Fact(Skip = "Remove to run test")]
    public void A_palindrome()
    {
        Assert.Equal("racecar", ReverseString.Reverse("racecar"));
    }
}