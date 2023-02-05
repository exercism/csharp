# Introduction

There are various idiomatic approaches to solve Grains.
You can use `Math.Pow` to calculate the number on grains on a square.
Or you can use bit-shifting.

## General guidance

The key to solving Grains is to focus on each square having double the amount of grains as the square before it.
This means that the amount of grains grows exponentially.
The first square has one grain, which is `2` to the power of `0`.
The second square has two grains, which is `2` to the power of `1`.
The third square has four grains, which is `2` to the power of `2`.
You can see that the exponent, or power, that `2` is raised by is always one less than the square number.

| Square | Power | Value                   |
| ------ | ----- | ----------------------- |
| 1      | 0     | 2 to the power of 0 = 1 |
| 2      | 1     | 2 to the power of 1 = 2 |
| 3      | 2     | 2 to the power of 2 = 4 |
| 4      | 3     | 2 to the power of 3 = 8 |

## Approach: `Math.Pow`

```csharp
public static double Square(int i)
{
    if (i is <= 0 or > 64)
        throw new ArgumentOutOfRangeException(nameof(i));

    return Math.Pow(2, i - 1);
}

public static double Total()
{
    return Enumerable.Range(1, 64).Sum(Square);
}
```

For more information, check the [Pow approach][approach-pow].

## Approach: Bit-shifting

```csharp
public static ulong Square(int n)
{
    switch (n)
    {
        case int num when num > 0 && num < 65: return (ulong)1 << (num - 1);
        default: throw new ArgumentOutOfRangeException("n must be 1 through 64");
    }
}

public static ulong Total()
{
    return (ulong)((BigInteger.One << 64) - 1);
}
```

For more information, check the [Bit-shifting approach][approach-bit-shifting].

## Other approaches

Besides the aforementioned, idiomatic approaches, you could also approach the exercise as follows:

### Other approach: Max value

The maximum value for an unsigned integer gives the total number of grains on all sixty-four squares.
For more information, check the [`System.UInt64.MaxValue` for Total Approach][approach-max-value].

## Which approach to use?

`Pow` may be considered the most readable solution.

Bit-shifting is more performant, but may be considered less readable.

For more information, check the [Performance article][article-performance].

[approach-pow]: https://exercism.org/tracks/csharp/exercises/grains/approaches/pow
[approach-bit-shifting]: https://exercism.org/tracks/csharp/exercises/grains/approaches/bit-shifting
[approach-max-value]: https://exercism.org/tracks/csharp/exercises/grains/approaches/max-value
[article-performance]: https://exercism.org/tracks/csharp/exercises/grains/articles/performance
