using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

public class FlattenArrayTest
{
    [Fact]
    public void Flattens_A_Nested_List()
    {
        var nestedList = new List<object> { new List<object>() };
        Assert.Empty(Flattener.Flatten(nestedList));
    }

    [Fact]
    public void Flattens_2_Level_Nested_List()
    {
        var nestedList = new List<object> { 1, new List<object> { 2, 3, 4 }, 5 };
        Assert.Equal(new List<int> { 1, 2, 3, 4, 5 }, Flattener.Flatten(nestedList).Cast<int>());
    }

    [Fact]
    public void Flattens_3_Level_Nested_List()
    {
        var nestedList = new List<object>
        {
            1,
            new List<object> { 2, 3, 4 },
            5,
            new List<object> { 6, new List<object> { 7, 8 } }
        };
        Assert.Equal(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 }, Flattener.Flatten(nestedList).Cast<int>());
    }

    [Fact]
    public void Flattens_5_Level_Nested_List()
    {
        var nestedList = new List<object>
        {
            0,
            2,
            new List<object>
            {
                new List<object> { 2, 3 },
                8,
                100,
                4,
                new List<object> { new List<object> { new List<object> { 50 } } },
                -2
            }
        };
        Assert.Equal(new List<int> { 0, 2, 2, 3, 8, 100, 4, 50, -2 }, Flattener.Flatten(nestedList).Cast<int>());
    }

    [Fact]
    public void Flattens_6_Level_Nested_List()
    {
        var nestedList = new List<object>
        {
            1,
            new List<object>
            {
                2,
                new List<object> { new List<object> { 3 } },
                new List<object> { 4, new List<object> { new List<object> { 5 } } },
                6,
                7
            },
            8
        };
        Assert.Equal(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 }, Flattener.Flatten(nestedList).Cast<int>());
    }

    [Fact]
    public void Flattens_6_Level_Nested_List_With_Nulls()
    {
        var nestedList = new List<object>
        {
            1,
            new List<object>
            {
                2,
                null,
                new List<object> { new List<object> { 3 }, null },
                new List<object> { 4, new List<object> { new List<object> { 5 } } },
                6,
                7,
                new List<object> { new List<object> { null } }
            },
            8,
            null
        };
        Assert.Equal(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 }, Flattener.Flatten(nestedList).Cast<int>());
    }

    [Fact]
    public void All_Null_Nested_List_Returns_Empty_List()
    {
        var nestedList = new List<object>
        {
            null,
            new List<object>
            {
                null,
                new List<object> { null },
                new List<object> { new List<object> { new List<object> { null } } }
            },
            null
        };
        Assert.Empty(Flattener.Flatten(nestedList));
    }
}