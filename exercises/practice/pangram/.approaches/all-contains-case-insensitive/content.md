# `All` with `Contains` using case-insensitive comparison

```csharp
using System.Linq;

public static class Pangram
{
    private static readonly StringComparison xcase = StringComparison.CurrentCultureIgnoreCase;
    
    public static bool IsPangram(string input)
    {
        return "abcdefghijklmnopqrstuvwxyz".All(c => input.Contains(c, xcase));
    }
}
```

- This begins by setting a variable for a case-insensitive `string` comparison.
- It then checks if all letters in the alphabet are contained in the input,
using the [LINQ][linq] method [`All`][all] with the `String` method [`Contains`][contains].
- `Contains` takes the optional [`StringComparison`][stringcomparison] argument,
but a case-insensitive comparison is about seven times slower than if the input were lowercased and then an exact comparison were done.

## Shortening

When the body of a function is a single expression, the function can be implemented as an [expression-bodied member][expression-bodied-member], like so

```csharp
public static bool IsPangram(string input) =>
    "abcdefghijklmnopqrstuvwxyz".All(c => input.Contains(c, xcase));
```

or

```csharp
public static bool IsPangram(string input) => "abcdefghijklmnopqrstuvwxyz".All(c => input.Contains(c, xcase));
```

[linq]: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/
[all]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.all
[contains]: https://learn.microsoft.com/en-us/dotnet/api/system.string.contains
[stringcomparison]: https://learn.microsoft.com/en-us/dotnet/api/system.stringcomparison
[expression-bodied-member]: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members
