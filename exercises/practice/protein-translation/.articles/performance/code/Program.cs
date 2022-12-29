using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;

[MemoryDiagnoser]
public class BenchMe
{
    private readonly string strand = "UGGUGUUAUUAAUGGUUU";

    private static readonly Dictionary<string, string> lookup = new();
    private static void RoboLoad(string protein, params string[] codons)
    {
        foreach (string codon in codons)
            lookup.Add(codon, protein);
    }

    [Benchmark]
    public string[] ProteinsSubstringDict()
    {
        var length = strand.Length;
        List<String> proteins = new();
        var endIndex = 3;
        while (endIndex <= length)
        {
            var codon = strand.Substring(endIndex - 3, 3);
            var protein = lookup[codon];
            switch (protein)
            {
                case "STOP":
                    return proteins.ToArray();
                default:
                    proteins.Add(protein);
                    break;
            }
            endIndex += 3;
        }
        return proteins.ToArray();
    }

    [Benchmark]
    public string[] ProteinsSubstringSwitch()
    {
        var length = strand.Length;
        List<String> proteins = new();
        var endIndex = 3;
        while (endIndex <= length)
        {
            var codon = strand.Substring(endIndex - 3, 3);
            var protein = ToProtein(codon);
            switch (protein)
            {
                case "STOP":
                    return proteins.ToArray();
                default:
                    proteins.Add(protein);
                    break;
            }
            endIndex += 3;
        }
        return proteins.ToArray();
    }

    private static readonly IDictionary<string, string> proteins = new Dictionary<string, string>();

    static BenchMe ()
    {
        RoboLoad("Methionine", "AUG");
        RoboLoad("Phenylalanine", "UUU", "UUC");
        RoboLoad("Leucine", "UUA", "UUG");
        RoboLoad("Serine", "UCU", "UCC", "UCA", "UCG");
        RoboLoad("Tyrosine", "UAU", "UAC");
        RoboLoad("Cysteine", "UGU", "UGC");
        RoboLoad("Tryptophan", "UGG");
        RoboLoad("STOP", "UAA", "UAG", "UGA");

        proteins.Add("AUG", "Methionine");
        proteins.Add("UUU", "Phenylalanine");
        proteins.Add("UUC", "Phenylalanine");
        proteins.Add("UUA", "Leucine");
        proteins.Add("UUG", "Leucine");
        proteins.Add("UCU", "Serine");
        proteins.Add("UCC", "Serine");
        proteins.Add("UCA", "Serine");
        proteins.Add("UCG", "Serine");
        proteins.Add("UAU", "Tyrosine");
        proteins.Add("UAC", "Tyrosine");
        proteins.Add("UGU", "Cysteine");
        proteins.Add("UGC", "Cysteine");
        proteins.Add("UGG", "Tryptophan");
        proteins.Add("UAA", "STOP");
        proteins.Add("UAG", "STOP");
        proteins.Add("UGA", "STOP");
    }

    [Benchmark]
    public string[] ProteinsLinqDict()
    {
        return strand
            .Select((_, i) => i)
            .Where(i => i % 3 == 0)
            .Select(i =>  proteins[strand.Substring(i, 3)])
            .TakeWhile(protein => protein != "STOP")
            .ToArray();
    }


    [Benchmark]
    public string[] ProteinsYieldDict() =>
            strand.Chunked(3).Select(codon => proteins[codon]).TakeWhile(protein => protein != "STOP").ToArray();

    private static string ToProtein(string input) =>
            input switch
            {
                "AUG" => "Methionine",
                "UUU" => "Phenylalanine",
                "UUC" => "Phenylalanine",
                "UUA" => "Leucine",
                "UUG" => "Leucine",
                "UCU" => "Serine",
                "UCC" => "Serine",
                "UCA" => "Serine",
                "UCG" => "Serine",
                "UAU" => "Tyrosine",
                "UAC" => "Tyrosine",
                "UGU" => "Cysteine",
                "UGC" => "Cysteine",
                "UGG" => "Tryptophan",
                "UAA" => "STOP",
                "UAG" => "STOP",
                "UGA" => "STOP",
                _ => throw new Exception("Invalid sequence")
            };

    [Benchmark]
    public string[] ProteinsYieldSwitch() =>
        strand.Chunked(3).Select(ToProtein).TakeWhile(protein => protein != "STOP").ToArray();

}
static class Program
{
    public static void Main()
    {
        var summary = BenchmarkRunner.Run<BenchMe>();
    }

    public static IEnumerable<string> Chunked(this string input, int size)
    {
        for (var i = 0; i < input.Length; i += size)
            yield return input[i..(i + size)];
    }

}
