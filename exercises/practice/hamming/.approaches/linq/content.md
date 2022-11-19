# LINQ

```csharp
using System;
using System.Linq;

public static class Hamming
{
    public static int Distance(string strand1, string strand2)
    {
        if (strand1.Length != strand2.Length)
            throw new ArgumentException("Strands have different length");

        return strand1.Zip(strand2).Count(pair => pair.First != pair.Second);
    }
}
```

The first step is to check if both strings have the same length:

```csharp
if (strand1.Length != strand2.Length)
    throw new ArgumentException("Strands have different length");
```

Once we've verified that, we can safely use LINQ's [`Zip()` (extension) method][enumerable-zip] to combine both strings:

```csharp
strand1.Zip(strand2)
```

This call returns a sequence of `(char, char)` tuples, the first element being `(strand1[0], strand2[0])`, the second `(strand1[1], strand2[1])`, and so on.

We then use the [`Count()` method overload that takes a predicate][enumerable-count] to only count the tuple pairs that have different chars (meaning: the zipped strings have different characters at that index):

```csharp
Count(pair => pair.First != pair.Second)
```

And with that, we have quite concise code that correctly calculates the hamming distance!

[linq]: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/
[enumerable-zip]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.zip
[enumerable-count]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.count
