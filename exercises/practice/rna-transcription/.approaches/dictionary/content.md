# Using a `Dictionary`

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

Within the `Select()` method's lambda argument, we'll need to translate the nucleotide to its complement.
We can do that by creating a dictionary with the key being the nucleotide and the value its complement:

```csharp
private static readonly Dictionary<char, char> Complements = new Dictionary<char, char>
    {
        ['G'] = 'C',
        ['C'] = 'G',
        ['T'] = 'A',
        ['A'] = 'U'
    };
```

Using a [target-typed new expression][target-typed-new], we can omit the second `Dictionary<char, char>` type:

```csharp
private static readonly Dictionary<char, char> Complements = new()
    {
        ['G'] = 'C',
        ['C'] = 'G',
        ['T'] = 'A',
        ['A'] = 'U'
    };
```

We can then use this dictionary in our lambda to get the nucleotide's complement:

```csharp
dna.Select(nucleotide => Complements[nucleotide])
```

This will return a new `IEnumerable<char>`, which we can convert back to a `string` by first converting it to a `char[]` and then passing that to a string constructor:

```csharp
public static string ToRna(string dna)
{
    return new string(dna.Select(nucleotide => Complements[nucleotide]).ToArray());
}
```

As this has just a single `return` statement, we can convert it to an [expression-bodied method][expression-bodied-method]:

```csharp
public static string ToRna(string dna) =>
    new string(dna.Select(nucleotide => Complements[nucleotide]).ToArray());
```

Finally, we can once again use a [target-typed new][target-typed-new] expression to replace `new string` with just `new`:

```csharp
public static string ToRna(string dna) =>
    new(dna.Select(nucleotide => Complements[nucleotide]).ToArray());
```

And with that we have a concise, working implementation!

## Alternative: using a `foreach` loop

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

[linq]: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/
[dictionary]: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2
[target-typed-new]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/target-typed-new
[enumerable.select]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.select
[enumerable.to-array]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.toarray?view=net-7.0
[expression-bodied-member]: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members
