// This file was auto-generated based on version 1.1.0 of the canonical data.

using System;
using Xunit;

public class SaddlePointsTest
{
    [Fact]
    public void Can_identify_single_saddle_point()
    {
        var matrix = new[,]
        {
             { 9, 8, 7 },
             { 5, 3, 2 },
             { 6, 6, 7 }
        };
        var sut = new SaddlePoints(matrix);
        var actual = sut.Calculate();
        var expected = new[] { (1, 0) };
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Can_identify_that_empty_matrix_has_no_saddle_points()
    {
        var matrix = new int[,] { };
        var sut = new SaddlePoints(matrix);
        var actual = sut.Calculate();
        Assert.Empty(actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Can_identify_lack_of_saddle_points_when_there_are_none()
    {
        var matrix = new[,]
        {
             { 1, 2, 3 },
             { 3, 1, 2 },
             { 2, 3, 1 }
        };
        var sut = new SaddlePoints(matrix);
        var actual = sut.Calculate();
        Assert.Empty(actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Can_identify_multiple_saddle_points()
    {
        var matrix = new[,]
        {
             { 4, 5, 4 },
             { 3, 5, 5 },
             { 1, 5, 4 }
        };
        var sut = new SaddlePoints(matrix);
        var actual = sut.Calculate();
        var expected = new[] { (0, 1), (1, 1), (2, 1) };
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Can_identify_saddle_point_in_bottom_right_corner()
    {
        var matrix = new[,]
        {
             { 8, 7, 9 },
             { 6, 7, 6 },
             { 3, 2, 5 }
        };
        var sut = new SaddlePoints(matrix);
        var actual = sut.Calculate();
        var expected = new[] { (2, 2) };
        Assert.Equal(expected, actual);
    }
}