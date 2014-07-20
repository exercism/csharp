using System.Collections.Generic;
using System.Linq;

public class Sieve
{
    private readonly int limit;
    public int[] Primes { get; private set; }

    public Sieve(int limit)
    {
        this.limit = limit;
        InitializePrimes();
    }

    private void InitializePrimes()
    {
        var candidates = new Queue<int>(Enumerable.Range(2, limit - 1));
        var primes = new List<int>();
        do
        {
            var prime = candidates.Dequeue();
            primes.Add(prime);
            candidates = new Queue<int>(candidates.Where(x => x % prime != 0));
        } while (candidates.Any());
        Primes = primes.ToArray();
    }
}