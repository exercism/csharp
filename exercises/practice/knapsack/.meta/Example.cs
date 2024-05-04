public static class Knapsack
{
    public static int MaximumValue(int maximumWeight, (int weight, int value)[] items)
    {
        var maxWeightForSize = new int[items.Length + 1, maximumWeight + 1];

        for (var item = 1; item <= items.Length; item++)
        {
            for (var capacity = 1; capacity <= maximumWeight; capacity++)
            {
                var maxWithCurrent = 
                    capacity >= items[item - 1].weight
                        ? maxWeightForSize[item - 1, capacity - items[item - 1].weight] + items[item - 1].value
                        : 0;

                maxWeightForSize[item, capacity] = Math.Max(maxWeightForSize[item - 1, capacity], maxWithCurrent);
            }
        }

        return maxWeightForSize[items.Length, maximumWeight];
    }
}
