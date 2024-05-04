using Xunit;

public class KnapsackTests
{
    [Fact]
    public void No_items()
    {
        Assert.Equal(0, Knapsack.MaximumValue(100, []));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void One_item_too_heavy()
    {
        (int weight, int value)[] items = [(weight: 100, value: 1)];
        Assert.Equal(0, Knapsack.MaximumValue(10, items));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Five_items_cannot_be_greedy_by_weight_()
    {
        (int weight, int value)[] items = [(weight: 2, value: 5), (weight: 2, value: 5), (weight: 2, value: 5), (weight: 2, value: 5), (weight: 10, value: 21)];
        Assert.Equal(21, Knapsack.MaximumValue(10, items));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Five_items_cannot_be_greedy_by_value_()
    {
        (int weight, int value)[] items = [(weight: 2, value: 20), (weight: 2, value: 20), (weight: 2, value: 20), (weight: 2, value: 20), (weight: 10, value: 50)];
        Assert.Equal(80, Knapsack.MaximumValue(10, items));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Example_knapsack()
    {
        (int weight, int value)[] items = [(weight: 5, value: 10), (weight: 4, value: 40), (weight: 6, value: 30), (weight: 4, value: 50)];
        Assert.Equal(90, Knapsack.MaximumValue(10, items));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Number_8_items()
    {
        (int weight, int value)[] items = [(weight: 25, value: 350), (weight: 35, value: 400), (weight: 45, value: 450), (weight: 5, value: 20), (weight: 25, value: 70), (weight: 3, value: 8), (weight: 2, value: 5), (weight: 2, value: 5)];
        Assert.Equal(900, Knapsack.MaximumValue(104, items));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Number_15_items()
    {
        (int weight, int value)[] items = [
            (weight: 70, value: 135), (weight: 73, value: 139), (weight: 77, value: 149), (weight: 80, value: 150),
            (weight: 82, value: 156), (weight: 87, value: 163), (weight: 90, value: 173), (weight: 94, value: 184),
            (weight: 98, value: 192), (weight: 106, value: 201), (weight: 110, value: 210),
            (weight: 113, value: 214), (weight: 115, value: 221), (weight: 118, value: 229),
            (weight: 120, value: 240)
        ];
        Assert.Equal(1458, Knapsack.MaximumValue(750, items));
    }
}
