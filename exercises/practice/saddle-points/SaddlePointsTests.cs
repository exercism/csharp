using System.Collections.Generic;
using System.Linq;
using Xunit;

public class SaddlePointsTests
{
    [Fact]
    public void Can_identify_single_saddle_point()
    {
        int[,] matrix =
        {
            { 9, 8, 7 },
            { 5, 3, 2 },
            { 6, 6, 7 }
        };
        HashSet<(int, int)> expected = [(2, 1)];
        Assert.Equal(expected, SaddlePoints.Calculate(matrix).ToHashSet());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Can_identify_that_empty_matrix_has_no_saddle_points()
    {
        int[,] matrix =
        {
        };
        Assert.Empty(SaddlePoints.Calculate(matrix));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Can_identify_lack_of_saddle_points_when_there_are_none()
    {
        int[,] matrix =
        {
            { 1, 2, 3 },
            { 3, 1, 2 },
            { 2, 3, 1 }
        };
        Assert.Empty(SaddlePoints.Calculate(matrix));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Can_identify_multiple_saddle_points_in_a_column()
    {
        int[,] matrix =
        {
            { 4, 5, 4 },
            { 3, 5, 5 },
            { 1, 5, 4 }
        };
        HashSet<(int, int)> expected = [(1, 2), (2, 2), (3, 2)];
        Assert.Equal(expected, SaddlePoints.Calculate(matrix).ToHashSet());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Can_identify_multiple_saddle_points_in_a_row()
    {
        int[,] matrix =
        {
            { 6, 7, 8 },
            { 5, 5, 5 },
            { 7, 5, 6 }
        };
        HashSet<(int, int)> expected = [(2, 1), (2, 2), (2, 3)];
        Assert.Equal(expected, SaddlePoints.Calculate(matrix).ToHashSet());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Can_identify_saddle_point_in_bottom_right_corner()
    {
        int[,] matrix =
        {
            { 8, 7, 9 },
            { 6, 7, 6 },
            { 3, 2, 5 }
        };
        HashSet<(int, int)> expected = [(3, 3)];
        Assert.Equal(expected, SaddlePoints.Calculate(matrix).ToHashSet());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Can_identify_saddle_points_in_a_non_square_matrix()
    {
        int[,] matrix =
        {
            { 3, 1, 3 },
            { 3, 2, 4 }
        };
        HashSet<(int, int)> expected = [(1, 3), (1, 1)];
        Assert.Equal(expected, SaddlePoints.Calculate(matrix).ToHashSet());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Can_identify_that_saddle_points_in_a_single_column_matrix_are_those_with_the_minimum_value()
    {
        int[,] matrix =
        {
            { 2 },
            { 1 },
            { 4 },
            { 1 }
        };
        HashSet<(int, int)> expected = [(2, 1), (4, 1)];
        Assert.Equal(expected, SaddlePoints.Calculate(matrix).ToHashSet());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Can_identify_that_saddle_points_in_a_single_row_matrix_are_those_with_the_maximum_value()
    {
        int[,] matrix =
        {
            { 2, 5, 3, 5 }
        };
        HashSet<(int, int)> expected = [(1, 2), (1, 4)];
        Assert.Equal(expected, SaddlePoints.Calculate(matrix).ToHashSet());
    }
}
