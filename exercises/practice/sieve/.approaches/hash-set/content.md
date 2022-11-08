# `HashSet`

```csharp
using System;
using System.Collections.Generic;

public static class Sieve
{
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
}
```

The first step is to check the input for validity:

```csharp
if (max < 0)
    throw new ArgumentOutOfRangeException(nameof(max));
```

We then create a [`HashSet<int>`][hash-set] that will contain the numbers that are a multiple of the primes we find:

```csharp
var primeMultiples = new HashSet<int>();
```

We then start iterating from `2` (the smallest prime) up until the maximum that was specified:

```csharp
for (var i = 2; i <= max; i++)
```

Within the loop, our first check is to see if the current number (`i`) is a multiple of one of the primes we found.
If so, we'll skip the number as it can't be a prime:

```csharp
if (primeMultiples.Contains(i))
    continue;
```

If this check returns `false`, we're dealing with a prime!
This means that we can then cross off any multiples of this prime, which we can do with another (nested) `for`-loop:

```csharp
for (var j = i * 2; j <= max; j += i)
    primeMultiples.Add(j);
```

Note how we start at the first multiple of the prime (`i * 2`) and that we increment the loop iterator variable by the prime number (`j += i`) to iterate over all the multiples of the prime.

The final step is to return the prime number, for which we use a [`yield` statement][yield-statement]:

```csharp
yield return i;
```

Note that even though we yield an indidivual integer, what is returned from a caller's viewpoint is a sequence of integers.

```exercism/note
When a `yield` statement is written, the compiler transforms the method into a state machine that is suspended after each yield statement.
```

```exercism/note
Methods that use a `yield` statement are also _lazy_, which means that calling `Sequence(number)` by itself does not do anything.
It is only when a method is called that forces evaluation (like `Count()` or `ToArray()`), that we're forcing iteration over the elements in the sequence.
```

[yield-statement]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/yield
[hash-set]: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.hashset-1
