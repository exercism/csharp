using NUnit.Framework;

[TestFixture]
public class TwelveDaysTest
{
    private TwelveDaysSong twelveDaysSong;

    [SetUp]
    public void Setup()
    {
        twelveDaysSong = new TwelveDaysSong();
    }

    [Test]
    public void Return_verse_1()
    {
        var expected = "On the first day of Christmas my true love gave to me, a Partridge in a Pear Tree.\n";

        Assert.That(twelveDaysSong.Verse(1), Is.EqualTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Return_verse_2()
    {
        var expected = "On the second day of Christmas my true love gave to me, two Turtle Doves, and a Partridge in a Pear Tree.\n";

        Assert.That(twelveDaysSong.Verse(2), Is.EqualTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Return_verse_3()
    {
        var expected = "On the third day of Christmas my true love gave to me, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n";

        Assert.That(twelveDaysSong.Verse(3), Is.EqualTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Return_verse_4()
    {
        var expected = "On the fourth day of Christmas my true love gave to me, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n";

        Assert.That(twelveDaysSong.Verse(4), Is.EqualTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Return_verse_5()
    {
        var expected = "On the fifth day of Christmas my true love gave to me, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n";

        Assert.That(twelveDaysSong.Verse(5), Is.EqualTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Return_verse_6()
    {
        var expected = "On the sixth day of Christmas my true love gave to me, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n";

        Assert.That(twelveDaysSong.Verse(6), Is.EqualTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Return_verse_7()
    {
        var expected = "On the seventh day of Christmas my true love gave to me, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n";

        Assert.That(twelveDaysSong.Verse(7), Is.EqualTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Return_verse_8()
    {
        var expected = "On the eighth day of Christmas my true love gave to me, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n";

        Assert.That(twelveDaysSong.Verse(8), Is.EqualTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Return_verse_9()
    {
        var expected = "On the ninth day of Christmas my true love gave to me, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n";

        Assert.That(twelveDaysSong.Verse(9), Is.EqualTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Return_verse_10()
    {
        var expected = "On the tenth day of Christmas my true love gave to me, ten Lords-a-Leaping, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n";

        Assert.That(twelveDaysSong.Verse(10), Is.EqualTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Return_verse_11()
    {
        var expected = "On the eleventh day of Christmas my true love gave to me, eleven Pipers Piping, ten Lords-a-Leaping, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n";

        Assert.That(twelveDaysSong.Verse(11), Is.EqualTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Return_verse_12()
    {
        var expected = "On the twelfth day of Christmas my true love gave to me, twelve Drummers Drumming, eleven Pipers Piping, ten Lords-a-Leaping, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n";

        Assert.That(twelveDaysSong.Verse(12), Is.EqualTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Return_multiple_verses()
    {
        var expected = "On the first day of Christmas my true love gave to me, a Partridge in a Pear Tree.\n\n" +
          "On the second day of Christmas my true love gave to me, two Turtle Doves, and a Partridge in a Pear Tree.\n\n" +
          "On the third day of Christmas my true love gave to me, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n\n";

        Assert.That(twelveDaysSong.Verses(1, 3), Is.EqualTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Return_entire_song()
    {
        Assert.That(twelveDaysSong.Verses(1, 12), Is.EqualTo(twelveDaysSong.Sing()));
    }
}