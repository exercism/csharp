# `All` with `Contains` on lowercased letters

```csharp
using System.Linq;

public static class Pangram
{
    private const string Letters = "abcdefghijklmnopqrstuvwxyz";
    
    public static bool IsPangram(string input)
    {
        var lowerCaseInput = input.ToLower();
        return Letters.All(letter => lowerCaseInput.Contains(letter));
    }
}
```

- This begins by lowercasing the input by using [ToLower][tolower].
- It then checks if all letters in the alphabet are contained in the input,
using the [LINQ][linq] method [`All`][all] with the `String` method [`Contains`][contains].

Instead of lowercasing the input, `Contains` could take an optional [`StringComparison`][stringcomparison] argument,
but a case-insensitive comparison is about seven times slower than lowercasing the input and then doing an exact comparison.

[tolower]: https://learn.microsoft.com/en-us/dotnet/api/system.string.tolower
[linq]: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/
[all]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.all
[contains]: https://learn.microsoft.com/en-us/dotnet/api/system.string.contains
[stringcomparison]: https://learn.microsoft.com/en-us/dotnet/api/system.stringcomparison
