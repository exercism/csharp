# Integer score

```csharp
using System.Collections.Generic;
using System.Linq;

public static class Poker
{
    public static IEnumerable<string> BestHands(IEnumerable<string> hands) =>
        hands.ToLookup(hand => Parser.ParseHand(hand).Score).MaxBy(g => g.Key);

    private record Card(int Rank, int Suit);

    private record Hand(Card[] Cards)
    {
        private readonly int[] ranks = Cards
            .Select(card => card.Rank)
            .OrderByDescending(rank => Cards.Count(card => card.Rank == rank))
            .ThenByDescending(card => card)
            .ToArray();

        private readonly int[] rankCounts = Cards
            .GroupBy(card => card.Rank)
            .Select(grouping => grouping.Count())
            .OrderDescending()
            .ToArray();

        private readonly int suitCount = Cards.DistinctBy(card => card.Suit).Count();

        public int Score => CategoryRanks.Prepend(CategoryScore).Aggregate((total, value) => total * 14 + value);

        private int[] CategoryRanks => IsLowAceStraight ? ranks.Append(ranks[0]).Skip(1).ToArray() : ranks;

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

        private bool IsStraightFlush => IsFlush && IsStraight;
        private bool IsFlush => suitCount == 1;
        private bool IsStraight => (rankCounts is [1, 1, 1, 1, 1] && ranks[0] - ranks[4] == 4) || IsLowAceStraight;
        private bool IsLowAceStraight => rankCounts is [1, 1, 1, 1, 1] && ranks[0] - ranks[1] is 9;
        private bool IsFourOfAKind => rankCounts is [4, 1];
        private bool IsFullHouse => rankCounts is [3, 2];
        private bool IsThreeOfAKind => rankCounts is [3, 1, 1];
        private bool IsTwoPair => rankCounts is [2, 2, 1];
        private bool IsOnePair => rankCounts is [2, 1, 1, 1];
    }

    private static class Parser
    {
        public static Hand ParseHand(string hand) => new(ParseCards(hand));
        private static Card[] ParseCards(string hand) => hand.Split(' ').Select(ParseCard).ToArray();
        private static Card ParseCard(string card) => new(ParseRank(card), ParseSuit(card));
        private static int ParseRank(string card) => "1234567890JQKA".IndexOf(card[^2]);
        private static int ParseSuit(string card) => "HSDC".IndexOf(card[^1]);
    }
}
```

In this approach, we'll compare hands by assigning each of them an integer score.
When comparing hands, we'll select the hands with the highest score.

## Modelling our domain

As our first step, let's look at how we want to model our domain in code.

To score hands based on the card's ranks, we'll model ranks (and suits) as integers: the higher the number, the higher its value.

### Cards

A card could be modelled as a `class` with two properties:

```csharp
private class Card
{
    public Card(int rank, int suit)
    {
        Rank = rank;
        Suit = suit;
    }

    public int Rank { get; }
    public int Suit { get; }
}
```

As we'll only be using the card to access its properties (no behavior associated with it), we can also more succinctly use a `record` type:

```csharp
private record Card(int Rank, int Suit);
```

### Hands

A hand is basically nothing more than a collection of five cards.
While we could model the cards as five different properties, it'll be easier to process them as an array of cards:

```csharp
private record Hand(Card[] Cards);
```

## Parsing

Having defined our `Hand` and `Card` types, let's try and parse them from our input string.
As a reminder, these are some example hand inputs:

```csharp
"4S 5S 7H 8D JC"
"2S 4C 7S 9H 10H"
```

### Parse suit

We can see that the suits are defined by the last character.
Traditionally, you'd access the last character in a string by using `str[str.Length - 1]`, but the [index from end operator][index-from-end] is a more elegant way to do that.

We can then convert a hand's suit to an integer by finding the suit character's index in a string that contains all suit characters:

```csharp
private static int ParseSuit(string card) => "HSDC".IndexOf(card[^1]);
```

Neat!

### Parse rank

Parsing a rank is similar to parsing a suit, but we'll now look at the first character:

```csharp
private static int ParseRank(string card) => "1234567890JQKA".IndexOf(card[^2]);
```

Note that this also works for the "10" rank, as its first character ("1") is a unique value.

### Parse card

Parsing a card is then a matter of calling the `Card` constructor with the parsed rank and suit:

```csharp
private static Card ParseCard(string card) => new Card(ParseRank(card), ParseSuit(card));
```

Or, more succinctly, using a [target-typed new expression][target-typed-new]:

```csharp
private static Card ParseCard(string card) => new (ParseRank(card), ParseSuit(card));
```

### Parsing hand

