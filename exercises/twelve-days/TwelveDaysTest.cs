// This file was auto-generated based on version 1.1.0 of the canonical data.

using Xunit;

public class TwelveDaysTest
{
    [Fact]
    public void First_day_a_partridge_in_a_pear_tree()
    {
        var expected = "On the first day of Christmas my true love gave to me, a Partridge in a Pear Tree.\n";
        Assert.Equal(expected, TwelveDaysSong.Verse(1));
    }

    [Fact()]
    public void Second_day_two_turtle_doves()
    {
        var expected = "On the second day of Christmas my true love gave to me, two Turtle Doves, and a Partridge in a Pear Tree.\n";
        Assert.Equal(expected, TwelveDaysSong.Verse(2));
    }

    [Fact()]
    public void Third_day_three_french_hens()
    {
        var expected = "On the third day of Christmas my true love gave to me, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n";
        Assert.Equal(expected, TwelveDaysSong.Verse(3));
    }

    [Fact()]
    public void Fourth_day_four_calling_birds()
    {
        var expected = "On the fourth day of Christmas my true love gave to me, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n";
        Assert.Equal(expected, TwelveDaysSong.Verse(4));
    }

    [Fact()]
    public void Fifth_day_five_gold_rings()
    {
        var expected = "On the fifth day of Christmas my true love gave to me, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n";
        Assert.Equal(expected, TwelveDaysSong.Verse(5));
    }

    [Fact()]
    public void Sixth_day_six_geese_a_laying()
    {
        var expected = "On the sixth day of Christmas my true love gave to me, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n";
        Assert.Equal(expected, TwelveDaysSong.Verse(6));
    }

    [Fact()]
    public void Seventh_day_seven_swans_a_swimming()
    {
        var expected = "On the seventh day of Christmas my true love gave to me, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n";
        Assert.Equal(expected, TwelveDaysSong.Verse(7));
    }

    [Fact()]
    public void Eighth_day_eight_maids_a_milking()
    {
        var expected = "On the eighth day of Christmas my true love gave to me, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n";
        Assert.Equal(expected, TwelveDaysSong.Verse(8));
    }

    [Fact()]
    public void Ninth_day_nine_ladies_dancing()
    {
        var expected = "On the ninth day of Christmas my true love gave to me, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n";
        Assert.Equal(expected, TwelveDaysSong.Verse(9));
    }

    [Fact()]
    public void Tenth_day_ten_lords_a_leaping()
    {
        var expected = "On the tenth day of Christmas my true love gave to me, ten Lords-a-Leaping, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n";
        Assert.Equal(expected, TwelveDaysSong.Verse(10));
    }

    [Fact()]
    public void Eleventh_day_eleven_pipers_piping()
    {
        var expected = "On the eleventh day of Christmas my true love gave to me, eleven Pipers Piping, ten Lords-a-Leaping, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n";
        Assert.Equal(expected, TwelveDaysSong.Verse(11));
    }

    [Fact()]
    public void Twelfth_day_twelve_drummers_drumming()
    {
        var expected = "On the twelfth day of Christmas my true love gave to me, twelve Drummers Drumming, eleven Pipers Piping, ten Lords-a-Leaping, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n";
        Assert.Equal(expected, TwelveDaysSong.Verse(12));
    }

    [Fact()]
    public void Recites_first_three_verses_of_the_song()
    {
        var expected = 
            "On the first day of Christmas my true love gave to me, a Partridge in a Pear Tree.\n\n" +
            "On the second day of Christmas my true love gave to me, two Turtle Doves, and a Partridge in a Pear Tree.\n\n" +
            "On the third day of Christmas my true love gave to me, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n\n";
        Assert.Equal(expected, TwelveDaysSong.Verses(1, 3));
    }

    [Fact()]
    public void Recites_three_verses_from_the_middle_of_the_song()
    {
        var expected = 
            "On the fourth day of Christmas my true love gave to me, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n\n" +
            "On the fifth day of Christmas my true love gave to me, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n\n" +
            "On the sixth day of Christmas my true love gave to me, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n\n";
        Assert.Equal(expected, TwelveDaysSong.Verses(4, 6));
    }

    [Fact()]
    public void Recites_the_whole_song()
    {
        var expected = 
            "On the first day of Christmas my true love gave to me, a Partridge in a Pear Tree.\n\n" +
            "On the second day of Christmas my true love gave to me, two Turtle Doves, and a Partridge in a Pear Tree.\n\n" +
            "On the third day of Christmas my true love gave to me, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n\n" +
            "On the fourth day of Christmas my true love gave to me, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n\n" +
            "On the fifth day of Christmas my true love gave to me, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n\n" +
            "On the sixth day of Christmas my true love gave to me, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n\n" +
            "On the seventh day of Christmas my true love gave to me, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n\n" +
            "On the eighth day of Christmas my true love gave to me, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n\n" +
            "On the ninth day of Christmas my true love gave to me, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n\n" +
            "On the tenth day of Christmas my true love gave to me, ten Lords-a-Leaping, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n\n" +
            "On the eleventh day of Christmas my true love gave to me, eleven Pipers Piping, ten Lords-a-Leaping, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n\n" +
            "On the twelfth day of Christmas my true love gave to me, twelve Drummers Drumming, eleven Pipers Piping, ten Lords-a-Leaping, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n\n";
        Assert.Equal(expected, TwelveDaysSong.Verses(1, 12));
    }
}