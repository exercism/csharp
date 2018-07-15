// This file was auto-generated based on version 1.0.0 of the canonical data.

using System.Collections.Generic;
using Xunit;

public class EtlTest
{
    [Fact]
    public void A_single_letter()
    {
        var input = new Dictionary<int, string[]>
        {
            [1] = new[] { "A" }
        };
        var expected = new Dictionary<string, int>
        {
            ["a"] = 1
        };
        Assert.Equal(expected, Etl.Transform(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Single_score_with_multiple_letters()
    {
        var input = new Dictionary<int, string[]>
        {
            [1] = new[] { "A", "E", "I", "O", "U" }
        };
        var expected = new Dictionary<string, int>
        {
            ["a"] = 1,
            ["e"] = 1,
            ["i"] = 1,
            ["o"] = 1,
            ["u"] = 1
        };
        Assert.Equal(expected, Etl.Transform(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Multiple_scores_with_multiple_letters()
    {
        var input = new Dictionary<int, string[]>
        {
            [1] = new[] { "A", "E" },
            [2] = new[] { "D", "G" }
        };
        var expected = new Dictionary<string, int>
        {
            ["a"] = 1,
            ["d"] = 2,
            ["e"] = 1,
            ["g"] = 2
        };
        Assert.Equal(expected, Etl.Transform(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Multiple_scores_with_differing_numbers_of_letters()
    {
        var input = new Dictionary<int, string[]>
        {
            [1] = new[] { "A", "E", "I", "O", "U", "L", "N", "R", "S", "T" },
            [2] = new[] { "D", "G" },
            [3] = new[] { "B", "C", "M", "P" },
            [4] = new[] { "F", "H", "V", "W", "Y" },
            [5] = new[] { "K" },
            [8] = new[] { "J", "X" },
            [10] = new[] { "Q", "Z" }
        };
        var expected = new Dictionary<string, int>
        {
            ["a"] = 1,
            ["b"] = 3,
            ["c"] = 3,
            ["d"] = 2,
            ["e"] = 1,
            ["f"] = 4,
            ["g"] = 2,
            ["h"] = 4,
            ["i"] = 1,
            ["j"] = 8,
            ["k"] = 5,
            ["l"] = 1,
            ["m"] = 3,
            ["n"] = 1,
            ["o"] = 1,
            ["p"] = 3,
            ["q"] = 10,
            ["r"] = 1,
            ["s"] = 1,
            ["t"] = 1,
            ["u"] = 1,
            ["v"] = 4,
            ["w"] = 4,
            ["x"] = 8,
            ["y"] = 4,
            ["z"] = 10
        };
        Assert.Equal(expected, Etl.Transform(input));
    }
}