// This file was auto-generated based on version 1.0.1 of the canonical data.

using Xunit;

public class AnagramTest
{
    [Fact]
    public void No_matches()
    {
        var candidates = new[] { "hello", "world", "zombies", "pants" };
        var sut = new Anagram("diaper");
        Assert.Empty(sut.Anagrams(candidates));
    }

    [Fact(Skip = "Remove to run test")]
    public void Detects_simple_anagram()
    {
        var candidates = new[] { "tan", "stand", "at" };
        var sut = new Anagram("ant");
        var expected = new[] { "tan" };
        Assert.Equal(expected, sut.Anagrams(candidates));
    }

    [Fact(Skip = "Remove to run test")]
    public void Does_not_detect_false_positives()
    {
        var candidates = new[] { "eagle" };
        var sut = new Anagram("galea");
        Assert.Empty(sut.Anagrams(candidates));
    }

    [Fact(Skip = "Remove to run test")]
    public void Detects_two_anagrams()
    {
        var candidates = new[] { "stream", "pigeon", "maters" };
        var sut = new Anagram("master");
        var expected = new[] { "stream", "maters" };
        Assert.Equal(expected, sut.Anagrams(candidates));
    }

    [Fact(Skip = "Remove to run test")]
    public void Does_not_detect_anagram_subsets()
    {
        var candidates = new[] { "dog", "goody" };
        var sut = new Anagram("good");
        Assert.Empty(sut.Anagrams(candidates));
    }

    [Fact(Skip = "Remove to run test")]
    public void Detects_anagram()
    {
        var candidates = new[] { "enlists", "google", "inlets", "banana" };
        var sut = new Anagram("listen");
        var expected = new[] { "inlets" };
        Assert.Equal(expected, sut.Anagrams(candidates));
    }

    [Fact(Skip = "Remove to run test")]
    public void Detects_three_anagrams()
    {
        var candidates = new[] { "gallery", "ballerina", "regally", "clergy", "largely", "leading" };
        var sut = new Anagram("allergy");
        var expected = new[] { "gallery", "regally", "largely" };
        Assert.Equal(expected, sut.Anagrams(candidates));
    }

    [Fact(Skip = "Remove to run test")]
    public void Does_not_detect_identical_words()
    {
        var candidates = new[] { "corn", "dark", "Corn", "rank", "CORN", "cron", "park" };
        var sut = new Anagram("corn");
        var expected = new[] { "cron" };
        Assert.Equal(expected, sut.Anagrams(candidates));
    }

    [Fact(Skip = "Remove to run test")]
    public void Does_not_detect_non_anagrams_with_identical_checksum()
    {
        var candidates = new[] { "last" };
        var sut = new Anagram("mass");
        Assert.Empty(sut.Anagrams(candidates));
    }

    [Fact(Skip = "Remove to run test")]
    public void Detects_anagrams_case_insensitively()
    {
        var candidates = new[] { "cashregister", "Carthorse", "radishes" };
        var sut = new Anagram("Orchestra");
        var expected = new[] { "Carthorse" };
        Assert.Equal(expected, sut.Anagrams(candidates));
    }

    [Fact(Skip = "Remove to run test")]
    public void Detects_anagrams_using_case_insensitive_subject()
    {
        var candidates = new[] { "cashregister", "carthorse", "radishes" };
        var sut = new Anagram("Orchestra");
        var expected = new[] { "carthorse" };
        Assert.Equal(expected, sut.Anagrams(candidates));
    }

    [Fact(Skip = "Remove to run test")]
    public void Detects_anagrams_using_case_insensitive_possible_matches()
    {
        var candidates = new[] { "cashregister", "Carthorse", "radishes" };
        var sut = new Anagram("orchestra");
        var expected = new[] { "Carthorse" };
        Assert.Equal(expected, sut.Anagrams(candidates));
    }

    [Fact(Skip = "Remove to run test")]
    public void Does_not_detect_a_word_as_its_own_anagram()
    {
        var candidates = new[] { "Banana" };
        var sut = new Anagram("banana");
        Assert.Empty(sut.Anagrams(candidates));
    }

    [Fact(Skip = "Remove to run test")]
    public void Does_not_detect_a_anagram_if_the_original_word_is_repeated()
    {
        var candidates = new[] { "go Go GO" };
        var sut = new Anagram("go");
        Assert.Empty(sut.Anagrams(candidates));
    }

    [Fact(Skip = "Remove to run test")]
    public void Anagrams_must_use_all_letters_exactly_once()
    {
        var candidates = new[] { "patter" };
        var sut = new Anagram("tapper");
        Assert.Empty(sut.Anagrams(candidates));
    }

    [Fact(Skip = "Remove to run test")]
    public void Capital_word_is_not_own_anagram()
    {
        var candidates = new[] { "Banana" };
        var sut = new Anagram("BANANA");
        Assert.Empty(sut.Anagrams(candidates));
    }
}