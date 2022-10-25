# `Distinct`

```csharp
// uses System.Linq
var lowerLetters = word.ToLower().Where(char.IsLetter).ToList();
return lowerLetters.Distinct().Count() == lowerLetters.Count;
```

The steps for this solution are

- [`ToLower`][tolower] returns a new `string` with characters changed to lower case according to the [`CurrentCulture`][currentculture].
- [`Where`][where] uses [IsLetter][isletter] to filter the characters to only those which are categorized as a Unicode letter,
and the result is put into a `List`.
- [`Distinct`][distinct] with [`Count`][count] returns the number of unique letter characters.
- The function returns whether the number of **_distinct_** letter characters is the same as the number of **_all_** letter characters.

[tolower]: https://learn.microsoft.com/en-us/dotnet/api/system.string.tolower
[currentculture]: https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.currentculture
[where]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.where
[isletter]: https://learn.microsoft.com/en-us/dotnet/api/system.char.isletter
[distinct]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.distinct
[count]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.count
