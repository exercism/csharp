public class StrainTests
{
    [Fact]
    public void Keep_on_empty_list_returns_empty_list()
    {
        int[] expected = [];
        int[] input = [];
        Assert.Equal(expected, input.Keep(x => true).ToArray());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Keeps_everything()
    {
        int[] expected = [1, 3, 5];
        int[] input = [1, 3, 5];
        Assert.Equal(expected, input.Keep(x => true).ToArray());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Keeps_nothing()
    {
        int[] expected = [];
        int[] input = [1, 3, 5];
        Assert.Equal(expected, input.Keep(x => false).ToArray());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Keeps_first_and_last()
    {
        int[] expected = [1, 3];
        int[] input = [1, 2, 3];
        Assert.Equal(expected, input.Keep(x => x % 2 == 1).ToArray());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Keeps_neither_first_nor_last()
    {
        int[] expected = [2];
        int[] input = [1, 2, 3];
        Assert.Equal(expected, input.Keep(x => x % 2 == 0).ToArray());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Keeps_strings()
    {
        string[] expected = ["zebra", "zombies", "zealot"];
        string[] input = ["apple", "zebra", "banana", "zombies", "cherimoya", "zealot"];
        Assert.Equal(expected, input.Keep(x => x.StartsWith('z')).ToArray());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Keeps_lists()
    {
        int[][] expected = [[5, 5, 5], [5, 1, 2], [1, 5, 2], [1, 2, 5]];
        int[][] input = [[1, 2, 3], [5, 5, 5], [5, 1, 2], [2, 1, 2], [1, 5, 2], [2, 2, 1], [1, 2, 5]];
        Assert.Equal(expected, input.Keep(x => x.Contains(5)).ToArray());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Discard_on_empty_list_returns_empty_list()
    {
        int[] expected = [];
        int[] input = [];
        Assert.Equal(expected, input.Discard(x => true).ToArray());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Discards_everything()
    {
        int[] expected = [];
        int[] input = [1, 3, 5];
        Assert.Equal(expected, input.Discard(x => true).ToArray());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Discards_nothing()
    {
        int[] expected = [1, 3, 5];
        int[] input = [1, 3, 5];
        Assert.Equal(expected, input.Discard(x => false).ToArray());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Discards_first_and_last()
    {
        int[] expected = [2];
        int[] input = [1, 2, 3];
        Assert.Equal(expected, input.Discard(x => x % 2 == 1).ToArray());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Discards_neither_first_nor_last()
    {
        int[] expected = [1, 3];
        int[] input = [1, 2, 3];
        Assert.Equal(expected, input.Discard(x => x % 2 == 0).ToArray());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Discards_strings()
    {
        string[] expected = ["apple", "banana", "cherimoya"];
        string[] input = ["apple", "zebra", "banana", "zombies", "cherimoya", "zealot"];
        Assert.Equal(expected, input.Discard(x => x.StartsWith('z')).ToArray());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Discards_lists()
    {
        int[][] expected = [[1, 2, 3], [2, 1, 2], [2, 2, 1]];
        int[][] input = [[1, 2, 3], [5, 5, 5], [5, 1, 2], [2, 1, 2], [1, 5, 2], [2, 2, 1], [1, 2, 5]];
        Assert.Equal(expected, input.Discard(x => x.Contains(5)).ToArray());
    }
}
