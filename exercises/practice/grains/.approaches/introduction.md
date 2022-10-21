# Introduction

There are several idiomatic approaches to solve Grains.

## Approach: `Math.Pow`

```csharp
using System;
using System.Linq;
public static class Grains
{
    public static double Square(int i)
    {
        if (i is <= 0 or > 64) throw new ArgumentOutOfRangeException(nameof(i));
        
        return Math.Pow(2, i - 1);
    }
    public static double Total() => Enumerable.Range(1, 64).Sum(Square);
}
```

For more information, check the .

## Approach: Bit-shifting

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
    
    public static ulong Total() => (ulong)((BigInteger.One << 64) - 1);
}
```

For more information, check the .

## Approach: `System.UInt64.MaxValue` for Total

```csharp
public static ulong Total() => System.UInt64.MaxValue;
```

For more information, check the .

## Which approach to use?
