# Using a `switch` expression

```csharp
using System.Linq;

public static class RnaTranscription
{
    public static string ToRna(string dna) =>
        new(dna.Select(Complement).ToArray());

    private static char Complement(char nucleotide) =>
        nucleotide switch
        {
            'G' => 'C',
            'C' => 'G',
            'T' => 'A',
            'A' => 'U'
        };
}
```

## Using a `foreach` loop

You could also use a regular `foreach` loop over LINQ:

```csharp
public static string ToRna(string dna)
{
    var rna = "";

    foreach (var nucleotide in dna)
        rna += Complement(nucleotide);

    return rna;
}
```

TODO

[linq]: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/
[dictionary]: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2
