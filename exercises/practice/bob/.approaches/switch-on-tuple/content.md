# `switch` on a `tuple`

```csharp
using System.Linq;

public static class Bob
{
    private static bool IsShout(string input) => input.Any(c => char.IsLetter(c)) && input.ToUpper() == input;

    public static string Response(string statement)
    {
        var input = statement.TrimEnd();
        if (input == "")
            return "Fine. Be that way!";

        switch ((input.EndsWith('?'), IsShout(input)))
        {
            case (true, true): return "Calm down, I know what I'm doing!";
            case (_, true): return "Whoa, chill out!";
            case (true, _): return "Sure.";
            default: return "Whatever."; 
        }
    }
}
```

In this approach you use a [`switch`][switch] to test if there is a question or a shout.
The `switch` returns the right response for a question, shout, shouted question, or for not being a shout or question.

The `String` [TrimEnd][trimend] method is applied to the input to eliminate any whitespace at the end of the input.
If the string has no characters left, it returns the response for saying nothing.

```exercism/caution
Note that a `null` `string` would be different from a `string` of all whitespace.
A `null` `string` would throw an `Exception` if `TrimEnd` were applied to it.
To test a `string` that might be `null` or only whitespace, the [IsNullOrWhiteSpace](https://learn.microsoft.com/en-us/dotnet/api/system.string.isnullorwhitespace) method of `String` would be used.
```

Next a [tuple][tuple] is made from the conditions for a queston and a shout.
The first half of the shout condition

```csharp
input.Any(c => char.IsLetter(c)) && input.ToUpper() == input
```

is constructed from the [Any][any] LINQ method and the [IsLetter][isletter] `Char` method to ensure there is at least one letter character in the `String`.
This is because the second half of the condition tests that the uppercased input is the same as the input.
If the input were only `"123"` it would equal itself uppercased, but without letters it would not be a shout.

The `tuple` is tested in a [switch][switch].
It checks the values of the expressions in the `tuple`, and uses the `_` [discard pattern][discardpattern] to disregard a value.
If none of the patterns match, the `default` arm of the `switch` returns the response when the input is neither a question nor a shout.

## Shortening

When the body of an `if` statement is a single line, both the test expression and the body could be put on the same line, like so

```csharp
if (input == "") return "Fine. Be that way!";
```

The [C# Coding Conventions][coding-conventions] advise to write only one statement per line in the [layout conventions][layout-conventions] section,
but the conventions begin by saying you can use them or adapt them to your needs.
Your team may choose to overrule them.

For `Any`, the lambda expression of `c => char.IsLetter(c)` can be shortened to just the method call of `char.IsLetter` like so

```csharp
input.Any(char.IsLetter)
```

`Any` passes a single character in each iteration, and the `char.IsLetter` method is called on that character implicitly.
There is a detailed description of how it works in the accepted answer for this [StackOverflow question][method-group].
 

[trimend]: https://learn.microsoft.com/en-us/dotnet/api/system.string.trimend
[isnullorwhitespace]: https://learn.microsoft.com/en-us/dotnet/api/system.string.isnullorwhitespace
[tuple]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-tuples
[any]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.any
[isletter]: https://learn.microsoft.com/en-us/dotnet/api/system.char.isletter
[discardpattern]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/patterns#discard-pattern
[switch]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements#the-switch-statement
[coding-conventions]: https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions
[layout-conventions]: https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions#layout-conventions
[method-group]: https://stackoverflow.com/questions/35420610/passing-a-method-to-a-linq-query
