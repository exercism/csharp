using NUnit.Framework;

[TestFixture]
public class TriangleTest
{
    [Test]
    public void Equilateral_triangles_have_equal_sides()
    {
        Assert.That(Triangle.Kind(2, 2, 2), Is.EqualTo(TriangleKind.Equilateral));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Larger_equilateral_triangles_also_have_equal_sides()
    {
        Assert.That(Triangle.Kind(10, 10, 10), Is.EqualTo(TriangleKind.Equilateral));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Isosceles_triangles_have_last_two_sides_equal()
    {
        Assert.That(Triangle.Kind(3, 4, 4), Is.EqualTo(TriangleKind.Isosceles));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Isosceles_triangles_have_first_and_last_sides_equal()
    {
        Assert.That(Triangle.Kind(4, 3, 4), Is.EqualTo(TriangleKind.Isosceles));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Isosceles_triangles_have_two_first_sides_equal()
    {
        Assert.That(Triangle.Kind(4, 4, 3), Is.EqualTo(TriangleKind.Isosceles));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Isosceles_triangles_have_in_fact_exactly_two_sides_equal()
    {
        Assert.That(Triangle.Kind(10, 10, 2), Is.EqualTo(TriangleKind.Isosceles));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Scalene_triangles_have_no_equal_sides()
    {
        Assert.That(Triangle.Kind(3, 4, 5), Is.EqualTo(TriangleKind.Scalene));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Scalene_triangles_have_no_equal_sides_at_a_larger_scale_too()
    {
        Assert.That(Triangle.Kind(10, 11, 12), Is.EqualTo(TriangleKind.Scalene));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Scalene_triangles_have_no_equal_sides_in_descending_order_either()
    {
        Assert.That(Triangle.Kind(5, 4, 2), Is.EqualTo(TriangleKind.Scalene));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Very_small_triangles_are_legal()
    {
        Assert.That(Triangle.Kind(0.4m, 0.6m, 0.3m), Is.EqualTo(TriangleKind.Scalene));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Triangles_with_no_size_are_illegal()
    {
        Assert.Throws<TriangleException>(() => Triangle.Kind(0, 0, 0));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Triangles_with_negative_sides_are_illegal()
    {
        Assert.Throws<TriangleException>(() => Triangle.Kind(3, 4, -5));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Triangles_violating_triangle_inequality_are_illegal()
    {
        Assert.Throws<TriangleException>(() => Triangle.Kind(1, 1, 3));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Triangles_violating_triangle_inequality_are_illegal_2()
    {
        Assert.Throws<TriangleException>(() => Triangle.Kind(2, 4, 2));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Triangles_violating_triangle_inequality_are_illegal_3()
    {
        Assert.Throws<TriangleException>(() => Triangle.Kind(7, 3, 2));
    }
}