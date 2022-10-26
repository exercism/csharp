# Introduction

There are various idiomatic approaches to solve Bob.
A basic approach can use a series of `if` statements to test the conditions.
Or a [switch][switch] on a [tuple][tuple] of the conditions can be used.
An array can contain answers from which the right response is selected by an index calculated from scores given to the conditions.

## Approach: `if` statements

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

For more information, check the [`if` statements approach][approach-if].

## Approach: `switch` on a `tuple`

```csharp
    // uses System.Linq;
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
```

For more information, check the [`switch` on a `tuple`][approach-switch].

## Other approaches

- An array can be defined that contains Bob’s answers, and each condition is given a score.
The correct answer is selected from the array by using the score as the array index.
For more information, check the [Answer array approach][approach-answer-array].

## Which approach to use?

Which to use is pretty much a matter of personal preference.

Regardless of the approach used, some things to look for include

- If the input is trimmed, [Trim][trim] only once.

- Use the [EndsWith][endswith] `String` method instead of checking the last character by index for `?`.

- Don't copy/paste the logic for determining a shout and for determing a question into determing a shouted question.
Combine the two determinations instead of copying them.
Not duplicating the code will keep the code [DRY][dry].

- Perhaps consider making `IsQuestion` and `IsShout` values set once instead of functions that are possibly called twice.

- If an `if` statement can return, then an `else if` or `else` is not needed.
Execution will either return or will continue to the next statement anyway.

- If the body of an `if` statement is only one line, curly braces aren't needed.
Some teams may still require them in their style guidelines, though.

- To compare the performance of the approaches, check out the [Performance approach][approach-performance].

[trim]: https://learn.microsoft.com/en-us/dotnet/api/system.string.trim?view=net-7.0
[endswith]: https://learn.microsoft.com/en-us/dotnet/api/system.string.endswith?view=net-6.0
[switch]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements#the-switch-statement
[tuple]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-tuples
[dry]: https://en.wikipedia.org/wiki/Don%27t_repeat_yourself
[approach-if]: https://exercism.org/tracks/csharp/exercises/bob/approaches/if
[approach-switch]: https://exercism.org/tracks/csharp/exercises/bob/approaches/switch-on-tuple
[approach-answer-array]: https://exercism.org/tracks/csharp/exercises/bob/approaches/answer-array
[approach-performance]: https://exercism.org/tracks/csharp/exercises/bob/approaches/performance