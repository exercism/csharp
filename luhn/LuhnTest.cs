using NUnit.Framework;

[TestFixture]
public class LuhnTest
{
    [Test]
    public void Check_digit_is_the_rightmost_digit()
    {
        Assert.That(new Luhn(34567).CheckDigit, Is.EqualTo(7));
    }

    [Ignore]
    [Test]
    public void Addends_doubles_every_other_number_from_the_right()
    {
        Assert.That(new Luhn(12121).Addends, Is.EqualTo(new[] { 1, 4, 1, 4, 1 }));
    }

    [Ignore]
    [Test]
    public void Addends_subtracts_9_when_doubled_number_is_more_than_9()
    {
        Assert.That(new Luhn(8631).Addends, Is.EqualTo(new[] { 7, 6, 6, 1 }));
    }

    [Ignore]
    [TestCase(4913, Result = 22)]
    [TestCase(201773, Result = 21)]
    public int Checksum_adds_addends_together(int number)
    {
        return new Luhn(number).Checksum;
    }

    [Ignore]
    [TestCase(738, Result = false)]
    [TestCase(8739567, Result = true)]
    public bool Number_is_valid_when_checksum_mod_10_is_zero(int number)
    {
        return new Luhn(number).Valid;
    }

    [Ignore]
    [Test]
    public void Luhn_can_create_simple_numbers_with_valid_check_digit()
    {
        Assert.That(Luhn.Create(123), Is.EqualTo(1230));
    }

    [Ignore]
    [Test]
    public void Luhn_can_create_larger_numbers_with_valid_check_digit()
    {
        Assert.That(Luhn.Create(873956), Is.EqualTo(8739567));
    }

    [Ignore]
    [Test]
    public void Luhn_can_create_huge_numbers_with_valid_check_digit()
    {
        Assert.That(Luhn.Create(837263756), Is.EqualTo(8372637564));
    }
}