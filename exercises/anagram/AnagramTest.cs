// This file was auto-generated based on version 1.0.1 of the canonical data.

using Xunit;

public class AnagramTest
{
    [Fact]
    public void No_matches()
    {
        var candidates = 
        {
            hello
            world
            zombies
            pants
        };
        var sut = new Anagram("diaper");
        Assert.Empty(sut.Anagrams(candidates));
    }

    [Fact(Skip = "Remove to run test")]
    public void Detects_simple_anagram()
    {
        var candidates = 
        {
            tan
            stand
            at
        };
        var sut = new Anagram("ant");
        var expected = 
        {
            tan
        };
        Assert.Equal(expected, sut.Anagrams(candidates));
    }

    [Fact(Skip = "Remove to run test")]
    public void Does_not_detect_false_positives()
    {
        var candidates = 
        {
            eagle
        };
        var sut = new Anagram("galea");
        Assert.Empty(sut.Anagrams(candidates));
    }

    [Fact(Skip = "Remove to run test")]
    public void Detects_two_anagrams()
    {
        var candidates = 
        {
            stream
            pigeon
            maters
        };
        var sut = new Anagram("master");
        var expected = 
        {
            stream
            maters
        };
        Assert.Equal(expected, sut.Anagrams(candidates));
    }

    [Fact(Skip = "Remove to run test")]
    public void Does_not_detect_anagram_subsets()
    {
        var candidates = 
        {
            dog
            goody
        };
        var sut = new Anagram("good");
        Assert.Empty(sut.Anagrams(candidates));
    }

    [Fact(Skip = "Remove to run test")]
    public void Detects_anagram()
    {
        var candidates = 
        {
            enlists
            google
            inlets
            banana
        };
        var sut = new Anagram("listen");
        var expected = 
        {
            inlets
        };
        Assert.Equal(expected, sut.Anagrams(candidates));
    }

    [Fact(Skip = "Remove to run test")]
    public void Detects_three_anagrams()
    {
        var candidates = 
        {
            gallery
            ballerina
            regally
            clergy
            largely
            leading
        };
        var sut = new Anagram("allergy");
        var expected = 
        {
            gallery
            regally
            largely
        };
        Assert.Equal(expected, sut.Anagrams(candidates));
    }

    [Fact(Skip = "Remove to run test")]
    public void Does_not_detect_identical_words()
    {
        var candidates = 
        {
            corn
            dark
            Corn
            rank
            CORN
            cron
            park
        };
        var sut = new Anagram("corn");
        var expected = 
        {
            cron
        };
        Assert.Equal(expected, sut.Anagrams(candidates));
    }

    [Fact(Skip = "Remove to run test")]
    public void Does_not_detect_non_anagrams_with_identical_checksum()
    {
        var candidates = 
        {
            last
        };
        var sut = new Anagram("mass");
        Assert.Empty(sut.Anagrams(candidates));
    }

    [Fact(Skip = "Remove to run test")]
    public void Detects_anagrams_case_insensitively()
    {
        var candidates = 
        {
            cashregister
            Carthorse
            radishes
        };
        var sut = new Anagram("Orchestra");
        var expected = 
        {
            Carthorse
        };
        Assert.Equal(expected, sut.Anagrams(candidates));
    }

    [Fact(Skip = "Remove to run test")]
    public void Detects_anagrams_using_case_insensitive_subject()
    {
        var candidates = 
        {
            cashregister
            carthorse
            radishes
        };
        var sut = new Anagram("Orchestra");
        var expected = 
        {
            carthorse
        };
        Assert.Equal(expected, sut.Anagrams(candidates));
    }

    [Fact(Skip = "Remove to run test")]
    public void Detects_anagrams_using_case_insensitive_possible_matches()
    {
        var candidates = 
        {
            cashregister
            Carthorse
            radishes
        };
        var sut = new Anagram("orchestra");
        var expected = 
        {
            Carthorse
        };
        Assert.Equal(expected, sut.Anagrams(candidates));
    }

    [Fact(Skip = "Remove to run test")]
    public void Does_not_detect_a_word_as_its_own_anagram()
    {
        var candidates = 
        {
            Banana
        };
        var sut = new Anagram("banana");
        Assert.Empty(sut.Anagrams(candidates));
    }

    [Fact(Skip = "Remove to run test")]
    public void Does_not_detect_a_anagram_if_the_original_word_is_repeated()
    {
        var candidates = 
        {
            go Go GO
        };
        var sut = new Anagram("go");
        Assert.Empty(sut.Anagrams(candidates));
    }

    [Fact(Skip = "Remove to run test")]
    public void Anagrams_must_use_all_letters_exactly_once()
    {
        var candidates = 
        {
            patter
        };
        var sut = new Anagram("tapper");
        Assert.Empty(sut.Anagrams(candidates));
    }

    [Fact(Skip = "Remove to run test")]
    public void Capital_word_is_not_own_anagram()
    {
        var candidates = 
        {
            Banana
        };
        var sut = new Anagram("BANANA");
        Assert.Empty(sut.Anagrams(candidates));
    }
}