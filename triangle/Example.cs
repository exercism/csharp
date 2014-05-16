using System;
using System.Linq;

public enum TriangleKind
{
    Equilateral,
    Isosceles,
    Scalene
}

public class Triangle
{
    private readonly decimal side1;
    private readonly decimal side2;
    private readonly decimal side3;

    public Triangle(decimal side1, decimal side2, decimal side3)
    {
        this.side1 = side1;
        this.side2 = side2;
        this.side3 = side3;
    }

    public TriangleKind Kind()
    {
        if (AllSidesAreZero() || HasImpossibleSides() || ViolatesTriangleInequality())
            throw new TriangleException();

        int uniqueSides = UniqueSides();
        if (uniqueSides == 1)
            return TriangleKind.Equilateral;
        if (uniqueSides == 2)
            return TriangleKind.Isosceles;
        return TriangleKind.Scalene;
    }

    private bool AllSidesAreZero()
    {
        return side1 == 0 && side2 == 0 && side3 == 0;
    }

    private bool HasImpossibleSides()
    {
        return side1 < 0 || side2 < 0 || side3 < 0;
    }

    private bool ViolatesTriangleInequality()
    {
        return side1 + side2 <= side3 || side1 + side3 <= side2 || side2 + side3 <= side1;
    }

    private int UniqueSides()
    {
        decimal[] sides = { side1, side2, side3 };
        return sides.Distinct().Count();
    }
}

public class TriangleException : Exception { }