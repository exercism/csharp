using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

public class AccumulateTest
{
    [Fact]
    public void Empty_accumulation_produces_empty_accumulation()
    {
        Assert.Equal(new int[0], new int[0].Accumulate(x => x * x));
    }

    [Fact(Skip="Remove to run test")]
    public void Accumulate_squares()
    {
        Assert.Equal(new[] { 1, 4, 9 }, new[] { 1, 2, 3 }.Accumulate(x => x * x));
    }

    [Fact(Skip="Remove to run test")]
    public void Accumulate_upcases()
    {
        Assert.That(new List<string> { "hello", "world" }.Accumulate(x => x.ToUpper()),
            Is.EqualTo(new List<string> { "HELLO", "WORLD" }));
    }

    [Fact(Skip="Remove to run test")]
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

    [Fact(Skip="Remove to run test")]
    public void Accumulate_within_accumulate()
    {
        var actual = new[] { "a", "b", "c" }.Accumulate(c =>
            string.Join(" ", new[] { "1", "2", "3" }.Accumulate(d => c + d)));
        Assert.Equal(new[] { "a1 a2 a3", "b1 b2 b3", "c1 c2 c3" }, actual);
    }

    [Fact(Skip="Remove to run test")]
    public void Accumulate_is_lazy()
    {
        var counter = 0;
        var accumulation = new[] { 1, 2, 3 }.Accumulate(x => x * counter++);

        Assert.Equal(0, counter);
        accumulation.ToList();
        Assert.Equal(3, counter);
    }

    [Fact(Skip="Remove to run test")]
    public void Accumulate_allows_different_return_type()
    {
        Assert.That(
            new[] { 1, 2, 3 }.Accumulate(x => x.ToString()), 
            Is.EqualTo(new[] { "1", "2", "3" }));
    }
}