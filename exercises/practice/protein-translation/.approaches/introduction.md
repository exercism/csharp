
## Approach: `Substring()` with a `Dictionary`

```csharp
using System;
using System.Collections.Generic;

public static class ProteinTranslation
{
    private static readonly Dictionary<string, string> lookup = new Dictionary<string, string>();

    private static void roboLoad(string protein, params string[] codons)
    {
        foreach (string codon in codons)
            lookup.Add(codon, protein);
    }

    static ProteinTranslation()
    {
        roboLoad("Methionine", "AUG");
        roboLoad("Phenylalanine", "UUU", "UUC");
        roboLoad("Leucine", "UUA", "UUG");
        roboLoad("Serine", "UCU", "UCC", "UCA", "UCG");
        roboLoad("Tyrosine", "UAU", "UAC");
        roboLoad("Cysteine", "UGU", "UGC");
        roboLoad("Tryptophan", "UGG");
        roboLoad("STOP", "UAA", "UAG", "UGA");
    }

    public static string[] Proteins(string strand)
    {
        var length = strand.Length;
        List<String> proteins = new List<String>();
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
}
```

## Approach: `Substring()` with a `switch`

```csharp
using System;
using System.Collections.Generic;

public static class ProteinTranslation
{
    public static string[] Proteins(string strand)
    {
        var length = strand.Length;
        List<String> proteins = new List<String>();
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
}
```

## Approach: LINQ with a `Dictionary`

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

public static class ProteinTranslation
{
    public static string[] Proteins(string strand)
    {
          IDictionary<string, string> proteins = new Dictionary<string, string>();
          proteins.Add("AUG", "Methionine");
          proteins.Add("UUU", "Phenylalanine");
          proteins.Add("UUC" , "Phenylalanine");
          proteins.Add("UUA", "Leucine");
          proteins.Add("UUG" , "Leucine");
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
  
        return strand
            .Select((s, i) => i)
            .Where(i => i % 3 == 0)
            .Select(i => strand.Substring(i, 3))
            .TakeWhile(s => proteins[s] != "STOP")
            .Select(s => proteins[s]).ToArray();
    }
 
}
```

## Approach: `yield` with a `Dictionary`

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

public static class ProteinTranslation
{
    private static IDictionary<string, string> proteins = new Dictionary<string, string>();

    static ProteinTranslation()
    {
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

    public static string[] Proteins(string strand) =>
        strand.Chunked(3).Select(protein => proteins[protein]).TakeWhile(protein => protein != "STOP").ToArray();

    private static IEnumerable<string> Chunked(this string input, int size)
    {
        for (var i = 0; i < input.Length; i += size)
            yield return input[i..(i + size)];
    }

}

```

## Approach: `yield` with a `switch`

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

public static class ProteinTranslation
{
    public static string[] Proteins(string strand) =>
        strand.Chunked(3).Select(ToProtein).TakeWhile(protein => protein != "STOP").ToArray();

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

    private static IEnumerable<string> Chunked(this string input, int size)
    {
        for (var i = 0; i < input.Length; i += size)
            yield return input[i .. (i + size)];
    }
}
```
