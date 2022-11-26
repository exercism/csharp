# `IComparer<T>`

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

public static class Poker
{
    public static IEnumerable<string> BestHands(IEnumerable<string> hands)
    {
        var parsedHands = hands.ToDictionary(hand => hand, Parser.ParseHand);
        var bestHand = parsedHands.Values.Max();

        return parsedHands
            .Where(hand => hand.Value.CompareTo(bestHand) == 0)
            .Select(hand => hand.Key)
            .ToArray();
    }

    private enum Suit { Diamonds, Clubs, Hearts, Spades }

    private enum Rank { Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace }

    private enum Category { HighCard, OnePair, TwoPair, ThreeOfAKind, Straight, Flush, FullHouse, FourOfAKind, StraightFlush }

    private record Card(Rank Rank, Suit Suit);

    private record Hand(Card[] Cards) : IComparable<Hand>
    {
        private readonly Rank[] ranks = Cards
            .Select(card => card.Rank)
            .OrderByDescending(rank => Cards.Count(card => card.Rank == rank))
            .ThenByDescending(rank => rank)
            .ToArray();

        private readonly int[] rankCounts = Cards
            .GroupBy(card => card.Rank)
            .Select(grouping => grouping.Count())
            .OrderDescending()
            .ToArray();

        private readonly int suitCount = Cards.DistinctBy(card => card.Suit).Count();

        public int CompareTo(Hand other) =>
            Category.CompareTo(other.Category) switch
            {
                < 0 => -1,
                > 0 => 1,
                0 => CategoryRanks.CompareTo(other.CategoryRanks)
            };

        private Category Category =>
            rankCounts switch
            {
                [1, 1, 1, 1, 1] when SameSuit && SequentialRanks => Category.StraightFlush,
                [4, 1] => Category.FourOfAKind,
                [3, 2] => Category.FullHouse,
                _ when SameSuit => Category.Flush,
                [1, 1, 1, 1, 1] when SequentialRanks => Category.Straight,
                [3, 1, 1] => Category.ThreeOfAKind,
                [2, 2, 1] => Category.TwoPair,
                [2, 1, 1, 1] => Category.OnePair,
                _ => Category.HighCard
            };

        private bool SameSuit => suitCount == 1;
        private bool SequentialRanks => ranks[0] - ranks[4] == 4 || SequentialRanksWithLowAce;
        private bool SequentialRanksWithLowAce => ranks is [Rank.Ace, Rank.Five, Rank.Four, Rank.Three, Rank.Two];

        private (Rank, Rank, Rank, Rank, Rank) CategoryRanks =>
            Category switch
            {
                Category.StraightFlush or Category.Straight when SequentialRanksWithLowAce => (ranks[1], ranks[2], ranks[3], ranks[4], ranks[0]),
                _ => (ranks[0], ranks[1], ranks[2], ranks[3], ranks[4])
            };
    }

    private static class Parser
    {
        public static Hand ParseHand(string hand) => new(ParseCards(hand));
        private static Card[] ParseCards(string hand) => hand.Split(' ').Select(ParseCard).ToArray();
        private static Card ParseCard(string card) => new(ParseRank(card), ParseSuit(card));

        private static Rank ParseRank(string card) =>
            card[0] switch
            {
                '2' => Rank.Two,
                '3' => Rank.Three,
                '4' => Rank.Four,
                '5' => Rank.Five,
                '6' => Rank.Six,
                '7' => Rank.Seven,
                '8' => Rank.Eight,
                '9' => Rank.Nine,
                '1' => Rank.Ten,
                'J' => Rank.Jack,
                'Q' => Rank.Queen,
                'K' => Rank.King,
                'A' => Rank.Ace,
            };

