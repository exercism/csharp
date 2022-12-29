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
        strand.Chunked(3).Select(codon => proteins[codon]).TakeWhile(protein => protein != "STOP").ToArray();

    private static IEnumerable<string> Chunked(this string input, int size)
    {
        for (var i = 0; i < input.Length; i += size)
            yield return input[i..(i + size)];
    }

}
```

The approach begins by defining a [`private`][private], [`static`][static], [`readonly`][readonly] [`Dictionary`][dictionary] for translating the codons to proteins.
It is private because it isn't needed outside the class.
It is static because only one is needed to serve every instance of the class.
It is readonly because, although it has interior mutability (meaning its elements can change),
the `Dictionary` variable itself will not be assigned to another `Dictionary`.

The [static constructor][static-constructor] loads the `Dictionary` from the codons and their matching protein.

The `Proteins()` method starts by calling the private static [extension method][extension-method] `Chunked()`,
which is also an [iterator method][iterator-method].
The function uses [`yield`][yield] to return chunks of the string input as [`IEnumerable`][ienumerable] strings.
The `for` loop returns the string chunk with a [range operator][range-operator]
that uses the `size` argument to the function for the starting and ending positions of the range.

The output of `Chunked()` is chained to the input of the [LINQ][linq] [`Select()`][select] method.
Inside the body of `Select()` is a [lambda][lambda] function which takes the codon chunk as an argument
and looks up its matching protein from the `Dictionary`.

Each matching protein is chained from the output of `Select()` to the input of the [`TakeWhile()`][takewhile] method,
which filters the proteins in a lambda based on whether the protein is a `STOP` codon.
Once the lambda in `TakeWhile()` encounters a failing lambda condition, it does not continue to iterate, but stops.

The proteins that survive the `TakeWhile()` are chained into the input of the `ToArray()` method.

The [`ToArray()`][toarray] method is used to return an array of the matched proteins from the `Proteins()` method.

[private]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/private
[static]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/static
[readonly]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/readonly
[dictionary]: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2
[static-constructor]: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/static-constructors
[extension-method]: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods
[iterator-method]: https://learn.microsoft.com/en-us/dotnet/csharp/iterators#enumeration-sources-with-iterator-methods
[yield]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/yield
[ienumerable]: https://learn.microsoft.com/en-us/dotnet/api/system.collections.ienumerable
[range-operator]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/member-access-operators#range-operator-
[linq]: https://learn.microsoft.com/en-us/dotnet/api/system.linq
[select]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.select
[lambda]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions
[takewhile]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.takewhile
[toarray]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.toarray
