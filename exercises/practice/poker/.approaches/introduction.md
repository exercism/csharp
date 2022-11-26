# Introduction

While this exercise might appear straightforward, an implementation has to deal with some edge cases (like a low ace straight).

## General guidance

- Define a straight flush using the logic to define a straight and a flush

## Approach: integer score

```csharp
record Hand(Card[] Cards)
{
    public int Score => CategoryRanks.Prepend(CategoryScore).Aggregate((total, value) => total * 14 + value);

    private int CategoryScore =>
        IsStraightFlush ? 9 :
        IsFourOfAKind ? 8 :
        IsFullHouse ? 7 :
        IsFlush ? 6 :
        IsStraight ? 5 :
        IsThreeOfAKind ? 4 :
        IsTwoPair ? 3 :
        IsOnePair ? 2 :
        1;
}
```

This approach assign a single integer score to each hand, which makes finding the best hand(s) quite straightforward.
For more information, check the [integer score approach][approach-icomparer].

## Approach: `IComparer<T>`

```csharp
private enum Category { HighCard, OnePair, TwoPair, ThreeOfAKind, Straight, Flush, FullHouse, FourOfAKind, StraightFlush }

record Hand(Card[] Cards) : IComparable<Hand>
{
    public int CompareTo(Hand other) =>
        Category.CompareTo(other.Category) switch
        {
            < 0 => -1,
            > 0 => 1,
            0 => CategoryRanks.CompareTo(other.CategoryRanks)
        };
}
```

This approach implements the [`IComparer<T>` interface][icomparer] to compare hands.
For more information, check the [`IComparer<T>` approach][approach-icomparer].

## Which approach to use?

What approach to choose depends a bit on how one would want the code to be used elsewhere.
The `IComparer<T>` approach model the domain a bit nicer, but the integer score fits well with the mental model of _scoring_ a hand.
Basically, you should choose whichever approach you prefer.

[approach-integer-score]: https://exercism.org/tracks/csharp/exercises/poker/approaches/integer-score
[approach-icomparer]: https://exercism.org/tracks/csharp/exercises/poker/approaches/icomparer
[icomparer]: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1
[list-patterns]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/patterns#list-patterns
