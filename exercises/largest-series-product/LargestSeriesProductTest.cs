// This file was auto-generated based on version 1.1.0 of the canonical data.

using System;
using Xunit;

public class LargestSeriesProductTest
{
    [Fact]
    public void Finds_the_largest_product_if_span_equals_length()
    {
        Assert.Equal(18, LargestSeriesProduct.GetLargestProduct("29", 2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Can_find_the_largest_product_of_2_with_numbers_in_order()
    {
        Assert.Equal(72, LargestSeriesProduct.GetLargestProduct("0123456789", 2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Can_find_the_largest_product_of_2()
    {
        Assert.Equal(48, LargestSeriesProduct.GetLargestProduct("576802143", 2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Can_find_the_largest_product_of_3_with_numbers_in_order()
    {
        Assert.Equal(504, LargestSeriesProduct.GetLargestProduct("0123456789", 3));
    }

    [Fact(Skip = "Remove to run test")]
    public void Can_find_the_largest_product_of_3()
    {
        Assert.Equal(270, LargestSeriesProduct.GetLargestProduct("1027839564", 3));
    }

    [Fact(Skip = "Remove to run test")]
    public void Can_find_the_largest_product_of_5_with_numbers_in_order()
    {
        Assert.Equal(15120, LargestSeriesProduct.GetLargestProduct("0123456789", 5));
    }

    [Fact(Skip = "Remove to run test")]
    public void Can_get_the_largest_product_of_a_big_number()
    {
        Assert.Equal(23520, LargestSeriesProduct.GetLargestProduct("73167176531330624919225119674426574742355349194934", 6));
    }

    [Fact(Skip = "Remove to run test")]
    public void Reports_zero_if_the_only_digits_are_zero()
    {
        Assert.Equal(0, LargestSeriesProduct.GetLargestProduct("0000", 2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Reports_zero_if_all_spans_include_zero()
    {
        Assert.Equal(0, LargestSeriesProduct.GetLargestProduct("99099", 3));
    }

    [Fact(Skip = "Remove to run test")]
    public void Rejects_span_longer_than_string_length()
    {
        Assert.Throws<ArgumentException>(() => LargestSeriesProduct.GetLargestProduct("123", 4));
    }

    [Fact(Skip = "Remove to run test")]
    public void Reports_1_for_empty_string_and_empty_product_0_span_()
    {
        Assert.Equal(1, LargestSeriesProduct.GetLargestProduct("", 0));
    }

    [Fact(Skip = "Remove to run test")]
    public void Reports_1_for_nonempty_string_and_empty_product_0_span_()
    {
        Assert.Equal(1, LargestSeriesProduct.GetLargestProduct("123", 0));
    }

    [Fact(Skip = "Remove to run test")]
    public void Rejects_empty_string_and_nonzero_span()
    {
        Assert.Throws<ArgumentException>(() => LargestSeriesProduct.GetLargestProduct("", 1));
    }

    [Fact(Skip = "Remove to run test")]
    public void Rejects_invalid_character_in_digits()
    {
        Assert.Throws<ArgumentException>(() => LargestSeriesProduct.GetLargestProduct("1234a5", 2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Rejects_negative_span()
    {
        Assert.Throws<ArgumentException>(() => LargestSeriesProduct.GetLargestProduct("12345", -1));
    }
}