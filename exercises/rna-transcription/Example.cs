using System.Collections.Generic;
using System.Linq;

public class Complement
{
    private static readonly Dictionary<char, char> DnaToRna = new Dictionary<char, char>
        {
            { 'G', 'C' }, { 'C', 'G' }, { 'T', 'A' }, { 'A', 'U' }
        };

    public static string ToRna(string nucleotide)
    {
        if (nucleotide.Any(x => !DnaToRna.ContainsKey(x)))
        {
            return null;
        }

        return string.Concat(nucleotide.Select(x => DnaToRna[x]));
    }
}