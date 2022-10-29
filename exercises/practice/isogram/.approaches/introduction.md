# Introduction

There are various idiomatic ways to solve Isogram.
You can use the LINQ method `Distinct` with the `String` method `Count`. 
Or you could use is the LINQ methods `GroupBy` and `All` with `Count`.

## General guidance

The key to solving Isogram is to determine if any of the letters in the `string` being checked are repeated.
A repeated letter means the `string` is not an Isogram.
The occurrence of the letter `a` and the letter `A` count as a repeated letter, so `Alpha` would not be an isogram.

## Approach: `Distinct` with `Count`

```csharp
using System.Linq;

public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        var lowerLetters = word.ToLower().Where(char.IsLetter).ToList();
        return lowerLetters.Distinct().Count() == lowerLetters.Count;
    }
}
```

For more information, check the [`Distinct` approach][approach-distinct].


## Approach: `GroupBy` with `All` and `Count`

```csharp
using System.Linq;

public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        return word.ToLower().Where(Char.IsLetter).GroupBy(ltr => ltr).All(ltr_grp => ltr_grp.Count() == 1);
    }
}
```

For more information, check the [`GroupBy` approach][approach-groupby].

## Other approaches

Besides the aforementioned, idiomatic approaches, you could also approach the exercise as follows:

## Bit field approach:

A fast approach can use a bit field to keep track of used letters.
For more information, check the [Bit field approach][approach-bitfield].

## Which approach to use?

The `GroupBy` approach is an idiomatic "one-liner", but it is more than twice as slow as the `Distinct` approach, which is also idiomatic and perhaps more readable.

The fastest is the `Bit field` approach, but it may be considered more idiomatic of the C language than C#.
Also, it depends on all of the letters being [ASCII][ascii].

To compare performance of the approaches, check the [Performance article][article-performance].

[approach-distinct]: https://exercism.org/tracks/csharp/exercises/isogram/approaches/distinct
[approach-groupby]: https://exercism.org/tracks/csharp/exercises/isogram/approaches/groupby
[approach-bitfield]: https://exercism.org/tracks/csharp/exercises/isogram/approaches/bitfield
[article-performance]: https://exercism.org/tracks/csharp/exercises/isogram/articles/performance
[ascii]: https://www.asciitable.com/
