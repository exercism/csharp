using System.Collections.Generic;
using System.Linq;

public class Complement
{
    private static readonly Dictionary<char, char> DnaToRna = new Dictionary<char, char>
        {
            { 'G', 'C' }, { 'C', 'G' }, { 'T', 'A' }, { 'A', 'U' }
        };

    public static string OfDna(string nucleotide)
    {
        return string.Concat(nucleotide.Select(x => DnaToRna[x]));
    }
}