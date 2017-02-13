using NUnit.Framework;

public class PokerTest
{
    [Test]
    public void One_hand()
    {
        const string hand = "4S 5S 7H 8D JC";
        Assert.That(Poker.BestHands(new[] { hand }), Is.EqualTo(new[] { hand }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Nothing_vs_one_pair()
    {
        const string nothing = "4S 5H 6S 8D JH";
        const string pairOf4 = "2S 4H 6S 4D JH";
        Assert.That(Poker.BestHands(new[] { nothing, pairOf4 }), Is.EqualTo(new[] { pairOf4 }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Two_pairs()
    {
        const string pairOf2 = "4S 2H 6S 2D JH";
        const string pairOf4 = "2S 4H 6S 4D JH";
        Assert.That(Poker.BestHands(new[] { pairOf2, pairOf4 }), Is.EqualTo(new[] { pairOf4 }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void One_pair_vs_double_pair()
    {
        const string pairOf8 = "2S 8H 6S 8D JH";
        const string doublePair = "4S 5H 4S 8D 5H";
        Assert.That(Poker.BestHands(new[] { pairOf8, doublePair }), Is.EqualTo(new[] { doublePair }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Two_double_pairs()
    {
        const string doublePair2And8 = "2S 8H 2S 8D JH";
        const string doublePair4And5 = "4S 5H 4S 8D 5H";
        Assert.That(Poker.BestHands(new[] { doublePair2And8, doublePair4And5 }), Is.EqualTo(new[] { doublePair2And8 }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Double_pair_vs_three()
    {
        const string doublePair2And8 = "2S 8H 2S 8D JH";
        const string threeOf4 = "4S 5H 4S 8D 4H";
        Assert.That(Poker.BestHands(new[] { doublePair2And8, threeOf4 }), Is.EqualTo(new[] { threeOf4 }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Two_threes()
    {
        const string threeOf2 = "2S 2H 2S 8D JH";
        const string threeOf1 = "4S AH AS 8D AH";
        Assert.That(Poker.BestHands(new[] { threeOf2, threeOf1 }), Is.EqualTo(new[] { threeOf1 }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Three_vs_straight()
    {
        const string threeOf4 = "4S 5H 4S 8D 4H";
        const string straight = "3S 4H 2S 6D 5H";
        Assert.That(Poker.BestHands(new[] { threeOf4, straight }), Is.EqualTo(new[] { straight }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Two_straights()
    {
        const string straightTo8 = "4S 6H 7S 8D 5H";
        const string straightTo9 = "5S 7H 8S 9D 6H";
        Assert.That(Poker.BestHands(new[] { straightTo8, straightTo9 }), Is.EqualTo(new[] { straightTo9 }));
        
        const string straightTo1 = "AS QH KS TD JH";
        const string straightTo5 = "4S AH 3S 2D 5H";
        Assert.That(Poker.BestHands(new[] { straightTo1, straightTo5 }), Is.EqualTo(new[] { straightTo1 }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Straight_vs_flush()
    {
        const string straightTo8 = "4S 6H 7S 8D 5H";
        const string flushTo7 = "2S 4S 5S 6S 7S";
        Assert.That(Poker.BestHands(new[] { straightTo8, flushTo7 }), Is.EqualTo(new[] { flushTo7 }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Two_flushes()
    {
        const string flushTo8 = "3H 6H 7H 8H 5H";
        const string flushTo7 = "2S 4S 5S 6S 7S";
        Assert.That(Poker.BestHands(new[] { flushTo8, flushTo7 }), Is.EqualTo(new[] { flushTo8 }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Flush_vs_full()
    {
        const string flushTo8 = "3H 6H 7H 8H 5H";
        const string full = "4S 5H 4S 5D 4H";
        Assert.That(Poker.BestHands(new[] { full, flushTo8 }), Is.EqualTo(new[] { full }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Two_fulls()
    {
        const string fullOf4By9 = "4H 4S 4D 9S 9D";
        const string fullOf5By8 = "5H 5S 5D 8S 8D";
        Assert.That(Poker.BestHands(new[] { fullOf4By9, fullOf5By8 }), Is.EqualTo(new[] { fullOf5By8 }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Full_vs_square()
    {
        const string full = "4S 5H 4S 5D 4H";
        const string squareOf3 = "3S 3H 2S 3D 3H";
        Assert.That(Poker.BestHands(new[] { full, squareOf3 }), Is.EqualTo(new[] { squareOf3 }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Two_squares()
    {
        const string squareOf2 = "2S 2H 2S 8D 2H";
        const string squareOf5 = "4S 5H 5S 5D 5H";
        Assert.That(Poker.BestHands(new[] { squareOf2, squareOf5 }), Is.EqualTo(new[] { squareOf5 }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Square_vs_straight_flush()
    {
        const string squareOf5 = "4S 5H 5S 5D 5H";
        const string straightFlushTo9 = "5S 7S 8S 9S 6S";
        Assert.That(Poker.BestHands(new[] { squareOf5, straightFlushTo9 }), Is.EqualTo(new[] { straightFlushTo9 }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Two_straight_flushes()
    {
        const string straightFlushTo8 = "4H 6H 7H 8H 5H";
        const string straightFlushTo9 = "5S 7S 8S 9S 6S";
        Assert.That(Poker.BestHands(new[] { straightFlushTo8, straightFlushTo9 }),
            Is.EqualTo(new[] { straightFlushTo9 }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Three_hand_with_tie()
    {
        const string spadeStraightTo9 = "9S 8S 7S 6S 5S";
        const string diamondStraightTo9 = "9D 8D 7D 6D 5D";
        const string threeOf4 = "4D 4S 4H QS KS";
        Assert.That(Poker.BestHands(new[] { spadeStraightTo9, diamondStraightTo9, threeOf4 }),
            Is.EqualTo(new[] { spadeStraightTo9, diamondStraightTo9 }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Straight_to_5_against_a_pair_of_jacks()
    {
        const string straightTo5 = "2S 4D 5C 3S AS";
        const string twoJacks = "JD 8D 7D JC 5D";
        Assert.That(Poker.BestHands(new[] { straightTo5, twoJacks }),
            Is.EqualTo(new[] { straightTo5 }));
    }
}
