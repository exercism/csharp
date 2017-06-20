// This file was auto-generated based on version 1.0.0 of the canonical data.

using Xunit;

public class FoodChainTest
{
    [Fact]
    public void Fly()
    {
        Assert.Equal("I know an old lady who swallowed a fly.\nI don't know why she swallowed the fly. Perhaps she'll die.", FoodChain.Verse(1));
    }

    [Fact(Skip = "Remove to run test")]
    public void Spider()
    {
        Assert.Equal("I know an old lady who swallowed a spider.\nIt wriggled and jiggled and tickled inside her.\nShe swallowed the spider to catch the fly.\nI don't know why she swallowed the fly. Perhaps she'll die.", FoodChain.Verse(2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Bird()
    {
        Assert.Equal("I know an old lady who swallowed a bird.\nHow absurd to swallow a bird!\nShe swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.\nShe swallowed the spider to catch the fly.\nI don't know why she swallowed the fly. Perhaps she'll die.", FoodChain.Verse(3));
    }

    [Fact(Skip = "Remove to run test")]
    public void Cat()
    {
        Assert.Equal("I know an old lady who swallowed a cat.\nImagine that, to swallow a cat!\nShe swallowed the cat to catch the bird.\nShe swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.\nShe swallowed the spider to catch the fly.\nI don't know why she swallowed the fly. Perhaps she'll die.", FoodChain.Verse(4));
    }

    [Fact(Skip = "Remove to run test")]
    public void Dog()
    {
        Assert.Equal("I know an old lady who swallowed a dog.\nWhat a hog, to swallow a dog!\nShe swallowed the dog to catch the cat.\nShe swallowed the cat to catch the bird.\nShe swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.\nShe swallowed the spider to catch the fly.\nI don't know why she swallowed the fly. Perhaps she'll die.", FoodChain.Verse(5));
    }

    [Fact(Skip = "Remove to run test")]
    public void Goat()
    {
        Assert.Equal("I know an old lady who swallowed a goat.\nJust opened her throat and swallowed a goat!\nShe swallowed the goat to catch the dog.\nShe swallowed the dog to catch the cat.\nShe swallowed the cat to catch the bird.\nShe swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.\nShe swallowed the spider to catch the fly.\nI don't know why she swallowed the fly. Perhaps she'll die.", FoodChain.Verse(6));
    }

    [Fact(Skip = "Remove to run test")]
    public void Cow()
    {
        Assert.Equal("I know an old lady who swallowed a cow.\nI don't know how she swallowed a cow!\nShe swallowed the cow to catch the goat.\nShe swallowed the goat to catch the dog.\nShe swallowed the dog to catch the cat.\nShe swallowed the cat to catch the bird.\nShe swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.\nShe swallowed the spider to catch the fly.\nI don't know why she swallowed the fly. Perhaps she'll die.", FoodChain.Verse(7));
    }

    [Fact(Skip = "Remove to run test")]
    public void Horse()
    {
        Assert.Equal("I know an old lady who swallowed a horse.\nShe's dead, of course!", FoodChain.Verse(8));
    }

    [Fact(Skip = "Remove to run test")]
    public void Multiple_verses()
    {
        Assert.Equal("I know an old lady who swallowed a fly.\nI don't know why she swallowed the fly. Perhaps she'll die.\n\nI know an old lady who swallowed a spider.\nIt wriggled and jiggled and tickled inside her.\nShe swallowed the spider to catch the fly.\nI don't know why she swallowed the fly. Perhaps she'll die.\n\nI know an old lady who swallowed a bird.\nHow absurd to swallow a bird!\nShe swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.\nShe swallowed the spider to catch the fly.\nI don't know why she swallowed the fly. Perhaps she'll die.", FoodChain.Verse(1, 3));
    }

    [Fact(Skip = "Remove to run test")]
    public void Full_song()
    {
        Assert.Equal("I know an old lady who swallowed a fly.\nI don't know why she swallowed the fly. Perhaps she'll die.\n\nI know an old lady who swallowed a spider.\nIt wriggled and jiggled and tickled inside her.\nShe swallowed the spider to catch the fly.\nI don't know why she swallowed the fly. Perhaps she'll die.\n\nI know an old lady who swallowed a bird.\nHow absurd to swallow a bird!\nShe swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.\nShe swallowed the spider to catch the fly.\nI don't know why she swallowed the fly. Perhaps she'll die.\n\nI know an old lady who swallowed a cat.\nImagine that, to swallow a cat!\nShe swallowed the cat to catch the bird.\nShe swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.\nShe swallowed the spider to catch the fly.\nI don't know why she swallowed the fly. Perhaps she'll die.\n\nI know an old lady who swallowed a dog.\nWhat a hog, to swallow a dog!\nShe swallowed the dog to catch the cat.\nShe swallowed the cat to catch the bird.\nShe swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.\nShe swallowed the spider to catch the fly.\nI don't know why she swallowed the fly. Perhaps she'll die.\n\nI know an old lady who swallowed a goat.\nJust opened her throat and swallowed a goat!\nShe swallowed the goat to catch the dog.\nShe swallowed the dog to catch the cat.\nShe swallowed the cat to catch the bird.\nShe swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.\nShe swallowed the spider to catch the fly.\nI don't know why she swallowed the fly. Perhaps she'll die.\n\nI know an old lady who swallowed a cow.\nI don't know how she swallowed a cow!\nShe swallowed the cow to catch the goat.\nShe swallowed the goat to catch the dog.\nShe swallowed the dog to catch the cat.\nShe swallowed the cat to catch the bird.\nShe swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.\nShe swallowed the spider to catch the fly.\nI don't know why she swallowed the fly. Perhaps she'll die.\n\nI know an old lady who swallowed a horse.\nShe's dead, of course!", FoodChain.Verse(1, 8));
    }
}