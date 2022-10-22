# Bit-shifting

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

Instead of using math to calculate the number of grains on a square, we can simply set a bit in the correct position of a `ulong` value.

To understand how this works, consider just two squares that are represented in bits as `00`.
- To get the one grain on square One, we set the first bit (on the right) to `1` like so: `01`, which is the decimal value of `1`.
- To get the two grains on square Two, we set the second bit (from the right) to `1` like so: `10`, which is the decimal value of `2`.

We use the [left-shift operator][left-shift-operator] to set `1` at the position needed to make the correct decimal value.
- To set the one grain on Square One we shift `1` for `0` positions to the left.
So, if `n` is `1` for square One, we subtract `n` by `1` to get `0`, which will not move it any positions to the left.
The result is `01`, which is decimal `1`.
- To set the two grains on Square Two we shift `1` for `1` position to the left.
So, if `n` is `2` for square Two, we subtract `n` by `1` to get `1`, which will move it `1` position to the left.
The result is `10`, which is decimal `2`.

For `Total` we want all of the 64 bits set to `1` to get the sum of grains on all sixty-four squares.
The easy way to do this is to set the 65th bit to `1` and then subtract `1`.
However, we can't do this with a `ulong` which has only `64` bits, so we need to use a [BigInteger][biginteger].
To go back to our two-square example, if we can grow to three squares, then we can set the third position from the right to `1` like so: `100`,
which is decimal `4`.
By subtracting `1` we get `3`, which is the total amount of grains on the two squares.


[left-shift-operator]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators#left-shift-operator-
[biginteger]: https://learn.microsoft.com/en-us/dotnet/api/system.numerics.biginteger?view=net-7.0
