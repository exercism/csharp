# Introduction


## Approach: if/else

```csharp
using System.Linq;

public static class Bob
{
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
}
```

For more information, check the .

## Approach: Switch on a tuple

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

For more information, check the .

## Approach: Answer array

```csharp
using System.Linq;

public static class Bob
{
    private static readonly string[] answers = {"Whatever.", "Sure.", "Whoa, chill out!", "Calm down, I know what I'm doing!"};
    
    public static string Response(string statement)
    {
        var input = statement.TrimEnd();
        if (input == "") return "Fine. Be that way!";
        
        var isShout = (input.Any(c => char.IsLetter(c)) && input.ToUpper() == input) ? 2: 0;
        
        var isQuestion = (input.EndsWith('?')) ? 1: 0;
        
        return answers[isShout + isQuestion];
    }
}
```

For more information, check the .

Things to look for

- If the input is trimmed, [Trim][trim] only once.

- Use [EndsWith][endswith] `String` method instead of checking the last character by index for `?`.

- If an `if` statement can return, then an `else if` or `else` is not needed.
It will either return or execution will continue to the next statement anyway.

- If the body of an `if` statement is only one line, curly braces aren't needed.
Some teams may still require them in their style guidelines, though.


[trim]: https://learn.microsoft.com/en-us/dotnet/api/system.string.trim?view=net-7.0
[endswith]: https://learn.microsoft.com/en-us/dotnet/api/system.string.endswith?view=net-6.0
