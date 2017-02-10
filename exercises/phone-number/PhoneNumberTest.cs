using Xunit;

public class PhoneNumberTest
{
    [Fact]
    public void Cleans_parens_spaces_and_dashes()
    {
        var phone = new PhoneNumber("(123) 456-7890");
        Assert.Equal("1234567890", phone.Number);
    }

    [Fact(Skip = "Remove to run test")]
    public void Cleans_numbers_with_dots()
    {
        var phone = new PhoneNumber("123.456.7890");
        Assert.Equal("1234567890", phone.Number);
    }

    [Fact(Skip = "Remove to run test")]
    public void Allows_us_country_code()
    {
        var phone = new PhoneNumber("11234567890");
        Assert.Equal("1234567890", phone.Number);
    }

    [Fact(Skip = "Remove to run test")]
    public void Invalid_when_11_digits()
    {
        var phone = new PhoneNumber("21234567890");
        Assert.Equal("0000000000", phone.Number);
    }

    [Fact(Skip = "Remove to run test")]
    public void Invalid_when_9_digits()
    {
        var phone = new PhoneNumber("123456789");
        Assert.Equal("0000000000", phone.Number);
    }

    [Fact(Skip = "Remove to run test")]
    public void Has_an_area_code()
    {
        var phone = new PhoneNumber("1234567890");
        Assert.Equal("123", phone.AreaCode);
    }

    [Fact(Skip = "Remove to run test")]
    public void Formats_a_number()
    {
        var phone = new PhoneNumber("1234567890");
        Assert.Equal("(123) 456-7890", phone.ToString());
    }
}