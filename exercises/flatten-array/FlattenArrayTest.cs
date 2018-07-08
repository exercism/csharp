// This file was auto-generated based on version 1.2.0 of the canonical data.

using Xunit;

public class FlattenArrayTest
{
    [Fact]
    public void No_nesting()
    {
        var array = new object[]
        {
            0,
            1,
            2
        };
        var expected = new[] { 0, 1, 2 };
        Assert.Equal(expected, FlattenArray.Flatten(array));
    }

    [Fact(Skip = "Remove to run test")]
    public void Flattens_array_with_just_integers_present()
    {
        var array = new object[]
        {
            1,
            new object[] { 2, 3, 4, 5, 6, 7 },
            8
        };
        var expected = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };
        Assert.Equal(expected, FlattenArray.Flatten(array));
    }

    [Fact(Skip = "Remove to run test")]
    public void Number_5_level_nesting()
    {
        var array = new object[]
        {
            0,
            2,
            new object[] { new object[] { 2, 3 }, 8, 100, 4, new object[] { new object[] { new object[] { 50 } } } },
            -2
        };
        var expected = new[] { 0, 2, 2, 3, 8, 100, 4, 50, -2 };
        Assert.Equal(expected, FlattenArray.Flatten(array));
    }

    [Fact(Skip = "Remove to run test")]
    public void Number_6_level_nesting()
    {
        var array = new object[]
        {
            1,
            new object[] { 2, new object[] { new object[] { 3 } }, new object[] { 4, new object[] { new object[] { 5 } } }, 6, 7 },
            8
        };
        var expected = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };
        Assert.Equal(expected, FlattenArray.Flatten(array));
    }

    [Fact(Skip = "Remove to run test")]
    public void Number_6_level_nest_list_with_null_values()
    {
        var array = new object[]
        {
            0,
            2,
            new object[] { new object[] { 2, 3 }, 8, new object[] { new object[] { 100 } }, null, new object[] { new object[] { null } } },
            -2
        };
        var expected = new[] { 0, 2, 2, 3, 8, 100, -2 };
        Assert.Equal(expected, FlattenArray.Flatten(array));
    }

    [Fact(Skip = "Remove to run test")]
    public void All_values_in_nested_list_are_null()
    {
        var array = new object[]
        {
            null,
            new object[] { new object[] { new object[] { null } } },
            null,
            null,
            new object[] { new object[] { null, null }, null },
            null
        };
        Assert.Empty(FlattenArray.Flatten(array));
    }
}