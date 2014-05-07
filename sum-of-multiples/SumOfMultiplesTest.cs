using NUnit.Framework;
using System.Collections.Generic;

[TestFixture]
public class SumOfMultiplesTest
{
    private SumOfMultiples sumOfMultiples;

    [SetUp]
    public void FixtureSetup()
    {
        sumOfMultiples = new SumOfMultiples();
    }

    [Test]
    public void Sum_To_1()
    {
        Assert.That(0, Is.EqualTo(sumOfMultiples.To(1)));
    }

    [Test]
    [Ignore]
    public void Sum_To_3()
    {
        Assert.That(3, Is.EqualTo(sumOfMultiples.To(4)));
    }

    [Test]
    [Ignore]
    public void Sum_To_10()
    {
        Assert.That(23, Is.EqualTo(sumOfMultiples.To(10)));
    }

    [Test]
    [Ignore]
    public void Sum_To_1000()
    {
        Assert.That(233168, Is.EqualTo(sumOfMultiples.To(1000)));
    }

    [Test]
    [Ignore]
    public void Configurable_7_13_17_To_20()
    {
        Assert.That(51, Is.EqualTo(new SumOfMultiples(new List<int> { 7, 13, 17 }).To(20)));
    }

    [Test]
    [Ignore]
    public void Configurable_43_47_To_10000()
    {
        Assert.That(2203160, Is.EqualTo(new SumOfMultiples(new List<int> { 43, 47 }).To(10000)));
    }
}