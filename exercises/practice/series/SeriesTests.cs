using System;
using System.Linq;
using Xunit;

public class SeriesTests
{
    [Fact]
    public void Slices_of_one_from_one()
    {
        var expected = new[] { "1" };
        Assert.Equal(expected, Series.Slices("1", 1).ToArray());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Slices_of_one_from_two()
    {
        var expected = new[] { "1", "2" };
        Assert.Equal(expected, Series.Slices("12", 1).ToArray());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Slices_of_two()
    {
        var expected = new[] { "35" };
        Assert.Equal(expected, Series.Slices("35", 2).ToArray());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Slices_of_two_overlap()
    {
        var expected = new[] { "91", "14", "42" };
        Assert.Equal(expected, Series.Slices("9142", 2).ToArray());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Slices_can_include_duplicates()
    {
        var expected = new[] { "777", "777", "777", "777" };
        Assert.Equal(expected, Series.Slices("777777", 3).ToArray());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Slices_of_a_long_series()
    {
        var expected = new[] { "91849", "18493", "84939", "49390", "93904", "39042", "90424", "04243" };
        Assert.Equal(expected, Series.Slices("918493904243", 5).ToArray());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Slice_length_is_too_large()
    {
        Assert.Throws<ArgumentException>(() => Series.Slices("12345", 6).ToArray());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Slice_length_is_way_too_large()
    {
        Assert.Throws<ArgumentException>(() => Series.Slices("12345", 42).ToArray());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Slice_length_cannot_be_zero()
    {
        Assert.Throws<ArgumentException>(() => Series.Slices("12345", 0).ToArray());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Slice_length_cannot_be_negative()
    {
        Assert.Throws<ArgumentException>(() => Series.Slices("123", -1).ToArray());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Empty_series_is_invalid()
    {
        Assert.Throws<ArgumentException>(() => Series.Slices("", 1).ToArray());
    }
}