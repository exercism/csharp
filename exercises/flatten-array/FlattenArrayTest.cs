using System.Collections.Generic;
using Xunit;

public class FlattenArrayTest
{
    [Fact]
    public void Flattens_A_Nested_List()
    {
        var nestedList = new List<object> { new List<object>() };
        Assert.That(Flattener.Flatten(nestedList), Is.Empty);
    }

    [Fact(Skip="Remove to run test")]
    public void Flattens_2_Level_Nested_List()
    {
        var nestedList = new List<object> { 1, new List<object> { 2, 3, 4 }, 5 };
        Assert.That(Flattener.Flatten(nestedList), Is.EquivalentTo(new List<object> { 1, 2, 3, 4, 5 }));
    }

    [Fact(Skip="Remove to run test")]
    public void Flattens_3_Level_Nested_List()
    {
        var nestedList = new List<object>
        {
            1,
            new List<object> { 2, 3, 4 },
            5,
            new List<object> { 6, new List<object> { 7, 8 } }
        };
        Assert.That(Flattener.Flatten(nestedList), Is.EquivalentTo(new List<object> { 1, 2, 3, 4, 5, 6, 7, 8 }));
    }

    [Fact(Skip="Remove to run test")]
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
        Assert.That(Flattener.Flatten(nestedList), Is.EquivalentTo(new List<object> { 0, 2, 2, 3, 8, 100, 4, 50, -2 }));
    }

    [Fact(Skip="Remove to run test")]
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
        Assert.That(Flattener.Flatten(nestedList), Is.EquivalentTo(new List<object> { 1, 2, 3, 4, 5, 6, 7, 8 }));
    }

    [Fact(Skip="Remove to run test")]
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
        Assert.That(Flattener.Flatten(nestedList), Is.EquivalentTo(new List<object> { 1, 2, 3, 4, 5, 6, 7, 8 }));
    }

    [Fact(Skip="Remove to run test")]
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
        Assert.That(Flattener.Flatten(nestedList), Is.Empty);
    }
}