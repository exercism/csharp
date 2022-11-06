# `for`-loop

```csharp
using System;

public static class Hamming
{
    public static int Distance(string strand1, string strand2)
    {
        if (strand1.Length != strand2.Length)
            throw new ArgumentException("Strands have different length");

        var distance = 0;

        for (var i = 0; i < strand1.Length; i++)
        {
            if (strand1[i] != strand2[i])
                distance++;
        }

        return distance;
    }
}
```

The first step is to check if both strings have the same length:

```csharp
if (strand1.Length != strand2.Length)
    throw new ArgumentException("Strands have different length");
```

Once we've verified that, we define a variable that will keep track of the hamming distance between the two strings:

```csharp
var distance = 0;
```

We then use a [`for`-loop][for-statement] to iterate over each index of the first (and second) string:

```csharp
for (var i = 0; i < strand1.Length; i++)
```

```exercism/note
We could equally well have used `i < strand2.Length`, as both strings are guaranteed to have the same length.
```

Within the loop, we can then use a simple [`if`-statement][if-statement] to check if the two strings have different characters at the specified index, and if so, increment the `distance` by one:

```csharp
if (strand1[i] != strand2[i])
    distance++;
```

Finally, once each index has been checked, we return the hamming distance:

```csharp
return distance;
```

[for-statement]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/for
[if-statement]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/if-else
