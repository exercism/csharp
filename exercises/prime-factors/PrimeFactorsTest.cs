using Xunit;

public class PrimeFactorsTest
{
    [Fact]
    public void Test_1()
    {
        Assert.Equal(new int[0], PrimeFactors.For(1));
    }

    [Fact]
    public void Test_2()
    {
        Assert.Equal(new[] { 2 }, PrimeFactors.For(2));
    }

    [Fact]
    public void Test_3()
    {
        Assert.Equal(new[] { 3 }, PrimeFactors.For(3));
    }

    [Fact]
    public void Test_4()
    {
        Assert.Equal(new[] { 2, 2 }, PrimeFactors.For(4));
    }

    [Fact]
    public void Test_6()
    {
        Assert.Equal(new[] { 2, 3 }, PrimeFactors.For(6));
    }

    [Fact]
    public void Test_8()
    {
        Assert.Equal(new[] { 2, 2, 2 }, PrimeFactors.For(8));
    }

    [Fact]
    public void Test_9()
    {
        Assert.Equal(new[] { 3, 3 }, PrimeFactors.For(9));
    }

    [Fact]
    public void Test_27()
    {
        Assert.Equal(new[] { 3, 3, 3 }, PrimeFactors.For(27));
    }

    [Fact]
    public void Test_625()
    {
        Assert.Equal(new[] { 5, 5, 5, 5 }, PrimeFactors.For(625));
    }

    [Fact]
    public void Test_901255()
    {
        Assert.Equal(new[] { 5, 17, 23, 461 }, PrimeFactors.For(901255));
    }

    [Fact]
    public void Test_93819012551()
    {
        Assert.Equal(new[] { 11, 9539, 894119 }, PrimeFactors.For(93819012551));
    }
}