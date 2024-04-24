using System;
using Xunit;

public class FlattenArrayTests
{
    [Fact]
    public void Empty()
    {
        var array = Array.Empty<object>();
        Assert.Empty(FlattenArray.Flatten(array));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
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

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Flattens_a_nested_array()
    {
        var array = new object[]
        {
            new object[] { Array.Empty<object>() }
        };
        Assert.Empty(FlattenArray.Flatten(array));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
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

    [Fact(Skip = "Remove this Skip property to run this test")]
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

    [Fact(Skip = "Remove this Skip property to run this test")]
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

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Null_values_are_omitted_from_the_final_result()
    {
        var array = new object[]
        {
            1,
            2,
            null
        };
        var expected = new[] { 1, 2 };
        Assert.Equal(expected, FlattenArray.Flatten(array));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Consecutive_null_values_at_the_front_of_the_list_are_omitted_from_the_final_result()
    {
        var array = new object[]
        {
            null,
            null,
            3
        };
        var expected = new[] { 3 };
        Assert.Equal(expected, FlattenArray.Flatten(array));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Consecutive_null_values_in_the_middle_of_the_list_are_omitted_from_the_final_result()
    {
        var array = new object[]
        {
            1,
            null,
            null,
            4
        };
        var expected = new[] { 1, 4 };
        Assert.Equal(expected, FlattenArray.Flatten(array));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
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

    [Fact(Skip = "Remove this Skip property to run this test")]
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
