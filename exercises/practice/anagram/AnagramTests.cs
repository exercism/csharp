public class AnagramTests
{
    [Fact]
    public void No_matches()
    {
        string[] candidates = ["hello", "world", "zombies", "pants"];
        var sut = new Anagram("diaper");
        Assert.Empty(sut.FindAnagrams(candidates));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Detects_two_anagrams()
    {
        string[] candidates = ["lemons", "cherry", "melons"];
        var sut = new Anagram("solemn");
        string[] expected = ["lemons", "melons"];
        Assert.Equal(expected, sut.FindAnagrams(candidates));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Does_not_detect_anagram_subsets()
    {
        string[] candidates = ["dog", "goody"];
        var sut = new Anagram("good");
        Assert.Empty(sut.FindAnagrams(candidates));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Detects_anagram()
    {
        string[] candidates = ["enlists", "google", "inlets", "banana"];
        var sut = new Anagram("listen");
        string[] expected = ["inlets"];
        Assert.Equal(expected, sut.FindAnagrams(candidates));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Detects_three_anagrams()
    {
        string[] candidates = ["gallery", "ballerina", "regally", "clergy", "largely", "leading"];
        var sut = new Anagram("allergy");
        string[] expected = ["gallery", "regally", "largely"];
        Assert.Equal(expected, sut.FindAnagrams(candidates));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Detects_multiple_anagrams_with_different_case()
    {
        string[] candidates = ["Eons", "ONES"];
        var sut = new Anagram("nose");
        string[] expected = ["Eons", "ONES"];
        Assert.Equal(expected, sut.FindAnagrams(candidates));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Does_not_detect_non_anagrams_with_identical_checksum()
    {
        string[] candidates = ["last"];
        var sut = new Anagram("mass");
        Assert.Empty(sut.FindAnagrams(candidates));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Detects_anagrams_case_insensitively()
    {
        string[] candidates = ["cashregister", "Carthorse", "radishes"];
        var sut = new Anagram("Orchestra");
        string[] expected = ["Carthorse"];
        Assert.Equal(expected, sut.FindAnagrams(candidates));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Detects_anagrams_using_case_insensitive_subject()
    {
        string[] candidates = ["cashregister", "carthorse", "radishes"];
        var sut = new Anagram("Orchestra");
        string[] expected = ["carthorse"];
        Assert.Equal(expected, sut.FindAnagrams(candidates));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Detects_anagrams_using_case_insensitive_possible_matches()
    {
        string[] candidates = ["cashregister", "Carthorse", "radishes"];
        var sut = new Anagram("orchestra");
        string[] expected = ["Carthorse"];
        Assert.Equal(expected, sut.FindAnagrams(candidates));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Does_not_detect_an_anagram_if_the_original_word_is_repeated()
    {
        string[] candidates = ["goGoGO"];
        var sut = new Anagram("go");
        Assert.Empty(sut.FindAnagrams(candidates));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Anagrams_must_use_all_letters_exactly_once()
    {
        string[] candidates = ["patter"];
        var sut = new Anagram("tapper");
        Assert.Empty(sut.FindAnagrams(candidates));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Words_are_not_anagrams_of_themselves()
    {
        string[] candidates = ["BANANA"];
        var sut = new Anagram("BANANA");
        Assert.Empty(sut.FindAnagrams(candidates));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Words_are_not_anagrams_of_themselves_even_if_letter_case_is_partially_different()
    {
        string[] candidates = ["Banana"];
        var sut = new Anagram("BANANA");
        Assert.Empty(sut.FindAnagrams(candidates));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Words_are_not_anagrams_of_themselves_even_if_letter_case_is_completely_different()
    {
        string[] candidates = ["banana"];
        var sut = new Anagram("BANANA");
        Assert.Empty(sut.FindAnagrams(candidates));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Words_other_than_themselves_can_be_anagrams()
    {
        string[] candidates = ["LISTEN", "Silent"];
        var sut = new Anagram("LISTEN");
        string[] expected = ["Silent"];
        Assert.Equal(expected, sut.FindAnagrams(candidates));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Handles_case_of_greek_letters()
    {
        string[] candidates = ["ΒΓΑ", "ΒΓΔ", "γβα", "αβγ"];
        var sut = new Anagram("ΑΒΓ");
        string[] expected = ["ΒΓΑ", "γβα"];
        Assert.Equal(expected, sut.FindAnagrams(candidates));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Different_characters_may_have_the_same_bytes()
    {
        string[] candidates = ["€a"];
        var sut = new Anagram("a⬂");
        Assert.Empty(sut.FindAnagrams(candidates));
    }
}
