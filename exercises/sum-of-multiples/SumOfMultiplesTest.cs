using NUnit.Framework;

[TestFixture]
public class SumOfMultiplesTest
{
    [Test]
    public void Sum_to_1()
    {
        Assert.That(SumOfMultiples.To(new[] { 3, 5 }, 1), Is.EqualTo(0));
    }
    
    [Test]
    public void Sum_to_3()
    {
        Assert.That(SumOfMultiples.To(new[] { 3, 5 }, 4), Is.EqualTo(3));
    }
    
    [Test]
    public void Sum_to_10()
    {
        Assert.That(SumOfMultiples.To(new[] { 3, 5 }, 10), Is.EqualTo(23));
    }
    
    [Test]
    public void Sum_to_100()
    {
       Assert.That(SumOfMultiples.To(new[] { 3, 5 }, 100), Is.EqualTo(2318));
    }
    
    [Test]
    public void Sum_to_1000()
    {
        Assert.That(SumOfMultiples.To(new[] { 3, 5 }, 1000), Is.EqualTo(233168));
    }
    
    [Test]
    public void Sum_to_20()
    {
        Assert.That(SumOfMultiples.To(new [] { 7, 13, 17 }, 20), Is.EqualTo(51));
    }
    
    [Test]
    public void Sum_to_10000()
    {
        Assert.That(SumOfMultiples.To(new [] { 43, 47 }, 10000), Is.EqualTo(2203160));
    }
}
