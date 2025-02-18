public class AccumulateTests
{
    [Fact]
    public void Accumulate_empty()
    {
        int[] input = [];
        int[] expected = [];
        Assert.Equal(expected, input.Accumulate((x) => x * x));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Accumulate_squares()
    {
        int[] input = [1, 2, 3];
        int[] expected = [1, 4, 9];
        Assert.Equal(expected, input.Accumulate((x) => x * x));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Accumulate_upcases()
    {
        string[] input = ["Hello", "world"];
        string[] expected = ["HELLO", "WORLD"];
        Assert.Equal(expected, input.Accumulate((x) => x.ToUpper()));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Accumulate_reversed_strings()
    {
        string[] input = ["the", "quick", "brown", "fox", "etc"];
        string[] expected = ["eht", "kciuq", "nworb", "xof", "cte"];
        Assert.Equal(expected, input.Accumulate((x) => new string(x.Reverse().ToArray())));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Accumulate_recursively()
    {
        string[] input = ["a", "b", "c"];
        string[][] expected = [["a1", "a2", "a3"], ["b1", "b2", "b3"], ["c1", "c2", "c3"]];
        Assert.Equal(expected, input.Accumulate((x) => new[] { "1", "2", "3" }.Accumulate((y) => x + y)));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Accumulate_is_lazy()
    {
        var counter = 0;
        int[] input = [1, 2, 3];
        var accumulation = input.Accumulate(x => x * counter++);
        Assert.Equal(0, counter);
        var _ = accumulation.ToList();
        Assert.Equal(3, counter);
    }
}
