// This file was auto-generated based on version 1.1.0 of the canonical data.

using Xunit;

public class TriangleTest
{
    [Fact]
    public void Returns_true_if_the_triangle_is_equilateral_true_if_all_sides_are_equal()
    {
        Assert.True(Triangle.IsEquilateral(2, 2, 2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Returns_true_if_the_triangle_is_equilateral_false_if_any_side_is_unequal()
    {
        Assert.False(Triangle.IsEquilateral(2, 3, 2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Returns_true_if_the_triangle_is_equilateral_false_if_no_sides_are_equal()
    {
        Assert.False(Triangle.IsEquilateral(5, 4, 6));
    }

    [Fact(Skip = "Remove to run test")]
    public void Returns_true_if_the_triangle_is_equilateral_all_zero_sides_are_illegal_so_the_triangle_is_not_equilateral()
    {
        Assert.False(Triangle.IsEquilateral(0, 0, 0));
    }

    [Fact(Skip = "Remove to run test")]
    public void Returns_true_if_the_triangle_is_equilateral_sides_may_be_floats()
    {
        Assert.True(Triangle.IsEquilateral(0.5, 0.5, 0.5));
    }

    [Fact(Skip = "Remove to run test")]
    public void Returns_true_if_the_triangle_is_isosceles_true_if_last_two_sides_are_equal()
    {
        Assert.True(Triangle.IsIsosceles(3, 4, 4));
    }

    [Fact(Skip = "Remove to run test")]
    public void Returns_true_if_the_triangle_is_isosceles_true_if_first_two_sides_are_equal()
    {
        Assert.True(Triangle.IsIsosceles(4, 4, 3));
    }

    [Fact(Skip = "Remove to run test")]
    public void Returns_true_if_the_triangle_is_isosceles_true_if_first_and_last_sides_are_equal()
    {
        Assert.True(Triangle.IsIsosceles(4, 3, 4));
    }

    [Fact(Skip = "Remove to run test")]
    public void Returns_true_if_the_triangle_is_isosceles_equilateral_triangles_are_also_isosceles()
    {
        Assert.True(Triangle.IsIsosceles(4, 4, 4));
    }

    [Fact(Skip = "Remove to run test")]
    public void Returns_true_if_the_triangle_is_isosceles_false_if_no_sides_are_equal()
    {
        Assert.False(Triangle.IsIsosceles(2, 3, 4));
    }

    [Fact(Skip = "Remove to run test")]
    public void Returns_true_if_the_triangle_is_isosceles_sides_that_violate_triangle_inequality_are_not_isosceles_even_if_two_are_equal()
    {
        Assert.False(Triangle.IsIsosceles(1, 1, 3));
    }

    [Fact(Skip = "Remove to run test")]
    public void Returns_true_if_the_triangle_is_isosceles_sides_may_be_floats()
    {
        Assert.True(Triangle.IsIsosceles(0.5, 0.4, 0.5));
    }

    [Fact(Skip = "Remove to run test")]
    public void Returns_true_if_the_triangle_is_scalene_true_if_no_sides_are_equal()
    {
        Assert.True(Triangle.IsScalene(5, 4, 6));
    }

    [Fact(Skip = "Remove to run test")]
    public void Returns_true_if_the_triangle_is_scalene_false_if_all_sides_are_equal()
    {
        Assert.False(Triangle.IsScalene(4, 4, 4));
    }

    [Fact(Skip = "Remove to run test")]
    public void Returns_true_if_the_triangle_is_scalene_false_if_two_sides_are_equal()
    {
        Assert.False(Triangle.IsScalene(4, 4, 3));
    }

    [Fact(Skip = "Remove to run test")]
    public void Returns_true_if_the_triangle_is_scalene_sides_that_violate_triangle_inequality_are_not_scalene_even_if_they_are_all_different()
    {
        Assert.False(Triangle.IsScalene(7, 3, 2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Returns_true_if_the_triangle_is_scalene_sides_may_be_floats()
    {
        Assert.True(Triangle.IsScalene(0.5, 0.4, 0.6));
    }
}