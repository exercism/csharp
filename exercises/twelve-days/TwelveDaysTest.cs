// This file was auto-generated based on version 1.1.0 of the canonical data.

using Xunit;

public class TwelveDaysTest
{
    [Fact]
    public void First_day_a_partridge_in_a_pear_tree()
    {
        var expected = "On the first day of Christmas my true love gave to me, a Partridge in a Pear Tree.";
        Assert.Equal(expected, TwelveDays.Recite(1));
    }

    [Fact(Skip = "Remove to run test")]
    public void Second_day_two_turtle_doves()
    {
        var expected = "On the second day of Christmas my true love gave to me, two Turtle Doves, and a Partridge in a Pear Tree.";
        Assert.Equal(expected, TwelveDays.Recite(2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Third_day_three_french_hens()
    {
        var expected = "On the third day of Christmas my true love gave to me, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.";
        Assert.Equal(expected, TwelveDays.Recite(3));
    }

    [Fact(Skip = "Remove to run test")]
    public void Fourth_day_four_calling_birds()
    {
        var expected = "On the fourth day of Christmas my true love gave to me, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.";
        Assert.Equal(expected, TwelveDays.Recite(4));
    }

    [Fact(Skip = "Remove to run test")]
    public void Fifth_day_five_gold_rings()
    {
        var expected = "On the fifth day of Christmas my true love gave to me, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.";
        Assert.Equal(expected, TwelveDays.Recite(5));
    }

    [Fact(Skip = "Remove to run test")]
    public void Sixth_day_six_geese_a_laying()
    {
        var expected = "On the sixth day of Christmas my true love gave to me, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.";
        Assert.Equal(expected, TwelveDays.Recite(6));
    }

    [Fact(Skip = "Remove to run test")]
    public void Seventh_day_seven_swans_a_swimming()
    {
        var expected = "On the seventh day of Christmas my true love gave to me, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.";
        Assert.Equal(expected, TwelveDays.Recite(7));
    }

    [Fact(Skip = "Remove to run test")]
    public void Eighth_day_eight_maids_a_milking()
    {
        var expected = "On the eighth day of Christmas my true love gave to me, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.";
        Assert.Equal(expected, TwelveDays.Recite(8));
    }

    [Fact(Skip = "Remove to run test")]
    public void Ninth_day_nine_ladies_dancing()
    {
        var expected = "On the ninth day of Christmas my true love gave to me, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.";
        Assert.Equal(expected, TwelveDays.Recite(9));
    }

    [Fact(Skip = "Remove to run test")]
    public void Tenth_day_ten_lords_a_leaping()
    {
        var expected = "On the tenth day of Christmas my true love gave to me, ten Lords-a-Leaping, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.";
        Assert.Equal(expected, TwelveDays.Recite(10));
    }

    [Fact(Skip = "Remove to run test")]
    public void Eleventh_day_eleven_pipers_piping()
    {
        var expected = "On the eleventh day of Christmas my true love gave to me, eleven Pipers Piping, ten Lords-a-Leaping, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.";
        Assert.Equal(expected, TwelveDays.Recite(11));
    }

    [Fact(Skip = "Remove to run test")]
    public void Twelfth_day_twelve_drummers_drumming()
    {
        var expected = "On the twelfth day of Christmas my true love gave to me, twelve Drummers Drumming, eleven Pipers Piping, ten Lords-a-Leaping, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.";
        Assert.Equal(expected, TwelveDays.Recite(12));
    }

    [Fact(Skip = "Remove to run test")]
    public void Recites_first_three_verses_of_the_song()
    {
        var expected = 
            "On the first day of Christmas my true love gave to me, a Partridge in a Pear Tree.\n" +
            "On the second day of Christmas my true love gave to me, two Turtle Doves, and a Partridge in a Pear Tree.\n" +
            "On the third day of Christmas my true love gave to me, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.";
        Assert.Equal(expected, TwelveDays.Recite(1, 3));
    }

    [Fact(Skip = "Remove to run test")]
    public void Recites_three_verses_from_the_middle_of_the_song()
    {
        var expected = 
            "On the fourth day of Christmas my true love gave to me, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n" +
            "On the fifth day of Christmas my true love gave to me, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n" +
            "On the sixth day of Christmas my true love gave to me, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.";
        Assert.Equal(expected, TwelveDays.Recite(4, 6));
    }

    [Fact(Skip = "Remove to run test")]
    public void Recites_the_whole_song()
    {
        var expected = 
            "On the first day of Christmas my true love gave to me, a Partridge in a Pear Tree.\n" +
            "On the second day of Christmas my true love gave to me, two Turtle Doves, and a Partridge in a Pear Tree.\n" +
            "On the third day of Christmas my true love gave to me, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n" +
            "On the fourth day of Christmas my true love gave to me, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n" +
            "On the fifth day of Christmas my true love gave to me, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n" +
            "On the sixth day of Christmas my true love gave to me, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n" +
            "On the seventh day of Christmas my true love gave to me, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n" +
            "On the eighth day of Christmas my true love gave to me, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n" +
            "On the ninth day of Christmas my true love gave to me, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n" +
            "On the tenth day of Christmas my true love gave to me, ten Lords-a-Leaping, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n" +
            "On the eleventh day of Christmas my true love gave to me, eleven Pipers Piping, ten Lords-a-Leaping, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n" +
            "On the twelfth day of Christmas my true love gave to me, twelve Drummers Drumming, eleven Pipers Piping, ten Lords-a-Leaping, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.";
        Assert.Equal(expected, TwelveDays.Recite(1, 12));
    }
}