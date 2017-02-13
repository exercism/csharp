using System;

public enum TriangleKind
{
    Equilateral,
    Isosceles,
    Scalene
}

public class Triangle
{
    public static TriangleKind Kind(decimal side1, decimal side2, decimal side3)
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}

public class TriangleException : Exception { }