        private static Suit ParseSuit(string card) =>
            card[^1] switch
            {
                'H' => Suit.Hearts,
                'S' => Suit.Spades,
                'D' => Suit.Diamonds,
                'C' => Suit.Clubs,
            };
    }
}
```

In this approach, we'll compare hands by implementing the [`IComparer<T>` interface][icomparer].
This interface is used in many places where elements are compared, e.g. when ordering an enumerable via [`OrderBy()`][enumerable.order-by].

## Modelling our domain

As our first step, let's look at how we want to model our domain in code.

The suit and rank of a card as well as the hand's _category_ can be modelled as enums:

```csharp
private enum Suit { Diamonds, Clubs, Hearts, Spades }
private enum Rank { Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace }
private enum Category { HighCard, OnePair, TwoPair, ThreeOfAKind, Straight, Flush, FullHouse, FourOfAKind, StraightFlush }
```

Note how we careful order the fields in the `Rank` and `Category` enums to be ascending order.
That way we can compare ranks and categories in a natural way, e.g. `Rank.Two < Rank.Three` and `Category.OnePair < Category.TwoPair`.

### Cards

A card could be modelled as a `class` with two properties:

```csharp
private class Card
{
    public Card(Rank rank, Suit suit)
    {
        Rank = rank;
        Suit = suit;
    }

    public Rank Rank { get; }
    public Suit Suit { get; }
}
```

As we'll only be using the card to access its properties (no behavior associated with it), we can also more succinctly use a `record` type:

```csharp
private record Card(Rank Rank, Suit Suit);
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
Traditionally, you'd access the last character in a string by using `str[str.Length - 1]`, but the [index from end operator][index-from-end] is a more elegant way to do that:

```csharp
private static Suit ParseSuit(string card) =>
    card[^1] switch
    {
        'H' => Suit.Hearts,
        'S' => Suit.Spades,
        'D' => Suit.Diamonds,
        'C' => Suit.Clubs,
    };
```

We then use a [`switch` expression][switch-expression] to match the last character to its suit.

### Parse rank

Parsing a rank is similar to parsing a suit, but we'll now look at the first character:

```csharp
private static Rank ParseRank(string card) =>
    card[0] switch
    {
        '2' => Rank.Two,
        '3' => Rank.Three,
        '4' => Rank.Four,
        '5' => Rank.Five,
        '6' => Rank.Six,
        '7' => Rank.Seven,
        '8' => Rank.Eight,
        '9' => Rank.Nine,
        '1' => Rank.Ten,
        'J' => Rank.Jack,
        'Q' => Rank.Queen,
        'K' => Rank.King,
        'A' => Rank.Ace,
    };
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

We now get to the core of this approach: making our hands _comparable_ to other hands.
To do so, our `Hand` class needs to implement the `IComparable<Card>` interface and its `CompareTo()` method:

```csharp
private record Hand(Card[] Cards) : IComparable<Hand>
{
    public int CompareTo(Hand other)
    {
        // We'll figure this out soon
    }
}
```

According to the instructions, there are nine different hand categories.
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

If two hands are of different categories, the best hand is the one with the higher category.
As a first step, let's only handle this scenario (different categories); we'll get to comparing hands with the same category later.

We'll start out with adding a `Category` property to the `Hand` class that returns its, well, category!

```csharp
private Category Category => ???
```

Assuming this property has been implemented properly (which we'll get to in a bit), we can then implement the `CompareTo()` method using:

```csharp
public int CompareTo(Hand other) => Category.CompareTo(other.Category);
```

With this code, `Hand` instances of different categories can be correctly compared to each other.
Let's move on to implementing the logic for categorizing a hand.

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
var isFullHouse = ranksCounts is [3, 2];
```

### Same suit

To detect whether all cards have the same suit, we can use `DistinctBy()` using the `Suit` property followed by `Count()`:

```csharp
private readonly int suitCount = Cards.DistinctBy(card => card.Suit).Count();
```

We can then define a `SameSuit` property that returns `true` when there is just one suit:

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

We can then test for sequential ranks via:

```csharp
private bool SequentialRanks => ranks.Max() - ranks.Min() == 4;
```

If we modify our `ranks` field to be in descending order, we don't need to use `Max()` en `Min()` (which will enumerate the ranks each time they're called) but can use direct array indexing:

```csharp
private readonly Rank[] ranks => Cards.Select(card => card.Rank).OrderDescending().ToArray();

private bool SequentialRanks => ranks[0] - ranks[4] == 4;
```

