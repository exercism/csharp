# Introduction

There are various idiomatic approaches to solve Grains.
A basic approach can use `Math.Pow` to calculate the number on grains on a square.
Or bit-shifting can be used.

## Approach: `Math.Pow`

```csharp
    // uses System.Linq;
    public static double Square(int i)
    {
        if (i is <= 0 or > 64) throw new ArgumentOutOfRangeException(nameof(i));
        
        return Math.Pow(2, i - 1);
    }
    
    public static double Total() => Enumerable.Range(1, 64).Sum(Square);
```

For more information, check the [Pow approach][approach-pow].

## Approach: Bit-shifting

```csharp
    // uses System.Numerics for BigInteger
    public static ulong Square(int n)
    {
        switch (n)
        {
            case int num when num > 0 && num < 65: return (ulong)1 << (num - 1);
            default: throw new ArgumentOutOfRangeException("n must be 1 through 64");
        }
    }
    
    public static ulong Total() => (ulong)((BigInteger.One << 64) - 1);
```

For more information, check the [Bit-shifting approach][approach-bit-shifting].

## Other approaches 

- The maximum value for an unsigned integer gives the total number of grains on all sixty-four squares.
For more information, check the [`System.UInt64.MaxValue` for Total Approach][approach-max-value].

## Which approach to use?

`Pow` may be considered the most readable solution.

Bit-shifting is more performant, but may be considered less readable.
For more information, check the [Performance approach][approach-performance].

[approach-pow]: https://exercism.org/tracks/csharp/exercises/grains/approaches/pow
[approach-bit-shifting]: https://exercism.org/tracks/csharp/exercises/grains/approaches/bit-shifting
[approach-max-value]: https://exercism.org/tracks/csharp/exercises/grains/approaches/max-value
[approach-performance]: https://exercism.org/tracks/csharp/exercises/grains/approaches/performance
