# `StringBuilder`

```csharp
using System.Text;

public static class Raindrops
{
    public static string Convert(int number)
    {
        var drops = new StringBuilder(15);

        if (number % 3 == 0) drops.Append("Pling");
        if (number % 5 == 0) drops.Append("Plang");
        if (number % 7 == 0) drops.Append("Plong");

        return drops.Length > 0 ? drops.ToString() : number.ToString();
    }
}
```

We start by create a new [`StringBuilder`][string-builder] instance:

```csharp
var drops = new StringBuilder(15);
```

```exercism/note
You may wonder why we're passing in `15` as the argument to the `StringBuilder` constructor?
Well, this sets the `StringBuilder`'s internal _capacity_, which is the length of the internal `char` array it allocates to build the string in.
When a call would have the string exceed the internal capacity, a new and bigger `char` array is allocated.
We know beforehand that our returning string is never longer than 15 characters (`"PlingPlangPlong"`), so by explicitly specifying the capacity we prevent any unneeded allocations, which is good for memory and thus performance.
```

We can then use the remainder operator (`%`) in an `if`-statement to check if the number is a multiple of `3`, and if so, append `"Pling"` to the `StringBuilder`:

```csharp
if (number % 3 == 0) drops.Append("Pling");
```

We then do the same for the other two sounds:

```csharp
if (number % 5 == 0) drops.Append("Plang");
if (number % 7 == 0) drops.Append("Plong");
```

Finally, we use the ternary operator to see if the `StringBuilder` is not empty (`drops.Length > 0`), and if so, we convert the `StringBuilder` to a `string` via its [`ToString()`][string-builder.tostring] method. If it does have length zero, we convert the input number to its string representation:

```csharp
return drops.Length > 0 ? drops.ToString() : number.ToString();
```

[string-builder]: https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder
[string-builder.append]: https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder.append
[string-builder.tostring]: https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder.tostring
