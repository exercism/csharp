using System;
using System.Linq;

public static class Squares
{
    public static int SquareOfSums(int max)
    {
        var numbers = Enumerable.Range(1, max);
        int sum = numbers.Sum();
        return sum * sum;
    }

    public static int SumOfSquares(int max)
    {
        var numbers = Enumerable.Range(1, max);
        return numbers.Select(x => x * x).Sum();
    }

    public static int DifferenceOfSquares(int max)
    {
        return SquareOfSums(max) - SumOfSquares(max);
    }
}