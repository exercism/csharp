// This file was auto-generated based on version 1.7.0 of the canonical data.

using Xunit;

public class IsogramTests
{
    [Fact]
    public void Empty_string()
    {
        Assert.True(Isogram.IsIsogram(""));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Isogram_with_only_lower_case_characters()
    {
        Assert.True(Isogram.IsIsogram("isogram"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Word_with_one_duplicated_character()
    {
        Assert.False(Isogram.IsIsogram("eleven"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Word_with_one_duplicated_character_from_the_end_of_the_alphabet()
    {
        Assert.False(Isogram.IsIsogram("zzyzx"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Longest_reported_english_isogram()
    {
        Assert.True(Isogram.IsIsogram("subdermatoglyphic"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Word_with_duplicated_character_in_mixed_case()
    {
        Assert.False(Isogram.IsIsogram("Alphabet"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Word_with_duplicated_character_in_mixed_case_lowercase_first()
    {
        Assert.False(Isogram.IsIsogram("alphAbet"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Hypothetical_isogrammic_word_with_hyphen()
    {
        Assert.True(Isogram.IsIsogram("thumbscrew-japingly"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Hypothetical_word_with_duplicated_character_following_hyphen()
    {
        Assert.False(Isogram.IsIsogram("thumbscrew-jappingly"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Isogram_with_duplicated_hyphen()
    {
        Assert.True(Isogram.IsIsogram("six-year-old"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Made_up_name_that_is_an_isogram()
    {
        Assert.True(Isogram.IsIsogram("Emily Jung Schwartzkopf"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Duplicated_character_in_the_middle()
    {
        Assert.False(Isogram.IsIsogram("accentor"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Same_first_and_last_characters()
    {
        Assert.False(Isogram.IsIsogram("angola"));
    }
}