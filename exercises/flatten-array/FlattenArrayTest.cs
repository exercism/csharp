// This file was auto-generated based on version 1.1.0 of the canonical data.

using Xunit;

public class FlattenArrayTest
{
    [Fact]
    public void No_nesting()
    {
        Assert.Equal(new[] { 0, 1, 2 }, FlattenArray.Flatten(new[] { 0, 1, 2 }));
    }

    [Fact(Skip = "Remove to run test")]
    public void Flattens_array_with_just_integers_present()
    {
        Assert.Equal(new[] { 1, 2, 3, 4, 5, 6, 7, 8 }, FlattenArray.Flatten(new[] { 1, new[] { 2, 3, 4, 5, 6, 7 }, 8 }));
    }

    [Fact(Skip = "Remove to run test")]
    public void Number_5_level_nesting()
    {
        Assert.Equal(new[] { 0, 2, 2, 3, 8, 100, 4, 50, -2 }, FlattenArray.Flatten(new[] { 0, 2, new[] { new[] { 2, 3 }, 8, 100, 4, new[] { new[] { new[] { 50 } } } }, -2 }));
    }

    [Fact(Skip = "Remove to run test")]
    public void Number_6_level_nesting()
    {
        Assert.Equal(new[] { 1, 2, 3, 4, 5, 6, 7, 8 }, FlattenArray.Flatten(new[] { 1, new[] { 2, new[] { new[] { 3 } }, new[] { 4, new[] { new[] { 5 } } }, 6, 7 }, 8 }));
    }

    [Fact(Skip = "Remove to run test")]
    public void Number_6_level_nest_list_with_null_values()
    {
        Assert.Equal(new[] { 0, 2, 2, 3, 8, 100, -2 }, FlattenArray.Flatten(new[] { 0, 2, new[] { new[] { 2, 3 }, 8, new[] { new[] { 100 } }, , new[] { new[] {  } } }, -2 }));
    }

    [Fact(Skip = "Remove to run test")]
    public void All_values_in_nested_list_are_null()
    {
        Assert.Empty(FlattenArray.Flatten(new[] { , new[] { new[] { new[] {  } } }, , , new[] { new[] { ,  },  },  }));
    }
}