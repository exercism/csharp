using System.Collections.Generic;
using System.Linq;
using Xunit;

public class StrainTest
{
    [Fact]
    public void Empty_keep()
    {
        Assert.Equal(new LinkedList<int>(), new LinkedList<int>().Keep(x => x < 10));
    }

    [Fact(Skip = "Remove to run test")]
    public void Keep_everything()
    {
        Assert.Equal(new HashSet<int> { 1, 2, 3 }, new HashSet<int> { 1, 2, 3 }.Keep(x => x < 10));
    }

    [Fact(Skip = "Remove to run test")]
    public void Keep_first_and_last()
    {
        Assert.Equal(new[] { 1, 3 }, new[] { 1, 2, 3 }.Keep(x => x % 2 != 0));
    }

    [Fact(Skip = "Remove to run test")]
    public void Keep_neither_first_nor_last()
    {
        Assert.Equal(new List<int> { 2, 4 }, new List<int> { 1, 2, 3, 4, 5 }.Keep(x => x % 2 == 0));
    }

    [Fact(Skip = "Remove to run test")]
    public void Keep_strings()
    {
        var words = "apple zebra banana zombies cherimoya zelot".Split(' ');
        Assert.Equal("zebra zombies zelot".Split(' '), words.Keep(x => x.StartsWith("z")));
    }

    [Fact(Skip = "Remove to run test")]
    public void Keep_arrays()
    {
        var actual = new[]
            {
                new[] { 1, 2, 3 },
                new[] { 5, 5, 5 },
                new[] { 5, 1, 2 },
                new[] { 2, 1, 2 },
                new[] { 1, 5, 2 },
                new[] { 2, 2, 1 },
                new[] { 1, 2, 5 }
            };
        var expected = new[] { new[] { 5, 5, 5 }, new[] { 5, 1, 2 }, new[] { 1, 5, 2 }, new[] { 1, 2, 5 } };
        Assert.Equal(expected, actual.Keep(x => x.Contains(5)));
    }

    [Fact(Skip = "Remove to run test")]
    public void Empty_discard()
    {
        Assert.Equal(new LinkedList<int>(), new LinkedList<int>().Discard(x => x < 10));
    }

    [Fact(Skip = "Remove to run test")]
    public void Discard_nothing()
    {
        Assert.Equal(new HashSet<int> { 1, 2, 3 }, new HashSet<int> { 1, 2, 3 }.Discard(x => x > 10));
    }

    [Fact(Skip = "Remove to run test")]
    public void Discard_first_and_last()
    {
        Assert.Equal(new[] { 2 }, new[] { 1, 2, 3 }.Discard(x => x % 2 != 0));
    }

    [Fact(Skip = "Remove to run test")]
    public void Discard_neither_first_nor_last()
    {
        Assert.Equal(new List<int> { 1, 3, 5 }, new List<int> { 1, 2, 3, 4, 5 }.Discard(x => x % 2 == 0));
    }

    [Fact(Skip = "Remove to run test")]
    public void Discard_strings()
    {
        var words = "apple zebra banana zombies cherimoya zelot".Split(' ');
        Assert.Equal("apple banana cherimoya".Split(' '), words.Discard(x => x.StartsWith("z")));
    }

    [Fact(Skip = "Remove to run test")]
    public void Discard_arrays()
    {
        var actual = new[]
            {
                new[] { 1, 2, 3 },
                new[] { 5, 5, 5 },
                new[] { 5, 1, 2 },
                new[] { 2, 1, 2 },
                new[] { 1, 5, 2 },
                new[] { 2, 2, 1 },
                new[] { 1, 2, 5 }
            };
        var expected = new[] { new[] { 1, 2, 3 }, new[] { 2, 1, 2 }, new[] { 2, 2, 1 } };
        Assert.Equal(expected, actual.Discard(x => x.Contains(5)));
    }
}