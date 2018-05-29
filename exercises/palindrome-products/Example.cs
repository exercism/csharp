using System;
using System.Collections.Generic;
using System.Linq;

public static class PalindromeProducts
{
    public static (int, IEnumerable<(int,int)>) Largest(int minFactor, int maxFactor)
    {
        return FindPalindrome(minFactor, maxFactor, x => x.Max(p => p.Item1));
    }

    public static (int, IEnumerable<(int,int)>) Smallest(int minFactor, int maxFactor)
    {
        return FindPalindrome(minFactor, maxFactor, x => x.Min(p => p.Item1));
    }

    private static (int, IEnumerable<(int, int)>) FindPalindrome(int minFactor, int maxFactor,
        Func<List<(int, (int, int))>, int> valueSelector)
    {
        if (minFactor > maxFactor || maxFactor < minFactor)
        {
            throw new ArgumentException();    
        }
        
        try
        {
            var palindromes = FindAllPalindromes(minFactor, maxFactor);
            var value = valueSelector(palindromes);
            var factors = new HashSet<(int, int)>(palindromes.Where(p => p.Item1 == value).Select(p => p.Item2));
            return (value, factors);
        } catch (InvalidOperationException)
        {
            throw new ArgumentException();
        }
    }

    private static List<(int, (int, int))> FindAllPalindromes(int minFactor, int maxFactor)
    {
        return (from pair in Pairs(minFactor, maxFactor)
                let product = pair.Item1 * pair.Item2
                where IsPalindrome(product)
                select (product, pair))
                .ToList();
    }

    private static IEnumerable<(int, int)> Pairs(int minFactor, int maxFactor)
    {
        return from x in Enumerable.Range(minFactor, maxFactor + 1 - minFactor)
               from y in Enumerable.Range(x, maxFactor + 1 - x)
               select (x, y);
    }

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
