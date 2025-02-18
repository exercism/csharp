using Xunit;

public class BottleSongTests
{
    [Fact]
    public void Verse_single_verse_first_generic_verse()
    {
        Assert.Equal(["Ten green bottles hanging on the wall,", "Ten green bottles hanging on the wall,", "And if one green bottle should accidentally fall,", "There'll be nine green bottles hanging on the wall."], BottleSong.Recite(10, 1));
    }

    [Fact]
    public void Verse_single_verse_last_generic_verse()
    {
        Assert.Equal(["Three green bottles hanging on the wall,", "Three green bottles hanging on the wall,", "And if one green bottle should accidentally fall,", "There'll be two green bottles hanging on the wall."], BottleSong.Recite(3, 1));
    }

    [Fact]
    public void Verse_single_verse_verse_with_2_bottles()
    {
        Assert.Equal(["Two green bottles hanging on the wall,", "Two green bottles hanging on the wall,", "And if one green bottle should accidentally fall,", "There'll be one green bottle hanging on the wall."], BottleSong.Recite(2, 1));
    }

    [Fact]
    public void Verse_single_verse_verse_with_1_bottle()
    {
        Assert.Equal(["One green bottle hanging on the wall,", "One green bottle hanging on the wall,", "And if one green bottle should accidentally fall,", "There'll be no green bottles hanging on the wall."], BottleSong.Recite(1, 1));
    }

    [Fact]
    public void Lyrics_multiple_verses_first_two_verses()
    {
        Assert.Equal(["Ten green bottles hanging on the wall,", "Ten green bottles hanging on the wall,", "And if one green bottle should accidentally fall,", "There'll be nine green bottles hanging on the wall.", "", "Nine green bottles hanging on the wall,", "Nine green bottles hanging on the wall,", "And if one green bottle should accidentally fall,", "There'll be eight green bottles hanging on the wall."], BottleSong.Recite(10, 2));
    }

    [Fact]
    public void Lyrics_multiple_verses_last_three_verses()
    {
        Assert.Equal(["Three green bottles hanging on the wall,", "Three green bottles hanging on the wall,", "And if one green bottle should accidentally fall,", "There'll be two green bottles hanging on the wall.", "", "Two green bottles hanging on the wall,", "Two green bottles hanging on the wall,", "And if one green bottle should accidentally fall,", "There'll be one green bottle hanging on the wall.", "", "One green bottle hanging on the wall,", "One green bottle hanging on the wall,", "And if one green bottle should accidentally fall,", "There'll be no green bottles hanging on the wall."], BottleSong.Recite(3, 3));
    }

    [Fact]
    public void Lyrics_multiple_verses_all_verses()
    {
        Assert.Equal(["Ten green bottles hanging on the wall,", "Ten green bottles hanging on the wall,", "And if one green bottle should accidentally fall,", "There'll be nine green bottles hanging on the wall.", "", "Nine green bottles hanging on the wall,", "Nine green bottles hanging on the wall,", "And if one green bottle should accidentally fall,", "There'll be eight green bottles hanging on the wall.", "", "Eight green bottles hanging on the wall,", "Eight green bottles hanging on the wall,", "And if one green bottle should accidentally fall,", "There'll be seven green bottles hanging on the wall.", "", "Seven green bottles hanging on the wall,", "Seven green bottles hanging on the wall,", "And if one green bottle should accidentally fall,", "There'll be six green bottles hanging on the wall.", "", "Six green bottles hanging on the wall,", "Six green bottles hanging on the wall,", "And if one green bottle should accidentally fall,", "There'll be five green bottles hanging on the wall.", "", "Five green bottles hanging on the wall,", "Five green bottles hanging on the wall,", "And if one green bottle should accidentally fall,", "There'll be four green bottles hanging on the wall.", "", "Four green bottles hanging on the wall,", "Four green bottles hanging on the wall,", "And if one green bottle should accidentally fall,", "There'll be three green bottles hanging on the wall.", "", "Three green bottles hanging on the wall,", "Three green bottles hanging on the wall,", "And if one green bottle should accidentally fall,", "There'll be two green bottles hanging on the wall.", "", "Two green bottles hanging on the wall,", "Two green bottles hanging on the wall,", "And if one green bottle should accidentally fall,", "There'll be one green bottle hanging on the wall.", "", "One green bottle hanging on the wall,", "One green bottle hanging on the wall,", "And if one green bottle should accidentally fall,", "There'll be no green bottles hanging on the wall."], BottleSong.Recite(10, 10));
    }
}
