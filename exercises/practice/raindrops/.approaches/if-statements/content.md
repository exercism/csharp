# `if` statements

```csharp
public static class Raindrops
{
    public string ConvertWithIfConcat(int number)
    {
        var drops = "";
        if (number % 3 == 0)
            drops += "Pling";
        if (number % 5 == 0)
            drops += "Plang";
        if (number % 7 == 0)
            drops += "Plong";
        return drops.Length > 0 ? drops.ToString() : number.ToString();
    }
}
```

- First, `drops` is defined with `var` to be implicitly typed as a `string`, initialized as empty.
- The first `if` statement uses the remainder operator to check if the year is evenly divided by `3`.
If so, "Pling" is [concatenated][concatenate] to `drops` using `+`.
- The second `if` statement uses the remainder operator to check if the year is evenly divided by `5`.
If so, "Plang" is concatenated to `drops` using `+`.
- The third `if` statement uses the remainder operator to check if the year is evenly divided by `7`.
If so, "Plong" is concatenated to `drops` using `+`.

A [ternary operator][ternary] is then used to return `drops` if it has more than `0` characters,
or  it returns `number`.[`ToString()`][tostring].


## Shortening

When the body of an `if` statement is a single line, both the test expression and the body could be put on the same line, like so

```csharp
if (number % 3 == 0) drops += "Pling";
```

The [C# Coding Conventions][coding-conventions] advise to write only one statement per line in the [layout conventions][layout-conventions] section,
but the conventions begin by saying you can use them or adapt them to your needs.
Your team may choose to overrule them.

[var]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/declarations
[coding-conventions]: https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions
[layout-conventions]: https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions#layout-conventions
[concatenate]: https://learn.microsoft.com/en-us/dotnet/csharp/how-to/concatenate-multiple-strings
[ternary]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/conditional-operator
[tostring]: https://learn.microsoft.com/en-us/dotnet/api/system.object.tostring
