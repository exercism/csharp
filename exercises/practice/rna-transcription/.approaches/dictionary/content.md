# LINQ using a `Dictionary`

```csharp
using System.Collections.Generic;
using System.Linq;

public static class RnaTranscription
{
    public static string ToRna(string dna) =>
        new(dna.Select(nucleotide => Complements[nucleotide]).ToArray());

    private static readonly Dictionary<char, char> Complements =
        new() { ['G'] = 'C', ['C'] = 'G', ['T'] = 'A', ['A'] = 'U' };
}
```

## Using a `foreach` loop

You could also use a regular `foreach` loop over LINQ:

```csharp
public static string ToRna(string dna)
{
    var rna = "";

    foreach (var nucleotide in dna)
        rna += Complements[nucleotide];

    return rna;
}
```

TODO

[linq]: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/
[dictionary]: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2
