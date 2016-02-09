using System;
using System.Collections.Generic;

public class DNA
{
    public IDictionary<char, int> NucleotideCounts { get; private set; }

    public DNA(string sequence)
    {
        InitializeNucleotideCounts(sequence);
    }

    private void InitializeNucleotideCounts(string sequence)
    {
        NucleotideCounts = new Dictionary<char, int> { { 'A', 0 }, { 'T', 0 }, { 'C', 0 }, { 'G', 0 } };
        foreach (var s in sequence)
            NucleotideCounts[s] += 1;
    }

    public int Count(char nucleotide)
    {
        int count;
        if (!NucleotideCounts.TryGetValue(nucleotide, out count))
            throw new InvalidNucleotideException();
        return count;
    }
}

public class InvalidNucleotideException : Exception { }