#### Low ace straight

There is one edge case that our code does not yet account for: a low ace straight, where the ace counts as a 1 (e.g. "4D AH 3S 2D 5C").
We can use a [list pattern][list-patterns] to check for this edge case:

```csharp
private bool IsLowAceStraight => ranks is [Rank.Ace, Rank.Five, Rank.Four, Rank.Three, Rank.Two];
```

We can then support this edge case by using it in the `SequentialRanks` property:

```csharp
private bool SequentialRanks => ranks[0] - ranks[4] == 4 || IsLowAceStraight;
```

### Straight flush

The rules for a straight flush are:

1. The ranks are all different
2. The cards all have the same suit
3. The cards have sequential ranks

This translates to:

```csharp
var isStraightFlush = rankCounts is [1, 1, 1, 1, 1] when SameSuit && SequentialRanks
```

### Four of a kind

The rule for a four of a kind hand is:

1. One rank occurs four times and one rank just once

This translates to:

```csharp
var isFourOfAKind = rankCount is [4, 1]
```

### Full house

The rule for a full house is:

1. One rank occurs three times and one rank two times

This translates to:

```csharp
var isFullHouse = rankCount is [3, 2]
```

### Flush

The rule for a flush is:

1. One rank occurs three times and one rank two times

This translates to:

```csharp
var isFlush = SameSuit;
```

### Straight

The rule for a straight is:

1. All ranks are sequential

This translates to:

```csharp
var isStraight = SequentialRanks;
```

### Three of a kind

The rule for a three of a kind is:

1. One rank occurs three times, the other two ranks occur once

This translates to:

```csharp
var isThreeOfAKind = ranksCounts is [3, 1, 1];
```

### Two pairs

The rule for two pairs is:

1. One rank occurs twice times, another rank also occurs twice and the other ranks occurs once

This translates to:

```csharp
var isTwoPair = rankCounts is [2, 2, 1];
```

### One pair

The rule for one pair is:

1. One rank occurs twice times, the other three ranks once

This translates to:

```csharp
var isOnePair = rankCounts is [2, 1, 1, 1];
```

### High card

There is no specific rule for the high card category, it is just the default category when the hand does not match any other category.

This translates to:

```csharp
var isHighCard = true;
```

### Putting it all together

We can put everything together in one `Category` property by pattern matching on the ranks counts:

```csharp
private Category Category =>
    rankCounts switch
    {
        [1, 1, 1, 1, 1] when SameSuit && SequentialRanks => Category.StraightFlush,
        [4, 1] => Category.FourOfAKind,
        [3, 2] => Category.FullHouse,
        _ when SameSuit => Category.Flush,
        [1, 1, 1, 1, 1] when SequentialRanks => Category.Straight,
        [3, 1, 1] => Category.ThreeOfAKind,
        [2, 2, 1] => Category.TwoPair,
        [2, 1, 1, 1] => Category.OnePair,
        _ => Category.HighCard
    };
```

## Compare hands with different category

Now that we can properly categorize hands, we can successfully compare hands with different categories:

```csharp
public int CompareTo(Hand other) =>
    Category.CompareTo(other.Category
```

## Compare hands with same category

The second part of comparing two hands is to compare hands that have the _same_ category.
Each category has its own rules to determine the better hand.

First, we'll need to update our `CompareTo()` method to handle two hands with the same category:

```csharp
public int CompareTo(Hand other) =>
    Category.CompareTo(other.Category) switch
    {
        < 0 => -1,
        > 0 => 1,
        0 => CategoryRank.CompareTo(other.CategoryRank)
    };
```

Using pattern matching, we'll first handle the cases where the categories are unequal.
Then, when the categories _are_ equal, we'll compare the category's rank.

For now we'll define `CategoryRank` as:

```csharp
private Rank CategoryRank => ???
```

#### Straight flush

Straight flush hands are compared by:

> Highest rank

We've dealt with using the highest rank before, which we can find at `ranks[0]`:

```csharp
private Rank CategoryRank => ranks[0];
```

