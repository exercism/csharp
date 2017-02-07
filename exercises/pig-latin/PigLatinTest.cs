using Xunit;

public class PigLatinTest
{
    [TestCase("apple", ExpectedResult = "appleay")]
    [TestCase("ear", ExpectedResult = "earay")]
    [TestCase("igloo", ExpectedResult = "iglooay")]
    [TestCase("object", ExpectedResult = "objectay")]
    [TestCase("under", ExpectedResult = "underay")]
    public string Ay_is_added_to_words_that_start_with_vowels(string word)
    {
        return PigLatin.Translate(word);
    }

    [Ignore("Remove to run test")]
    [TestCase("pig", ExpectedResult = "igpay")]
    [TestCase("koala", ExpectedResult = "oalakay")]
    [TestCase("yellow", ExpectedResult = "ellowyay")]
    [TestCase("xenon", ExpectedResult = "enonxay")]
    public string First_letter_and_ay_are_moved_to_the_end_of_words_that_start_with_consonants(string word)
    {
        return PigLatin.Translate(word);
    }

    [Fact(Skip="Remove to run test")]
    public void Ch_is_treated_like_a_single_consonant()
    {
        Assert.Equal("airchay", PigLatin.Translate("chair"));
    }

    [Fact(Skip="Remove to run test")]
    public void Qu_is_treated_like_a_single_consonant()
    {
        Assert.Equal("eenquay", PigLatin.Translate("queen"));
    }

    [Fact(Skip="Remove to run test")]
    public void Qu_and_a_single_preceding_consonant_are_treated_like_a_single_consonant()
    {
        Assert.Equal("aresquay", PigLatin.Translate("square"));
    }

    [Fact(Skip="Remove to run test")]
    public void Th_is_treated_like_a_single_consonant()
    {
        Assert.Equal("erapythay", PigLatin.Translate("therapy"));
    }

    [Fact(Skip="Remove to run test")]
    public void Thr_is_treated_like_a_single_consonant()
    {
        Assert.Equal("ushthray", PigLatin.Translate("thrush"));
    }

    [Fact(Skip="Remove to run test")]
    public void Sch_is_treated_like_a_single_consonant()
    {
        Assert.Equal("oolschay", PigLatin.Translate("school"));
    }

    [Fact(Skip="Remove to run test")]
    public void Yt_is_treated_like_a_single_vowel()
    {
        Assert.Equal("yttriaay", PigLatin.Translate("yttria"));
    }

    [Fact(Skip="Remove to run test")]
    public void Xr_is_treated_like_a_single_vowel()
    {
        Assert.Equal("xrayay", PigLatin.Translate("xray"));
    }

    [Fact(Skip="Remove to run test")]
    public void Phrases_are_translated()
    {
        Assert.Equal("ickquay astfay unray", PigLatin.Translate("quick fast run"));
    }
}