# Introduction

The key to this exercise is to handle the various ways in which the phone number can be defined, so you'll need to ignore any non-digit characters.

## General guidance

- [Regular expressions][regular-expression] can be used to solve the exercise, but beware of readability issues

- It can help to process the input string in phases: start with sanitizing the string (removing any non-digit characters), then validate the string and finally return the correctly formatted string

## Approach: regular expression

```csharp
public static string Clean(string phoneNumber)
{
    var match = Regex.Match(phoneNumber, @"^(\+?1)?[^\d]*?([2-9]\d{2})[^\d]*?([2-9]\d{2})[^\d]*?(\d{4})[^\d]*$");

    if (!match.Success)
        throw new ArgumentException("Invalid phone number", nameof(phoneNumber));

    return $"{match.Groups[2].Value}{match.Groups[3].Value}{match.Groups[4].Value}";
}
```

This approach uses a [regular expression][regular-expression] to both validate _and_ capture the relevant parts of the phone number.
For more information, check the [regular expression approach][approach-regular-expression].

[approach-regular-expression]: https://exercism.org/tracks/csharp/exercises/phone-number/approaches/regular-expression
[regular-expression]: https://learn.microsoft.com/en-us/dotnet/standard/base-types/regular-expressions
