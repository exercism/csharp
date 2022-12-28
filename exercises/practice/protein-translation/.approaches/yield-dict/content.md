# `yield` with a `Dictionary`

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
