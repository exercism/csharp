// This file was auto-generated based on version 1.7.0 of the canonical data.

using System;
using Xunit;

public class PhoneNumberTests
{
    [Fact]
    public void Cleans_the_number()
    {
        var phrase = "(223) 456-7890";
        Assert.Equal("2234567890", PhoneNumber.Clean(phrase));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Cleans_numbers_with_dots()
    {
        var phrase = "223.456.7890";
        Assert.Equal("2234567890", PhoneNumber.Clean(phrase));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Cleans_numbers_with_multiple_spaces()
    {
        var phrase = "223 456   7890   ";
        Assert.Equal("2234567890", PhoneNumber.Clean(phrase));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Invalid_when_9_digits()
    {
        var phrase = "123456789";
        Assert.Throws<ArgumentException>(() => PhoneNumber.Clean(phrase));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Invalid_when_11_digits_does_not_start_with_a_1()
    {
        var phrase = "22234567890";
        Assert.Throws<ArgumentException>(() => PhoneNumber.Clean(phrase));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Valid_when_11_digits_and_starting_with_1()
    {
        var phrase = "12234567890";
        Assert.Equal("2234567890", PhoneNumber.Clean(phrase));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Valid_when_11_digits_and_starting_with_1_even_with_punctuation()
    {
        var phrase = "+1 (223) 456-7890";
        Assert.Equal("2234567890", PhoneNumber.Clean(phrase));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Invalid_when_more_than_11_digits()
    {
        var phrase = "321234567890";
        Assert.Throws<ArgumentException>(() => PhoneNumber.Clean(phrase));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Invalid_with_letters()
    {
        var phrase = "123-abc-7890";
        Assert.Throws<ArgumentException>(() => PhoneNumber.Clean(phrase));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Invalid_with_punctuations()
    {
        var phrase = "123-@:!-7890";
        Assert.Throws<ArgumentException>(() => PhoneNumber.Clean(phrase));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Invalid_if_area_code_starts_with_0()
    {
        var phrase = "(023) 456-7890";
        Assert.Throws<ArgumentException>(() => PhoneNumber.Clean(phrase));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Invalid_if_area_code_starts_with_1()
    {
        var phrase = "(123) 456-7890";
        Assert.Throws<ArgumentException>(() => PhoneNumber.Clean(phrase));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Invalid_if_exchange_code_starts_with_0()
    {
        var phrase = "(223) 056-7890";
        Assert.Throws<ArgumentException>(() => PhoneNumber.Clean(phrase));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Invalid_if_exchange_code_starts_with_1()
    {
        var phrase = "(223) 156-7890";
        Assert.Throws<ArgumentException>(() => PhoneNumber.Clean(phrase));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Invalid_if_area_code_starts_with_0_on_valid_11_digit_number()
    {
        var phrase = "1 (023) 456-7890";
        Assert.Throws<ArgumentException>(() => PhoneNumber.Clean(phrase));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Invalid_if_area_code_starts_with_1_on_valid_11_digit_number()
    {
        var phrase = "1 (123) 456-7890";
        Assert.Throws<ArgumentException>(() => PhoneNumber.Clean(phrase));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Invalid_if_exchange_code_starts_with_0_on_valid_11_digit_number()
    {
        var phrase = "1 (223) 056-7890";
        Assert.Throws<ArgumentException>(() => PhoneNumber.Clean(phrase));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Invalid_if_exchange_code_starts_with_1_on_valid_11_digit_number()
    {
        var phrase = "1 (223) 156-7890";
        Assert.Throws<ArgumentException>(() => PhoneNumber.Clean(phrase));
    }
}