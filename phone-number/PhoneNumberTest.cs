using NUnit.Framework;

[TestFixture]
public class PhoneNumberTest
{
    [Test]
    public void CleansParensSpacesAndDashes()
    {
        var phone = new PhoneNumber("(123) 456-7890");
        Assert.That(phone.Number, Is.EqualTo("1234567890"));
    }

    [Test, Ignore]
    public void CleansNumbersWithDots()
    {
        var phone = new PhoneNumber("123.456.7890");
        Assert.That(phone.Number, Is.EqualTo("1234567890"));
    }

    [Test, Ignore]
    public void AllowsUsCountryCode()
    {
        var phone = new PhoneNumber("11234567890");
        Assert.That(phone.Number, Is.EqualTo("1234567890"));
    }

    [Test, Ignore]
    public void InvalidWhen11Digits()
    {
        var phone = new PhoneNumber("21234567890");
        Assert.That(phone.Number, Is.EqualTo("0000000000"));
    }

    [Test, Ignore]
    public void InvalidWhen9Digits()
    {
        var phone = new PhoneNumber("123456789");
        Assert.That(phone.Number, Is.EqualTo("0000000000"));
    }

    [Test, Ignore]
    public void HasAnAreaCode()
    {
        var phone = new PhoneNumber("1234567890");
        Assert.That(phone.AreaCode, Is.EqualTo("123"));
    }

    [Test, Ignore]
    public void FormatsANumber()
    {
        var phone = new PhoneNumber("1234567890");
        Assert.That(phone.ToString(), Is.EqualTo("(123) 456-7890"));
    }
}