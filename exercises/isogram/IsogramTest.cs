using Xunit;

public class IsogramTest
{
    [Fact]
    public void Empty_string()
    {
        Assert.True(Isogram.IsIsogram(""));
    }

    [Fact(Skip = "Remove to run test")]
    public void Isogram_with_only_lower_case_characters()
    {
        Assert.True(Isogram.IsIsogram("isogram"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Word_with_one_duplicated_character()
    {
        Assert.False(Isogram.IsIsogram("eleven"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Longest_reported_english_isogram()
    {
        Assert.True(Isogram.IsIsogram("subdermatoglyphic"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Word_with_duplicated_character_in_mixed_case()
    {
        Assert.False(Isogram.IsIsogram("Alphabet"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Hypothetical_isogrammic_word_with_hyphen()
    {
        Assert.True(Isogram.IsIsogram("thumbscrew-japingly"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Isogram_with_duplicated_non_letter_character()
    {
        Assert.True(Isogram.IsIsogram("Hjelmqvist-Gryb-Zock-Pfund-Wax"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Made_up_name_that_is_an_isogram()
    {
        Assert.True(Isogram.IsIsogram("Emily Jung Schwartzkopf"));
    }
}