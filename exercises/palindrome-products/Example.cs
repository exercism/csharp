using System;
using System.Collections.Generic;
using System.Linq;

public class Palindrome
{
    private Palindrome(int value, ISet<Tuple<int, int>> factors)
    {
        Value = value;
        Factors = factors;
    }

    public int Value { get; }

    public ISet<Tuple<int, int>> Factors { get; }

    public static Palindrome Largest(int maxFactor)
    {
        return Largest(1, maxFactor);
    }

    public static Palindrome Largest(int minFactor, int maxFactor)
    {
        return FindPalindrome(minFactor, maxFactor, x => x.Max(p => p.Item1));
    }

    public static Palindrome Smallest(int maxFactor)
    {
        return Smallest(1, maxFactor);
    }

    public static Palindrome Smallest(int minFactor, int maxFactor)
    {
        return FindPalindrome(minFactor, maxFactor, x => x.Min(p => p.Item1));
    }
    
    private static Palindrome FindPalindrome(int minFactor, int maxFactor, Func<List<Tuple<int, Tuple<int, int>>>, int> valueSelector)
    {
        var palindromes = FindAllPalindromes(minFactor, maxFactor);
        var value = valueSelector(palindromes);
        var factors = new HashSet<Tuple<int, int>>(palindromes.Where(p => p.Item1 == value).Select(p => p.Item2));

        return new Palindrome(value, factors);
    }

    private static List<Tuple<int, Tuple<int, int>>> FindAllPalindromes(int minFactor, int maxFactor)
    {
        return (from pair in Pairs(minFactor, maxFactor)
                let product = pair.Item1 * pair.Item2
                where IsPalindrome(product)
                select Tuple.Create(product, pair))
                .ToList();
    }

    private static IEnumerable<Tuple<int, int>> Pairs(int minFactor, int maxFactor)
    {
        return from x in Enumerable.Range(minFactor, maxFactor + 1 - minFactor)
               from y in Enumerable.Range(x, maxFactor + 1 - x)
               select Tuple.Create(x, y);
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
