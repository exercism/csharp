public class DominoesTests
{
    [Fact]
    public void Empty_input_empty_output()
    {
        Assert.True(Dominoes.CanChain([]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Singleton_input_singleton_output()
    {
        Assert.True(Dominoes.CanChain([(1, 1)]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Singleton_that_can_t_be_chained()
    {
        Assert.False(Dominoes.CanChain([(1, 2)]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Three_elements()
    {
        Assert.True(Dominoes.CanChain([(1, 2), (3, 1), (2, 3)]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Can_reverse_dominoes()
    {
        Assert.True(Dominoes.CanChain([(1, 2), (1, 3), (2, 3)]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Can_t_be_chained()
    {
        Assert.False(Dominoes.CanChain([(1, 2), (4, 1), (2, 3)]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Disconnected_simple()
    {
        Assert.False(Dominoes.CanChain([(1, 1), (2, 2)]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Disconnected_double_loop()
    {
        Assert.False(Dominoes.CanChain([(1, 2), (2, 1), (3, 4), (4, 3)]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Disconnected_single_isolated()
    {
        Assert.False(Dominoes.CanChain([(1, 2), (2, 3), (3, 1), (4, 4)]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Need_backtrack()
    {
        Assert.True(Dominoes.CanChain([(1, 2), (2, 3), (3, 1), (2, 4), (2, 4)]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Separate_loops()
    {
        Assert.True(Dominoes.CanChain([(1, 2), (2, 3), (3, 1), (1, 1), (2, 2), (3, 3)]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Nine_elements()
    {
        Assert.True(Dominoes.CanChain([(1, 2), (5, 3), (3, 1), (1, 2), (2, 4), (1, 6), (2, 3), (3, 4), (5, 6)]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Separate_three_domino_loops()
    {
        Assert.False(Dominoes.CanChain([(1, 2), (2, 3), (3, 1), (4, 5), (5, 6), (6, 4)]));
    }
}
