# Introduction

There are various idiomatic ways to solve Isogram.

## Approach: `Distinct` with `Count`

```csharp
// uses System.Linq
var lowerLetters = word.ToLower().Where(char.IsLetter).ToList();
return lowerLetters.Distinct().Count() == lowerLetters.Count;
```

For more information, check the [`Distinct` approach][approach-distinct].


## Approach: `GroupBy` with `All` and `Count`

```csharp
// uses System.Linq
return word.ToLower().Where(Char.IsLetter).GroupBy(ltr => ltr).All(ltr_grp => ltr_grp.Count() == 1);
```

For more information, check the [`GroupBy` approach][approach-groupby].

## other approaches

- A fast approach can use a bit field to keep track of used letters.
For more information, check the [Bit Field approach][approach-bitfield].

## Which approach to use?

The `GroupBy` approach is an idiomatic "one-liner", but it is more than twice as slow as the `Distinct` approach, which is also idiomatic and perhaps more readable.

The fastest is the `Bit Field` approach, but it may be considered more C language idiomatic than C# idiomatic.
Also, it depends on all of the letters being [ASCII][ascii].

To compare performance of the approaches, check the [Performance approach][approach-performance].

[approach-distinct]: https://exercism.org/tracks/csharp/exercises/isogram/approaches/distinct
[approach-groupby]: https://exercism.org/tracks/csharp/exercises/isogram/approaches/groupby
[approach-bitfield]: https://exercism.org/tracks/csharp/exercises/isogram/approaches/bitfield
[approach-performance]: https://exercism.org/tracks/csharp/exercises/isogram/approaches/performance
[ascii]: https://www.asciitable.com/
