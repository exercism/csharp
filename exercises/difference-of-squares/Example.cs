using System;
using System.Linq;

public class Squares
{
    private readonly int max;

    public Squares(int max)
    {
        if (max < 0)
        {
            throw new ArgumentException("Max must be positive", "max");
        }

        this.max = max;
    }

    public int SquareOfSums()
    {
        var numbers = Enumerable.Range(1, max);
        int sum = numbers.Sum();
        return sum * sum;
    }

    public int SumOfSquares()
    {
        var numbers = Enumerable.Range(1, max);
        return numbers.Select(x => x * x).Sum();
    }

    public int DifferenceOfSquares()
    {
        return SquareOfSums() - SumOfSquares();
    }
}