# Introduction

The key to this exercise is to both iterate over a string _and_ transform its characters, resulting in a new string.

## General guidance

- [LINQ][linq] can be very useful to iterate and map over a `string`

## Approach: using a `Dictionary`

```csharp
public static string ToRna(string dna) =>
    new(dna.Select(nucleotide => Complements[nucleotide]).ToArray());

private static readonly Dictionary<char, char> Complements =
    new() { ['G'] = 'C', ['C'] = 'G', ['T'] = 'A', ['A'] = 'U' };
```

This approach uses [LINQ][linq] to iterate and map the nucleotide and a [`Dictionary`][dictionary] to translate .
For more information, check the [`Dictionary` approach][approach-dictionary].

## Approach: using a `switch` expression

```csharp
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
```

This approach uses [LINQ][linq] to iterate and map the nucleotide and a [`switch` expression][switch-expression] translate .
For more information, check the [`switch` expression approach][approach-switch-expression].

## Which approach to use?

Which approach to use is pretty much a matter of personal preference.

[approach-dictionary]: https://exercism.org/tracks/csharp/exercises/rna-transcription/approaches/dictionary
[approach-switch-expression]: https://exercism.org/tracks/csharp/exercises/rna-transcription/approaches/switch-expression
[linq]: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/
[dictionary]: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2
[switch-expression]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/switch-expression
