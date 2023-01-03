# Introduction

There are various idiomatic approaches to solve Protein Translation in C#.
The `Substring()` method could be used with looking values up in either a `Dictionary` or a `switch`.
Some chained LINQ methods could also use `Substring()` and look the values up in a `Dictionary`.
The `yield` method could be used with looking values up in either a `Dictionary` or a `switch`.

## General guidance

The objective is to iterate three characters at a time and to stop iterating when a `STOP` codon is received.
At the time of this writing there is no defensive coding needed to validate codons, but that could change in the future.

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

For more information, check the [`Substring()` with `Dictionary` approach][approach-substring-dict].

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

For more information, check the [`Substring()` with `switch` approach][approach-substring-switch].

## Approach: LINQ with a `Dictionary`

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

public static class ProteinTranslation
{

    private static readonly IDictionary<string, string> proteins = new Dictionary<string, string>();

    static ProteinTranslation()
    {
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
    }
    
    public static string[] Proteins(string strand)
    {
        return strand
            .Select((_, i) => i)
            .Where(i => i % 3 == 0)
            .Select(i =>  proteins[strand.Substring(i, 3)])
            .TakeWhile(protein => protein != "STOP")
            .ToArray();
    }
 
}
```

For more information, check the [LINQ with `Dictionary` approach][approach-linq-dict].

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
        strand.Chunked(3).Select(codon => proteins[codon]).TakeWhile(protein => protein != "STOP").ToArray();

    private static IEnumerable<string> Chunked(this string input, int size)
    {
        for (var i = 0; i < input.Length; i += size)
            yield return input[i..(i + size)];
    }

}

```

For more information, check the [`yield` with `Dictionary` approach][approach-yield-dict].

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

For more information, check the [`yield` with `switch` approach][approach-substring-switch].

# Which approach to use?

The `Substring()` with `switch` approach benchmarked the fastest.

- To compare the performance of the approaches, check out the [Performance article][article-performance].

[approach-substring-dict]: https://exercism.org/tracks/csharp/exercises/protein-translation/approaches/substring-dict
[approach-substring-switch]: https://exercism.org/tracks/csharp/exercises/protein-translation/approaches/substring-switch
[approach-linq-dict]: https://exercism.org/tracks/csharp/exercises/protein-translation/approaches/linq-dict
[approach-yield-dict]: https://exercism.org/tracks/csharp/exercises/protein-translation/approaches/yield-dict
[approach-yield-switch]: https://exercism.org/tracks/csharp/exercises/protein-translation/approaches/yield-switch
[article-performance]: https://exercism.org/tracks/csharp/exercises/protein-translation/articles/performance
