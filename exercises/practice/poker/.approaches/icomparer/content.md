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
            hand.IsFlush && hand.IsSmallStraight ? hand.Ranks[3] :
            hand.IsFlush && hand.IsLargeStraight ? hand.Ranks[4] :
            0;
    }

    private class FourOfAKindComparer : IComparer<Hand>
    {
        public int Compare(Hand x, Hand y) => Score(x).CompareTo(Score(y));
        private static (int, int) Score(Hand hand) =>
            hand.IsFourOfAKind
                ? (hand.Ranks[1], Math.Min(hand.Ranks[0], hand.Ranks[4]))
                : (0, 0);
    }

    private class FullHouseComparer : IComparer<Hand>
    {
        public int Compare(Hand x, Hand y) => Score(x).CompareTo(Score(y));
        private static (int, int) Score(Hand hand) =>
            hand.IsFullHouse
                ? hand.Ranks[2] == hand.Ranks[4]
                ? (hand.Ranks[2], hand.Ranks[0])
                : (hand.Ranks[0], hand.Ranks[4])
                : (0, 0);
    }

    private class FlushComparer : IComparer<Hand>
    {
        public int Compare(Hand x, Hand y) => Score(x).CompareTo(Score(y));
        private static (int, int, int, int, int) Score(Hand hand) =>
            hand.IsFlush
                ? (hand.Ranks[4], hand.Ranks[3], hand.Ranks[2], hand.Ranks[1], hand.Ranks[0])
                : (0, 0, 0, 0, 0);
    }

    private class StraightComparer : IComparer<Hand>
    {
        public int Compare(Hand x, Hand y) => Score(x).CompareTo(Score(y));

        private static int Score(Hand hand) =>
            hand.IsSmallStraight ? hand.Ranks[3] :
            hand.IsLargeStraight ? hand.Ranks[4] :
            0;
    }

    private class ThreeOfAKindComparer : IComparer<Hand>
    {
        public int Compare(Hand x, Hand y) => Score(x).CompareTo(Score(y));
        private static (int, int, int) Score(Hand hand) => hand.IsThreeOfAKind
            ? hand.Ranks[4] == hand.Ranks[2] ? (hand.Ranks[4], hand.Ranks[1], hand.Ranks[0])
            : hand.Ranks[3] == hand.Ranks[1] ? (hand.Ranks[3], hand.Ranks[4], hand.Ranks[0])
            : (hand.Ranks[0], hand.Ranks[4], hand.Ranks[3])
            : (0, 0, 0);
    }

    private class TwoPairComparer : IComparer<Hand>
    {
        public int Compare(Hand x, Hand y) => Score(x).CompareTo(Score(y));
        private static (int, int) Score(Hand hand) => hand.IsTwoPair
            ? hand.Ranks[0] != hand.Ranks[1] ? (hand.Ranks[4], hand.Ranks[2])
            : hand.Ranks[1] != hand.Ranks[2] ? (hand.Ranks[3], hand.Ranks[0])
            : (hand.Ranks[2], hand.Ranks[0])
            : (0, 0);
    }

    private class OnePairComparer : IComparer<Hand>
    {
        public int Compare(Hand x, Hand y) => Score(x).CompareTo(Score(y));
        private static (int, int, int, int) Score(Hand hand) => hand.IsOnePair
            ? hand.Ranks[0] == hand.Ranks[1] ? (hand.Ranks[0], hand.Ranks[4], hand.Ranks[3], hand.Ranks[2])
            : hand.Ranks[1] == hand.Ranks[2] ? (hand.Ranks[1], hand.Ranks[4], hand.Ranks[3], hand.Ranks[0])
            : hand.Ranks[2] == hand.Ranks[3] ? (hand.Ranks[2], hand.Ranks[4], hand.Ranks[1], hand.Ranks[0])
            : (hand.Ranks[3], hand.Ranks[2], hand.Ranks[1], hand.Ranks[0])
            : (0, 0, 0, 0);
    }

    private class HighCardComparer : IComparer<Hand>
    {
        public int Compare(Hand x, Hand y) => Score(x).CompareTo(Score(y));
        private static (int, int, int, int, int) Score(Hand hand) =>
            (hand.Ranks[4], hand.Ranks[3], hand.Ranks[2], hand.Ranks[1], hand.Ranks[0]);
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

    private record Hand(string Text, Card[] Cards)
    {
        public int[] Ranks => Cards.Select(card => card.Rank).ToArray();
        public int[] Suits => Cards.Select(card => card.Suit).ToArray();

        public bool IsFlush => Suits.Distinct().Count() == 1;
        public bool IsSmallStraight => Ranks[4] - Ranks[0] == 12 && Ranks.Distinct().Count() == 5;
        public bool IsLargeStraight => Ranks[4] - Ranks[0] == 4 && Ranks.Distinct().Count() == 5;
        public bool IsFourOfAKind => HasRankOfCount(4);
        public bool IsFullHouse => HasRankOfCount(3) && HasRankOfCount(2);
        public bool IsThreeOfAKind => HasRankOfCount(3);
        public bool IsTwoPair => HasRankOfCount(2, numberOfTimes: 2);
        public bool IsOnePair => HasRankOfCount(2);

        private bool HasRankOfCount(int count, int numberOfTimes = 1) =>
            Ranks.GroupBy(rank => rank).Count(g => g.Count() == count) == numberOfTimes;
    }

    public static IEnumerable<string> BestHands(IEnumerable<string> handDescriptions)
    {
        var hands = handDescriptions.Select(ParseHand).OrderDescending(new HandComparer()).ToArray();
        return hands.TakeWhile(h => new HandComparer().Compare(h, hands[0]) == 0).Select(h => h.Text).ToArray();
    }

    private static Hand ParseHand(string hand) => new(hand, ParseCards(hand));
    private static Card[] ParseCards(string hand) => hand.Split(' ').Select(ParseCard).OrderBy(card => card.Rank).ToArray();
    private static Card ParseCard(string card) => new(card.Rank(), card.Suit());
    private static int Rank(this string card) => "..234567890JQKA".IndexOf(card[^2]);
    private static int Suit(this string card) => ".HSDC".IndexOf(card[^1]);
}
```
