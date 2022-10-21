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

[extension-methods]: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods


