// This file was auto-generated based on version 1.2.0 of the canonical data.

using Xunit;

public class AnagramTest
{
    [Fact]
    public void No_matches()
    {
        var sut = new Anagram("diaper");
        Assert.Empty(sut.Anagrams());
    }

    [Fact(Skip = "Remove to run test")]
    public void Detects_two_anagrams()
    {
        var sut = new Anagram("master");
        var expected = new[] { "stream", "maters" };
        Assert.Equal(expected, sut.Anagrams());
    }

    [Fact(Skip = "Remove to run test")]
    public void Does_not_detect_anagram_subsets()
    {
        var sut = new Anagram("good");
        Assert.Empty(sut.Anagrams());
    }

    [Fact(Skip = "Remove to run test")]
    public void Detects_anagram()
    {
        var sut = new Anagram("listen");
        var expected = new[] { "inlets" };
        Assert.Equal(expected, sut.Anagrams());
    }

    [Fact(Skip = "Remove to run test")]
    public void Detects_three_anagrams()
    {
        var sut = new Anagram("allergy");
        var expected = new[] { "gallery", "regally", "largely" };
        Assert.Equal(expected, sut.Anagrams());
    }

    [Fact(Skip = "Remove to run test")]
    public void Does_not_detect_non_anagrams_with_identical_checksum()
    {
        var sut = new Anagram("mass");
        Assert.Empty(sut.Anagrams());
    }

    [Fact(Skip = "Remove to run test")]
    public void Detects_anagrams_case_insensitively()
    {
        var sut = new Anagram("Orchestra");
        var expected = new[] { "Carthorse" };
        Assert.Equal(expected, sut.Anagrams());
    }

    [Fact(Skip = "Remove to run test")]
    public void Detects_anagrams_using_case_insensitive_subject()
    {
        var sut = new Anagram("Orchestra");
        var expected = new[] { "carthorse" };
        Assert.Equal(expected, sut.Anagrams());
    }

    [Fact(Skip = "Remove to run test")]
    public void Detects_anagrams_using_case_insensitive_possible_matches()
    {
        var sut = new Anagram("orchestra");
        var expected = new[] { "Carthorse" };
        Assert.Equal(expected, sut.Anagrams());
    }

    [Fact(Skip = "Remove to run test")]
    public void Does_not_detect_a_anagram_if_the_original_word_is_repeated()
    {
        var sut = new Anagram("go");
        Assert.Empty(sut.Anagrams());
    }

    [Fact(Skip = "Remove to run test")]
    public void Anagrams_must_use_all_letters_exactly_once()
    {
        var sut = new Anagram("tapper");
        Assert.Empty(sut.Anagrams());
    }

    [Fact(Skip = "Remove to run test")]
    public void Capital_word_is_not_own_anagram()
    {
        var sut = new Anagram("BANANA");
        Assert.Empty(sut.Anagrams());
    }
}