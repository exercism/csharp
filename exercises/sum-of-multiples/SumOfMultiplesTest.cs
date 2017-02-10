﻿using Xunit;

public class SumOfMultiplesTest
{
    [Fact(Skip = "Remove to run test")]
    public void Sum_to_1()
    {
        Assert.Equal(0, SumOfMultiples.To(new[] { 3, 5 }, 1));
    }

    [Fact(Skip = "Remove to run test")]
    public void Sum_to_3()
    {
        Assert.Equal(3, SumOfMultiples.To(new[] { 3, 5 }, 4));
    }

    [Fact(Skip = "Remove to run test")]
    public void Sum_to_10()
    {
        Assert.Equal(23, SumOfMultiples.To(new[] { 3, 5 }, 10));
    }

    [Fact(Skip = "Remove to run test")]
    public void Sum_to_100()
    {
       Assert.Equal(2318, SumOfMultiples.To(new[] { 3, 5 }, 100));
    }

    [Fact(Skip = "Remove to run test")]
    public void Sum_to_1000()
    {
        Assert.Equal(233168, SumOfMultiples.To(new[] { 3, 5 }, 1000));
    }

    [Fact(Skip = "Remove to run test")]
    public void Sum_to_20()
    {
        Assert.Equal(51, SumOfMultiples.To(new [] { 7, 13, 17 }, 20));
    }

    [Fact(Skip = "Remove to run test")]
    public void Sum_to_10000()
    {
        Assert.Equal(2203160, SumOfMultiples.To(new [] { 43, 47 }, 10000));
    }
}
