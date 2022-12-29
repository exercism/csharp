# `Substring()` with a `switch`

```csharp
using System;
using System.Collections.Generic;

public static class ProteinTranslation
{
    public static string[] Proteins(string strand)
    {
        var length = strand.Length;
        List<String> proteins = new List<String>();
        var endIndex = 3;
        while (endIndex <= length)
        {
            var codon = strand.Substring(endIndex - 3, 3);
            var protein = ToProtein(codon);
            switch (protein)
            {
                case "STOP":
                    return proteins.ToArray();
                default:
                    proteins.Add(protein);
                    break;
            }
            endIndex += 3;
        }
        return proteins.ToArray();
    }

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
}
```

The `Proteins()` method starts by defining a [`List`][list] and a couple of variables to control iterating the codons.

While there are still characters left to iterate, a codon is set from a [`Substring()`][substring] of the input strand.
The matching protein for the codon is looked up from the [`private`][private], [`static`][static] `ToProteins()` method.
It is `private` because it isn't needed outside the class.
It is `static` because it doesn't use any state from an instantiated object, so it does not need to be copied to every object,
but remains with the class.

The `ToProteins()` uses a [`switch`][switch] to look up and return the matching protein for the codon.

The returned protein is tested in a [`switch`][switch].
If the codon was a `STOP` codon, then [`break`][break] is used to exit the loop.
If not, then the protein is added to the `List`.

After the loop is finished, the `List`'s [`ToArray()`][toarray] method is used to return an array of the matched proteins from the method.

[private]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/private
[static]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/static
[list]: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1
[substring]: https://learn.microsoft.com/en-us/dotnet/api/system.string.substring
[switch]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements#the-switch-statement
[break]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/jump-statements#the-break-statement
[toarray]: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.toarray
