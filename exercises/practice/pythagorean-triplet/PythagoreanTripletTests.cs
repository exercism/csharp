// This file was auto-generated based on version 1.0.0 of the canonical data.

using System;
using Xunit;

public class PythagoreanTripletTests
{
    [Fact]
    public void Triplets_whose_sum_is_12()
    {
        Assert.Equal(new[]
        {
            (3, 4, 5)
        }, PythagoreanTriplet.TripletsWithSum(12));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Triplets_whose_sum_is_108()
    {
        Assert.Equal(new[]
        {
            (27, 36, 45)
        }, PythagoreanTriplet.TripletsWithSum(108));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Triplets_whose_sum_is_1000()
    {
        Assert.Equal(new[]
        {
            (200, 375, 425)
        }, PythagoreanTriplet.TripletsWithSum(1000));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void No_matching_triplets_for_1001()
    {
        Assert.Equal(Array.Empty<(int, int, int)>(), PythagoreanTriplet.TripletsWithSum(1001));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Returns_all_matching_triplets()
    {
        Assert.Equal(new[]
        {
            (9, 40, 41),
            (15, 36, 39)
        }, PythagoreanTriplet.TripletsWithSum(90));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Several_matching_triplets()
    {
        Assert.Equal(new[]
        {
            (40, 399, 401),
            (56, 390, 394),
            (105, 360, 375),
            (120, 350, 370),
            (140, 336, 364),
            (168, 315, 357),
            (210, 280, 350),
            (240, 252, 348)
        }, PythagoreanTriplet.TripletsWithSum(840));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Triplets_for_large_number()
    {
        Assert.Equal(new[]
        {
            (1200, 14375, 14425),
            (1875, 14000, 14125),
            (5000, 12000, 13000),
            (6000, 11250, 12750),
            (7500, 10000, 12500)
        }, PythagoreanTriplet.TripletsWithSum(30000));
    }
}