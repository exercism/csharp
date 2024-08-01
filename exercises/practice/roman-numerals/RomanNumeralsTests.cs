using Xunit;

public class RomanNumeralsTests
{
    [Fact]
    public void Number_1_is_i()
    {
        Assert.Equal("I", 1.ToRoman());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Number_2_is_ii()
    {
        Assert.Equal("II", 2.ToRoman());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Number_3_is_iii()
    {
        Assert.Equal("III", 3.ToRoman());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Number_4_is_iv()
    {
        Assert.Equal("IV", 4.ToRoman());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Number_5_is_v()
    {
        Assert.Equal("V", 5.ToRoman());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Number_6_is_vi()
    {
        Assert.Equal("VI", 6.ToRoman());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Number_9_is_ix()
    {
        Assert.Equal("IX", 9.ToRoman());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Number_16_is_xvi()
    {
        Assert.Equal("XVI", 16.ToRoman());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Number_27_is_xxvii()
    {
        Assert.Equal("XXVII", 27.ToRoman());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Number_48_is_xlviii()
    {
        Assert.Equal("XLVIII", 48.ToRoman());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Number_49_is_xlix()
    {
        Assert.Equal("XLIX", 49.ToRoman());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Number_59_is_lix()
    {
        Assert.Equal("LIX", 59.ToRoman());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Number_66_is_lxvi()
    {
        Assert.Equal("LXVI", 66.ToRoman());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Number_93_is_xciii()
    {
        Assert.Equal("XCIII", 93.ToRoman());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Number_141_is_cxli()
    {
        Assert.Equal("CXLI", 141.ToRoman());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Number_163_is_clxiii()
    {
        Assert.Equal("CLXIII", 163.ToRoman());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Number_166_is_clxvi()
    {
        Assert.Equal("CLXVI", 166.ToRoman());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Number_402_is_cdii()
    {
        Assert.Equal("CDII", 402.ToRoman());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Number_575_is_dlxxv()
    {
        Assert.Equal("DLXXV", 575.ToRoman());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Number_666_is_dclxvi()
    {
        Assert.Equal("DCLXVI", 666.ToRoman());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Number_911_is_cmxi()
    {
        Assert.Equal("CMXI", 911.ToRoman());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Number_1024_is_mxxiv()
    {
        Assert.Equal("MXXIV", 1024.ToRoman());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Number_1666_is_mdclxvi()
    {
        Assert.Equal("MDCLXVI", 1666.ToRoman());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Number_3000_is_mmm()
    {
        Assert.Equal("MMM", 3000.ToRoman());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Number_3001_is_mmmi()
    {
        Assert.Equal("MMMI", 3001.ToRoman());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Number_3888_is_mmmdccclxxxviii()
    {
        Assert.Equal("MMMDCCCLXXXVIII", 3888.ToRoman());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Number_3999_is_mmmcmxcix()
    {
        Assert.Equal("MMMCMXCIX", 3999.ToRoman());
    }
}
