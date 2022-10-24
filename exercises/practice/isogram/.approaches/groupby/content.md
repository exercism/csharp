```csharp
return word.ToLower().Where(Char.IsLetter).GroupBy(ltr => ltr).All(ltr_grp => ltr_grp.Count() == 1);
```

The steps for this solution are

- [`ToLower`][tolower] returns a new `string` with characters changed to lower case according to the [`CurrentCulture`][currentculture].
- [`Where`][where] uses [IsLetter][isletter] to filter the characters to only those which are categorized as a Unicode letter.
- [`GroupBy`][groupby] groups each letter into its own group.
- [`All`][all] uses [`Count`][count] to return whether all groups of letters have only one letter in the group.

[tolower]: https://learn.microsoft.com/en-us/dotnet/api/system.string.tolower
[currentculture]: https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.currentculture
[where]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.where
[isletter]: https://learn.microsoft.com/en-us/dotnet/api/system.char.isletter
[groupby]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.groupby
[all]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.all
[count]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.count
