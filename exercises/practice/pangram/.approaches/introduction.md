# Introduction

There are various idomatic approaches to Pangram.

## Approach: `All` with `Contains` on lowercased letters



```csharp
    // uses System.Linq
    private const string Letters = "abcdefghijklmnopqrstuvwxyz";
    public static bool IsPangram(string input)
    {
        var lowerCaseInput = input.ToLower();
        return Letters.All(letter => lowerCaseInput.Contains(letter));
    }
```

## Approach: `All` with `Contains` using case-insensitive comparison

```csharp
    // uses System.Linq
    private static readonly StringComparison xcase = StringComparison.CurrentCultureIgnoreCase;
    public static bool IsPangram(string input) =>
        "abcdefghijklmnopqrstuvwxyz".All(c => input.Contains(c, xcase));
```


## other approaches

- A fast approach can use a bit field to keep track of used letters.
For more information, check the [Bit Field approach][approach-bitfield].

## Which approach to use?

The `All/Contains` on lowercased letters approach is readable, idiomatic,
and is about seven times faster than the `All/Contains` using case-insensitive comparison approach.

The fastest is the `Bit Field` approach, but it may be considered more C language idiomatic than C# idiomatic.
Also, it depends on all of the letters being [ASCII][ascii].

To compare performance of the approaches, check the [Performance approach][approach-performance].

[approach-all-contains-tolower]: https://exercism.org/tracks/csharp/exercises/pangram/approaches/all-contains-tolower
[approach-all-contains-case-insensitive]: https://exercism.org/tracks/csharp/exercises/pangram/approaches/all-contains-case-insensitive
[approach-bitfield]: https://exercism.org/tracks/csharp/exercises/pangram/approaches/bitfield
[approach-performance]: https://exercism.org/tracks/csharp/exercises/pangram/approaches/performance
[ascii]: https://www.asciitable.com/
