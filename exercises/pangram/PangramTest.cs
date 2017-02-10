using Xunit;

public class PangramTest
{
    [Fact]
    public void Empty_sentence()
    {
        var input = "";
        Assert.Equal(false, Pangram.IsPangram(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Pangram_with_only_lower_case()
    {
        var input = "the quick brown fox jumps over the lazy dog";
        Assert.Equal(true, Pangram.IsPangram(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Missing_character_x()
    {
        var input = "a quick movement of the enemy will jeopardize five gunboats";
        Assert.Equal(false, Pangram.IsPangram(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Another_missing_character_x()
    {
        var input = "the quick brown fish jumps over the lazy dog";
        Assert.Equal(false, Pangram.IsPangram(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Pangram_with_underscores()
    {
        var input = "the_quick_brown_fox_jumps_over_the_lazy_dog";
        Assert.Equal(true, Pangram.IsPangram(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Pangram_with_numbers()
    {
        var input = "the 1 quick brown fox jumps over the 2 lazy dogs";
        Assert.Equal(true, Pangram.IsPangram(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Missing_letters_replaced_by_numbers()
    {
        var input = "7h3 qu1ck brown fox jumps ov3r 7h3 lazy dog";
        Assert.Equal(false, Pangram.IsPangram(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Pangram_with_mixed_case_and_punctuation()
    {
        var input = "\"Five quacking Zephyrs jolt my wax bed.\"";
        Assert.Equal(true, Pangram.IsPangram(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Pangram_with_non_ascii_characters()
    {
        var input = "Victor jagt zwölf Boxkämpfer quer über den großen Sylter Deich.";
        Assert.Equal(true, Pangram.IsPangram(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Pangram_in_alphabet_other_than_ascii()
    {
        var input = "Широкая электрификация южных губерний даст мощный толчок подъёму сельского хозяйства.";
        Assert.Equal(false, Pangram.IsPangram(input));
    }
}