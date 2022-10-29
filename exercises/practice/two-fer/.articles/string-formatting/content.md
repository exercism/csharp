# String formatting

There are various ways in which you can format the return string.

## Option 1: string interpolation

[String interpolation][string-interpolation] was introduced in C# 6.0 and is the most idiomatic way to build up a string with one more variable parts.

```csharp
$"One for {name}, one for me.";
```

## Option 2: string concatenation

As there are few variable parts in the returned string (just one), regular [string concatentation][string-concatenation] works well too:

```csharp
"One for " + name + ", one for me.";
```

It is slightly more verbose than string interpolation, but still completely reasonable.

## Option 3: using `string.Format()`

Before string interpolation was introduced in C# 6, [`string.Format()`][string-format] was the go-to option for dynamically formatting strings.

```csharp
string.Format("One for {0}, one for me.", name);
```

String interpolation is in most ways superior to `string.Format()`, so it is no longer idiomatic to use `string.Format()`.

## Option 4: using `string.Concat()`

Another option is [`string.Concat()`][string-concat]:

```csharp
string.Concat("One for ", name, ", one for me.");
```

## Conclusion

String interpolation is the preferred and idiomatic way to format strings.
String concatentation is absolutely a viable option too, as there is only one variable part.
Both `string.Format()` and `string.Concat()` are functionally equivalent, but more cumbersome to read and there we don't recommend using them.

[approaches]: https://exercism.org/tracks/csharp/exercises/two-fer/approaches
[approach-optional-parameter]: https://exercism.org/tracks/csharp/exercises/two-fer/approaches/optional-parameter
[approach-method-overloading]: https://exercism.org/tracks/csharp/exercises/two-fer/approaches/method-overloading
[string-interpolation]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/interpolated
[string-format]: https://learn.microsoft.com/en-us/dotnet/api/system.string.format#Starting
[string-concatenation]: https://learn.microsoft.com/en-us/dotnet/csharp/how-to/concatenate-multiple-strings#-and--operators
[string-concat]: https://learn.microsoft.com/en-us/dotnet/api/system.string.concat
