# Regular expression

```csharp
using System;
using System.Text.RegularExpressions;

public static class PhoneNumber
{
    public static string Clean(string phoneNumber)
    {
        var match = Regex.Match(phoneNumber, @"^[^\d]*?1?[^\d]*?([2-9]\d{2})[^\d]*?([2-9]\d{2})[^\d]*?(\d{4})[^\d]*$");
        if (!match.Success)
            throw new ArgumentException("Invalid phone number", nameof(phoneNumber));

        return $"{match.Groups[1].Value}{match.Groups[2].Value}{match.Groups[3].Value}";
    }
}
```

## Pattern

As our approach revolves around regular expressions (regexes), let's start with building our regular expression.

The rules we have to implement are:

- The phone number consists of:
  - An optional country code, which must be `1` if present
  - A three-digit area code, not starting with `0` or `1`
  - A three-digit exchange code, not starting with `0` or `1`
  - A four-digit subscriber number
- Any non-digit characters are to be ignored

Let's tackle these one by one.

First, the optional country code, which must be `1` if present. We can match this with `1?`, which matches one the `1` character, or when there is no character.

Second, a three-digit area code, not starting with `0` or `1`. This can be written as `[2-9]\d{2}`, which starts matching in a number from `2` to `9` (excluding `0` and `1`), followed by two numbers (we could also have used `\d\d`).

Third, a three-digit exchanged code, not starting with `0` or `1`. We can use the same regular expression as used for the area code: `[2-9]\d{2}`.

Fourth, a four digit subscriber number, which we can match with `\d{4}` (four digits).

And finally, any non-digit character can be matched with `[^\d]`.

Combining all these parts into one regular expression gives us the following pattern:

```
^[^\d]*?1?[^\d]*?([2-9]\d{2})[^\d]*?([2-9]\d{2})[^\d]*?(\d{4})[^\d]*$
```

## Implementation

We can then use this pattern with [`Regex.Match()`][regex-match] to get a [`Match` object][match] that indicates if our input phone number matches the regex pattern:

```csharp
var match = Regex.Match(phoneNumber, "^[^\d]*?1?[^\d]*?([2-9]\d{2})[^\d]*?([2-9]\d{2})[^\d]*?(\d{4})[^\d]*$");
```

We can then use the `Success` property to throw an `ArgumentException` if the input string did not match our pattern:

```csharp
if (!match.Success)
    throw new ArgumentException("Invalid phone number", nameof(phoneNumber));
```

Finally, we concatenate the area code, exchange code and subscriber number using an [interpolated string][string-interpolation]:

```csharp
return $"{match.Groups[1].Value}{match.Groups[2].Value}{match.Groups[3].Value}";
```

## Readability

One of the downsides of using regular expressions is that they can quickly become hard to read.
Our regex is already quite dense, so what options do we have to improve readability?

### Named matched subexpressions

Our regular expression matches several subexpressions, which value we then later access by index (`{match.Groups[2].Value}`).
We can improve upon this index-based approach by using [named matched subexpressions][named-matched-subexpressions], where we give a name to our matched subexpressions by adding `?<name>` after the opening parenthesis:

```csharp
var match = Regex.Match(phoneNumber, @"^[^\d]*?1?[^\d]*?(?<areacode>[2-9]\d{2})[^\d]*?(?<exchangecode>[2-9]\d{2})[^\d]*?(?<subscribernumber>\d{4})[^\d]*$");
```

While more verbose, the regex pattern now better encodes our domain and our returned string looks far more readable:

```csharp
return $"{match.Groups["areacode"].Value}{match.Groups["exchangecode"].Value}{match.Groups["subscribernumber"].Value}";
```

### Introduce constant(s)

A second improvement would be to convert the string literal used for the regex pattern to `const`:

```csharp
public static class PhoneNumber
{
    private const string PhoneNumberPattern = @"^[^\d]*?1?[^\d]*?([2-9]\d{2})[^\d]*?([2-9]\d{2})[^\d]*?(\d{4})[^\d]*$";

    public static string Clean(string phoneNumber)
    {
        var match = Regex.Match(phoneNumber, PhoneNumberPattern);

        ...
    }
}
```

We could even introduce constants for the individual parts of the regex:

```csharp
private const string CountryCodePattern = @"1?";
private const string AreaCodePattern = @"(?<areacode>[2-9]\d{2})";
private const string ExchangeCodePattern = @"(?<exchangecode>[2-9]\d{2})";
private const string SubscriberNumberPattern = @"(?<subscribernumber>\d{4})";
private const string NonDigitPattern = @"[^\d]*?";
private const string PhoneNumberPattern = $"^{NonDigitPattern}{CountryCodePattern}{NonDigitPattern}{AreaCodePattern}{NonDigitPattern}{ExchangeCodePattern}{NonDigitPattern}{SubscriberNumberPattern}{NonDigitPattern}$";
```

Where or not that helps readability is up to you to decide.

[named-matched-subexpressions]: https://learn.microsoft.com/en-us/dotnet/standard/base-types/grouping-constructs-in-regular-expressions#named-matched-subexpressions
[string-interpolation]: https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/string-interpolation
[regex-match]: https://docs.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.match
[match]: https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.match
