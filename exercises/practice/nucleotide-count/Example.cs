using System;
using System.Collections.Generic;

public static class NucleotideCount
{
    public static IDictionary<char, int> Count(string sequence)
    {
        var nucleotideCounts = new Dictionary<char, int> { { 'A', 0 }, { 'T', 0 }, { 'C', 0 }, { 'G', 0 } };
      
        foreach (var s in sequence)
        {
            if (nucleotideCounts.TryGetValue(s, out var count))
            {
                nucleotideCounts[s] = count + 1;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        return nucleotideCounts;
    }
}
