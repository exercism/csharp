// This file was auto-generated based on version 1.2.0 of the canonical data.

using System;
using Xunit;

public class SumOfMultiplesTest
{
    [Fact]
    public void Multiples_of_3_or_5_up_to_1()
    {
        Assert.Equal(0, SumOfMultiples.Sum(new[] { 3, 5 }, 1));
    }

    [Fact(Skip = "Remove to run test")]
    public void Multiples_of_3_or_5_up_to_4()
    {
        Assert.Equal(3, SumOfMultiples.Sum(new[] { 3, 5 }, 4));
    }

    [Fact(Skip = "Remove to run test")]
    public void Multiples_of_3_up_to_7()
    {
        Assert.Equal(9, SumOfMultiples.Sum(new[] { 3 }, 7));
    }

    [Fact(Skip = "Remove to run test")]
    public void Multiples_of_3_or_5_up_to_10()
    {
        Assert.Equal(23, SumOfMultiples.Sum(new[] { 3, 5 }, 10));
    }

    [Fact(Skip = "Remove to run test")]
    public void Multiples_of_3_or_5_up_to_100()
    {
        Assert.Equal(2318, SumOfMultiples.Sum(new[] { 3, 5 }, 100));
    }

    [Fact(Skip = "Remove to run test")]
    public void Multiples_of_3_or_5_up_to_1000()
    {
        Assert.Equal(233168, SumOfMultiples.Sum(new[] { 3, 5 }, 1000));
    }

    [Fact(Skip = "Remove to run test")]
    public void Multiples_of_7_13_or_17_up_to_20()
    {
        Assert.Equal(51, SumOfMultiples.Sum(new[] { 7, 13, 17 }, 20));
    }

    [Fact(Skip = "Remove to run test")]
    public void Multiples_of_4_or_6_up_to_15()
    {
        Assert.Equal(30, SumOfMultiples.Sum(new[] { 4, 6 }, 15));
    }

    [Fact(Skip = "Remove to run test")]
    public void Multiples_of_5_6_or_8_up_to_150()
    {
        Assert.Equal(4419, SumOfMultiples.Sum(new[] { 5, 6, 8 }, 150));
    }

    [Fact(Skip = "Remove to run test")]
    public void Multiples_of_5_or_25_up_to_51()
    {
        Assert.Equal(275, SumOfMultiples.Sum(new[] { 5, 25 }, 51));
    }

    [Fact(Skip = "Remove to run test")]
    public void Multiples_of_43_or_47_up_to_10000()
    {
        Assert.Equal(2203160, SumOfMultiples.Sum(new[] { 43, 47 }, 10000));
    }

    [Fact(Skip = "Remove to run test")]
    public void Multiples_of_1_up_to_100()
    {
        Assert.Equal(4950, SumOfMultiples.Sum(new[] { 1 }, 100));
    }

    [Fact(Skip = "Remove to run test")]
    public void Multiples_of_an_empty_list_up_to_10000()
    {
        Assert.Equal(0, SumOfMultiples.Sum(Array.Empty<int>(), 10000));
    }
}