This will ensure that the same hand comparison code:

```csharp
CategoryRank.CompareTo(other.CategoryRank)
```

works to correctly compare straight flush hands.

### Four of a kind

Four of a kind hands are compared by:

- First: the rank occuring four times
- Second: the rank occuring once (known as the _kicker_)

We have an issue now, as our `CategoryRank` property only returns a single rank, but that won't do.
Instead, we can return a two-rank tuple to leverage the fact that tuples have built-in functionality to compare them element by element:

```csharp
(4, 7).CompareTo((5, 9)) // < 0 as 4 < 5
(4, 7).CompareTo((3, 9)) // > 0 as 4 > 3
(4, 7).CompareTo((4, 7)) // = 0 as 4 == 4 && 7 == 7
(4, 7).CompareTo((4, 6)) // > 0 as 4 == 4 && 7 > 6
(4, 7).CompareTo((4, 9)) // < 0 as 4 == 4 && 7 < 9
```

Before we'll use this in our code, we'll need to determine which rank occurs four times, and which just once.
For that, we'll tweak our existing `ranks` field a bit.
Instead of just sorting by rank descendingly, we'll first sort them by _count_:

```csharp
private readonly Rank[] ranks => Cards
    .Select(card => card.Rank)
    .OrderByDescending(rank => Cards.Count(card => card.Rank == rank))
    .ThenByDescending(rank => rank)
    .ToArray();
```

For a four of a kind hand, we are now guaranteed that the first four ranks are those that occur four times, and the last rank is the kicker.

Let's modify the `CategoryRank` property to return the correct tuple pair per category:

```csharp
private (Rank, Rank) CategoryRank =>
    Category switch
    {
        Rank.StraightFlush => (ranks[0], 0),
        Rank.FourOfAKind => (ranks[0], ranks[4])
    };
```

Note: we need to also return a tuple for the straight flush hand, which only compares by the first card, so we add a fixed value for the second element.

### Full house

Full house hands are compared by:

- First: the rank occuring three times
- Second: the rank occuring twice

Using our sorted ranks field, we can use:

```csharp
Rank.Fullhouse => (ranks[0], ranks[3])
```

### Flush

Flush hands are compared by:

- First: the highest rank
- Second: the second highest rank
- Third: the third highest rank
- Fourth: the fourth highest rank
- Fifth: the fifth highest rank

This means that we _have_ to return a 5-tuple:

```csharp
private (Rank, Rank, Rank, Rank, Rank) CategoryRank =>
    Category switch
    {
        Rank.StraightFlush => (ranks[0], 0, 0, 0, 0),
        Rank.FourOfAKind => (ranks[0], ranks[4], 0, 0, 0),
        Rank.FullHouse => (ranks[0], ranks[3], 0, 0, 0),
        Rank.Flush => (ranks[0], ranks[1], ranks[2], ranks[3], ranks[4])
    };
```

Again, we're using the dummy values trick to pad the other category's tuple to all have the same size.
However, do we actually need to do that?
Let look at the following full house hand: "4S 5H 4C 5D 4H"
The `ranks` field for that hand is: `Rank.Four`, `Rank.Four`, `Rank.Four`, `Rank.Five`, `Rank.Five`.
We could thus compare these hands by `(ranks[0], ranks[1], ranks[2], ranks[3], ranks[4])`, as either the first rank doesn't match and we're done, or it matches and the next two ranks will thus _also_ match.
We then apply the same logic to the fourth rank, where equal ranks result in comparing the fifth rank which will also be equal.

With this in mind, it becomes clear what we can use the same pattern for _all_ categories:

```csharp
private (Rank, Rank, Rank, Rank, Rank) CategoryRank =>
    Category switch
    {
        Rank.StraightFlush => (ranks[0], ranks[1], ranks[2], ranks[3], ranks[4]),
        Rank.FourOfAKind   => (ranks[0], ranks[1], ranks[2], ranks[3], ranks[4]),
        Rank.FullHouse     => (ranks[0], ranks[1], ranks[2], ranks[3], ranks[4]),
        Rank.Flush         => (ranks[0], ranks[1], ranks[2], ranks[3], ranks[4])
    };
```

