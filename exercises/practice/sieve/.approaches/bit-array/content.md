# `BitArray`

```csharp
using System;
using System.Collections;
using System.Collections.Generic;

public static class Sieve
{
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
}
```

The first step is to check the input for validity:

```csharp
if (max < 0)
    throw new ArgumentOutOfRangeException(nameof(max));
```

We then create a [`BitArray`][hash-set] that will contain the numbers that are a multiple of the primes we find:

```csharp
var primes = new BitArray(max + 1, true);
```

The `BitArray` constructor takes two values:

1. The number of items it should hold (in our case, `max + 1` as counting starts at `0`)
2. The initial value of all items (`true` in our case)

This will allocate just enough memory to hold `max + 1` bits, with their initial value set to true (which is the bit value of `1`).

| Max | Default value | Bits       |
| --- | ------------- | ---------- |
| `8` | `false`       | `00000000` |
| `8` | `true`        | `11111111` |

We'll then use this bit array to represent our sieve.
For any prime we find, we'll change the value for all its multiples to `false`, which we can then use to skip those numbers later on.

Let's look at an example to see how this would work.
If we take `9` as the maximum value, our initial `BitArray`'s content look something like this:

```
Index: 0123456789
Value: 1111111111
```

Now if we start at index `2` (which is prime) and then cross off its multiples (setting them to `false`), we get:

```
Index: 0123456789
Value: 1111010101
```

You can see how the numbers at index `4`, `6` and `8` have all had their value set to `false`, essentially crossing them off as possible primes.

We then move to index `3`, which value is `true` so it must be a prime.
Crossing off its multiples (`6`, which was already crossed off, and `9`) gives us:

```
Index: 0123456789
Value: 1111010100
```

We then check index `4`, which value is `false` and thus can't be a prime so we'll skip it and move to the next number, until we've iterated over all numbers up to `max`.

Let's see how to implement this.

First, we start iterating from `2` (the smallest prime) up until the maximum that was specified:

```csharp
for (var i = 2; i <= max; i++)
```

Within the loop, our first check is to see if the value at index `i` (our current number) is `false`, which means that it must be a multiple of a prime.
It thus can't be a prime and we'll skip the number:

```csharp
if (!primes[i])
    continue;
```

If this check returns `false`, we're dealing with a prime!
This means that we can then cross off any multiples of this prime, which we can do with another (nested) `for`-loop:

```csharp
for (var j = i * 2; j <= max; j += i)
    primes[j] = false;
```

Note how we start at the first multiple of the prime (`i * 2`) and that we increment the loop iterator variable by the prime number (`j += i`) to iterate over all the multiples of the prime.

The final step is to return the prime number, for which we use a [`yield` statement][yield-statement]:

```csharp
yield return i;
```

Note that even though we yield an indidivual integer, what is returned from a caller's viewpoint is a sequence of integers.

~~~~exercism/note
When a `yield` statement is written, the compiler transforms the method into a state machine that is suspended after each yield statement.
~~~~

~~~~exercism/note
Methods that use a `yield` statement are also _lazy_, which means that calling `Sequence(number)` by itself does not do anything.
It is only when a method is called that forces evaluation (like `Count()` or `ToArray()`), that we're forcing iteration over the elements in the sequence.
~~~~

[yield-statement]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/yield
[bit-array]: https://learn.microsoft.com/en-us/dotnet/api/system.collections.bitarray
