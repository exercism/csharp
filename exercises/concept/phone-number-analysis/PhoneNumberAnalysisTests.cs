using Xunit;
using Exercism.Tests;

public class TuplesTest
{
    [Fact]
    public void Analyze_non_fake_non_newyork()
    {
        Assert.Equal((false, false, "1234"), PhoneNumber.Analyze("631-502-1234"));
    }

    [Fact]
    public void Analyze_fake_non_newyork()
    {
        Assert.Equal((false, true, "1234"), PhoneNumber.Analyze("631-555-1234"));
    }

    [Fact]
    public void Analyze_non_fake_newyork()
    {
        Assert.Equal((true, false, "1234"), PhoneNumber.Analyze("212-502-1234"));
    }

    [Fact]
    public void Analyze_fake_newyork()
    {
        Assert.Equal((true, true, "1234"), PhoneNumber.Analyze("212-555-1234"));
    }

    [Fact]
    public void Analyze_fake_fake()
    {
        Assert.Equal((false, false, "1234"), PhoneNumber.Analyze("515-212-1234"));
    }

    [Fact]
    public void Is_Fake_fake()
    {
        Assert.True(PhoneNumber.IsFake(PhoneNumber.Analyze("212-555-1234")));
    }

    [Fact]
    public void Is_Fake_non_fake()
    {
        Assert.False(PhoneNumber.IsFake(PhoneNumber.Analyze("555-212-1234")));
    }
}
