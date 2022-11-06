# Introduction

The key to this exercise is to keep track of a list of numbers and their status of possibly being prime.

## General guidance

- Carefully consider which data structure to use
- Try to only allocate memory once for the data structure you use to keep track of the sieve

## Approach: `BitArray`

```csharp
public static IEnumerable<int> Primes(int max)
{
    if (max < 0)
        throw new ArgumentOutOfRangeException(nameof(max));

    var primes = new BitArray(max + 1, true);

    for (var i = 2; i <= max; i++)
    {
        if (!primes[i])
            continue;

        for (var j = i * 2; j <= max; j += i)
            primes[j] = false;

        yield return i;
    }
}
```

This approach uses a [`BitArray`][bit-array] to (efficiently) keep track of and skip the prime multiples.
For more information, check the [`BitArray` approach][approach-bit-array].

## Approach: `HashSet`

```csharp
public static IEnumerable<int> Primes(int max)
{
    if (max < 0)
        throw new ArgumentOutOfRangeException(nameof(max));

    var primeMultiples = new HashSet<int>();

    for (var i = 2; i <= max; i++)
    {
        if (primeMultiples.Contains(i))
            continue;

        for (var j = i * 2; j <= max; j += i)
            primeMultiples.Add(j);

        yield return i;
    }
}
```

This approach uses a [`HashSet<T>`][hash-set] to keep track of and skip the prime multiples.
For more information, check the [`HashSet<T>` approach][approach-hash-set].

## Which approach to use?

While the difference between the two approaches is minor, the `BitArray` approach has two things going for it:

1. It is a more natural way to encode the problem, as the sieve itself is described as using one list and crossing items off that list.
2. Its performance is better than that of the `HashSet<T>` for the majority of cases. For more details, check out the [Performance article][article-performance].

[approach-bit-array]: https://exercism.org/tracks/csharp/exercises/sieve/approaches/bit-array
[approach-hash-set]: https://exercism.org/tracks/csharp/exercises/sieve/approaches/hash-set
[article-performance]: https://exercism.org/tracks/csharp/exercises/sieve/articles/performance
[bit-array]: https://learn.microsoft.com/en-us/dotnet/api/system.collections.bitarray
[hash-set]: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.hashset-1
