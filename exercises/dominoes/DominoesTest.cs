using System;
using NUnit.Framework;

public class DominoesTest
{
    [Test]
    public void Empty_input_equals_empty_output()
    {
        var actual = new Tuple<int, int>[0];
        Assert.That(Dominoes.CanChain(actual), Is.True);
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Singleton_input_equals_singleton_output()
    {
        var actual = new[] { Tuple.Create(1, 1) };
        Assert.That(Dominoes.CanChain(actual), Is.True);
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Singleton_that_cant_be_chained()
    {
        var actual = new[] { Tuple.Create(1, 2) };
        Assert.That(Dominoes.CanChain(actual), Is.False);
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Three_elements()
    {
        var actual = new[] { Tuple.Create(1, 2), Tuple.Create(3, 1), Tuple.Create(2, 3) };
        Assert.That(Dominoes.CanChain(actual), Is.True);
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Can_reverse_dominoes()
    {
        var actual = new[] { Tuple.Create(1, 2), Tuple.Create(1, 3), Tuple.Create(2, 3) };
        Assert.That(Dominoes.CanChain(actual), Is.True);
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Cant_be_chained()
    {
        var actual = new[] { Tuple.Create(1, 2), Tuple.Create(4, 1), Tuple.Create(2, 3) };
        Assert.That(Dominoes.CanChain(actual), Is.False);
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Disconnected_simple()
    {
        var actual = new[] { Tuple.Create(1, 1), Tuple.Create(2, 2) };
        Assert.That(Dominoes.CanChain(actual), Is.False);
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Disconnected_double_loop()
    {
        var actual = new[] { Tuple.Create(1, 2), Tuple.Create(2, 1), Tuple.Create(3, 4), Tuple.Create(4, 3) };
        Assert.That(Dominoes.CanChain(actual), Is.False);
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Disconnected_single_isolated()
    {
        var actual = new[] { Tuple.Create(1, 2), Tuple.Create(2, 3), Tuple.Create(3, 1), Tuple.Create(4, 4) };
        Assert.That(Dominoes.CanChain(actual), Is.False);
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Need_backtrack()
    {
        var actual = new[] { Tuple.Create(1, 2), Tuple.Create(2, 3), Tuple.Create(3, 1), Tuple.Create(2, 4), Tuple.Create(2, 4) };
        Assert.That(Dominoes.CanChain(actual), Is.True);
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Separate_loops()
    {
        var actual = new[]
        {
            Tuple.Create(1, 2), Tuple.Create(2, 3), Tuple.Create(3, 1), Tuple.Create(1, 1), Tuple.Create(2, 2), Tuple.Create(3, 3)
        };
        Assert.That(Dominoes.CanChain(actual), Is.True);
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Ten_elements()
    {
        var actual = new[]
        {
            Tuple.Create(1, 2), Tuple.Create(5, 3), Tuple.Create(3, 1), Tuple.Create(1, 2), Tuple.Create(2, 4),
            Tuple.Create(1, 6), Tuple.Create(2, 3), Tuple.Create(3, 4), Tuple.Create(5, 6)
        };
        Assert.That(Dominoes.CanChain(actual), Is.True);
    }
}