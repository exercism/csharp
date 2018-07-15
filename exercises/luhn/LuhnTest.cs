// This file was auto-generated based on version 1.2.0 of the canonical data.

using Xunit;

public class LuhnTest
{
    [Fact]
    public void Single_digit_strings_can_not_be_valid()
    {
        Assert.False(Luhn.IsValid("1"));
    }

    [Fact(Skip = "Remove to run test")]
    public void A_single_zero_is_invalid()
    {
        Assert.False(Luhn.IsValid("0"));
    }

    [Fact(Skip = "Remove to run test")]
    public void A_simple_valid_sin_that_remains_valid_if_reversed()
    {
        Assert.True(Luhn.IsValid("059"));
    }

    [Fact(Skip = "Remove to run test")]
    public void A_simple_valid_sin_that_becomes_invalid_if_reversed()
    {
        Assert.True(Luhn.IsValid("59"));
    }

    [Fact(Skip = "Remove to run test")]
    public void A_valid_canadian_sin()
    {
        Assert.True(Luhn.IsValid("055 444 285"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Invalid_canadian_sin()
    {
        Assert.False(Luhn.IsValid("055 444 286"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Invalid_credit_card()
    {
        Assert.False(Luhn.IsValid("8273 1232 7352 0569"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Valid_strings_with_a_non_digit_included_become_invalid()
    {
        Assert.False(Luhn.IsValid("055a 444 285"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Valid_strings_with_punctuation_included_become_invalid()
    {
        Assert.False(Luhn.IsValid("055-444-285"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Valid_strings_with_symbols_included_become_invalid()
    {
        Assert.False(Luhn.IsValid("055£ 444$ 285"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Single_zero_with_space_is_invalid()
    {
        Assert.False(Luhn.IsValid(" 0"));
    }

    [Fact(Skip = "Remove to run test")]
    public void More_than_a_single_zero_is_valid()
    {
        Assert.True(Luhn.IsValid("0000 0"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Input_digit_9_is_correctly_converted_to_output_digit_9()
    {
        Assert.True(Luhn.IsValid("091"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Strings_with_non_digits_is_invalid()
    {
        Assert.False(Luhn.IsValid(":9"));
    }
}