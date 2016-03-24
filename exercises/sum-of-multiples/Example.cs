using System.Collections.Generic;
using System.Linq;

public static class SumOfMultiples
{
    public static int To(IEnumerable<int> multiples, int max)
    {
        return Enumerable.Range(1, max - 1)
            .Where(i => multiples.Any(m => i % m == 0))
            .Sum();
    }
}