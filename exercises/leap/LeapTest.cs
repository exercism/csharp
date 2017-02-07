using Xunit;

public class LeapTest
{
    [Fact]
    public void Valid_leap_year()
    {
        Assert.That(Year.IsLeap(1996), Is.True);
    }

    [Fact(Skip="Remove to run test")]
    public void Invalid_leap_year()
    {
        Assert.That(Year.IsLeap(1997), Is.False);
    }

    [Fact(Skip="Remove to run test")]
    public void Turn_of_the_20th_century_is_not_a_leap_year()
    {
        Assert.That(Year.IsLeap(1900), Is.False);
    }

    [Fact(Skip="Remove to run test")]
    public void Turn_of_the_25th_century_is_a_leap_year()
    {
        Assert.That(Year.IsLeap(2400), Is.True);
    }
}