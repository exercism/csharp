using System;

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
        throw new NotImplementedException("You need to implement this function.");
    }

    public bool IsIsosceles(decimal side1, decimal side2, decimal side3) 
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public bool IsEquilaterial(decimal side1, decimal side2, decimal side3) 
    {
        throw new NotImplementedException("You need to implement this function.");
    }
    
    private static TriangleKind Kind(decimal side1, decimal side2, decimal side3)
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}

public class TriangleException : Exception { }