# Introduction

The key to this exercise is to efficiently work with modulus division for large numbers.

## General guidance

- The `BigInteger` class has a built-in method efficiently perform modulus division on a number raised to the power of another number.

## Approach: `BigInteger`

```csharp
public static BigInteger PrivateKey(BigInteger p) =>
    new(Random.Shared.Next(1, (int)p));

public static BigInteger PublicKey(BigInteger p, BigInteger g, BigInteger privateKey) =>
    BigInteger.ModPow(g, privateKey, p);

public static BigInteger Secret(BigInteger p, BigInteger publicKey, BigInteger privateKey) =>
    BigInteger.ModPow(publicKey, privateKey, p);
```

This approach uses the [`BigInteger` class'][big-integer] built-in methods to efficiently perform modulus division on a number raised to the power of another number.
For more information, check the [`BigInteger` approach][approach-big-integer].

[approach-big-integer]: https://exercism.org/tracks/csharp/exercises/diffie-hellman/approaches/big-integer
[big-integer]: https://learn.microsoft.com/en-us/dotnet/api/system.numerics.biginteger
