using System;
using Xunit;

public class SeriesTest
{
    public static readonly TheoryData<string, int[][]> SliceOneTestData = new TheoryData<string, int[][]>
        {
            { "01234", new[] { new[] { 0 }, new[] { 1 }, new[] { 2 }, new[] { 3 }, new[] { 4 } } },
            { "92834", new[] { new[] { 9 }, new[] { 2 }, new[] { 8 }, new[] { 3 }, new[] { 4 } } }
        };

    [Theory]
    [MemberData(nameof(SliceOneTestData))]
    public void Series_of_one_splits_to_one_digit(string input, int[][] result)
    {
        Assert.Equal(result, new Series(input).Slices(1));
    }

    public static readonly TheoryData<string, int[][]> SliceTwoTestData = new TheoryData<string, int[][]>
        {
            { "01234", new[] { new[] { 0, 1 }, new[] { 1, 2 }, new[] { 2, 3 }, new[] { 3, 4 } } },
            { "98273463", new[] { new[] { 9, 8 }, new[] { 8, 2 }, new[] { 2, 7 }, new[] { 7, 3 }, new[] { 3, 4 }, new[] { 4, 6 }, new[] { 6, 3 } } },
            { "37103", new[] { new[] { 3, 7 }, new[] { 7, 1 }, new[] { 1, 0 }, new[] { 0, 3 } } }
        };

    [Theory(Skip = "Remove to run test")]
    [MemberData(nameof(SliceTwoTestData))]
    public void Series_of_two_splits_to_two_digits(string input, int[][] result)
    {
        Assert.Equal(result, new Series(input).Slices(2));
    }

    public static readonly TheoryData<string, int[][]> SliceThreeTestData = new TheoryData<string, int[][]>
        {
            { "01234", new[] { new[] { 0, 1, 2 }, new[] { 1, 2, 3 }, new[] { 2, 3, 4 } } },
            { "31001", new[] { new[] { 3, 1, 0 }, new[] { 1, 0, 0 }, new[] { 0, 0, 1 } } },
            { "982347", new[] { new[] { 9, 8, 2 }, new[] { 8, 2, 3 }, new[] { 2, 3, 4 }, new[] { 3, 4, 7 } } }
        };

    [Theory(Skip = "Remove to run test")]
    [MemberData(nameof(SliceThreeTestData))]
    public void Series_of_three_splits_to_three_digits(string input, int[][] result)
    {
        Assert.Equal(result, new Series(input).Slices(3));
    }

    public static readonly TheoryData<string, int[][]> SliceFourTestData = new TheoryData<string, int[][]>
        {
            { "01234", new[] { new[] { 0, 1, 2, 3 }, new[] { 1, 2, 3, 4 } } },
            { "91274", new[] { new[] { 9, 1, 2, 7 }, new[] { 1, 2, 7, 4 } } }
        };

    [Theory(Skip = "Remove to run test")]
    [MemberData(nameof(SliceFourTestData))]
    public void Series_of_four_splits_to_four_digits(string input, int[][] result)
    {
        Assert.Equal(result, new Series(input).Slices(4));
    }

    public static readonly TheoryData<string, int[][]> SliceFiveTestData = new TheoryData<string, int[][]>
        {
            { "01234", new[] { new[] { 0, 1, 2, 3, 4 } } },
            { "81228", new[] { new[] { 8, 1, 2, 2, 8 } } }
        };

    [Theory(Skip = "Remove to run test")]
    [MemberData(nameof(SliceFiveTestData))]
    public void Series_of_five_splits_to_five_digits(string input, int[][] result)
    {
        Assert.Equal(result, new Series(input).Slices(5));
    }

    [Theory(Skip = "Remove to run test")]
    [InlineData("01234", 6)]
    [InlineData("01032987583", 19)]
    public void Slice_longer_than_input_is_not_allowed(string input, int slice)
    {
        Assert.Throws<ArgumentException>(() => new Series(input).Slices(slice));
    }
}