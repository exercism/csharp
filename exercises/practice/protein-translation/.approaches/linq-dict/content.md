# LINQ with a `Dictionary`

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

The approach begins by defining a [`private`][private], [`static`][static], [`readonly`][readonly] [`Dictionary`][dictionary] for translating the codons to proteins.
It is private because it isn't needed outside the class.
It is static because only one is needed to serve every instance of the class.
It is readonly because, although it has interior mutability (meaning its elements can change),
the `Dictionary` variable itself will not be assigned to another `Dictionary`.

The [static constructor][static-constructor] loads the `Dictionary` from the codons and their matching protein.

The `Proteins()` method starts by calling the [LINQ][linq] [`Select()`][select] method to iterate the characters of the input strand.
Inside the body of the `Select()` is a [lambda][lambda] function that take two arguments: the character and its index.
Since the character isn't used, it is represented by a [discard][discard] (`_`).

The index from `Select()` is chained into the input for the [`Where()` ][where] method,
which filters the indexes by whether they are evenly divisible by `3`.

The surviving indexes are chained into the input for the next `Select()`.
Inside the body of the `Select()` is a lambda which calls the [`Substring()`][substring] method,
passing the index for the starting position and a length of `3`.
For a strand of six characters, the first surviving index will be `0`, since `0` divided by `3` has a remainder of `0`,
and the `Substring()` will get the characters from positions `0` through `2`.
The next surviving index will be `3`, since `3` divided by `3` has a remainder of `0`,
and the `Substring()` will get the characters from positions `3` through `5`.
These substrings are the codons that are used as the key to lookup their matching proteins in the `Dictionary`.

Each matching protein is chained from the output of `Select()` to the input of the [`TakeWhile()`][takewhile] method,
which filters the proteins in a lambda based on whether the protein is a `STOP` codon.
Unlike `Where()`, once the lambda in `TakeWhile()` encounters a failing lambda condition, it does not continue to iterate, but stops.

The proteins that survive the `TakeWhile()` are chained into the input of the `ToArray()` method.

The [`ToArray()`][toarray] method is used to return an array of the matched proteins from the `Proteins()` method.

[private]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/private
[static]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/static
[readonly]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/readonly
[dictionary]: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2
[static-constructor]: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/static-constructors
[linq]: https://learn.microsoft.com/en-us/dotnet/api/system.linq
[select]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.select
[lambda]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions
[discard]: https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/discards
[where]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.where
[substring]: https://learn.microsoft.com/en-us/dotnet/api/system.string.substring
[takewhile]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.takewhile
[toarray]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.toarray
