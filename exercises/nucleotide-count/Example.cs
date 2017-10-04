using System;
using System.Collections.Generic;

public class NucleotideCount
{
    public IDictionary<char, int> NucleotideCounts { get; private set; }

    public NucleotideCount(string sequence)
    {
        InitializeNucleotideCounts(sequence);
    }

    private void InitializeNucleotideCounts(string sequence)
    {
        NucleotideCounts = new Dictionary<char, int> { { 'A', 0 }, { 'T', 0 }, { 'C', 0 }, { 'G', 0 } };
        try
        {
            foreach (var s in sequence)
                NucleotideCounts[s] += 1;
        }
        catch (KeyNotFoundException)
        {
            throw new InvalidNucleotideException();
        }
    }
}

public class InvalidNucleotideException : Exception { }
