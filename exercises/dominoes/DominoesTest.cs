// This file was auto-generated based on version 2.0.0 of the canonical data.

using Xunit;
using System;

public class DominoesTest
{
    [Fact]
    public void Empty_input_empty_output()
    {
        var input = new Tuple<int, int>[] {  };
        Assert.True(Dominoes.CanChain(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Singleton_input_singleton_output()
    {
        var input = new Tuple<int, int>[] { Tuple.Create(1, 1) };
        Assert.True(Dominoes.CanChain(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Singleton_that_cant_be_chained()
    {
        var input = new Tuple<int, int>[] { Tuple.Create(1, 2) };
        Assert.False(Dominoes.CanChain(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Three_elements()
    {
        var input = new Tuple<int, int>[] { Tuple.Create(1, 2), Tuple.Create(3, 1), Tuple.Create(2, 3) };
        Assert.True(Dominoes.CanChain(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Can_reverse_dominoes()
    {
        var input = new Tuple<int, int>[] { Tuple.Create(1, 2), Tuple.Create(1, 3), Tuple.Create(2, 3) };
        Assert.True(Dominoes.CanChain(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Cant_be_chained()
    {
        var input = new Tuple<int, int>[] { Tuple.Create(1, 2), Tuple.Create(4, 1), Tuple.Create(2, 3) };
        Assert.False(Dominoes.CanChain(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Disconnected_simple()
    {
        var input = new Tuple<int, int>[] { Tuple.Create(1, 1), Tuple.Create(2, 2) };
        Assert.False(Dominoes.CanChain(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Disconnected_double_loop()
    {
        var input = new Tuple<int, int>[] { Tuple.Create(1, 2), Tuple.Create(2, 1), Tuple.Create(3, 4), Tuple.Create(4, 3) };
        Assert.False(Dominoes.CanChain(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Disconnected_single_isolated()
    {
        var input = new Tuple<int, int>[] { Tuple.Create(1, 2), Tuple.Create(2, 3), Tuple.Create(3, 1), Tuple.Create(4, 4) };
        Assert.False(Dominoes.CanChain(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Need_backtrack()
    {
        var input = new Tuple<int, int>[] { Tuple.Create(1, 2), Tuple.Create(2, 3), Tuple.Create(3, 1), Tuple.Create(2, 4), Tuple.Create(2, 4) };
        Assert.True(Dominoes.CanChain(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Separate_loops()
    {
        var input = new Tuple<int, int>[] { Tuple.Create(1, 2), Tuple.Create(2, 3), Tuple.Create(3, 1), Tuple.Create(1, 1), Tuple.Create(2, 2), Tuple.Create(3, 3) };
        Assert.True(Dominoes.CanChain(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Nine_elements()
    {
        var input = new Tuple<int, int>[] { Tuple.Create(1, 2), Tuple.Create(5, 3), Tuple.Create(3, 1), Tuple.Create(1, 2), Tuple.Create(2, 4), Tuple.Create(1, 6), Tuple.Create(2, 3), Tuple.Create(3, 4), Tuple.Create(5, 6) };
        Assert.True(Dominoes.CanChain(input));
    }
}