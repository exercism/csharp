using NUnit.Framework;

[TestFixture]
public class PrimeFactorsTest
{
    [Test]
    public void Test_1()
    {
        Assert.That(PrimeFactors.For(1), Is.EqualTo(new int[0]));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Test_2()
    {
        Assert.That(PrimeFactors.For(2), Is.EqualTo(new[] { 2 }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Test_3()
    {
        Assert.That(PrimeFactors.For(3), Is.EqualTo(new[] { 3 }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Test_4()
    {
        Assert.That(PrimeFactors.For(4), Is.EqualTo(new[] { 2, 2 }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Test_6()
    {
        Assert.That(PrimeFactors.For(6), Is.EqualTo(new[] { 2, 3 }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Test_8()
    {
        Assert.That(PrimeFactors.For(8), Is.EqualTo(new[] { 2, 2, 2 }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Test_9()
    {
        Assert.That(PrimeFactors.For(9), Is.EqualTo(new[] { 3, 3 }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Test_27()
    {
        Assert.That(PrimeFactors.For(27), Is.EqualTo(new[] { 3, 3, 3 }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Test_625()
    {
        Assert.That(PrimeFactors.For(625), Is.EqualTo(new[] { 5, 5, 5, 5 }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Test_901255()
    {
        Assert.That(PrimeFactors.For(901255), Is.EqualTo(new[] { 5, 17, 23, 461 }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Test_93819012551()
    {
        Assert.That(PrimeFactors.For(93819012551), Is.EqualTo(new[] { 11, 9539, 894119 }));
    }
}