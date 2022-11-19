# Introduction

There are various idomatic approaches to Pangram.
You can use the LINQ method `All` with the `String` method `Contains` on lower-cased letters.
Or you can use the LINQ method `All` with the `String` method `Contains` using case-insensitive comparison.

## General guidance

The key to solving Pangram is determining if all of the letters in the alphabet are in the `string` being tested.
The occurrence of either the letter `a` or the letter `A` would count as the same letter.

## Approach: `All` with `Contains` on lowercased letters

```csharp
public static bool IsPangram(string input)
{
    const string Letters = "abcdefghijklmnopqrstuvwxyz";
    var lowerCaseInput = input.ToLower();
    return Letters.All(letter => lowerCaseInput.Contains(letter));
}
```

For more information, check the [`All` with `Contains` on lowercase approach][approach-all-contains-tolower].

## Approach: `All` with `Contains` using case-insensitive comparison

```csharp
public static bool IsPangram(string input)
{
    return "abcdefghijklmnopqrstuvwxyz".All(c => input.Contains(c, StringComparison.CurrentCultureIgnoreCase));
}
```

For more information, check the [`All` with `Contains` case-insensitive approach][approach-all-contains-case-insensitive]

## Other approaches

Besides the aforementioned, idiomatic approaches, you could also approach the exercise as follows:

### Other approach: Bit field

A fast approach can use a bit field to keep track of used letters.
For more information, check the [Bit field approach][approach-bitfield].

## Which approach to use?

The `All/Contains` on lowercased letters approach is readable, idiomatic,
and is about seven times faster than the `All/Contains` using a case-insensitive comparison approach.

The fastest is the `Bit field` approach, but it may be considered more idiomatic of the C language than C#.

To compare performance of the approaches, check the [Performance article][article-performance].

[approach-all-contains-tolower]: https://exercism.org/tracks/csharp/exercises/pangram/approaches/all-contains-tolower
[approach-all-contains-case-insensitive]: https://exercism.org/tracks/csharp/exercises/pangram/approaches/all-contains-case-insensitive
[approach-bitfield]: https://exercism.org/tracks/csharp/exercises/pangram/approaches/bitfield
[article-performance]: https://exercism.org/tracks/csharp/exercises/pangram/articles/performance
