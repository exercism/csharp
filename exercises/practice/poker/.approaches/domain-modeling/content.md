# `IComparer<T>`

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

public static class Poker
{
    private class StraightFlushComparer : IComparer<Hand>
    {
        public int Compare(Hand x, Hand y) => Score(x).CompareTo(Score(y));
        private static int Score(Hand hand) =>
            hand.SuitCounts.Count == 1 &&
            hand.Ranks[4] - hand.Ranks[0] is 4 or 12 &&
            hand.RankCounts.Count == 5 ? hand.Ranks[4] - hand.Ranks[0] is 12 ? hand.Ranks[3] : hand.Ranks[4] : 0;
    }

    private class FourOfAKindComparer : IComparer<Hand>
    {
        public int Compare(Hand x, Hand y) => Score(x).CompareTo(Score(y));
        private static (int, int) Score(Hand hand) =>
            hand.RankCounts.ContainsValue(4) ? (hand.Ranks[1], Math.Min(hand.Ranks[0], hand.Ranks[4])) : (0, 0);
    }

    private class FullHouseComparer : IComparer<Hand>
    {
        public int Compare(Hand x, Hand y) => Score(x).CompareTo(Score(y));
        private static (int, int) Score(Hand hand) =>
            hand.RankCounts.ContainsValue(3) && hand.RankCounts.ContainsValue(2)
                ? hand.Ranks[2] == hand.Ranks[4]
                ? (hand.Ranks[2], hand.Ranks[0])
                : (hand.Ranks[0], hand.Ranks[4])
                : (0, 0);
    }

    private class FlushComparer : IComparer<Hand>
    {
        public int Compare(Hand x, Hand y) => Score(x).CompareTo(Score(y));
        private static (int, int, int, int, int) Score(Hand hand) =>
            hand.SuitCounts.Count == 1 ? (hand.Ranks[4], hand.Ranks[3], hand.Ranks[2], hand.Ranks[1], hand.Ranks[0]) : (0, 0, 0, 0, 0);
    }

    private class StraightComparer : IComparer<Hand>
    {
        public int Compare(Hand x, Hand y) => Score(x).CompareTo(Score(y));
        private static int Score(Hand hand) =>
            hand.Ranks[4] - hand.Ranks[0] is 4 or 12 &&
            hand.RankCounts.Count == 5 ? hand.Ranks[4] - hand.Ranks[0] is 12 ? hand.Ranks[3] : hand.Ranks[4] : 0;
    }

    private class ThreeOfAKindComparer : IComparer<Hand>
    {
        public int Compare(Hand x, Hand y) => Score(x).CompareTo(Score(y));
        private static (int, int, int) Score(Hand hand) => hand.RankCounts.ContainsValue(3)
            ? hand.Ranks[4] == hand.Ranks[2] ? (hand.Ranks[4], hand.Ranks[1], hand.Ranks[0])
            : hand.Ranks[3] == hand.Ranks[1] ? (hand.Ranks[3], hand.Ranks[4], hand.Ranks[0])
            : (hand.Ranks[0], hand.Ranks[4], hand.Ranks[3])
            : (0, 0, 0);
    }

    private class TwoPairComparer : IComparer<Hand>
    {
        public int Compare(Hand x, Hand y) => Score(x).CompareTo(Score(y));
        private static (int, int) Score(Hand hand) => hand.RankCounts.Count == 3
            ? hand.Ranks[0] != hand.Ranks[1] ? (hand.Ranks[4], hand.Ranks[2])
            : hand.Ranks[1] != hand.Ranks[2] ? (hand.Ranks[3], hand.Ranks[0])
            : (hand.Ranks[2], hand.Ranks[0])
            : (0, 0);
    }

    private class OnePairComparer : IComparer<Hand>
    {
        public int Compare(Hand x, Hand y) => Score(x).CompareTo(Score(y));
        private static (int, int, int, int) Score(Hand hand) => hand.RankCounts.ContainsValue(2)
            ? hand.Ranks[0] == hand.Ranks[1] ? (hand.Ranks[0], hand.Ranks[4], hand.Ranks[3], hand.Ranks[2])
            : hand.Ranks[1] == hand.Ranks[2] ? (hand.Ranks[1], hand.Ranks[4], hand.Ranks[3], hand.Ranks[0])
            : hand.Ranks[2] == hand.Ranks[3] ? (hand.Ranks[2], hand.Ranks[4], hand.Ranks[1], hand.Ranks[0])
            : (hand.Ranks[3], hand.Ranks[2], hand.Ranks[1], hand.Ranks[0])
            : (0, 0, 0, 0);
    }

    private class HighCardComparer : IComparer<Hand>
    {
        public int Compare(Hand x, Hand y) => Score(x).CompareTo(Score(y));
        private static (int, int, int, int, int) Score(Hand hand) => (hand.Ranks[4], hand.Ranks[3], hand.Ranks[2], hand.Ranks[1], hand.Ranks[0]);
    }

    private class HandComparer : IComparer<Hand>
    {
        private static readonly IComparer<Hand>[] Comparers =
        {
            new StraightFlushComparer(), new FourOfAKindComparer(), new FullHouseComparer(), new FlushComparer(),
            new StraightComparer(), new ThreeOfAKindComparer(), new TwoPairComparer(), new OnePairComparer(), new HighCardComparer()
        };

        public int Compare(Hand x, Hand y) =>
            Comparers.Aggregate(0, (comparison, comparer) => comparison == 0 ? comparer.Compare(x, y) : comparison);
    }

    private record Card(int Rank, int Suit);

    private record Hand
    {
        public Hand(string text, Card[] cards)
        {
            Text = text;
            Cards = cards;
            Ranks = cards.Select(card => card.Rank).Order().ToArray();
            RankCounts = cards.GroupBy(card => card.Rank).ToDictionary(rank => rank.Key, cards => cards.Count());
            SuitCounts = cards.GroupBy(card => card.Suit).ToDictionary(rank => rank.Key, cards => cards.Count());
        }

        public string Text { get; }
        public Card[] Cards { get; }
        public int[] Ranks { get; }
        public Dictionary<int,int> RankCounts { get; }
        public Dictionary<int,int> SuitCounts { get; }
    }

    public static IEnumerable<string> BestHands(IEnumerable<string> handDescriptions)
    {
        var hands = handDescriptions.Select(ParseHand).ToArray();
        var bestHand = hands.Max(new HandComparer());
        return hands.Where(h => h == bestHand || new HandComparer().Compare(h, bestHand) == 0).Select(h => h.Text).ToArray();
    }

    private static Hand ParseHand(string hand) => new(hand, ParseCards(hand));
    private static Card[] ParseCards(string hand) => hand.Split(' ').Select(ParseCard).ToArray();
    private static Card ParseCard(string card) => new(card.Rank(), card.Suit());
    private static int Rank(this string card) => "..234567890JQKA".IndexOf(card[^2]);
    private static int Suit(this string card) => ".HSDC".IndexOf(card[^1]);
}
```
