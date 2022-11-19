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

The first step is to decide how we want to iterate over and transform the nucleotides.
As the `string` class implements the `IEnumerable<char>` interface, this allows us to call
[LINQ][linq]'s [`Select()` method][enumerable.select] on it, which can do both the iteration _and_ the transformation in one go!

```csharp
dna.Select(nucleotide => TODO)
```

Within the `Select()` method's lambda argument, we'll need to translate the nucleotide to its complement.
Let's implement a new `Complement()` method that takes a nucleotide, pattern matches on its value a using a [`switch` expression][switch-expression] and returns its complement:

```csharp
private static char Complement(char nucleotide)
{
    return nucleotide switch
    {
        'G' => 'C',
        'C' => 'G',
        'T' => 'A',
        'A' => 'U'
    };
}
```

As this method returns a single expression, we can convert it to an [expression-bodied method][expression-bodied-method]:

```csharp
private static char Complement(char nucleotide) =>
    nucleotide switch
    {
        'G' => 'C',
        'C' => 'G',
        'T' => 'A',
        'A' => 'U'
    };
```

We can then use this method in our lambda:

```csharp
dna.Select(nucleotide => Complement(nucleotide))
```

As the lambda is doing nothing more than passing the argument to a method, we can rewrite it to a [method group][method-group]:

```csharp
dna.Select(Complement)
```

This call will return a new `IEnumerable<char>`, which we can convert back to a `string` by first converting it to a `char[]` and then passing that to a string constructor:

```csharp
public static string ToRna(string dna)
{
    return new string(dna.Select(Complement).ToArray());
}
```

As this has just a single `return` statement, we can convert it to an [expression-bodied method][expression-bodied-method]:

```csharp
public static string ToRna(string dna) =>
    new string(dna.Select(Complement).ToArray());
```

Finally, we can once again use a [target-typed new][target-typed-new] expression to replace `new string` with just `new`:

```csharp
public static string ToRna(string dna) =>
    new(dna.Select(Complement).ToArray());
```

And with that we have a concise, working implementation!

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

[linq]: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/
[switch-expression]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/switch-expression
[switch-statement]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements#the-switch-statement
[foreach-statement]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/iteration-statements#the-foreach-statement
[expression-bodied-member]: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members
[method-group]: https://stackoverflow.com/questions/35420610/passing-a-method-to-a-linq-query