That means we can rewrite the `CategoryRank` property to just be:

```csharp
private (Rank, Rank, Rank, Rank, Rank) CategoryRank =>
    (ranks[0], ranks[1], ranks[2], ranks[3], ranks[4]);
```

Lovely, isn't it?

### Straight

Straight hands are compared by:

- First: the highest rank
- Second: the second highest rank
- Third: the third highest rank
- Fourth: the fourth highest rank
- Fifth: the fifth highest rank

#### Low ace straight

Our category ranking logic works for all hands but one: a low ace straight.
In this case, the `ranks` field's first value will be the ace (as it has the highest value), but it should actually count as the _lowest_ value and thus be the last element in the comparison.
As this also applies to straight flushes, we can tweak our `CategoryRanks` property to special-case straight flush and straight hands that are low ace straights:

```csharp
private (Rank, Rank, Rank, Rank, Rank) CategoryRanks =>
    Category switch
    {
        Category.StraightFlush or Category.Straight when IsLowAceStraight =>
             (ranks[1], ranks[2], ranks[3], ranks[4], ranks[0]),
        _ => (ranks[0], ranks[1], ranks[2], ranks[3], ranks[4])
    };
```

### Three of a kind

Three of a kind hands are compared by:

- First: the rank occuring three times
- Second: the highest remaining rank
- Third: the second highest remaining rank

No change is needed in our category ranks logic.

### Two pairs

Two pairs hands are compared by:

- First: the highest rank occuring twice
- Second: the lowest rank occuring twice
- Third: the remaining rank

Again, no change is needed in our category ranks logic.

### One pair

Two pairs hands are compared by:

- First: the rank occuring twice
- Second: the highest remaining rank
- Third: the second highest remaining rank
- Fourth: the third highest remaining rank

No change is needed in our category ranks logic.

### High card

- First: the highest rank
- Second: the second highest rank
- Third: the third highest rank
- Fourth: the fourth highest rank
- Fifth: the fifth highest rank

No change is needed in our category ranks logic.

## Finding the best hands

The final step is to use our hand comparison logic to find the best hands.
As a reminder, this is the method signature for the `BestHands()` method:

```csharp
public static IEnumerable<string> BestHands(IEnumerable<string> hands)
```

To find the best hands, we'll first parse the input into a `Hand[]`:

```csharp
var parsedHands = hands.Select(Parser.ParseHand).ToArray();
```

As the `Hand` class implements `IComparable<Hand>`, we can use the [`Max()` (extension-)method][enumerable.max] to find the best hand:

```csharp
var bestHand = parsedHands.Max();
```

Now that we have our best hand, we're not done though, as there can be multiple hands that are the best hand.
So let's go over the parsed hands again and find the hands that are equal to the best hand:

```csharp
var bestHands = parsedHands.Where(hand => hand.CompareTo(bestHand) == 0).ToArray();
```

Great progress, yay!
But looking at the method signature, we need to return an `IEnumerable<string>`, not an `IEnumerable<Hand>` 🤔
We there somehow need to associate an parsed hand with its original input.
There are several ways in which to do this:

- Store the input string within the `Hand` class
- Store the parsed hands alongside their input string

We opted for the second option, as the `Hand` class really doesn't have to know about its input string.
What we then did was to create a dictionary where the input string is the key, and the value the parsed `Hand`:

```csharp
var parsedHands = hands.ToDictionary(hand => hand, Parser.ParseHand);
```

We then get the parsed hand by getting the maximum of the dictionary's values (which are the `Hand` instances):

```csharp
var bestHand = parsedHands.Values.Max();
```

Finally, we only keep the key/value pairs which value (the `Hand` instance) is equal to the best hand and then select their key (which is the input string):

```csharp
return parsedHands
    .Where(hand => hand.Value.CompareTo(bestHand) == 0)
    .Select(hand => hand.Key)
    .ToArray();
```

[icomparer]: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1
[enumerable.max]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.max
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
