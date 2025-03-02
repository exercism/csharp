record Artist(string Name);
record Album(string Title, int Year, Artist Artist);

class Collection
{
    public Collection(int size)
    {
        for (var i = 1; i <= size; i++)
        {
            for (var j = 1; j <= i; j++)
            {
                Artist artist = new("Artist " + i);
                Albums.Add(new Album("Album " + j, 2000 + j, artist));    
            }
            Artists.Add(new("Artist " + i));
        }
    }
    
    public List<Album> Albums { get; } = new();
    public List<Artist> Artists { get; } = new();
}
