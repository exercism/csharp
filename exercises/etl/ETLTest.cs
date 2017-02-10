using System.Collections.Generic;
using Xunit;

public class ETLTest
{
    [Fact]
    public void Transforms_one_value()
    {
        var old = new Dictionary<int, IList<string>> { { 1, new List<string> { "A" } } };
        var expected = new Dictionary<string, int> { { "a", 1 } };
        Assert.Equal(expected, ETL.Transform(old));
    }

    [Fact(Skip = "Remove to run test")]
    public void Transforms_multiple_values()
    {
        var old = new Dictionary<int, IList<string>> { { 1, new List<string> { "A", "E", "I", "O", "U" } } };
        var expected = new Dictionary<string, int> { { "a", 1 }, { "e", 1 }, { "i", 1 }, { "o", 1 }, { "u", 1 } };
        Assert.Equal(expected, ETL.Transform(old));
    }

    [Fact(Skip = "Remove to run test")]
    public void Transforms_multiple_keys()
    {
        var old = new Dictionary<int, IList<string>> { { 1, new List<string> { "A", "E" } }, { 2, new List<string> { "D", "G" } } };
        var expected = new Dictionary<string, int> { { "a", 1 }, { "e", 1 }, { "d", 2 }, { "g", 2 } };
        Assert.Equal(expected, ETL.Transform(old));
    }

    [Fact(Skip = "Remove to run test")]
    public void Transforms_a_full_dataset()
    {
        var old = new Dictionary<int, IList<string>>
        {
            { 1, new List<string> { "A", "E", "I", "O", "U", "L", "N", "R", "S", "T" } },
            { 2, new List<string> { "D", "G" } },
            { 3, new List<string> { "B", "C", "M", "P" } },
            { 4, new List<string> { "F", "H", "V", "W", "Y" } },
            { 5, new List<string> { "K" } },
            { 8, new List<string> { "J", "X" } },
            { 10, new List<string> { "Q", "Z" } },
        };
        var expected = new Dictionary<string, int>
        {
            { "a", 1 }, { "b", 3 }, { "c", 3 }, { "d", 2 }, { "e", 1 }, { "f", 4 }, { "g", 2 }, { "h", 4 }, { "i", 1 },
            { "j", 8 }, { "k", 5 }, { "l", 1 }, { "m", 3 }, { "n", 1 }, { "o", 1 }, { "p", 3 }, { "q", 10 }, { "r", 1 },
            { "s", 1 }, { "t", 1 }, { "u", 1 }, { "v", 4 }, { "w", 4 }, { "x", 8 }, { "y", 4 }, { "z", 10 }
        };
        Assert.Equal(expected, ETL.Transform(old));
    }
}