# `yield` with a `switch`

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

The `Proteins()` method starts by calling the private static [extension method][extension-method] `Chunked()`,
which is also an [iterator method][iterator-method].
The function uses [`yield`][yield] to return chunks of the string input as [`IEnumerable`][ienumerable] strings.
The `for` loop returns the string chunk with a [range operator][range-operator]
that uses the `size` argument to the function for the starting and ending positions of the range.

The output of `Chunked()` is chained to the input of the [LINQ][linq] [`Select()`][select] method.
Inside the body of `Select()` is a [lambda][lambda] function which takes the codon chunk as an argument
and passes it as an argument to the [`private`][private], [`static`][static] `ToProtein` method.
It is private because it isn't needed outside the class.
It is `static` because it doesn't use any state from an instantiated object, so it does not need to be copied to every object,
but remains with the class.
Inside `ToProtein()` it uses a [`switch`][switch] to look up and return the matching protein for the codon.

Each matching protein is chained from the output of `Select()` to the input of the [`TakeWhile()`][takewhile] method,
which filters the proteins in a lambda based on whether the protein is a `STOP` codon.
Once the lambda in `TakeWhile()` encounters a failing lambda condition, it does not continue to iterate, but stops.

The proteins that survive the `TakeWhile()` are chained into the input of the `ToArray()` method.

The [`ToArray()`][toarray] method is used to return an array of the matched proteins from the `Proteins()` method.


[private]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/private
[static]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/static
[switch]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements#the-switch-statement
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
