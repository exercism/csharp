using System;
using System.Linq;

public enum TriangleKind
{
    Equilateral,
    Isosceles,
    Scalene,
    Invalid
}

public static class Triangle
{
    public static bool IsScalene(double side1, double side2, double side3)
    {
        return Kind(side1, side2, side3) == TriangleKind.Scalene;
    }

    public static bool IsIsosceles(double side1, double side2, double side3) 
    {
        var triangle = Kind(side1, side2, side3);
        return triangle == TriangleKind.Isosceles || triangle == TriangleKind.Equilateral;
    }

    public static bool IsEquilateral(double side1, double side2, double side3) 
    {
        return Kind(side1, side2, side3) == TriangleKind.Equilateral;
    }

    private static TriangleKind Kind(double side1, double side2, double side3)
    {
        if (AllSidesAreZero(side1, side2, side3) ||
            HasImpossibleSides(side1, side2, side3) ||
            ViolatesTriangleInequality(side1, side2, side3))
        {
            return TriangleKind.Invalid;
        }

        int uniqueSides = UniqueSides(side1, side2, side3);
        if (uniqueSides == 1)
            return TriangleKind.Equilateral;
        if (uniqueSides == 2)
            return TriangleKind.Isosceles;
        return TriangleKind.Scalene;
    }

    private static bool AllSidesAreZero(double side1, double side2, double side3)
    {
        return side1 == 0 && side2 == 0 && side3 == 0;
    }

    private static bool HasImpossibleSides(double side1, double side2, double side3)
    {
        return side1 < 0 || side2 < 0 || side3 < 0;
    }

    private static bool ViolatesTriangleInequality(double side1, double side2, double side3)
    {
        return side1 + side2 <= side3 || side1 + side3 <= side2 || side2 + side3 <= side1;
    }

    private static int UniqueSides(double side1, double side2, double side3)
    {
        double[] sides = { side1, side2, side3 };
        return sides.Distinct().Count();
    }
}