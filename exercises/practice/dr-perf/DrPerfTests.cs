public class DrPerfTests
{
    [Fact]
    public void CollectionCreatesCorrectNumberOfArtists()
    {
        var collection = new Collection(6);
        Assert.Equal(6, collection.Artists.Count);
    }

    [Fact]
    public void CollectionCreatesCorrectNumberOfAlbums()
    {
        var collection = new Collection(5);
        Assert.Equal(15, collection.Albums.Count);
    }

    [Fact]
    public void NthArtistHasNAlbums()
    {
        var collection = new Collection(3);
        Assert.All(collection.Albums[..1], album => Assert.Equal(collection.Artists[0], album.Artist));
        Assert.All(collection.Albums[1..3], album => Assert.Equal(collection.Artists[1], album.Artist));
        Assert.All(collection.Albums[3..6], album => Assert.Equal(collection.Artists[2], album.Artist));
    }

    [Fact]
    public void EachArtistHasUniqueAlbumTitles()
    {
        var collection = new Collection(3);
        Assert.Equal(1, collection.Albums[..1].Select(album => album.Title).Distinct().Count());
        Assert.Equal(2, collection.Albums[1..3].Select(album => album.Title).Distinct().Count());
        Assert.Equal(3, collection.Albums[3..6].Select(album => album.Title).Distinct().Count());
    }

    [Fact]
    public void EachArtistHasUniqueName()
    {
        var collection = new Collection(3);
        Assert.Equal(3, collection.Artists.Select(artist => artist.Name).Distinct().Count());
    }
}