Parsing a hand means parsing its cards, which are rank/suit strings separated by spaces (e.g. `"4S 5S 7H 8D JC"`).
We thus first split the string by spaces via the `string`'s [`Split()` method][string.split]:

```csharp
hand.Split(' ')
```

This will return an array of strings representing each card.
We then use [`Select()`][enumerable.select] to parse each card string into a `Card` instance:

```csharp
hand.Split(' ').Select(card => ParseCard(card))
```

As the lambda passed to `Select()` only passed its argument to another method, it can be shortened using a [method group][method-group]:

```csharp
hand.Split(' ').Select(ParseCard);
```

We then materialize the parsed cards to an array using [`ToArray()`][enumerable.to-array]:

```csharp
private static Card[] ParseCards(string hand) => hand.Split(' ').Select(ParseCard).ToArray();
```

Finally, we can parse our hand by doing:

```csharp
public static Hand ParseHand(string hand) => new(ParseCards(hand));
```

## Comparing hands

We now get to the core of this approach: scoring each hand to allow them to be compared.
To do so, our `Hand` class will have `Score` property that returns the hand's score as an integer:

```csharp
private record Hand(Card[] Cards) : IComparable<Hand>
{
    public int Score => ???
}
```

## Categorizing hands

Before we'll get to any code, let's take a step back and examine the rules for the categories.
We can define all categories using three different constraints:

- Rank counts: how often ranks occur in a single hand
- Same suit: all cards must have the same suit
- Sequential ranks: the ranks have to be in sequential order

| Rule            | Rank counts   | Same suit | Sequential ranks |
| --------------- | ------------- | --------- | ---------------- |
| Straight flush  | 1, 1, 1, 1, 1 | Yes       | Yes              |
| Four of a kind  | 4, 1          | No        | No               |
| Full house      | 3, 2          | No        | No               |
| Flush           | _any_         | Yes       | No               |
| Straight        | 1, 1, 1, 1, 1 | No        | Yes              |
| Three of a kind | 3, 1, 1       | No        | No               |
| Two pairs       | 2, 2, 1       | No        | No               |
| One pair        | 2, 1, 1, 1    | No        | No               |
| High card       | _any_         | No        | No               |

Before we'll look at the individual rule, let's first add code to can help us identify the rank counts, same suit and sequential ranks criteria.

### Rank counts

To detect the rank counts, we can group cards by rank using [`GroupBy()`][enumerable.group-by] and then convert each rank group to its count via [`Select()`][enumerable.select] and [`Count()`][enumerable.count]:

```csharp
Cards.GroupBy(card => card.Rank).Select(grouping => grouping.Count())
```

Finally, we'll order them descendingly using [`OrderDescending()`][enumerable.order-descending] and [`ToArray()`][enumerable.to-array]:

```csharp
private readonly int[] rankCounts = Cards
    .GroupBy(card => card.Rank)
    .Select(grouping => grouping.Count())
    .OrderDescending()
    .ToArray();
```

We can now detect a full house (rank count of 3 and 2) using a simple [list pattern][list-patterns]:

```csharp
private bool IsFullHouse = ranksCounts is [3, 2];
```

### Same suit

To detect whether all cards have the same suit, we can use `DistinctBy()` using the `Suit` property followed by `Count()`:

```csharp
private readonly int suitCount = Cards.DistinctBy(card => card.Suit).Count();
```

As cards with the same suit are known as a _flush_, let's define an `IsFlush` property that returns `true` when there is just one suit:

```csharp
private bool IsFlush => suitCount == 1;
```

You should read this as: there is just one suit and it is present on all five cards.

### Sequential ranks

To detect whether all ranks are sequential, we could sort the ranks and then iterate over them in pairs, checking whether the difference between them is always equal to one.
But, we can also use the fact that is the ranks are sequential, the difference between the highest and the lowest rank is always 4:

| Hand              | Lowest rank | Highest rank | Difference |
| ----------------- | ----------- | ------------ | ---------- |
| "3S 4D 2S 6D 5C"  | 2           | 6            | 4          |
| "5S 7H 8S 9D 6H"  | 5           | 9            | 4          |
| "10D JH QS KD AC" | 10          | 14 (ace)     | 4          |

There is one exception to this rule, but we'll get to that in a minute.
Let's start by defining a field that contains the card's ranks:

```csharp
private readonly Rank[] ranks => Cards.Select(card => card.Rank).ToArray();
```

As sequential ranks are known as a _straight_, we'll define an `IsStraight` property that returns `true` when the ranks are sequential:

```csharp
private bool IsStraight => rankCounts is [1, 1, 1, 1, 1] && ranks.Max() - ranks.Min() == 4;
```

