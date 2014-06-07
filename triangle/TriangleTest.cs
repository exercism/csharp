using NUnit.Framework;

[TestFixture]
public class TriangleTest
{
    [Test]
    public void Equilateral_triangles_have_equal_sides()
    {
        Assert.That(new Triangle(2, 2, 2).Kind(), Is.EqualTo(TriangleKind.Equilateral));
    }

    [Ignore]
    [Test]
    public void Larger_equilateral_triangles_also_have_equal_sides()
    {
        Assert.That(new Triangle(10, 10, 10).Kind(), Is.EqualTo(TriangleKind.Equilateral));
    }

    [Ignore]
    [Test]
    public void Isosceles_triangles_have_last_two_sides_equal()
    {
        Assert.That(new Triangle(3, 4, 4).Kind(), Is.EqualTo(TriangleKind.Isosceles));
    }

    [Ignore]
    [Test]
    public void Isosceles_triangles_have_first_and_last_sides_equal()
    {
        Assert.That(new Triangle(4, 3, 4).Kind(), Is.EqualTo(TriangleKind.Isosceles));
    }

    [Ignore]
    [Test]
    public void Isosceles_triangles_have_two_first_sides_equal()
    {
        Assert.That(new Triangle(4, 4, 3).Kind(), Is.EqualTo(TriangleKind.Isosceles));
    }

    [Ignore]
    [Test]
    public void Isosceles_triangles_have_in_fact_exactly_two_sides_equal()
    {
        Assert.That(new Triangle(10, 10, 2).Kind(), Is.EqualTo(TriangleKind.Isosceles));
    }

    [Ignore]
    [Test]
    public void Scalene_triangles_have_no_equal_sides()
    {
        Assert.That(new Triangle(3, 4, 5).Kind(), Is.EqualTo(TriangleKind.Scalene));
    }

    [Ignore]
    [Test]
    public void Scalene_triangles_have_no_equal_sides_at_a_larger_scale_too()
    {
        Assert.That(new Triangle(10, 11, 12).Kind(), Is.EqualTo(TriangleKind.Scalene));
    }

    [Ignore]
    [Test]
    public void Scalene_triangles_have_no_equal_sides_in_descending_order_either()
    {
        Assert.That(new Triangle(5, 4, 2).Kind(), Is.EqualTo(TriangleKind.Scalene));
    }

    [Ignore]
    [Test]
    public void Very_small_triangles_are_legal()
    {
        Assert.That(new Triangle(0.4m, 0.6m, 0.3m).Kind(), Is.EqualTo(TriangleKind.Scalene));
    }

    [Ignore]
    [Test]
    public void Triangles_with_no_size_are_illegal()
    {
        Assert.Throws<TriangleException>(() => new Triangle(0, 0, 0).Kind());
    }

    [Ignore]
    [Test]
    public void Triangles_with_negative_sides_are_illegal()
    {
        Assert.Throws<TriangleException>(() => new Triangle(3, 4, -5).Kind());
    }

    [Ignore]
    [Test]
    public void Triangles_violating_triangle_inequality_are_illegal()
    {
        Assert.Throws<TriangleException>(() => new Triangle(1, 1, 3).Kind());
    }

    [Ignore]
    [Test]
    public void Triangles_violating_triangle_inequality_are_illegal_2()
    {
        Assert.Throws<TriangleException>(() => new Triangle(2, 4, 2).Kind());
    }

    [Ignore]
    [Test]
    public void Triangles_violating_triangle_inequality_are_illegal_3()
    {
        Assert.Throws<TriangleException>(() => new Triangle(7, 3, 2).Kind());
    }
}