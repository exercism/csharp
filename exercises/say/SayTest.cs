using Xunit;

public class SayTest
{
    [Fact]
    public void Zero()
    {
        Assert.That(Say.InEnglish(0L), Is.EqualTo("zero"));
    }

    [Fact(Skip="Remove to run test")]
    public void One()
    {
        Assert.That(Say.InEnglish(1L), Is.EqualTo("one"));
    }

    [Fact(Skip="Remove to run test")]
    public void Fourteen()
    {
        Assert.That(Say.InEnglish(14L), Is.EqualTo("fourteen"));
    }

    [Fact(Skip="Remove to run test")]
    public void Twenty()
    {
        Assert.That(Say.InEnglish(20L), Is.EqualTo("twenty"));
    }

    [Fact(Skip="Remove to run test")]
    public void Twenty_two()
    {
        Assert.That(Say.InEnglish(22L), Is.EqualTo("twenty-two"));
    }

    [Fact(Skip="Remove to run test")]
    public void One_hundred()
    {
        Assert.That(Say.InEnglish(100L), Is.EqualTo("one hundred"));
    }

    [Fact(Skip="Remove to run test")]
    public void One_hundred_twenty_three()
    {
        Assert.That(Say.InEnglish(123L), Is.EqualTo("one hundred twenty-three"));
    }

    [Fact(Skip="Remove to run test")]
    public void One_thousand()
    {
        Assert.That(Say.InEnglish(1000L), Is.EqualTo("one thousand"));
    }

    [Fact(Skip="Remove to run test")]
    public void One_thousand_two_hundred_thirty_four()
    {
        Assert.That(Say.InEnglish(1234L), Is.EqualTo("one thousand two hundred thirty-four"));
    }

    [Fact(Skip="Remove to run test")]
    public void One_million()
    {
        Assert.That(Say.InEnglish(1000000L), Is.EqualTo("one million"));
    }

    [Fact(Skip="Remove to run test")]
    public void One_million_two()
    {
        Assert.That(Say.InEnglish(1000002L), Is.EqualTo("one million two"));
    }

    [Fact(Skip="Remove to run test")]
    public void One_million_two_thousand_three_hundred_forty_five()
    {
        Assert.That(Say.InEnglish(1002345L), Is.EqualTo("one million two thousand three hundred forty-five"));
    }

    [Fact(Skip="Remove to run test")]
    public void One_billion()
    {
        Assert.That(Say.InEnglish(1000000000L), Is.EqualTo("one billion"));
    }

    [Fact(Skip="Remove to run test")]
    public void A_big_number()
    {
        Assert.That(Say.InEnglish(987654321123L), Is.EqualTo("nine hundred eighty-seven billion six hundred fifty-four million three hundred twenty-one thousand one hundred twenty-three"));
    }

    [Fact(Skip="Remove to run test")]
    public void Lower_bound()
    {
        Assert.That(() => Say.InEnglish(-1L), Throws.Exception);
    }

    [Fact(Skip="Remove to run test")]
    public void Upper_bound()
    {
        Assert.That(() => Say.InEnglish(1000000000000L), Throws.Exception);
    }
}