If we modify our `ranks` field to be in descending order, we don't need to use `Max()` en `Min()` (which will enumerate the ranks each time they're called) but can use direct array indexing:

```csharp
private readonly Rank[] ranks => Cards.Select(card => card.Rank).OrderDescending().ToArray();

private bool IsStraight => rankCounts is [1, 1, 1, 1, 1] && ranks[0] - ranks[4] == 4;
```

#### Low ace straight

There is one edge case that our code does not yet account for: a low ace straight, where the ace counts as a 1 (e.g. "4D AH 3S 2D 5C").
We can use a [list pattern][list-patterns] to check for this edge case:

```csharp
private bool IsLowAceStraight => rankCounts is [1, 1, 1, 1, 1] && ranks[0] - ranks[1] is 9;
```

We can then support this edge case by using it in the `SequentialRanks` property:

```csharp
private bool IsStraight => (rankCounts is [1, 1, 1, 1, 1] && ranks[0] - ranks[4] == 4) || IsLowAceStraight;
```

### Straight flush

The rules for a straight flush are:

1. The ranks are all different
2. The cards all have the same suit
3. The cards have sequential ranks

This is equivalent to: the hand is a flush _and_ the hand is a straight:

```csharp
private bool IsStraightFlush => IsFlush && IsStraight;
```

### Four of a kind

The rule for a four of a kind hand is:

1. One rank occurs four times and one rank just once

This translates to:

```csharp
private bool IsFourOfAKind => rankCount is [4, 1]
```

### Full house

The rule for a full house is:

1. One rank occurs three times and one rank two times

This translates to:

```csharp
private bool IsFullHouse => rankCount is [3, 2]
```

### Flush

The rule for a flush is:

1. One rank occurs three times and one rank two times

As we have already defined the `IsFlush` property, we don't need to do anything (yay!).

### Straight

The rule for a straight is:

1. All ranks are sequential

Again, we've already defined a property (`IsStraight`), so nothing to do here.

### Three of a kind

The rule for a three of a kind is:

1. One rank occurs three times, the other two ranks occur once

This translates to:

```csharp
private bool IsThreeOfAKind => ranksCounts is [3, 1, 1];
```

### Two pairs

The rule for two pairs is:

1. One rank occurs twice times, another rank also occurs twice and the other ranks occurs once

This translates to:

```csharp
private bool IsTwoPair = rankCounts is [2, 2, 1];
```

### One pair

The rule for one pair is:

1. One rank occurs twice times, the other three ranks once

This translates to:

```csharp
private bool IsOnePair => rankCounts is [2, 1, 1, 1];
```

### High card

There is no specific rule for the high card category as it is more like a fallback, so let's move on.

## Compare hands with different category

We now have logic to categorize and compare hands based on the nine different hand categories.
Ordered from high to low, they are:

- 1. Straight flush
- 2. Four of a kind
- 3. Full house
- 4. Flush
- 5. Straight
- 6. Three of a kind
- 7. Two pairs
- 8. One pair
- 9. High card

We can modify the `Score` property to return a score that reflects the category's ordering, with higher categories being assigned higher scores:

```csharp
public int Score =>
    IsStraightFlush ? 9 :
    IsFourOfAKind ? 8 :
    IsFullHouse ? 7 :
    IsFlush ? 6 :
    IsStraight ? 5 :
    IsThreeOfAKind ? 4 :
    IsTwoPair ? 3 :
    IsOnePair ? 2 :
    1;
```

With that, we can now compare hands with different categories.

## Compare hands with same category

The second part of comparing two hands is to compare hands that have the _same_ category.
Each category has its own rules to determine the better hand.

As an example, let's look at how we should score two four of a kind hands.
Four of a kind hands are compared by:

- First: the rank occuring four times
- Second: the rank occuring once (known as the _kicker_)

First, we'll need to be able to identify which rank occurs four times, and which just once.
For that, we'll tweak our existing `ranks` field a bit.
Instead of just sorting by rank descendingly, we'll first sort them by _count_:

```csharp
private readonly Rank[] ranks => Cards
    .Select(card => card.Rank)
    .OrderByDescending(rank => Cards.Count(card => card.Rank == rank))
    .ThenByDescending(rank => rank)
    .ToArray();
```

For a four of a kind hand, we are now guaranteed that the first four ranks are those that occur four times (`ranks[0]`, `ranks[1]`, `ranks[2]` and `ranks[3]`), and the last rank is the kicker (`ranks[4]`).

So how do we translate this into different scores?

### Base 14 encoding

Consider the following two four of kind hands:

- Hand 1: "2S 2H 2C 8D 2D"
- Hand 2: "4S 5H 5S 5D 5C"

