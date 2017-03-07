using System;
using Xunit;

public class PalindromeTest
{
    [Fact]
    public void Largest_palindrome_from_single_digit_factors()
    {
        var actual = Palindrome.Largest(9);
        Assert.Equal(9, actual.Value);
        Assert.Equal(new [] { Tuple.Create(1, 9), Tuple.Create(3, 3) }, actual.Factors);
    }

    [Fact(Skip = "Remove to run test")]
    public void Smallest_palindrome_from_single_digit_factors()
    {
        var actual = Palindrome.Smallest(9);
        Assert.Equal(1, actual.Value);
        Assert.Equal(new[] { Tuple.Create(1, 1) }, actual.Factors);
    }

    [Fact(Skip = "Remove to run test")]
    public void Largest_palindrome_from_double_digit_actors()
    {
        var actual = Palindrome.Largest(10, 99);
        Assert.Equal(9009, actual.Value);
        Assert.Equal(new[] { Tuple.Create(91, 99) }, actual.Factors);
    }

    [Fact(Skip = "Remove to run test")]
    public void Smallest_palindrome_from_double_digit_factors()
    {
        var actual = Palindrome.Smallest(10, 99);
        Assert.Equal(121, actual.Value);
        Assert.Equal(new[] { Tuple.Create(11, 11) }, actual.Factors);
    }

    [Fact(Skip = "Remove to run test")]
    public void Largest_palindrome_from_triple_digit_factors()
    {
        var actual = Palindrome.Largest(100, 999);
        Assert.Equal(906609, actual.Value);
        Assert.Equal(new[] { Tuple.Create(913, 993) }, actual.Factors);
    }

    [Fact(Skip = "Remove to run test")]
    public void Smallest_palindrome_from_triple_digit_factors()
    {
        var actual = Palindrome.Smallest(100, 999);
        Assert.Equal(10201, actual.Value);
        Assert.Equal(new[] { Tuple.Create(101, 101) }, actual.Factors);
    }

    [Fact(Skip = "Remove to run test")]
    public void Largest_palindrome_from_four_digit_factors()
    {
        var actual = Palindrome.Largest(1000, 9999);
        Assert.Equal(99000099, actual.Value);
        Assert.Equal(new[] { Tuple.Create(9901, 9999) }, actual.Factors);
    }

    [Fact(Skip = "Remove to run test")]
    public void Smallest_palindrome_from_four_digit_factors()
    {
        var actual = Palindrome.Smallest(1000, 9999);
        Assert.Equal(1002001, actual.Value);
        Assert.Equal(new[] { Tuple.Create(1001, 1001) }, actual.Factors);
    }
}