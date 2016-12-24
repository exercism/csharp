using System;
using System.Collections.Generic;
using System.Linq;

public class BookStore
{
    public static double CalculateTotalCost(List<int> books)
    {
        return CalculateTotalCost(books, 0);
    }

    private static double CalculateTotalCost(List<int> books, double priceSoFar)
    {
        if (books.Count == 0)
        {
            return priceSoFar;
        }

        var groups = books
            .GroupBy(b => b)
            .Select(g => g.Key)
            .ToList();

        var minPrice = double.MaxValue;

        for (int i = groups.Count; i >= 1; i--)
        {
            var itemsToRemove = groups.Take(i).ToList();
            var remaining = books.ToList();

            foreach (var item in itemsToRemove)
            {
                remaining.Remove(item);
            }

            var price = CalculateTotalCost(remaining.ToList(), priceSoFar + CostPerGroup(i));
            minPrice = Math.Min(minPrice, price);
        }

        return minPrice;
    }

    private static double CostPerGroup(int groupSize)
    {
        double discountPercentage;

        switch (groupSize)
        {
            case 1:
                discountPercentage = 0;
                break;
            case 2:
                discountPercentage = 5;
                break;
            case 3:
                discountPercentage = 10;
                break;
            case 4:
                discountPercentage = 20;
                break;
            case 5:
                discountPercentage = 25;
                break;
            default:
                throw new InvalidOperationException($"Invalid group size: {groupSize}");
        }
        
        return 8 * groupSize * (100 - discountPercentage) / 100;
    }
}