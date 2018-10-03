// This file was auto-generated based on version 1.0.0 of the canonical data.

using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

public class PythagoreanTripletTest
{
    [Fact]
    public void Triplets_whose_sum_is_12()
    {
        Assert.Equal(new Triplet[]{
            new Triplet(3, 4, 5),
        }.ToHashSet()
        , Triplet.Where(12, 1, 12).ToHashSet());
    }

    [Fact(Skip = "Remove to run test")]
    public void Triplets_whose_sum_is_108()
    {
        Assert.Equal(new Triplet[]{
            new Triplet(27, 36, 45),
        }.ToHashSet()
        , Triplet.Where(108, 1, 108).ToHashSet());
    }

    [Fact(Skip = "Remove to run test")]
    public void Triplets_whose_sum_is_1000()
    {
        Assert.Equal(new Triplet[]{
            new Triplet(200, 375, 425),
        }.ToHashSet()
        , Triplet.Where(1000, 1, 1000).ToHashSet());
    }

    [Fact(Skip = "Remove to run test")]
    public void No_matching_triplets_for_1001()
    {
        Assert.Equal(new Triplet[]{
        }.ToHashSet()
        , Triplet.Where(1001, 1, 1001).ToHashSet());
    }

    [Fact(Skip = "Remove to run test")]
    public void Returns_all_matching_triplets()
    {
        Assert.Equal(new Triplet[]{
            new Triplet(9, 40, 41),
            new Triplet(15, 36, 39),
        }.ToHashSet()
        , Triplet.Where(90, 1, 90).ToHashSet());
    }

    [Fact(Skip = "Remove to run test")]
    public void Several_matching_triplets()
    {
        Assert.Equal(new Triplet[]{
            new Triplet(40, 399, 401),
            new Triplet(56, 390, 394),
            new Triplet(105, 360, 375),
            new Triplet(120, 350, 370),
            new Triplet(140, 336, 364),
            new Triplet(168, 315, 357),
            new Triplet(210, 280, 350),
            new Triplet(240, 252, 348),
        }.ToHashSet()
        , Triplet.Where(840, 1, 840).ToHashSet());
    }

    [Fact(Skip = "Remove to run test")]
    public void Triplets_for_large_number()
    {
        Assert.Equal(new Triplet[]{
            new Triplet(1200, 14375, 14425),
            new Triplet(1875, 14000, 14125),
            new Triplet(5000, 12000, 13000),
            new Triplet(6000, 11250, 12750),
            new Triplet(7500, 10000, 12500),
        }.ToHashSet()
        , Triplet.Where(30000, 1, 30000).ToHashSet());
    }
}