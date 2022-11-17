# Introduction

TODO

## General guidance

TODO

## Approach:using a `Dictionary`

```csharp
public static class RnaTranscription
{
    public static string ToRna(string dna) =>
        new(dna.Select(nucleotide => Complements[nucleotide]).ToArray());

    private static readonly Dictionary<char, char> Complements =
        new() { ['G'] = 'C', ['C'] = 'G', ['T'] = 'A', ['A'] = 'U' };
}
```

This approach uses [LINQ][linq] to iterate and map the nucleotide and a [`Dictionary`][dictionary] to translate .
For more information, check the [`Dictionary` approach][approach-dictionary].

## Which approach to use?

TODO

[approach-dictionary]: https://exercism.org/tracks/csharp/exercises/rna-transcription/approaches/linq-dictionary
[linq]: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/
[dictionary]: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2
