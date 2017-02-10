using System;
using Xunit;

public class DominoesTest
{
    [Fact(Skip = "Remove to run test")]
    public void Empty_input_equals_empty_output()
    {
        var actual = new Tuple<int, int>[0];
        Assert.True(Dominoes.CanChain(actual));
    }
    
    [Fact(Skip = "Remove to run test")]
    public void Singleton_input_equals_singleton_output()
    {
        var actual = new[] { Tuple.Create(1, 1) };
        Assert.True(Dominoes.CanChain(actual));
    }
    
    [Fact(Skip = "Remove to run test")]
    public void Singleton_that_cant_be_chained()
    {
        var actual = new[] { Tuple.Create(1, 2) };
        Assert.False(Dominoes.CanChain(actual));
    }
    
    [Fact(Skip = "Remove to run test")]
    public void Three_elements()
    {
        var actual = new[] { Tuple.Create(1, 2), Tuple.Create(3, 1), Tuple.Create(2, 3) };
        Assert.True(Dominoes.CanChain(actual));
    }
    
    [Fact(Skip = "Remove to run test")]
    public void Can_reverse_dominoes()
    {
        var actual = new[] { Tuple.Create(1, 2), Tuple.Create(1, 3), Tuple.Create(2, 3) };
        Assert.True(Dominoes.CanChain(actual));
    }
    
    [Fact(Skip = "Remove to run test")]
    public void Cant_be_chained()
    {
        var actual = new[] { Tuple.Create(1, 2), Tuple.Create(4, 1), Tuple.Create(2, 3) };
        Assert.False(Dominoes.CanChain(actual));
    }
    
    [Fact(Skip = "Remove to run test")]
    public void Disconnected_simple()
    {
        var actual = new[] { Tuple.Create(1, 1), Tuple.Create(2, 2) };
        Assert.False(Dominoes.CanChain(actual));
    }
    
    [Fact(Skip = "Remove to run test")]
    public void Disconnected_double_loop()
    {
        var actual = new[] { Tuple.Create(1, 2), Tuple.Create(2, 1), Tuple.Create(3, 4), Tuple.Create(4, 3) };
        Assert.False(Dominoes.CanChain(actual));
    }
    
    [Fact(Skip = "Remove to run test")]
    public void Disconnected_single_isolated()
    {
        var actual = new[] { Tuple.Create(1, 2), Tuple.Create(2, 3), Tuple.Create(3, 1), Tuple.Create(4, 4) };
        Assert.False(Dominoes.CanChain(actual));
    }
    
    [Fact(Skip = "Remove to run test")]
    public void Need_backtrack()
    {
        var actual = new[] { Tuple.Create(1, 2), Tuple.Create(2, 3), Tuple.Create(3, 1), Tuple.Create(2, 4), Tuple.Create(2, 4) };
        Assert.True(Dominoes.CanChain(actual));
    }
    
    [Fact(Skip = "Remove to run test")]
    public void Separate_loops()
    {
        var actual = new[]
        {
            Tuple.Create(1, 2), Tuple.Create(2, 3), Tuple.Create(3, 1), Tuple.Create(1, 1), Tuple.Create(2, 2), Tuple.Create(3, 3)
        };
        Assert.True(Dominoes.CanChain(actual));
    }

    [Fact(Skip = "Remove to run test")]
    public void Ten_elements()
    {
        var actual = new[]
        {
            Tuple.Create(1, 2), Tuple.Create(5, 3), Tuple.Create(3, 1), Tuple.Create(1, 2), Tuple.Create(2, 4),
            Tuple.Create(1, 6), Tuple.Create(2, 3), Tuple.Create(3, 4), Tuple.Create(5, 6)
        };
        Assert.True(Dominoes.CanChain(actual));
    }
}