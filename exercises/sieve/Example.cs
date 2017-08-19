using System;
using System.Collections.Generic;
using System.Linq;

public class Sieve
{
    public static int[] Primes(int limit)
    {
        return InitializePrimes(limit);
    }

    private static int[] InitializePrimes(int limit)
    {
        if (limit < 2)
        {
            throw new ArgumentOutOfRangeException(nameof(limit));
        }

        var candidates = new Queue<int>(Enumerable.Range(2, limit - 1));
        var primes = new List<int>();
        do
        {
            var prime = candidates.Dequeue();
            primes.Add(prime);
            candidates = new Queue<int>(candidates.Where(x => x % prime != 0));
        } while (candidates.Any());
        return primes.ToArray();
    }
}