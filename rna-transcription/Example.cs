using System.Collections.Generic;
using System.Linq;

public class Complement
{
    private static readonly Dictionary<char, char> DnaToRna = new Dictionary<char, char>
        {
            { 'G', 'C' }, { 'C', 'G' }, { 'T', 'A' }, { 'A', 'U' }
        };
    private static readonly Dictionary<char, char> RnaToDna = new Dictionary<char, char>
        {
            { 'C', 'G' }, { 'G', 'C' }, { 'A', 'T' }, { 'U', 'A' }
        };

    public static string OfDna(string nucleotide)
    {
        return string.Concat(nucleotide.Select(x => DnaToRna[x]));
    }

    public static string OfRna(string nucleotide)
    {
        return string.Concat(nucleotide.Select(x => RnaToDna[x]));
    }
}