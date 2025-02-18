public class EtlTests
{
    [Fact]
    public void Single_letter()
    {
        var legacy = new Dictionary<int, string[]>
        {
            [1] = ["A"]
        };
        var expected = new Dictionary<string, int>
        {
            ["a"] = 1
        };
        Assert.Equal(expected, Etl.Transform(legacy));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Single_score_with_multiple_letters()
    {
        var legacy = new Dictionary<int, string[]>
        {
            [1] = ["A", "E", "I", "O", "U"]
        };
        var expected = new Dictionary<string, int>
        {
            ["a"] = 1,
            ["e"] = 1,
            ["i"] = 1,
            ["o"] = 1,
            ["u"] = 1
        };
        Assert.Equal(expected, Etl.Transform(legacy));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Multiple_scores_with_multiple_letters()
    {
        var legacy = new Dictionary<int, string[]>
        {
            [1] = ["A", "E"],
            [2] = ["D", "G"]
        };
        var expected = new Dictionary<string, int>
        {
            ["a"] = 1,
            ["d"] = 2,
            ["e"] = 1,
            ["g"] = 2
        };
        Assert.Equal(expected, Etl.Transform(legacy));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Multiple_scores_with_differing_numbers_of_letters()
    {
        var legacy = new Dictionary<int, string[]>
        {
            [1] = ["A", "E", "I", "O", "U", "L", "N", "R", "S", "T"],
            [2] = ["D", "G"],
            [3] = ["B", "C", "M", "P"],
            [4] = ["F", "H", "V", "W", "Y"],
            [5] = ["K"],
            [8] = ["J", "X"],
            [10] = ["Q", "Z"]
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
        Assert.Equal(expected, Etl.Transform(legacy));
    }
}
