﻿using System;
using Xunit;

public class PalindromeTest
{
    [Fact]
    public void Largest_palindrome_from_single_digit_factors()
    {
        var actual = Palindrome.Largest(9);
        Assert.That(actual.Value, Is.EqualTo(9));
        Assert.That(actual.Factors, Is.EqualTo(new [] { Tuple.Create(1, 9), Tuple.Create(3, 3) }));
    }

    [Fact(Skip="Remove to run test")]
    public void Smallest_palindrome_from_single_digit_factors()
    {
        var actual = Palindrome.Smallest(9);
        Assert.That(actual.Value, Is.EqualTo(1));
        Assert.That(actual.Factors, Is.EqualTo(new[] { Tuple.Create(1, 1) }));
    }

    [Fact(Skip="Remove to run test")]
    public void Largest_palindrome_from_double_digit_actors()
    {
        var actual = Palindrome.Largest(10, 99);
        Assert.That(actual.Value, Is.EqualTo(9009));
        Assert.That(actual.Factors, Is.EqualTo(new[] { Tuple.Create(91, 99) }));
    }

    [Fact(Skip="Remove to run test")]
    public void Smallest_palindrome_from_double_digit_factors()
    {
        var actual = Palindrome.Smallest(10, 99);
        Assert.That(actual.Value, Is.EqualTo(121));
        Assert.That(actual.Factors, Is.EqualTo(new[] { Tuple.Create(11, 11) }));
    }

    [Fact(Skip="Remove to run test")]
    public void Largest_palindrome_from_triple_digit_factors()
    {
        var actual = Palindrome.Largest(100, 999);
        Assert.That(actual.Value, Is.EqualTo(906609));
        Assert.That(actual.Factors, Is.EqualTo(new[] { Tuple.Create(913, 993) }));
    }

    [Fact(Skip="Remove to run test")]
    public void Smallest_palindrome_from_triple_digit_factors()
    {
        var actual = Palindrome.Smallest(100, 999);
        Assert.That(actual.Value, Is.EqualTo(10201));
        Assert.That(actual.Factors, Is.EqualTo(new[] { Tuple.Create(101, 101) }));
    }

    [Fact(Skip="Remove to run test")]
    public void Largest_palindrome_from_four_digit_factors()
    {
        var actual = Palindrome.Largest(1000, 9999);
        Assert.That(actual.Value, Is.EqualTo(99000099));
        Assert.That(actual.Factors, Is.EqualTo(new[] { Tuple.Create(9901, 9999) }));
    }

    [Fact(Skip="Remove to run test")]
    public void Smallest_palindrome_from_four_digit_factors()
    {
        var actual = Palindrome.Smallest(1000, 9999);
        Assert.That(actual.Value, Is.EqualTo(1002001));
        Assert.That(actual.Factors, Is.EqualTo(new[] { Tuple.Create(1001, 1001) }));
    }
}