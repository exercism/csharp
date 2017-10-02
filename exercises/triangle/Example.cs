using System;
using System.Linq;

public enum TriangleKind
{
    Equilateral,
    Isosceles,
    Scalene
}

public static class Triangle
{
    
    public bool IsScalene(decimal side1, decimal side2, decimal side3)
    {
        return Kind(side1, side2, side3) == TriangleKind.Scalene;
    }

    public bool IsIsosceles(decimal side1, decimal side2, decimal side3) 
    {
        return Kind(side1, side2, side3) == TriangleKind.Isosceles;
    }

    public bool IsEquilaterial(decimal side1, decimal side2, decimal side3) 
    {
        return Kind(side1, side2, side3) == TriangleKind.Equilateral;
    }

    private static TriangleKind Kind(decimal side1, decimal side2, decimal side3)
    {
        if (AllSidesAreZero(side1, side2, side3) ||
            HasImpossibleSides(side1, side2, side3) ||
            ViolatesTriangleInequality(side1, side2, side3))
        {
            throw new TriangleException();
        }

        int uniqueSides = UniqueSides(side1, side2, side3);
        if (uniqueSides == 1)
            return TriangleKind.Equilateral;
        if (uniqueSides == 2)
            return TriangleKind.Isosceles;
        return TriangleKind.Scalene;
    }

    private static bool AllSidesAreZero(decimal side1, decimal side2, decimal side3)
    {
        return side1 == 0 && side2 == 0 && side3 == 0;
    }

    private static bool HasImpossibleSides(decimal side1, decimal side2, decimal side3)
    {
        return side1 < 0 || side2 < 0 || side3 < 0;
    }

    private static bool ViolatesTriangleInequality(decimal side1, decimal side2, decimal side3)
    {
        return side1 + side2 <= side3 || side1 + side3 <= side2 || side2 + side3 <= side1;
    }

    private static int UniqueSides(decimal side1, decimal side2, decimal side3)
    {
        decimal[] sides = { side1, side2, side3 };
        return sides.Distinct().Count();
    }
}

public class TriangleException : Exception { }