using System;
using System.Collections.Generic;

public class DNA
{
    public DNA(string sequence)
    {
    }

    public IDictionary<char, int> NucleotideCounts
    {
        get
        {
            throw new NotImplementedException("You need to implement this function.");
        }
    }

    public int Count(char nucleotide)
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}

public class InvalidNucleotideException : Exception { }
