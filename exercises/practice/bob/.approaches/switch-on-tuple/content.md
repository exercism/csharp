# `switch` on a `tuple`

```csharp
using System.Linq;

public static class Bob
{
    private static bool isShout(string input) => input.Any(c => char.IsLetter(c)) && input.ToUpper() == input;

    public static string Response(string statement)
    {
        var input = statement.TrimEnd();
        if (input == "") return "Fine. Be that way!";

        switch ((input.EndsWith('?'), isShout(input)))
        {
            case (true, true): return "Calm down, I know what I'm doing!";
            case (_, true): return "Whoa, chill out!";
            case (true, _): return "Sure.";
            default: return "Whatever.";
        }
    }
}
```

The `String` [TrimEnd][trimend] method is applied to the input to eliminate any whitespace at the end of the input.
If the string has no characters left, it returns the response for saying nothing.
Note that a `null` `string` would be different from a `string` of all whitespace.
A `null` `string` would throw an `Exception` if `TrimEnd` were applied to it.
To test a string that might be `null` or only whitespace, the [IsNullOrWhiteSpace][isnullorwhitespace] method of `String` would be used.

Next a [tuple][tuple] is made from the conditions for a queston and a shout.
The first half of the shout condition is constructed from the [Any][any] LINQ method and the [IsLetter][isletter] `Char` method to ensure there is at least one letter character in the `String`.
This is because the second half of the condition tests that the uppercased input is the same as the input.
If the input were only `"123"` it would equal itself uppercased, but without letters it would not be a shout.

The `tuple` is tested in a [switch][switch].
It checks the values of the expressions in the `tuple`, and uses the `_` [discard pattern][discardpattern] to disregard a value.
If none of the patterns match, the `default` arm of the `switch` returns the response when the input is neither a question nor a shout.
 

[trimend]: https://learn.microsoft.com/en-us/dotnet/api/system.string.trimend?view=net-7.0
[isnullorwhitespace]: https://learn.microsoft.com/en-us/dotnet/api/system.string.isnullorwhitespace?view=net-7.0
[tuple]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-tuples
[any]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.any?view=net-7.0
[isletter]: https://learn.microsoft.com/en-us/dotnet/api/system.char.isletter?view=net-6.0
[discardpattern]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/patterns#discard-pattern
[switch]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements#the-switch-statement
