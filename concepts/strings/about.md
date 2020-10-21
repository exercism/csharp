The key thing to remember about C# strings is that they are immutable objects representing text as a sequence of Unicode characters (letters, digits, punctuation, etc.). Double quotes are used to define a `string` instance:

```csharp
string fruit = "Apple";
```

Manipulating a string can be done by calling one of its [methods][methods] or [properties][properties]. As string values can never change after having been defined, all string manipulation methods will return a new string.

A string is delimited by double quote (`"`) characters. Some special characters need [escaping][escaping] using the backslash (`\`) character. Strings can also be prefixed with the at (`@`) symbol, which makes it a [verbatim string][verbatim] that will ignore any escaped characters.

```csharp
string escaped = "c:\\test.txt";
string verbatim = @"c:\test.txt";
escaped == verbatim;
// => true
```

Finally, there are [many ways to concatenate a string][concatenation]. The simplest one is by using the [`+` operator][plus-operator].

```csharp
string name = "Jane";
"Hello " + name + "!";
// => "Hello Jane!"
```

For any string formatting more complex than simple concatenation, [string interpolation][interpolation] is preferred. To enable interpolation in a string, prefix it with the dollar (`$`) symbol.

```csharp
string name = "Jane";
$"Hello {name}!";
// => "Hello Jane!"
```

[concatenation]: https://docs.microsoft.com/en-us/dotnet/csharp/how-to/concatenate-multiple-strings
[interpolation]: https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/string-interpolation
[verbatim]: https://csharp.net-tutorials.com/data-types/strings/#aelm5298
[plus-operator]: https://csharp.net-tutorials.com/data-types/strings/#aelm5211
[escaping]: https://devblogs.microsoft.com/csharpfaq/what-character-escape-sequences-are-available/
[methods]: https://docs.microsoft.com/en-us/dotnet/api/system.string?view=netcore-3.1#methods
[properties]: https://docs.microsoft.com/en-us/dotnet/api/system.string?view=netcore-3.1#properties
