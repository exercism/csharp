# Regular expressions

```csharp
using System.Text.RegularExpressions;

public static class Bob
{
    public static string Response(string message)
    {
        if (IsSilence(message))
            return "Fine. Be that way!";

        if (IsYell(message) && IsQuestion(message))
            return "Calm down, I know what I'm doing!";

        if (IsYell(message))
            return "Whoa, chill out!";

        if (IsQuestion(message))
            return "Sure.";

        return "Whatever.";
    }

    private static bool IsSilence(string message)
    {
        return Regex.IsMatch(message, @"^\s*$");
    }

    private static bool IsYell(string message)
    {
        return Regex.IsMatch(message, @"^[^\p{Ll}]*\p{Lu}[^\p{Ll}]*$");
    }

    private static bool IsQuestion(string message)
    {
        return Regex.IsMatch(message, @"\?\s*$");
    }
}
```

In this approach you have a series of `if` statements using private methods that use [regular expressions][regular-expressions] to evaluate the conditions.
As soon as the right condition is found, the correct response is returned.

```exercism/note
Note that there are no `else if` or `else` statements.
If an `if` statement returns, then an `else if` or `else` is not needed.
Execution will either return or will continue to the next statement anyway.
```

### Silence

The `IsSilence()` method should match when the string is either empty or only contains whitespace characters.
We can use the following regular expression for that: `^\s*$`.
This pattern matches when there are zero or more whitespace characters (`\s*`) between the begin (`^`) and end (`^`) of the input.

To match on this regular expression, we use [`Regex.IsMatch()`][regex-ismatch], which takes an input string and a regular expression pattern and returns a `bool` indicating if the input matches the pattern:

```csharp
Regex.IsMatch(message, @"^\s*$");
```

```exercism/note
When defining regular expression patterns, consider defining them with a verbatim string literal (prefixed with `@`) to prevent having to escape any backslash characters.
```

### Yell

The `IsYell()` method should match when the string contains only uppercase letters and optionally zero or more non-letter characters.
We could use the following regular expression for that: `^[^a-z]*[A-Z]+[^a-z]*$`.
This says that the input must start (`^`) with zero or more non-lowercase letters (`^a-z]*`), followed by one or more uppercase letters (`A-Z]+`) and end (`$`) with zero or more non-lowercase letters (`^a-z]*`).
while this passes the tests, it only works with ASCII strings; any Unicode uppercase letters would not match the above pattern (e.g. `Ġ` would not match as an uppercase letter).

#### Unicode

Luckily, .NET regular expressions support [Unicode character groups][regex-word-character-group], which include character groups for uppercase letters (`\p{Lu}`) and lowercase letters (`\p{Ll}`).
With this, we can rewrite our regular expression to: `^[^\p{Ll}]*\p{Lu}+[^\p{Ll}]*$`.
And now, our regular expression will correct match lower- and uppercase Unicode letters:

```csharp
Regex.IsMatch(message, @"^[^\p{Ll}]*\p{Lu}+[^\p{Ll}]*$"");
```

### Question

The `IsQuestion()` method should match when the string ends with a question mark (`?`), optionally followed by zero or more whitespace characters.
We can use the following regular expression for that: `\?\s*$`.
What this regular expressions says is that the input must end (`$`) with a question mark (`\?`, which we need to escape as to match the `?` character class) and zero or more whitespace (`\s*`) characters.

```csharp
Regex.IsMatch(message, @"\?\s*$");
```

## Extension methods

For this exercise you could add behavior to the `String` type using [Extension methods][extension-methods], like so

```csharp
private static bool IsSilence(this string message)
{
    return Regex.IsMatch(message, @"^\s*$");
}
```

which would be called like so

```csharp
if (message.IsSilence())
    return "Fine. Be that way!";
```

## Shortening

When the body of a function is a single expression, the function can be implemented as a [member-bodied expression][member-bodied-expressions], like so

```csharp
private bool IsSilence(string message) =>
    Regex.IsMatch(message, @"^\s*$");
```

or

```csharp
private bool IsSilence(string message) => Regex.IsMatch(message, @"^\s*$");
```

[extension-methods]: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods
[member-bodied-expressions]: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members
[regular-expressions]: https://learn.microsoft.com/en-us/dotnet/standard/base-types/regular-expression-language-quick-reference
[regex-ismatch]: https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch
[regex-character-classes]: https://learn.microsoft.com/en-us/dotnet/standard/base-types/character-classes-in-regular-expressions
[regex-word-character-group]: https://learn.microsoft.com/en-us/dotnet/standard/base-types/character-classes-in-regular-expressions#word-character-w
[regex-whitespace-character-group]: https://learn.microsoft.com/en-us/dotnet/standard/base-types/character-classes-in-regular-expressions#whitespace-character-s
