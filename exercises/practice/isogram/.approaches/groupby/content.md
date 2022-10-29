# GroupBy

```csharp
using System.Linq;

public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        return word.ToLower().Where(Char.IsLetter).GroupBy(ltr => ltr).All(ltr_grp => ltr_grp.Count() == 1);
    }
}
```

The steps for this solution are

- [`ToLower`][tolower] produces a new `string` with its characters changed to lower case.
That string is chained to `Where`.
- [`Where`][where] uses [IsLetter][isletter] to filter the `string` so only Unicode letters get put into a [List][list].
So no hyphens nor apostrophes (nor anything else that is not a letter) will make it into the `List`.
- [`GroupBy`][groupby] groups each letter into its own group.
- [`All`][all] uses [`Count`][count] to return whether all groups of letters have only one letter in its group.

If any group has a count of more than `1` for its letter, the word is not an isogram.
- The word `Bravo` is an isogram because all five groups of letters has a count of `1`.
- The word `Alpha` is not an isogram because `a` is considered to repeat `A`, so it has only four groups of letters,
and the group for `a` has a count of `2`.

[tolower]: https://learn.microsoft.com/en-us/dotnet/api/system.string.tolower
[where]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.where
[isletter]: https://learn.microsoft.com/en-us/dotnet/api/system.char.isletter
[list]: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1
[groupby]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.groupby
[all]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.all
[count]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.count