We should compare them by quadruplet rank (`2` and `5`) and then by kicker rank (`8` and `4`).
What we need is some way to have 5,4 translate to a higher score than 2,8.
We could do that by "removing the comma": 54 is higher than 28.
What we've done here is convert the two numbers into one base 10 number (decimal):

5,4 = `5 * 10^1 + 4 * 10^0` = `5 * 10 + 4 * 1` = `50 + 4` = `54`
2,8 = `2 * 10^1 + 8 * 10^0` = `2 * 10 + 8 * 1` = `20 + 8` = `28`

Clearly, this works, but how do we apply this to our ranks?
Well, first we need to identify what _base_ to use.
We can't just use base 10, as we have 13 different ranks.
But we _can_ use a base 14 numeral system:

5,4 = `5 * 14^1 + 4 * 14^0` = `5 * 14 + 4 * 1` = `70 + 4` = `74`
2,8 = `2 * 14^1 + 8 * 14^0` = `2 * 14 + 8 * 1` = `28 + 8` = `36`

Translating that to code, we can do:

```csharp
if (IsFourOfAKind)
    return ranks[0] * 14 + ranks[4];
```

Beautiful!

#### Simplifying

Applying this logic to the flush category, we get:

```csharp
return ranks[0] * 14 * 14 * 14 * 14 + ranks[1] * 14 * 14 * 14 + ranks[2] * 14 * 14 + ranks[3] * 14 + ranks[4];
```

It works, but it is quite verbose.
We can shorten this quite a bit using [`Aggregate()`][enumerable.aggregate]:

```csharp
ranks.Aggregate((total, value) => total * 14 + value);
```

As a matter of fact, we can use this code for _all_ categories!
For example, for a four of a kind hand, `ranks[0]`, `ranks[1]`, `ranks[2]` and `ranks[3]` all have the same value.
It doesn't matter if we compare four of kind hands by just the first rank + kicker or the first four ranks + kicker, as the resulting score will indicate the same relative result (less than, equal or greater than).

##### Scoring categories

Currently, we're just scoring ranks, resulting in a four of kind hand with a quadruplet of rank 7 losing to a three of kind hand with a triplet of rank 10.
To fix this, we'll need to score a hand's category and use that as the first value for our score calculation.

We can score the categories as follows:

```csharp
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
```

We then prepend this value before the ranks when calculating the score:

```csharp
public int Score => ranks.Prepend(CategoryScore).Aggregate((total, value) => total * 14 + value);
```

We now have a fully working scoring system!

#### Low ace straight

Our hand scoring logic works for all hands but one: a low ace straight.
In this case, the `ranks` field's first value will be the ace (as it has the highest value), but it should actually count as the _lowest_ value and thus be the last element in the comparison.
As this also applies to straight flushes, we can add a new `CategoryRanks` property to special-case straight flush and straight hands that are low ace straights:

```csharp
private int[] CategoryRanks => IsLowAceStraight ? ranks.Append(ranks[0]).Skip(1).ToArray() : ranks;
```

Then, we update the `Score()` method to use the above property:

```csharp
public int Score => CategoryRanks.Prepend(CategoryScore).Aggregate((total, value) => total * 14 + value);
```

## Finding the best hands

The final step is to use our hand comparison logic to find the best hands.
As a reminder, this is the method signature for the `BestHands()` method:

```csharp
public static IEnumerable<string> BestHands(IEnumerable<string> hands)
```

To find the best hands, we'll create a lookup where the key is the hand's score:

```csharp
hands.ToLookup(hand => Parser.ParseHand(hand).Score);
```

Then all we need to do is to is to get the values for the maximum score key, for which we can use [`MaxBy()`][enumerable.max-by]:

```csharp
hands.ToLookup(hand => Parser.ParseHand(hand).Score).MaxBy(g => g.Key);
```

[icomparer]: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1
[enumerable.aggregate]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.aggregate
[enumerable.max]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.max
[enumerable.max-by]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.maxby
[enumerable.any]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.any
[enumerable.order]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.order
[enumerable.order-descending]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.order-descending
[enumerable.order-by]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.orderby
[enumerable.distinct-by]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.distinctby
[enumerable.select]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.select
[enumerable.to-array]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.toarray
[enumerable.count]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.count
[enumerable.group-by]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.groupby
[index-from-end]: https://learn.microsoft.com/en-us/dotnet/csharp/tutorials/ranges-indexes#language-support-for-indices-and-ranges
[switch-expression]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/switch-expression
[target-typed-new]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/target-typed-new
[method-group]: https://stackoverflow.com/questions/35420610/passing-a-method-to-a-linq-query
[string.split]: https://learn.microsoft.com/en-us/dotnet/api/system.string.split
[list-patterns]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/patterns#list-patterns
