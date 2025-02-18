using System;
using System.Linq;

public static class DifferenceOfSquares
{
    public static int CalculateSquareOfSum(int max)
    {
        var numbers = Enumerable.Range(1, max);
        int sum = numbers.Sum();
        return sum * sum;
    }

    public static int CalculateSumOfSquares(int max)
    {
        var numbers = Enumerable.Range(1, max);
        return numbers.Select(x => x * x).Sum();
    }

    public static int CalculateDifferenceOfSquares(int max)
    {
        return CalculateSquareOfSum(max) - CalculateSumOfSquares(max);
    }
}