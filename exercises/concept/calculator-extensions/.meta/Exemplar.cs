using System;
using System.Collections.Generic;
using System.Linq;

public static class CalculatorExtensions
{
    public static int Sum(this IEnumerable<int> numbers) =>
        numbers.Aggregate(0, (acc, cur) => acc + cur);

    public static int Product(this IEnumerable<int> numbers) =>
        numbers.Aggregate(1, (acc, cur) => acc * cur);

    public static double Mean(this IEnumerable<int> numbers) =>
        (double)numbers.Sum() / numbers.Count();

    public static double Median(this IEnumerable<int> numbers) =>
        numbers.Count() % 2 == 0
        ? numbers.OrderBy(x => x)
            .Skip((numbers.Count() - 1) / 2)
            .Take(2)
            .Mean()
        : numbers.OrderBy(x => x)
            .Skip((numbers.Count() - 1) / 2)
            .First();

    public static int Mode(this IEnumerable<int> numbers) =>
        numbers.GroupBy(v => v)
            .OrderByDescending(g => g.Count())
            .First()
            .Key;
}