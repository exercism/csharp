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

## Alternative: using a `switch` statement

You could also replace the `switch` expression with a regular [`switch`][switch-statement]:

```csharp
private static char Complement(char nucleotide)
{
    switch (nucleotide)
    {
        case 'G':
            return 'C';
        case 'C':
            return 'G';
        case 'T':
            return 'A';
        case 'A':
            return 'U';
        default:
            throw new ArgumentOutOfRangeException(nameof(nucleotide));
    }
}
```

This is not only more verbose, but it also requires the `default` arm to be added as well as not allowing the method to be written an an [expression-bodied member][expression-bodied-member].

## Alternative: using a `foreach` loop

For the iteration, you could also use a regular [`foreach` loop][foreach-statement] instead of LINQ:

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
[switch-expression]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/switch-expression
[switch-statement]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements#the-switch-statement
[foreach-statement]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/iteration-statements#the-foreach-statement
[expression-bodied-member]: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members
