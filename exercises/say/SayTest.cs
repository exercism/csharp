// This file was auto-generated based on version 1.1.0 of the canonical data.

using System;
using Xunit;

public class SayTest
{
    [Fact]
    public void Zero()
    {
        Assert.Equal("zero", Say.InEnglish(0));
    }

    [Fact(Skip = "Remove to run test")]
    public void One()
    {
        Assert.Equal("one", Say.InEnglish(1));
    }

    [Fact(Skip = "Remove to run test")]
    public void Fourteen()
    {
        Assert.Equal("fourteen", Say.InEnglish(14));
    }

    [Fact(Skip = "Remove to run test")]
    public void Twenty()
    {
        Assert.Equal("twenty", Say.InEnglish(20));
    }

    [Fact(Skip = "Remove to run test")]
    public void Twenty_two()
    {
        Assert.Equal("twenty-two", Say.InEnglish(22));
    }

    [Fact(Skip = "Remove to run test")]
    public void One_hundred()
    {
        Assert.Equal("one hundred", Say.InEnglish(100));
    }

    [Fact(Skip = "Remove to run test")]
    public void One_hundred_twenty_three()
    {
        Assert.Equal("one hundred twenty-three", Say.InEnglish(123));
    }

    [Fact(Skip = "Remove to run test")]
    public void One_thousand()
    {
        Assert.Equal("one thousand", Say.InEnglish(1000));
    }

    [Fact(Skip = "Remove to run test")]
    public void One_thousand_two_hundred_thirty_four()
    {
        Assert.Equal("one thousand two hundred thirty-four", Say.InEnglish(1234));
    }

    [Fact(Skip = "Remove to run test")]
    public void One_million()
    {
        Assert.Equal("one million", Say.InEnglish(1000000));
    }

    [Fact(Skip = "Remove to run test")]
    public void One_million_two_thousand_three_hundred_forty_five()
    {
        Assert.Equal("one million two thousand three hundred forty-five", Say.InEnglish(1002345));
    }

    [Fact(Skip = "Remove to run test")]
    public void One_billion()
    {
        Assert.Equal("one billion", Say.InEnglish(1000000000));
    }

    [Fact(Skip = "Remove to run test")]
    public void A_big_number()
    {
        Assert.Equal("nine hundred eighty-seven billion six hundred fifty-four million three hundred twenty-one thousand one hundred twenty-three", Say.InEnglish(987654321123));
    }

    [Fact(Skip = "Remove to run test")]
    public void Numbers_below_zero_are_out_of_range()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Say.InEnglish(-1));
    }

    [Fact(Skip = "Remove to run test")]
    public void Numbers_above_999_999_999_999_are_out_of_range()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Say.InEnglish(1000000000000));
    }
}