using System;
using System.Collections.Generic;
using System.Linq;

public static class PalindromeProducts
{
    public static (int, IEnumerable<(int,int)>) Smallest(int minFactor, int maxFactor)
    {
        if (minFactor > maxFactor) throw new ArgumentException();

        var smallestPalindromeProduct = int.MaxValue;
        var smallestPalindromeProductFactors = new List<(int, int)>();

        foreach (var (x, y) in Pairs(minFactor, maxFactor))
        {
            var product = x * y;
            
            if (product > smallestPalindromeProduct || !IsPalindrome(product))
                continue;

            if (product < smallestPalindromeProduct)
                smallestPalindromeProductFactors.Clear();
            
            smallestPalindromeProductFactors.Add((x, y));
            smallestPalindromeProduct = product;
        }

        if (smallestPalindromeProduct == int.MaxValue) throw new ArgumentException();

        return (smallestPalindromeProduct, smallestPalindromeProductFactors);
    }
    
    public static (int, IEnumerable<(int,int)>) Largest(int minFactor, int maxFactor)
    {
        if (minFactor > maxFactor) throw new ArgumentException();

        var largestPalindromeProduct = int.MinValue;
        var largestPalindromeProductFactors = new List<(int, int)>();

        foreach (var (x, y) in Pairs(minFactor, maxFactor).Reverse())
        {
            var product = x * y;
            
            if (product < largestPalindromeProduct || !IsPalindrome(product))
                continue;

            if (product > largestPalindromeProduct)
                largestPalindromeProductFactors.Clear();
            
            largestPalindromeProductFactors.Add((x, y));
            largestPalindromeProduct = product;
        }

        if (largestPalindromeProduct == int.MinValue) throw new ArgumentException();

        largestPalindromeProductFactors.Reverse();

        return (largestPalindromeProduct, largestPalindromeProductFactors);
    }

    private static IEnumerable<(int, int)> Pairs(int minFactor, int maxFactor) 
        => from x in Enumerable.Range(minFactor, maxFactor + 1 - minFactor)
           from y in Enumerable.Range(x, maxFactor + 1 - x)
           select (x, y);

    private static bool IsPalindrome(int num)
    {
        var n = num;
        var rev = 0;

        while (num > 0)
        {
            var dig = num % 10;
            rev = rev * 10 + dig;
            num = num / 10;
        }

        return n == rev;
    }
}
