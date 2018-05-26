// This file was auto-generated based on version 2.1.0 of the canonical data.

using Xunit;

public class FoodChainTest
{
    [Fact]
    public void Fly()
    {
        var expected = 
            "I know an old lady who swallowed a fly.\n" +
            "I don't know why she swallowed the fly. Perhaps she'll die.";
        Assert.Equal(expected, FoodChain.Recite(1));
    }

    [Fact(Skip = "Remove to run test")]
    public void Spider()
    {
        var expected = 
            "I know an old lady who swallowed a spider.\n" +
            "It wriggled and jiggled and tickled inside her.\n" +
            "She swallowed the spider to catch the fly.\n" +
            "I don't know why she swallowed the fly. Perhaps she'll die.";
        Assert.Equal(expected, FoodChain.Recite(2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Bird()
    {
        var expected = 
            "I know an old lady who swallowed a bird.\n" +
            "How absurd to swallow a bird!\n" +
            "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.\n" +
            "She swallowed the spider to catch the fly.\n" +
            "I don't know why she swallowed the fly. Perhaps she'll die.";
        Assert.Equal(expected, FoodChain.Recite(3));
    }

    [Fact(Skip = "Remove to run test")]
    public void Cat()
    {
        var expected = 
            "I know an old lady who swallowed a cat.\n" +
            "Imagine that, to swallow a cat!\n" +
            "She swallowed the cat to catch the bird.\n" +
            "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.\n" +
            "She swallowed the spider to catch the fly.\n" +
            "I don't know why she swallowed the fly. Perhaps she'll die.";
        Assert.Equal(expected, FoodChain.Recite(4));
    }

    [Fact(Skip = "Remove to run test")]
    public void Dog()
    {
        var expected = 
            "I know an old lady who swallowed a dog.\n" +
            "What a hog, to swallow a dog!\n" +
            "She swallowed the dog to catch the cat.\n" +
            "She swallowed the cat to catch the bird.\n" +
            "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.\n" +
            "She swallowed the spider to catch the fly.\n" +
            "I don't know why she swallowed the fly. Perhaps she'll die.";
        Assert.Equal(expected, FoodChain.Recite(5));
    }

    [Fact(Skip = "Remove to run test")]
    public void Goat()
    {
        var expected = 
            "I know an old lady who swallowed a goat.\n" +
            "Just opened her throat and swallowed a goat!\n" +
            "She swallowed the goat to catch the dog.\n" +
            "She swallowed the dog to catch the cat.\n" +
            "She swallowed the cat to catch the bird.\n" +
            "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.\n" +
            "She swallowed the spider to catch the fly.\n" +
            "I don't know why she swallowed the fly. Perhaps she'll die.";
        Assert.Equal(expected, FoodChain.Recite(6));
    }

    [Fact(Skip = "Remove to run test")]
    public void Cow()
    {
        var expected = 
            "I know an old lady who swallowed a cow.\n" +
            "I don't know how she swallowed a cow!\n" +
            "She swallowed the cow to catch the goat.\n" +
            "She swallowed the goat to catch the dog.\n" +
            "She swallowed the dog to catch the cat.\n" +
            "She swallowed the cat to catch the bird.\n" +
            "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.\n" +
            "She swallowed the spider to catch the fly.\n" +
            "I don't know why she swallowed the fly. Perhaps she'll die.";
        Assert.Equal(expected, FoodChain.Recite(7));
    }

    [Fact(Skip = "Remove to run test")]
    public void Horse()
    {
        var expected = 
            "I know an old lady who swallowed a horse.\n" +
            "She's dead, of course!";
        Assert.Equal(expected, FoodChain.Recite(8));
    }

    [Fact(Skip = "Remove to run test")]
    public void Multiple_verses()
    {
        var expected = 
            "I know an old lady who swallowed a fly.\n" +
            "I don't know why she swallowed the fly. Perhaps she'll die.\n" +
            "\n" +
            "I know an old lady who swallowed a spider.\n" +
            "It wriggled and jiggled and tickled inside her.\n" +
            "She swallowed the spider to catch the fly.\n" +
            "I don't know why she swallowed the fly. Perhaps she'll die.\n" +
            "\n" +
            "I know an old lady who swallowed a bird.\n" +
            "How absurd to swallow a bird!\n" +
            "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.\n" +
            "She swallowed the spider to catch the fly.\n" +
            "I don't know why she swallowed the fly. Perhaps she'll die.";
        Assert.Equal(expected, FoodChain.Recite(1, 3));
    }

    [Fact(Skip = "Remove to run test")]
    public void Full_song()
    {
        var expected = 
            "I know an old lady who swallowed a fly.\n" +
            "I don't know why she swallowed the fly. Perhaps she'll die.\n" +
            "\n" +
            "I know an old lady who swallowed a spider.\n" +
            "It wriggled and jiggled and tickled inside her.\n" +
            "She swallowed the spider to catch the fly.\n" +
            "I don't know why she swallowed the fly. Perhaps she'll die.\n" +
            "\n" +
            "I know an old lady who swallowed a bird.\n" +
            "How absurd to swallow a bird!\n" +
            "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.\n" +
            "She swallowed the spider to catch the fly.\n" +
            "I don't know why she swallowed the fly. Perhaps she'll die.\n" +
            "\n" +
            "I know an old lady who swallowed a cat.\n" +
            "Imagine that, to swallow a cat!\n" +
            "She swallowed the cat to catch the bird.\n" +
            "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.\n" +
            "She swallowed the spider to catch the fly.\n" +
            "I don't know why she swallowed the fly. Perhaps she'll die.\n" +
            "\n" +
            "I know an old lady who swallowed a dog.\n" +
            "What a hog, to swallow a dog!\n" +
            "She swallowed the dog to catch the cat.\n" +
            "She swallowed the cat to catch the bird.\n" +
            "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.\n" +
            "She swallowed the spider to catch the fly.\n" +
            "I don't know why she swallowed the fly. Perhaps she'll die.\n" +
            "\n" +
            "I know an old lady who swallowed a goat.\n" +
            "Just opened her throat and swallowed a goat!\n" +
            "She swallowed the goat to catch the dog.\n" +
            "She swallowed the dog to catch the cat.\n" +
            "She swallowed the cat to catch the bird.\n" +
            "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.\n" +
            "She swallowed the spider to catch the fly.\n" +
            "I don't know why she swallowed the fly. Perhaps she'll die.\n" +
            "\n" +
            "I know an old lady who swallowed a cow.\n" +
            "I don't know how she swallowed a cow!\n" +
            "She swallowed the cow to catch the goat.\n" +
            "She swallowed the goat to catch the dog.\n" +
            "She swallowed the dog to catch the cat.\n" +
            "She swallowed the cat to catch the bird.\n" +
            "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.\n" +
            "She swallowed the spider to catch the fly.\n" +
            "I don't know why she swallowed the fly. Perhaps she'll die.\n" +
            "\n" +
            "I know an old lady who swallowed a horse.\n" +
            "She's dead, of course!";
        Assert.Equal(expected, FoodChain.Recite(1, 8));
    }
}