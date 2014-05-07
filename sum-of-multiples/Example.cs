using System.Collections.Generic;
using System.Linq;

public class SumOfMultiples
{
    private List<int> multiples;

    public SumOfMultiples()
    {
        multiples = new List<int> { 5, 3 };
    }

    public SumOfMultiples(IEnumerable<int> multiplesToCheck)
    {
        multiples = multiplesToCheck.ToList();
    }

    public int To(int limit)
    {
        return Enumerable.Range(1, limit - 1).Where(IsMultiple).Sum();
    }

    private bool IsMultiple(int input)
    {
        return multiples.Any(multiple => input % multiple == 0);
    }
}