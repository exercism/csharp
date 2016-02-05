using NUnit.Framework;

[TestFixture]
public class PhoneNumberTest
{
    [Test]
    public void Cleans_parens_spaces_and_dashes()
    {
        var phone = new PhoneNumber("(123) 456-7890");
        Assert.That(phone.Number, Is.EqualTo("1234567890"));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Cleans_numbers_with_dots()
    {
        var phone = new PhoneNumber("123.456.7890");
        Assert.That(phone.Number, Is.EqualTo("1234567890"));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Allows_us_country_code()
    {
        var phone = new PhoneNumber("11234567890");
        Assert.That(phone.Number, Is.EqualTo("1234567890"));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Invalid_when_11_digits()
    {
        var phone = new PhoneNumber("21234567890");
        Assert.That(phone.Number, Is.EqualTo("0000000000"));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Invalid_when_9_digits()
    {
        var phone = new PhoneNumber("123456789");
        Assert.That(phone.Number, Is.EqualTo("0000000000"));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Has_an_area_code()
    {
        var phone = new PhoneNumber("1234567890");
        Assert.That(phone.AreaCode, Is.EqualTo("123"));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Formats_a_number()
    {
        var phone = new PhoneNumber("1234567890");
        Assert.That(phone.ToString(), Is.EqualTo("(123) 456-7890"));
    }
}