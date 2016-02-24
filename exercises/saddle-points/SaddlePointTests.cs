using System;
using NUnit.Framework;

public class SaddlePointTests
{
    [Test]
    public void Readme_example()
    {
        var values = new[,]
        {
            { 9, 8, 7 }, 
            { 5, 3, 2 }, 
            { 6, 6, 7 }
        };
        var actual = new SaddlePoints(values).Calculate();
        Assert.That(actual, Is.EqualTo(new [] { Tuple.Create(1, 0)}));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void No_saddle_point()
    {
        var values = new[,] 
        { 
            { 2, 1 }, 
            { 1, 2 }
        };
        var actual = new SaddlePoints(values).Calculate();
        Assert.That(actual, Is.Empty);
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Saddle_point()
    {
        var values = new[,] 
        { 
            { 1, 2 }, 
            { 3, 4 }
        };
        var actual = new SaddlePoints(values).Calculate();
        Assert.That(actual, Is.EqualTo(new[] { Tuple.Create(0, 1) }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Another_saddle_point()
    {
        var values = new[,] 
        { 
            { 18,  3, 39, 19,  91 }, 
            { 38, 10,  8, 77, 320 }, 
            {  3,  4,  8,  6,   7 }
        };
        var actual = new SaddlePoints(values).Calculate();
        Assert.That(actual, Is.EqualTo(new[] { Tuple.Create(2, 2) }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Multiple_saddle_points()
    {
        var values = new[,]
        {
            { 4, 5, 4 },
            { 3, 5, 5 },
            { 1, 5, 4 }
        };
        var actual = new SaddlePoints(values).Calculate();
        Assert.That(actual, Is.EqualTo(new[] { Tuple.Create(0, 1), Tuple.Create(1, 1), Tuple.Create(2, 1) }));
    }
}