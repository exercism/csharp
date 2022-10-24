# `if` statements

```csharp
    // uses System.Linq;
    public static string Response(string message)
    {
        if (message.IsSilence())
            return "Fine. Be that way!";

        if (message.IsYell() && message.IsQuestion())
            return "Calm down, I know what I'm doing!";

        if (message.IsYell())
            return "Whoa, chill out!";

        if (message.IsQuestion())
            return "Sure.";

        return "Whatever.";
    }

    private static bool IsSilence(this string message) =>
        string.IsNullOrWhiteSpace(message);

    private static bool IsYell(this string message) =>
        message.Any(char.IsLetter) && message.ToUpperInvariant() == message;

    private static bool IsQuestion(this string message) =>
        message.TrimEnd().EndsWith("?");
```

[Extension methods][extension-methods] have been used in this solution to add behavior to the `String` type.
Those methods are then used for determing the conditions in a series of `if` statements.
Note that there are no `else if` or `else` statements.
If an `if` statement can return, then an `else if` or `else` is not needed.
Execution will either return or will continue to the next statement anyway.

The [LINQ][linq] method [EndsWith][endswith] is used to determine if the input ends with a question mark.

The `String` method [IsNullOrWhiteSpace][isnullorwhitespace] is used to determine if the input is `null` or only contains [whitespace][whitespace] characters.

The first half of the yell condition is constructed from the [Any][any] LINQ method and the [IsLetter][isletter] `Char` method to ensure there is at least one letter character in the `String`.
This is because the second half of the condition tests that the uppercased input is the same as the input.
If the input were only `"123"` it would equal itself uppercased, but without letters it would not be a yell.
The uppercasing is done by using the `String` method [ToUpperInvariant][toupperinvariant].
The invariant culture represents a culture that is culture-insensitive.
It is associated with the English language but not with a specific country or region.
For more information, see the [CultureInfo.InvariantCulture][invariantculture] property.

[extension-methods]: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods
[linq]: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/
[endswith]: https://learn.microsoft.com/en-us/dotnet/api/system.string.endswith
[isnullorwhitespace]: https://learn.microsoft.com/en-us/dotnet/api/system.string.isnullorwhitespace
[whitespace]: https://www.oreilly.com/library/view/programming-c/0596001177/ch03s04.html
[any]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.any
[isletter]: https://learn.microsoft.com/en-us/dotnet/api/system.char.isletter
[toupperinvariant]: https://learn.microsoft.com/en-us/dotnet/api/system.string.toupperinvariant
[invariantculture]: https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.invariantculture
