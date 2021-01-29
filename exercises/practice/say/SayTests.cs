// This file was auto-generated based on version 1.2.0 of the canonical data.

using System;
using Xunit;

public class SayTests
{
    [Fact]
    public void Zero()
    {
        Assert.Equal("zero", Say.InEnglish(0L));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void One()
    {
        Assert.Equal("one", Say.InEnglish(1L));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Fourteen()
    {
        Assert.Equal("fourteen", Say.InEnglish(14L));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Twenty()
    {
        Assert.Equal("twenty", Say.InEnglish(20L));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Twenty_two()
    {
        Assert.Equal("twenty-two", Say.InEnglish(22L));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void One_hundred()
    {
        Assert.Equal("one hundred", Say.InEnglish(100L));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void One_hundred_twenty_three()
    {
        Assert.Equal("one hundred twenty-three", Say.InEnglish(123L));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void One_thousand()
    {
        Assert.Equal("one thousand", Say.InEnglish(1000L));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void One_thousand_two_hundred_thirty_four()
    {
        Assert.Equal("one thousand two hundred thirty-four", Say.InEnglish(1234L));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void One_million()
    {
        Assert.Equal("one million", Say.InEnglish(1000000L));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void One_million_two_thousand_three_hundred_forty_five()
    {
        Assert.Equal("one million two thousand three hundred forty-five", Say.InEnglish(1002345L));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void One_billion()
    {
        Assert.Equal("one billion", Say.InEnglish(1000000000L));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void A_big_number()
    {
        Assert.Equal("nine hundred eighty-seven billion six hundred fifty-four million three hundred twenty-one thousand one hundred twenty-three", Say.InEnglish(987654321123L));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Numbers_below_zero_are_out_of_range()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Say.InEnglish(-1L));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Numbers_above_999_999_999_999_are_out_of_range()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Say.InEnglish(1000000000000L));
    }
}