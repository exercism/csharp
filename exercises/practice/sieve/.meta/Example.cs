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
        if (limit < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(limit));
        }

        var primes = new List<int>();
        if (limit == 0 || limit == 1) return primes.ToArray();

        var candidates = new Queue<int>(Enumerable.Range(2, limit - 1));
        do
        {
            var prime = candidates.Dequeue();
            primes.Add(prime);
            candidates = new Queue<int>(candidates.Where(x => x % prime != 0));
        } while (candidates.Any());
        return primes.ToArray();
    }
}