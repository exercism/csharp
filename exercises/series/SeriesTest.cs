using NUnit.Framework;

[TestFixture]
public class SeriesTest
{
    private static readonly object[] SliceOneTestData =
        {
            new object[] { "01234", new[] { new[] { 0 }, new[] { 1 }, new[] { 2 }, new[] { 3 }, new[] { 4 } } },
            new object[] { "92834", new[] { new[] { 9 }, new[] { 2 }, new[] { 8 }, new[] { 3 }, new[] { 4 } } }
        };

    [TestCaseSource("SliceOneTestData")]
    public void Series_of_one_splits_to_one_digit(string input, int[][] result)
    {
        Assert.That(new Series(input).Slices(1), Is.EqualTo(result));
    }

    private static readonly object[] SliceTwoTestData =
        {
            new object[] { "01234", new[] { new[] { 0, 1 }, new[] { 1, 2 }, new[] { 2, 3 }, new[] { 3, 4 } } },
            new object[] { "98273463", new[] { new[] { 9, 8 }, new[] { 8, 2 }, new[] { 2, 7 }, new[] { 7, 3 }, new[] { 3, 4 }, new[] { 4, 6 }, new[] { 6, 3 } } },
            new object[] { "37103", new[] { new[] { 3, 7 }, new[] { 7, 1 }, new[] { 1, 0 }, new[] { 0, 3 } } }
        };

    [Ignore("Remove to run test")]
    [TestCaseSource("SliceTwoTestData")]
    public void Series_of_two_splits_to_two_digits(string input, int[][] result)
    {
        Assert.That(new Series(input).Slices(2), Is.EqualTo(result));
    }

    private static readonly object[] SliceThreeTestData =
        {
            new object[] { "01234", new[] { new[] { 0, 1, 2 }, new[] { 1, 2, 3 }, new[] { 2, 3, 4 } } },
            new object[] { "31001", new[] { new[] { 3, 1, 0 }, new[] { 1, 0, 0 }, new[] { 0, 0, 1 } } },
            new object[] { "982347", new[] { new[] { 9, 8, 2 }, new[] { 8, 2, 3 }, new[] { 2, 3, 4 }, new[] { 3, 4, 7 } } }
        };

    [Ignore("Remove to run test")]
    [TestCaseSource("SliceThreeTestData")]
    public void Series_of_three_splits_to_three_digits(string input, int[][] result)
    {
        Assert.That(new Series(input).Slices(3), Is.EqualTo(result));
    }

    private static readonly object[] SliceFourTestData =
        {
            new object[] { "01234", new[] { new[] { 0, 1, 2, 3 }, new[] { 1, 2, 3, 4 } } },
            new object[] { "91274", new[] { new[] { 9, 1, 2, 7 }, new[] { 1, 2, 7, 4 } } }
        };

    [Ignore("Remove to run test")]
    [TestCaseSource("SliceFourTestData")]
    public void Series_of_four_splits_to_four_digits(string input, int[][] result)
    {
        Assert.That(new Series(input).Slices(4), Is.EqualTo(result));
    }

    private static readonly object[] SliceFiveTestData =
        {
            new object[] { "01234", new[] { new[] { 0, 1, 2, 3, 4 } } },
            new object[] { "81228", new[] { new[] { 8, 1, 2, 2, 8 } } }
        };

    [Ignore("Remove to run test")]
    [TestCaseSource("SliceFiveTestData")]
    public void Series_of_five_splits_to_five_digits(string input, int[][] result)
    {
        Assert.That(new Series(input).Slices(5), Is.EqualTo(result));
    }

    [Ignore("Remove to run test")]
    [TestCase("01234", 6)]
    [TestCase("01032987583", 19)]
    public void Slice_longer_than_input_is_not_allowed(string input, int slice)
    {
        Assert.That(() => new Series(input).Slices(slice), Throws.ArgumentException);
    }
}