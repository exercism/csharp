using Xunit;

public class ReverseStringTests
{
    [Fact]
    public void An_empty_string()
    {
        Assert.Equal("", ReverseString.Reverse(""));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void A_word()
    {
        Assert.Equal("tobor", ReverseString.Reverse("robot"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void A_capitalized_word()
    {
        Assert.Equal("nemaR", ReverseString.Reverse("Ramen"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void A_sentence_with_punctuation()
    {
        Assert.Equal("!yrgnuh m'I", ReverseString.Reverse("I'm hungry!"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void A_palindrome()
    {
        Assert.Equal("racecar", ReverseString.Reverse("racecar"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void An_even_sized_word()
    {
        Assert.Equal("reward", ReverseString.Reverse("drawer"));
    }
}