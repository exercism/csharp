using Xunit;

public class PigLatinTest
{
    [Theory]
    [InlineData("apple", "appleay")]
    [InlineData("ear", "earay")]
    [InlineData("igloo", "iglooay")]
    [InlineData("object", "objectay")]
    [InlineData("under", "underay")]
    public void Ay_is_added_to_words_that_start_with_vowels(string word, string expected)
    {
        Assert.Equal(expected, PigLatin.Translate(word));
    }

    [Theory]
    [InlineData("pig", "igpay")]
    [InlineData("koala", "oalakay")]
    [InlineData("yellow", "ellowyay")]
    [InlineData("xenon", "enonxay")]
    public void First_letter_and_ay_are_moved_to_the_end_of_words_that_start_with_consonants(string word, string expected)
    {
        Assert.Equal(expected, PigLatin.Translate(word));
    }

    [Fact]
    public void Ch_is_treated_like_a_single_consonant()
    {
        Assert.Equal("airchay", PigLatin.Translate("chair"));
    }

    [Fact]
    public void Qu_is_treated_like_a_single_consonant()
    {
        Assert.Equal("eenquay", PigLatin.Translate("queen"));
    }

    [Fact]
    public void Qu_and_a_single_preceding_consonant_are_treated_like_a_single_consonant()
    {
        Assert.Equal("aresquay", PigLatin.Translate("square"));
    }

    [Fact]
    public void Th_is_treated_like_a_single_consonant()
    {
        Assert.Equal("erapythay", PigLatin.Translate("therapy"));
    }

    [Fact]
    public void Thr_is_treated_like_a_single_consonant()
    {
        Assert.Equal("ushthray", PigLatin.Translate("thrush"));
    }

    [Fact]
    public void Sch_is_treated_like_a_single_consonant()
    {
        Assert.Equal("oolschay", PigLatin.Translate("school"));
    }

    [Fact]
    public void Yt_is_treated_like_a_single_vowel()
    {
        Assert.Equal("yttriaay", PigLatin.Translate("yttria"));
    }

    [Fact]
    public void Xr_is_treated_like_a_single_vowel()
    {
        Assert.Equal("xrayay", PigLatin.Translate("xray"));
    }

    [Fact]
    public void Phrases_are_translated()
    {
        Assert.Equal("ickquay astfay unray", PigLatin.Translate("quick fast run"));
    }
}