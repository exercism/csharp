using Xunit;

public class SumOfMultiplesTest
{
    [Fact]
    public void Sum_to_1()
    {
        Assert.That(SumOfMultiples.To(new[] { 3, 5 }, 1), Is.EqualTo(0));
    }

    [Fact(Skip="Remove to run test")]
    public void Sum_to_3()
    {
        Assert.That(SumOfMultiples.To(new[] { 3, 5 }, 4), Is.EqualTo(3));
    }

    [Fact(Skip="Remove to run test")]
    public void Sum_to_10()
    {
        Assert.That(SumOfMultiples.To(new[] { 3, 5 }, 10), Is.EqualTo(23));
    }

    [Fact(Skip="Remove to run test")]
    public void Sum_to_100()
    {
       Assert.That(SumOfMultiples.To(new[] { 3, 5 }, 100), Is.EqualTo(2318));
    }

    [Fact(Skip="Remove to run test")]
    public void Sum_to_1000()
    {
        Assert.That(SumOfMultiples.To(new[] { 3, 5 }, 1000), Is.EqualTo(233168));
    }

    [Fact(Skip="Remove to run test")]
    public void Sum_to_20()
    {
        Assert.That(SumOfMultiples.To(new [] { 7, 13, 17 }, 20), Is.EqualTo(51));
    }

    [Fact(Skip="Remove to run test")]
    public void Sum_to_10000()
    {
        Assert.That(SumOfMultiples.To(new [] { 43, 47 }, 10000), Is.EqualTo(2203160));
    }
}
