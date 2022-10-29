# Introduction

There are various idomatic approaches to Pangram.

## General guidance

The key to solving Pangram is determining if all of the letters in the alphabet are in the `string` being tested.
You can use the LINQ method `All` with the `String` method `Contains` on lower-cased letters.
Or you can use the LINQ method `All` with the `String` method `Contains` using case-insensitive comparison.

## Approach: `All` with `Contains` on lowercased letters

```csharp
using System.Linq;

public static class Pangram
{
    private const string Letters = "abcdefghijklmnopqrstuvwxyz";
    
    public static bool IsPangram(string input)
    {
        var lowerCaseInput = input.ToLower();
        return Letters.All(letter => lowerCaseInput.Contains(letter));
    }
}
```

## Approach: `All` with `Contains` using case-insensitive comparison

```csharp
using System.Linq;

public static class Pangram
{
    private static readonly StringComparison xcase = StringComparison.CurrentCultureIgnoreCase;
    
    public static bool IsPangram(string input)
    {
        return "abcdefghijklmnopqrstuvwxyz".All(c => input.Contains(c, xcase));
    }
}
```

## Other approaches

Besides the aforementioned, idiomatic approaches, you could also approach the exercise as follows:

## Bit field approach:

A fast approach can use a bit field to keep track of used letters.
For more information, check the [Bit field approach][approach-bitfield].

## Which approach to use?

The `All/Contains` on lowercased letters approach is readable, idiomatic,
and is about seven times faster than the `All/Contains` using a case-insensitive comparison approach.

The fastest is the `Bit field` approach, but it may be considered more idiomatic of the C language than C#.

To compare performance of the approaches, check the [Performance approach][approach-performance].

[approach-all-contains-tolower]: https://exercism.org/tracks/csharp/exercises/pangram/approaches/all-contains-tolower
[approach-all-contains-case-insensitive]: https://exercism.org/tracks/csharp/exercises/pangram/approaches/all-contains-case-insensitive
[approach-bitfield]: https://exercism.org/tracks/csharp/exercises/pangram/approaches/bitfield
[approach-performance]: https://exercism.org/tracks/csharp/exercises/pangram/approaches/performance
