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

The first step is to decide how we want to iterate over and transform the nucleotides.
As the `string` class implements the `IEnumerable<char>` interface, this allows us to call
[LINQ][linq]'s [`Select()` method][enumerable.select] on it, which can do both the iteration _and_ the transformation in one go!

```csharp
dna.Select(nucleotide => TODO)
```

To translate

```csharp
private static readonly Dictionary<char, char> Complements =
    new Dictionary<char, char>() { ['G'] = 'C', ['C'] = 'G', ['T'] = 'A', ['A'] = 'U' };
```

Using a [target-typed new][target-typed-new] expression, we don't have to repeat the `Dictionary<char, char>` type after the `new()` call, as the compiler can figure out its type:

```csharp
private static readonly Dictionary<char, char> Complements =
    new() { ['G'] = 'C', ['C'] = 'G', ['T'] = 'A', ['A'] = 'U' };
```

## Using a `foreach` loop

You could also use a regular `foreach` loop instead of LINQ:

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
[target-typed-new]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/target-typed-new
[enumerable.select]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.select
[enumerable.to-array]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.toarray?view=net-7.0
