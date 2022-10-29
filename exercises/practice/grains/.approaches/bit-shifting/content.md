# Bit-shifting

```csharp
using System;
using System.Numerics; // for use with BigInteger

public static class Grains
{
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
}
```

Instead of using math to calculate the number of grains on a square, you can simply set a bit in the correct position of a `ulong` value.

To understand how this works, consider just two squares that are represented in binary bits as `00`.

You use the [left-shift operator][left-shift-operator] to set `1` at the position needed to make the correct decimal value.
- To set the one grain on Square One you shift `1` for `0` positions to the left.
So, if `n` is `1` for square One, you subtract `n` by `1` to get `0`, which will not move it any positions to the left.
The result is binary `01`, which is decimal `1`.
- To set the two grains on Square Two you shift `1` for `1` position to the left.
So, if `n` is `2` for square Two, you subtract `n` by `1` to get `1`, which will move it `1` position to the left.
The result is binary `10`, which is decimal `2`.

| Square  | Shift Left By | Binary Value | Decimal Value |
| ------- | ------------- | ------------ | ------------- |
|       1 |             0 |         0001 |             1 |
|       2 |             1 |         0010 |             2 |
|       3 |             2 |         0100 |             4 |
|       4 |             3 |         1000 |             8 |

For `Total` we want all of the 64 bits set to `1` to get the sum of grains on all sixty-four squares.
The easy way to do this is to set the 65th bit to `1` and then subtract `1`.
However, we can't do this with a `ulong` which has only `64` bits, so we need to use a [BigInteger][biginteger].
To go back to our two-square example, if we can grow to three squares, then we can shift [BigInteger.One][biginteger-one] two positions to the left for binary `100`,
which is decimal `4`.
By subtracting `1` we get `3`, which is the total amount of grains on the two squares.

| Square  | Binary Value | Decimal Value |
| ------- | ------------ | ------------- |
|       3 |         0100 |             4 |

| Square  | Sum Binary Value | Sum Decimal Value |
| ------- | ---------------- | ----------------- |
|       1 |             0001 |                 1 |
|       2 |             0011 |                 3 |

## Shortening

When the body of a function is a single expression, the function can be implemented as an [expression-bodied member][expression-bodied-member], like so

```csharp
public static ulong Total() =>
    (ulong)((BigInteger.One << 64) - 1);
```

or

```csharp
public static ulong Total() => (ulong)((BigInteger.One << 64) - 1);
```

[left-shift-operator]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators#left-shift-operator-
[biginteger]: https://learn.microsoft.com/en-us/dotnet/api/system.numerics.biginteger
[biginteger-one]: https://learn.microsoft.com/en-us/dotnet/api/system.numerics.biginteger.one
[expression-bodied-member]: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members
