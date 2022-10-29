# `Distinct`

```csharp
using System.Linq;

public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        var lowerLetters = word.ToLower().Where(char.IsLetter).ToList();
        return lowerLetters.Distinct().Count() == lowerLetters.Count;
    }
}
```

The steps for this solution are

- [`ToLower`][tolower] produces a new `string` with its characters changed to lower case.
That string is chained to `Where`.
- [`Where`][where] uses [IsLetter][isletter] to filter the `string` so only Unicode letters get put into a [List][list].
So no hyphens nor apostrophes (nor anything else that is not a letter) will make it into the `List`.
- [`Distinct`][distinct] uses [`Count`][count] to get the number of _unique_ letters in the `lowerLetters` `List`.
- The function returns whether the number of **_distinct_** letters is the same as the number of **_all_** letters.

A string is an isogram if its number of distinct letters is the same as the number of all its letters.
- The word `Bravo` is an isogram because it has five distinct letters and five letters total.
- The word `Alpha` is not an isogram because `a` is considered to repeat `A`, so it has only four distinct letters but five letters total.

[tolower]: https://learn.microsoft.com/en-us/dotnet/api/system.string.tolower
[where]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.where
[isletter]: https://learn.microsoft.com/en-us/dotnet/api/system.char.isletter
[list]: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1
[distinct]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.distinct
[count]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.count
