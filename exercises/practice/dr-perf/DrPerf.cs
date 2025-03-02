record Artist(string Name);
record Album(string Title, int Year, Artist artist);

class Collection
{
    public Collection(int size)
    {
        for (var i = 1; i <= size; i++)
        {
            for (var j = 1; j <= i; j++)
            {
                Artist artist = new("Artist " + i);
                Albums.Add(new Album("Album " + i, 2000 + i, artist));    
            }
        }
    }
    
    public List<Album> Albums { get; } = new();
}
