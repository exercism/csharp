// This file was auto-generated based on version 2.7.0 of the canonical data.

using Xunit;

public class IsbnVerifierTest
{
    [Fact]
    public void Valid_isbn_number()
    {
        Assert.True(IsbnVerifier.IsValid("3-598-21508-8"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Invalid_isbn_check_digit()
    {
        Assert.False(IsbnVerifier.IsValid("3-598-21508-9"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Valid_isbn_number_with_a_check_digit_of_10()
    {
        Assert.True(IsbnVerifier.IsValid("3-598-21507-X"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Check_digit_is_a_character_other_than_x()
    {
        Assert.False(IsbnVerifier.IsValid("3-598-21507-A"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Invalid_character_in_isbn()
    {
        Assert.False(IsbnVerifier.IsValid("3-598-P1581-X"));
    }

    [Fact(Skip = "Remove to run test")]
    public void X_is_only_valid_as_a_check_digit()
    {
        Assert.False(IsbnVerifier.IsValid("3-598-2X507-9"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Valid_isbn_without_separating_dashes()
    {
        Assert.True(IsbnVerifier.IsValid("3598215088"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Isbn_without_separating_dashes_and_x_as_check_digit()
    {
        Assert.True(IsbnVerifier.IsValid("359821507X"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Isbn_without_check_digit_and_dashes()
    {
        Assert.False(IsbnVerifier.IsValid("359821507"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Too_long_isbn_and_no_dashes()
    {
        Assert.False(IsbnVerifier.IsValid("3598215078X"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Too_short_isbn()
    {
        Assert.False(IsbnVerifier.IsValid("00"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Isbn_without_check_digit()
    {
        Assert.False(IsbnVerifier.IsValid("3-598-21507"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Check_digit_of_x_should_not_be_used_for_0()
    {
        Assert.False(IsbnVerifier.IsValid("3-598-21515-X"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Empty_isbn()
    {
        Assert.False(IsbnVerifier.IsValid(""));
    }

    [Fact(Skip = "Remove to run test")]
    public void Input_is_9_characters()
    {
        Assert.False(IsbnVerifier.IsValid("134456729"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Invalid_characters_are_not_ignored()
    {
        Assert.False(IsbnVerifier.IsValid("3132P34035"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Input_is_too_long_but_contains_a_valid_isbn()
    {
        Assert.False(IsbnVerifier.IsValid("98245726788"));
    }
}