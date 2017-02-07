using System;
using Xunit;
using System.Linq;
using System.Collections.Generic;

public class DominoesTest
{
    private static bool ConsecutivesMatch(IEnumerable<Tuple<int, int>> chain)
    {
        for (int i = 0; i < chain.Count() - 2; i++)
        {
            if (chain.ElementAt(i).Item2 != chain.ElementAt(i + 1).Item1)
                return false;
        }

        return true;
    }

    private static bool EndsMatch(IEnumerable<Tuple<int, int>> chain)
        => !chain.Any() || chain.First().Item1 == chain.Last().Item2;

    private static Tuple<int, int> SortDomino(Tuple<int, int> domino)
        => domino.Item1 > domino.Item2 ? Tuple.Create(domino.Item2, domino.Item1) : domino;

    private static IEnumerable<Tuple<int, int>> SortDominoes(IEnumerable<Tuple<int, int>> dominoes)
        => dominoes.Select(SortDomino).OrderBy(x => x);

    private static bool HasSameDominoes(IEnumerable<Tuple<int, int>> chain, IEnumerable<Tuple<int, int>> input)
        => SortDominoes(chain).SequenceEqual(SortDominoes(input));

    private static bool IsValidSolution(IEnumerable<Tuple<int, int>> chain, IEnumerable<Tuple<int, int>> input)
    {
        return
            ConsecutivesMatch(chain) &&
            EndsMatch(chain) &&
            HasSameDominoes(chain, input);
    }

    [Fact]
    public void Empty_input_equals_empty_output()
    {
        var actual = new Tuple<int, int>[0];
        var chain = Dominoes.Chain(actual);
        Assert.That(IsValidSolution(chain, actual));
    }

    [Fact]
    public void Singleton_input_equals_singleton_output()
    {
        var actual = new[] { Tuple.Create(1, 1) };
        var chain = Dominoes.Chain(actual);
        Assert.That(IsValidSolution(chain, actual));
    }

    [Fact]
    public void Singleton_that_cant_be_chained()
    {
        var actual = new[] { Tuple.Create(1, 2) };
        var chain = Dominoes.Chain(actual);
        Assert.That(chain, Is.Null);
    }

    [Fact]
    public void Three_elements()
    {
        var actual = new[] { Tuple.Create(1, 2), Tuple.Create(3, 1), Tuple.Create(2, 3) };
        var chain = Dominoes.Chain(actual);
        Assert.That(IsValidSolution(chain, actual));
    }

    [Fact]
    public void Can_reverse_dominoes()
    {
        var actual = new[] { Tuple.Create(1, 2), Tuple.Create(1, 3), Tuple.Create(2, 3) };
        var chain = Dominoes.Chain(actual);
        Assert.That(IsValidSolution(chain, actual));
    }

    [Fact]
    public void Cant_be_chained()
    {
        var actual = new[] { Tuple.Create(1, 2), Tuple.Create(4, 1), Tuple.Create(2, 3) };
        var chain = Dominoes.Chain(actual);
        Assert.That(chain, Is.Null);
    }

    [Fact]
    public void Disconnected_simple()
    {
        var actual = new[] { Tuple.Create(1, 1), Tuple.Create(2, 2) };
        var chain = Dominoes.Chain(actual);
        Assert.That(chain, Is.Null);
    }

    [Fact]
    public void Disconnected_double_loop()
    {
        var actual = new[] { Tuple.Create(1, 2), Tuple.Create(2, 1), Tuple.Create(3, 4), Tuple.Create(4, 3) };
        var chain = Dominoes.Chain(actual);
        Assert.That(chain, Is.Null);
    }

    [Fact]
    public void Disconnected_single_isolated()
    {
        var actual = new[] { Tuple.Create(1, 2), Tuple.Create(2, 3), Tuple.Create(3, 1), Tuple.Create(4, 4) };
        var chain = Dominoes.Chain(actual);
        Assert.That(chain, Is.Null);
    }

    [Fact]
    public void Need_backtrack()
    {
        var actual = new[] { Tuple.Create(1, 2), Tuple.Create(2, 3), Tuple.Create(3, 1), Tuple.Create(2, 4), Tuple.Create(2, 4) };
        var chain = Dominoes.Chain(actual);
        Assert.That(IsValidSolution(chain, actual));
    }

    [Fact]
    public void Separate_loops()
    {
        var actual = new[]
        {
            Tuple.Create(1, 2), Tuple.Create(2, 3), Tuple.Create(3, 1), Tuple.Create(1, 1), Tuple.Create(2, 2), Tuple.Create(3, 3)
        };
        var chain = Dominoes.Chain(actual);
        Assert.That(IsValidSolution(chain, actual));
    }

    [Fact]
    public void Ten_elements()
    {
        var actual = new[]
        {
            Tuple.Create(1, 2), Tuple.Create(5, 3), Tuple.Create(3, 1), Tuple.Create(1, 2), Tuple.Create(2, 4),
            Tuple.Create(1, 6), Tuple.Create(2, 3), Tuple.Create(3, 4), Tuple.Create(5, 6)
        };
        var chain = Dominoes.Chain(actual);
        Assert.That(IsValidSolution(chain, actual));
    }
}