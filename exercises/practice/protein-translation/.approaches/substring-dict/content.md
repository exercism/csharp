# Approach: `Substring()` with a `Dictionary`

```csharp
using System;
using System.Collections.Generic;

public static class ProteinTranslation
{
    private static readonly Dictionary<string, string> lookup = new Dictionary<string, string>();

    private static void roboLoad(string protein, params string[] codons)
    {
        foreach (string codon in codons)
            lookup.Add(codon, protein);
    }

    static ProteinTranslation()
    {
        roboLoad("Methionine", "AUG");
        roboLoad("Phenylalanine", "UUU", "UUC");
        roboLoad("Leucine", "UUA", "UUG");
        roboLoad("Serine", "UCU", "UCC", "UCA", "UCG");
        roboLoad("Tyrosine", "UAU", "UAC");
        roboLoad("Cysteine", "UGU", "UGC");
        roboLoad("Tryptophan", "UGG");
        roboLoad("STOP", "UAA", "UAG", "UGA");
    }

    public static string[] Proteins(string strand)
    {
        var length = strand.Length;
        List<String> proteins = new List<String>();
        var endIndex = 3;
        while (endIndex <= length)
        {
            var codon = strand.Substring(endIndex - 3, 3);
            var protein = lookup[codon];
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
}
```

The approach begins by defining a [`private`][private], [`static`][static], [`readonly`][readonly] [`Dictionary`][dictionary] for translating the codons to proteins.
It is private because it isn't needed outside the class.
It is static because only one is needed to serve every instance of the class.
It is readonly because, although it has interior mutability (meaning its elements can change),
the `Dictionary` variable itself will not be assigned to another `Dictionary`.

A private static helper method is defined to load the `Dictionary` from the supplied protein and its matching codon(s).

The [static constructor][static-constructor] calls the helper method with the necessary arguments.

The `Proteins()` method starts by defining a [`List`][list] and a couple of variables to control iterating the codons.

While there are still characters left to iterate, a codon is set from a [`Substring()`][substring] of the input strand.
The matching protein for the codon is looked up from the `Dictionary` and is tested in a [`switch`][switch].
If the codon was a `STOP` codon, then [`break`][break] is used to exit the loop.
If not, then the protein is added to the `List`.

After the loop is finished, the `List`'s [`ToArray()`][toarray] method is used to return an array of the matched proteins from the method.

[private]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/private
[static]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/static
[readonly]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/readonly
[dictionary]: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2
[static-constructor]: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/static-constructors
[list]: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1
[substring]: https://learn.microsoft.com/en-us/dotnet/api/system.string.substring
[switch]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements#the-switch-statement
[break]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/jump-statements#the-break-statement
[toarray]: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.toarray
