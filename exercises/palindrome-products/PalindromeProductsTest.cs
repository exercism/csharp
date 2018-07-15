// This file was auto-generated based on version 1.1.0 of the canonical data.

using System;
using Xunit;

public class PalindromeProductsTest
{
    [Fact]
    public void Finds_the_smallest_palindrome_from_single_digit_factors()
    {
        var actual = PalindromeProducts.Smallest(1, 9);
        var expected = (1, new[] { (1, 1) });
        Assert.Equal(expected.Item1, actual.Item1);
        Assert.Equal(expected.Item2, actual.Item2);
    }

    [Fact(Skip = "Remove to run test")]
    public void Finds_the_largest_palindrome_from_single_digit_factors()
    {
        var actual = PalindromeProducts.Largest(1, 9);
        var expected = (9, new[] { (1, 9), (3, 3) });
        Assert.Equal(expected.Item1, actual.Item1);
        Assert.Equal(expected.Item2, actual.Item2);
    }

    [Fact(Skip = "Remove to run test")]
    public void Find_the_smallest_palindrome_from_double_digit_factors()
    {
        var actual = PalindromeProducts.Smallest(10, 99);
        var expected = (121, new[] { (11, 11) });
        Assert.Equal(expected.Item1, actual.Item1);
        Assert.Equal(expected.Item2, actual.Item2);
    }

    [Fact(Skip = "Remove to run test")]
    public void Find_the_largest_palindrome_from_double_digit_factors()
    {
        var actual = PalindromeProducts.Largest(10, 99);
        var expected = (9009, new[] { (91, 99) });
        Assert.Equal(expected.Item1, actual.Item1);
        Assert.Equal(expected.Item2, actual.Item2);
    }

    [Fact(Skip = "Remove to run test")]
    public void Find_smallest_palindrome_from_triple_digit_factors()
    {
        var actual = PalindromeProducts.Smallest(100, 999);
        var expected = (10201, new[] { (101, 101) });
        Assert.Equal(expected.Item1, actual.Item1);
        Assert.Equal(expected.Item2, actual.Item2);
    }

    [Fact(Skip = "Remove to run test")]
    public void Find_the_largest_palindrome_from_triple_digit_factors()
    {
        var actual = PalindromeProducts.Largest(100, 999);
        var expected = (906609, new[] { (913, 993) });
        Assert.Equal(expected.Item1, actual.Item1);
        Assert.Equal(expected.Item2, actual.Item2);
    }

    [Fact(Skip = "Remove to run test")]
    public void Find_smallest_palindrome_from_four_digit_factors()
    {
        var actual = PalindromeProducts.Smallest(1000, 9999);
        var expected = (1002001, new[] { (1001, 1001) });
        Assert.Equal(expected.Item1, actual.Item1);
        Assert.Equal(expected.Item2, actual.Item2);
    }

    [Fact(Skip = "Remove to run test")]
    public void Find_the_largest_palindrome_from_four_digit_factors()
    {
        var actual = PalindromeProducts.Largest(1000, 9999);
        var expected = (99000099, new[] { (9901, 9999) });
        Assert.Equal(expected.Item1, actual.Item1);
        Assert.Equal(expected.Item2, actual.Item2);
    }

    [Fact(Skip = "Remove to run test")]
    public void Empty_result_for_smallest_if_no_palindrome_in_the_range()
    {
        Assert.Throws<ArgumentException>(() => PalindromeProducts.Smallest(1002, 1003));
    }

    [Fact(Skip = "Remove to run test")]
    public void Empty_result_for_largest_if_no_palindrome_in_the_range()
    {
        Assert.Throws<ArgumentException>(() => PalindromeProducts.Largest(15, 15));
    }

    [Fact(Skip = "Remove to run test")]
    public void Error_result_for_smallest_if_min_is_more_than_max()
    {
        Assert.Throws<ArgumentException>(() => PalindromeProducts.Smallest(10000, 1));
    }

    [Fact(Skip = "Remove to run test")]
    public void Error_result_for_largest_if_min_is_more_than_max()
    {
        Assert.Throws<ArgumentException>(() => PalindromeProducts.Largest(2, 1));
    }
}