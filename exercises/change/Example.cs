using System;
using System.Linq;

public static class Change
{
    public static int[] Calculate(int target, int[] coins)
    {
        if (target < 0)
        {
            throw new ArgumentException("Target amount cannot be negative.");
        }
        if (target > 0 && target < coins.Min())
        {
            throw new ArgumentException("Target amount cannot be less than minimal coin value.");
        }

        var minimalCoins = new int[target + 1][];
        minimalCoins[0] = new int[0];

        for (var amount = 1; amount <= target; amount++)
        {
            minimalCoins[amount] = coins.Where(c => c <= amount)
                                       .Select(c => Prepend(c, minimalCoins[amount - c]))
                                       .OrderBy(c => c.Length)
                                       .FirstOrDefault() ?? new int[0];
        }

        return minimalCoins[target];
    }

    private static int[] Prepend(int coin, int[] coins)
    {
        var newCoins = new int[coins.Length + 1];
        newCoins[0] = coin;
        Array.Copy(coins, 0, newCoins, 1, coins.Length);

        return newCoins;
    }
}