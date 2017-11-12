// This file was auto-generated based on version 2.0.0 of the canonical data.

using Xunit;

public class HouseTest
{
    [Fact]
    public void Verse_one_the_house_that_jack_built()
    {
        var expected = "This is the house that Jack built.";
        Assert.Equal(expected, House.Recite(1, 1));
    }

    [Fact(Skip = "Remove to run test")]
    public void Verse_two_the_malt_that_lay()
    {
        var expected = 
            "This is the malt\n" +
            "that lay in the house that Jack built.";
        Assert.Equal(expected, House.Recite(2, 2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Verse_three_the_rat_that_ate()
    {
        var expected = 
            "This is the rat\n" +
            "that ate the malt\n" +
            "that lay in the house that Jack built.";
        Assert.Equal(expected, House.Recite(3, 3));
    }

    [Fact(Skip = "Remove to run test")]
    public void Verse_four_the_cat_that_killed()
    {
        var expected = 
            "This is the cat\n" +
            "that killed the rat\n" +
            "that ate the malt\n" +
            "that lay in the house that Jack built.";
        Assert.Equal(expected, House.Recite(4, 4));
    }

    [Fact(Skip = "Remove to run test")]
    public void Verse_five_the_dog_that_worried()
    {
        var expected = 
            "This is the dog\n" +
            "that worried the cat\n" +
            "that killed the rat\n" +
            "that ate the malt\n" +
            "that lay in the house that Jack built.";
        Assert.Equal(expected, House.Recite(5, 5));
    }

    [Fact(Skip = "Remove to run test")]
    public void Verse_six_the_cow_with_the_crumpled_horn()
    {
        var expected = 
            "This is the cow with the crumpled horn\n" +
            "that tossed the dog\n" +
            "that worried the cat\n" +
            "that killed the rat\n" +
            "that ate the malt\n" +
            "that lay in the house that Jack built.";
        Assert.Equal(expected, House.Recite(6, 6));
    }

    [Fact(Skip = "Remove to run test")]
    public void Verse_seven_the_maiden_all_forlorn()
    {
        var expected = 
            "This is the maiden all forlorn\n" +
            "that milked the cow with the crumpled horn\n" +
            "that tossed the dog\n" +
            "that worried the cat\n" +
            "that killed the rat\n" +
            "that ate the malt\n" +
            "that lay in the house that Jack built.";
        Assert.Equal(expected, House.Recite(7, 7));
    }

    [Fact(Skip = "Remove to run test")]
    public void Verse_eight_the_man_all_tattered_and_torn()
    {
        var expected = 
            "This is the man all tattered and torn\n" +
            "that kissed the maiden all forlorn\n" +
            "that milked the cow with the crumpled horn\n" +
            "that tossed the dog\n" +
            "that worried the cat\n" +
            "that killed the rat\n" +
            "that ate the malt\n" +
            "that lay in the house that Jack built.";
        Assert.Equal(expected, House.Recite(8, 8));
    }

    [Fact(Skip = "Remove to run test")]
    public void Verse_nine_the_priest_all_shaven_and_shorn()
    {
        var expected = 
            "This is the priest all shaven and shorn\n" +
            "that married the man all tattered and torn\n" +
            "that kissed the maiden all forlorn\n" +
            "that milked the cow with the crumpled horn\n" +
            "that tossed the dog\n" +
            "that worried the cat\n" +
            "that killed the rat\n" +
            "that ate the malt\n" +
            "that lay in the house that Jack built.";
        Assert.Equal(expected, House.Recite(9, 9));
    }

    [Fact(Skip = "Remove to run test")]
    public void Verse_10_the_rooster_that_crowed_in_the_morn()
    {
        var expected = 
            "This is the rooster that crowed in the morn\n" +
            "that woke the priest all shaven and shorn\n" +
            "that married the man all tattered and torn\n" +
            "that kissed the maiden all forlorn\n" +
            "that milked the cow with the crumpled horn\n" +
            "that tossed the dog\n" +
            "that worried the cat\n" +
            "that killed the rat\n" +
            "that ate the malt\n" +
            "that lay in the house that Jack built.";
        Assert.Equal(expected, House.Recite(10, 10));
    }

    [Fact(Skip = "Remove to run test")]
    public void Verse_11_the_farmer_sowing_his_corn()
    {
        var expected = 
            "This is the farmer sowing his corn\n" +
            "that kept the rooster that crowed in the morn\n" +
            "that woke the priest all shaven and shorn\n" +
            "that married the man all tattered and torn\n" +
            "that kissed the maiden all forlorn\n" +
            "that milked the cow with the crumpled horn\n" +
            "that tossed the dog\n" +
            "that worried the cat\n" +
            "that killed the rat\n" +
            "that ate the malt\n" +
            "that lay in the house that Jack built.";
        Assert.Equal(expected, House.Recite(11, 11));
    }

    [Fact(Skip = "Remove to run test")]
    public void Verse_12_the_horse_and_the_hound_and_the_horn()
    {
        var expected = 
            "This is the horse and the hound and the horn\n" +
            "that belonged to the farmer sowing his corn\n" +
            "that kept the rooster that crowed in the morn\n" +
            "that woke the priest all shaven and shorn\n" +
            "that married the man all tattered and torn\n" +
            "that kissed the maiden all forlorn\n" +
            "that milked the cow with the crumpled horn\n" +
            "that tossed the dog\n" +
            "that worried the cat\n" +
            "that killed the rat\n" +
            "that ate the malt\n" +
            "that lay in the house that Jack built.";
        Assert.Equal(expected, House.Recite(12, 12));
    }

    [Fact(Skip = "Remove to run test")]
    public void Multiple_verses()
    {
        var expected = 
            "This is the cat\n" +
            "that killed the rat\n" +
            "that ate the malt\n" +
            "that lay in the house that Jack built.\n" +
            "\n" +
            "This is the dog\n" +
            "that worried the cat\n" +
            "that killed the rat\n" +
            "that ate the malt\n" +
            "that lay in the house that Jack built.\n" +
            "\n" +
            "This is the cow with the crumpled horn\n" +
            "that tossed the dog\n" +
            "that worried the cat\n" +
            "that killed the rat\n" +
            "that ate the malt\n" +
            "that lay in the house that Jack built.\n" +
            "\n" +
            "This is the maiden all forlorn\n" +
            "that milked the cow with the crumpled horn\n" +
            "that tossed the dog\n" +
            "that worried the cat\n" +
            "that killed the rat\n" +
            "that ate the malt\n" +
            "that lay in the house that Jack built.\n" +
            "\n" +
            "This is the man all tattered and torn\n" +
            "that kissed the maiden all forlorn\n" +
            "that milked the cow with the crumpled horn\n" +
            "that tossed the dog\n" +
            "that worried the cat\n" +
            "that killed the rat\n" +
            "that ate the malt\n" +
            "that lay in the house that Jack built.";
        Assert.Equal(expected, House.Recite(4, 8));
    }

    [Fact(Skip = "Remove to run test")]
    public void Full_rhyme()
    {
        var expected = 
            "This is the house that Jack built.\n" +
            "\n" +
            "This is the malt\n" +
            "that lay in the house that Jack built.\n" +
            "\n" +
            "This is the rat\n" +
            "that ate the malt\n" +
            "that lay in the house that Jack built.\n" +
            "\n" +
            "This is the cat\n" +
            "that killed the rat\n" +
            "that ate the malt\n" +
            "that lay in the house that Jack built.\n" +
            "\n" +
            "This is the dog\n" +
            "that worried the cat\n" +
            "that killed the rat\n" +
            "that ate the malt\n" +
            "that lay in the house that Jack built.\n" +
            "\n" +
            "This is the cow with the crumpled horn\n" +
            "that tossed the dog\n" +
            "that worried the cat\n" +
            "that killed the rat\n" +
            "that ate the malt\n" +
            "that lay in the house that Jack built.\n" +
            "\n" +
            "This is the maiden all forlorn\n" +
            "that milked the cow with the crumpled horn\n" +
            "that tossed the dog\n" +
            "that worried the cat\n" +
            "that killed the rat\n" +
            "that ate the malt\n" +
            "that lay in the house that Jack built.\n" +
            "\n" +
            "This is the man all tattered and torn\n" +
            "that kissed the maiden all forlorn\n" +
            "that milked the cow with the crumpled horn\n" +
            "that tossed the dog\n" +
            "that worried the cat\n" +
            "that killed the rat\n" +
            "that ate the malt\n" +
            "that lay in the house that Jack built.\n" +
            "\n" +
            "This is the priest all shaven and shorn\n" +
            "that married the man all tattered and torn\n" +
            "that kissed the maiden all forlorn\n" +
            "that milked the cow with the crumpled horn\n" +
            "that tossed the dog\n" +
            "that worried the cat\n" +
            "that killed the rat\n" +
            "that ate the malt\n" +
            "that lay in the house that Jack built.\n" +
            "\n" +
            "This is the rooster that crowed in the morn\n" +
            "that woke the priest all shaven and shorn\n" +
            "that married the man all tattered and torn\n" +
            "that kissed the maiden all forlorn\n" +
            "that milked the cow with the crumpled horn\n" +
            "that tossed the dog\n" +
            "that worried the cat\n" +
            "that killed the rat\n" +
            "that ate the malt\n" +
            "that lay in the house that Jack built.\n" +
            "\n" +
            "This is the farmer sowing his corn\n" +
            "that kept the rooster that crowed in the morn\n" +
            "that woke the priest all shaven and shorn\n" +
            "that married the man all tattered and torn\n" +
            "that kissed the maiden all forlorn\n" +
            "that milked the cow with the crumpled horn\n" +
            "that tossed the dog\n" +
            "that worried the cat\n" +
            "that killed the rat\n" +
            "that ate the malt\n" +
            "that lay in the house that Jack built.\n" +
            "\n" +
            "This is the horse and the hound and the horn\n" +
            "that belonged to the farmer sowing his corn\n" +
            "that kept the rooster that crowed in the morn\n" +
            "that woke the priest all shaven and shorn\n" +
            "that married the man all tattered and torn\n" +
            "that kissed the maiden all forlorn\n" +
            "that milked the cow with the crumpled horn\n" +
            "that tossed the dog\n" +
            "that worried the cat\n" +
            "that killed the rat\n" +
            "that ate the malt\n" +
            "that lay in the house that Jack built.";
        Assert.Equal(expected, House.Recite(1, 12));
    }
}