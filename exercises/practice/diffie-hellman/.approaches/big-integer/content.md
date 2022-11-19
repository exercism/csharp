# `BigInteger`

```csharp
using System;
using System.Numerics;

public static class DiffieHellman
{
    public static BigInteger PrivateKey(BigInteger p) =>
        new(Random.Shared.NextInt64(1, (long)p));

    public static BigInteger PublicKey(BigInteger p, BigInteger g, BigInteger privateKey) =>
        BigInteger.ModPow(g, privateKey, p);

    public static BigInteger Secret(BigInteger p, BigInteger publicKey, BigInteger privateKey) =>
        BigInteger.ModPow(publicKey, privateKey, p);
}
```

## Generate random key

The first thing to tackle is to generate a random private key.
For that, the `Random` class can be used, which has a [`Next()` method][random.next] to generate a random number within a range (lower bound inclusive, upper bound exclusive).

```csharp
public static BigInteger PrivateKey(BigInteger p)
{
    return Random.Shared.NextInt64(1, (long)p);
}
```

This will generate a number `>= 1` and `< p`.

```exercism/note
The `Random.Shared` instance if guaranteed to be thread-safe, so is usually preferrable over creating your own `Random` instance.
```

## Calculate public key and secret

Conveniently, the public key and the secret can both be calculated using just one method: [`BigInteger.ModPow()`][big-integer.modpow]:

```csharp
public static BigInteger PublicKey(BigInteger p, BigInteger g, BigInteger privateKey) =>
    BigInteger.ModPow(g, privateKey, p);

public static BigInteger Secret(BigInteger p, BigInteger publicKey, BigInteger privateKey) =>
    BigInteger.ModPow(publicKey, privateKey, p);
```

And that's it!

## Shortening

There are two things we can do to further shorten this method:

1. Remove the curly braces by converting to an [expression-bodied method][expression-bodied-method]
1. Use a [target-typed new][target-typed-new] expression to replace `new string` with just `new` (the compiler can figure out the type from the method's return type)

Using this, we end up with:

```csharp
public static BigInteger PrivateKey(BigInteger p) => new(Random.Shared.Next(1, (int) p - 1));

public static BigInteger PublicKey(BigInteger p, BigInteger g, BigInteger privateKey) =>
    BigInteger.ModPow(g, privateKey, p);

public static BigInteger Secret(BigInteger p, BigInteger publicKey, BigInteger privateKey) =>
    BigInteger.ModPow(publicKey, privateKey, p);
```

[big-integer]: https://learn.microsoft.com/en-us/dotnet/api/system.numerics.biginteger
[big-integer.modpow]: https://learn.microsoft.com/en-us/dotnet/api/system.numerics.biginteger.modpow
[random]: https://learn.microsoft.com/en-us/dotnet/api/system.random
[random.shared]: https://learn.microsoft.com/en-us/dotnet/api/system.random.shared
[random.next]: https://learn.microsoft.com/en-us/dotnet/api/system.random.next
[expression-bodied-method]: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members#methods
[target-typed-new]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/target-typed-new
