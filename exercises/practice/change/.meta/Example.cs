using System;
using System.Collections.Generic;
using System.Linq;

public static class Change
{
    public static int[] FindFewestCoins(int[] coins, int target)
    {
        if (target < 0)
        {
            throw new ArgumentException("Target amount cannot be negative.");
        }
        if (target > 0 && target < coins.Min())
        {
            throw new ArgumentException("Target amount cannot be less than minimal coin value.");
        }

        var minimalCoinsMapSeed = new Dictionary<int, List<int>>
        {
            [0] = new List<int>(0)
        };

        var minimalCoinsMap = Enumerable.Range(1, target)
            .Aggregate(minimalCoinsMapSeed, UpdateMinimalCoinsMap);

        if (minimalCoinsMap.TryGetValue(target, out var minimalCoins))
            return minimalCoins.OrderBy(x => x).ToArray();
        
        throw new ArgumentException();

        Dictionary<int, List<int>> UpdateMinimalCoinsMap(Dictionary<int, List<int>> current, int subTarget)
        {
            var subTargetMinimalCoins = MinimalCoins(current, subTarget);
            if (subTargetMinimalCoins != null)
                current.Add(subTarget, subTargetMinimalCoins);

            return current;
        }

        List<int> MinimalCoins(Dictionary<int, List<int>> current, int subTarget)
        {
            return coins
                .Where(coin => coin <= subTarget)
                .Select(coin => current.TryGetValue(subTarget - coin, out var subTargetMinimalCoins)
                    ? subTargetMinimalCoins.Append(coin).ToList()
                    : null)
                .Where(subTargetMinimalCoins => subTargetMinimalCoins != null)
                .OrderBy(subTargetMinimalCoins => subTargetMinimalCoins.Count)
                .FirstOrDefault();
        }
    }
}