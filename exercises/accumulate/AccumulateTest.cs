using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public class AccumulateTest
{
    [Test]
    public void Empty_accumulation_produces_empty_accumulation()
    {
        Assert.That(new int[0].Accumulate(x => x * x), Is.EqualTo(new int[0]));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Accumulate_squares()
    {
        Assert.That(new[] { 1, 2, 3 }.Accumulate(x => x * x), Is.EqualTo(new[] { 1, 4, 9 }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Accumulate_upcases()
    {
        Assert.That(new List<string> { "hello", "world" }.Accumulate(x => x.ToUpper()),
            Is.EqualTo(new List<string> { "HELLO", "WORLD" }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Accumulate_reversed_strings()
    {
        Assert.That("the quick brown fox etc".Split(' ').Accumulate(Reverse),
            Is.EqualTo("eht kciuq nworb xof cte".Split(' ')));
    }

    private static string Reverse(string value)
    {
        var array = value.ToCharArray();
        Array.Reverse(array);
        return new string(array);
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Accumulate_within_accumulate()
    {
        var actual = new[] { "a", "b", "c" }.Accumulate(c =>
            string.Join(" ", new[] { "1", "2", "3" }.Accumulate(d => c + d)));
        Assert.That(actual, Is.EqualTo(new[] { "a1 a2 a3", "b1 b2 b3", "c1 c2 c3" }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Accumulate_is_lazy()
    {
        var counter = 0;
        var accumulation = new[] { 1, 2, 3 }.Accumulate(x => x * counter++);

        Assert.That(counter, Is.EqualTo(0));
        accumulation.ToList();
        Assert.That(counter, Is.EqualTo(3));
    }
}