public class PhoneNumberTests
{
    [Fact]
    public void Cleans_the_number()
    {
        Assert.Equal("2234567890", PhoneNumber.Clean("(223) 456-7890"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Cleans_numbers_with_dots()
    {
        Assert.Equal("2234567890", PhoneNumber.Clean("223.456.7890"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Cleans_numbers_with_multiple_spaces()
    {
        Assert.Equal("2234567890", PhoneNumber.Clean("223 456   7890   "));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Invalid_when_9_digits()
    {
        Assert.Throws<ArgumentException>(() => PhoneNumber.Clean("123456789"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Invalid_when_11_digits_does_not_start_with_a_1()
    {
        Assert.Throws<ArgumentException>(() => PhoneNumber.Clean("22234567890"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Valid_when_11_digits_and_starting_with_1()
    {
        Assert.Equal("2234567890", PhoneNumber.Clean("12234567890"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Valid_when_11_digits_and_starting_with_1_even_with_punctuation()
    {
        Assert.Equal("2234567890", PhoneNumber.Clean("+1 (223) 456-7890"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Invalid_when_more_than_11_digits()
    {
        Assert.Throws<ArgumentException>(() => PhoneNumber.Clean("321234567890"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Invalid_with_letters()
    {
        Assert.Throws<ArgumentException>(() => PhoneNumber.Clean("523-abc-7890"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Invalid_with_punctuations()
    {
        Assert.Throws<ArgumentException>(() => PhoneNumber.Clean("523-@:!-7890"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Invalid_if_area_code_starts_with_0()
    {
        Assert.Throws<ArgumentException>(() => PhoneNumber.Clean("(023) 456-7890"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Invalid_if_area_code_starts_with_1()
    {
        Assert.Throws<ArgumentException>(() => PhoneNumber.Clean("(123) 456-7890"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Invalid_if_exchange_code_starts_with_0()
    {
        Assert.Throws<ArgumentException>(() => PhoneNumber.Clean("(223) 056-7890"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Invalid_if_exchange_code_starts_with_1()
    {
        Assert.Throws<ArgumentException>(() => PhoneNumber.Clean("(223) 156-7890"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Invalid_if_area_code_starts_with_0_on_valid_11_digit_number()
    {
        Assert.Throws<ArgumentException>(() => PhoneNumber.Clean("1 (023) 456-7890"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Invalid_if_area_code_starts_with_1_on_valid_11_digit_number()
    {
        Assert.Throws<ArgumentException>(() => PhoneNumber.Clean("1 (123) 456-7890"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Invalid_if_exchange_code_starts_with_0_on_valid_11_digit_number()
    {
        Assert.Throws<ArgumentException>(() => PhoneNumber.Clean("1 (223) 056-7890"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Invalid_if_exchange_code_starts_with_1_on_valid_11_digit_number()
    {
        Assert.Throws<ArgumentException>(() => PhoneNumber.Clean("1 (223) 156-7890"));
    }
}
