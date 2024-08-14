using System;
using System.Collections.Generic;
using System.Linq;

public static class RnaTranscription
{
    private static readonly Dictionary<char, char> DnaToRna = new Dictionary<char, char>
        {
            { 'G', 'C' }, { 'C', 'G' }, { 'T', 'A' }, { 'A', 'U' }
        };

    public static string ToRna(string strand)
    {
        if (strand.Any(x => !DnaToRna.ContainsKey(x)))
        {
            throw new ArgumentException("invalid nucleotide");
        }

        return string.Concat(strand.Select(x => DnaToRna[x]));
    }
}