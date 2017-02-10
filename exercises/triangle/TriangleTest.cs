using Xunit;

public class TriangleTest
{
    [Fact]
    public void Equilateral_triangles_have_equal_sides()
    {
        Assert.Equal(TriangleKind.Equilateral, Triangle.Kind(2, 2, 2));
    }

    [Fact]
    public void Larger_equilateral_triangles_also_have_equal_sides()
    {
        Assert.Equal(TriangleKind.Equilateral, Triangle.Kind(10, 10, 10));
    }

    [Fact]
    public void Isosceles_triangles_have_last_two_sides_equal()
    {
        Assert.Equal(TriangleKind.Isosceles, Triangle.Kind(3, 4, 4));
    }

    [Fact]
    public void Isosceles_triangles_have_first_and_last_sides_equal()
    {
        Assert.Equal(TriangleKind.Isosceles, Triangle.Kind(4, 3, 4));
    }

    [Fact]
    public void Isosceles_triangles_have_two_first_sides_equal()
    {
        Assert.Equal(TriangleKind.Isosceles, Triangle.Kind(4, 4, 3));
    }

    [Fact]
    public void Isosceles_triangles_have_in_fact_exactly_two_sides_equal()
    {
        Assert.Equal(TriangleKind.Isosceles, Triangle.Kind(10, 10, 2));
    }

    [Fact]
    public void Scalene_triangles_have_no_equal_sides()
    {
        Assert.Equal(TriangleKind.Scalene, Triangle.Kind(3, 4, 5));
    }

    [Fact]
    public void Scalene_triangles_have_no_equal_sides_at_a_larger_scale_too()
    {
        Assert.Equal(TriangleKind.Scalene, Triangle.Kind(10, 11, 12));
    }

    [Fact]
    public void Scalene_triangles_have_no_equal_sides_in_descending_order_either()
    {
        Assert.Equal(TriangleKind.Scalene, Triangle.Kind(5, 4, 2));
    }

    [Fact]
    public void Very_small_triangles_are_legal()
    {
        Assert.Equal(TriangleKind.Scalene, Triangle.Kind(0.4m, 0.6m, 0.3m));
    }

    [Fact]
    public void Triangles_with_no_size_are_illegal()
    {
        Assert.Throws<TriangleException>(() => Triangle.Kind(0, 0, 0));
    }

    [Fact]
    public void Triangles_with_negative_sides_are_illegal()
    {
        Assert.Throws<TriangleException>(() => Triangle.Kind(3, 4, -5));
    }

    [Fact]
    public void Triangles_violating_triangle_inequality_are_illegal()
    {
        Assert.Throws<TriangleException>(() => Triangle.Kind(1, 1, 3));
    }

    [Fact]
    public void Triangles_violating_triangle_inequality_are_illegal_2()
    {
        Assert.Throws<TriangleException>(() => Triangle.Kind(2, 4, 2));
    }

    [Fact]
    public void Triangles_violating_triangle_inequality_are_illegal_3()
    {
        Assert.Throws<TriangleException>(() => Triangle.Kind(7, 3, 2));
    }
}