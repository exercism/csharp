# `if` statements

```csharp
using System.Linq;
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

    private bool IsSilence(string message)
    {
        return string.IsNullOrWhiteSpace(message);
    }

    private bool IsYell(string message)
    {
        return message.Any(char.IsLetter) && message.ToUpperInvariant() == message;
    }

    private bool IsQuestion(string message)
    {
        return message.TrimEnd().EndsWith("?");
    }
}
```

In this approach you have a series of `if` statements using the private methods to evaluate the conditions.
As soon as the right condition is found, the correct response is returned.

Note that there are no `else if` or `else` statements.
If an `if` statement can return, then an `else if` or `else` is not needed.
Execution will either return or will continue to the next statement anyway.

The [LINQ][linq] method [EndsWith][endswith] is used to determine if the input ends with a question mark.

The `String` method [IsNullOrWhiteSpace][isnullorwhitespace] is used to determine if the input is `null` or only contains [whitespace][whitespace] characters.

The first half of the yell condition

```csharp
message.Any(char.IsLetter) && message.ToUpperInvariant()
```

is constructed from the [Any][any] LINQ method and the [IsLetter][isletter] `Char` method to ensure there is at least one letter character in the `String`.
This is because the second half of the condition tests that the uppercased input is the same as the input.
If the input were only `"123"` it would equal itself uppercased, but without letters it would not be a yell.
The uppercasing is done by using the `String` method [ToUpperInvariant][toupperinvariant].

```exercism/note
The invariant culture represents a culture that is culture-insensitive.
It is associated with the English language but not with a specific country or region.
For more information, see the [CultureInfo.InvariantCulture](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.invariantculture) property.
```

## Extension methods

For this exercise you could add behavior to the `String` type using [Extension methods][extension-methods], like so

```csharp
private static bool IsSilence(this string message) =>
    string.IsNullOrWhiteSpace(message);
```

which would be called like so

```csharp
if (message.IsSilence())
    return "Fine. Be that way!";
```

## Shortening

When the body of an `if` statement is a single line, both the test expression and the body could be put on the same line, like so

```csharp
if (IsSilence(message)) return "Fine. Be that way!";
```

The [C# Coding Conventions][coding-conventions] advise to write only one statement per line in the [layout conventions][layout-conventions] section,
but the conventions begin by saying you can use them or adapt them to your needs.
Your team may choose to overrule them.

When the body of a function is a single expression, the function can be implemented as a [member-bodied expression][member-bodied-expressions], like so

```csharp
private bool IsSilence(string message) =>
    string.IsNullOrWhiteSpace(message);
```

or

```csharp
private bool IsSilence(string message) => string.IsNullOrWhiteSpace(message);
```

A [ternary operator][ternary operator] can be used to shorten the code and make the logic more efficient, like so

```csharp
if (IsSilence(message))
      return "Fine. Be that way!";
if (IsQuestion(message))
    return IsYell(message) ? "Calm down, I know what I'm doing!": "Sure.";
if (IsYell(message))
    return "Whoa, chill out!";
return "Whatever.";
```

If the input is a question, then the the ternary operator returns the response for a yelled question or just a question.
If the input is not a question, then the function tests if it is a yell.
If the input is a yell, then it can simply return the response for a yell, since it is already known that it is not a question.
The ternary operator makes the code more efficient while reducing the number of lines.

[extension-methods]: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods
[linq]: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/
[endswith]: https://learn.microsoft.com/en-us/dotnet/api/system.string.endswith
[isnullorwhitespace]: https://learn.microsoft.com/en-us/dotnet/api/system.string.isnullorwhitespace
[whitespace]: https://www.oreilly.com/library/view/programming-c/0596001177/ch03s04.html
[any]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.any
[isletter]: https://learn.microsoft.com/en-us/dotnet/api/system.char.isletter
[toupperinvariant]: https://learn.microsoft.com/en-us/dotnet/api/system.string.toupperinvariant
[invariantculture]: https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.invariantculture
[coding-conventions]: https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions
[layout-conventions]: https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions#layout-conventions
[member-bodied-expressions]: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members
[ternary operator]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/conditional-operator
