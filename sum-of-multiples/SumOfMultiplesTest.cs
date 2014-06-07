using NUnit.Framework;
using System.Collections.Generic;

[TestFixture]
public class SumOfMultiplesTest
{
    private SumOfMultiples sumOfMultiples;

    [SetUp]
    public void SetUp()
    {
        sumOfMultiples = new SumOfMultiples();
    }

    [Test]
    public void Sum_to_1()
    {
        Assert.That(sumOfMultiples.To(1), Is.EqualTo(0));
    }

    [Ignore]
    [Test]
    public void Sum_to_3()
    {
        Assert.That(sumOfMultiples.To(4), Is.EqualTo(3));
    }

    [Ignore]
    [Test]
    public void Sum_to_10()
    {
        Assert.That(sumOfMultiples.To(10), Is.EqualTo(23));
    }

    [Ignore]
    [Test]
    public void Sum_to_1000()
    {
        Assert.That(sumOfMultiples.To(1000), Is.EqualTo(233168));
    }

    [Ignore]
    [Test]
    public void Configurable_7_13_17_to_20()
    {
        Assert.That(new SumOfMultiples(new List<int> { 7, 13, 17 }).To(20), Is.EqualTo(51));
    }

    [Ignore]
    [Test]
    public void Configurable_43_47_to_10000()
    {
        Assert.That(new SumOfMultiples(new List<int> { 43, 47 }).To(10000), Is.EqualTo(2203160));
    }
}