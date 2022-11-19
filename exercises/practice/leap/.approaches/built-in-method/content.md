# `DateTime.IsLeapYear`

```csharp
using System; // for DateTime

public static bool IsLeapYear(int year)
{
    return DateTime.IsLeapYear(year);
}
```

This may be considered a "wicked cheat" for this exercise, by simply passing the year into the [IsLeapYear][is-leap-year] method of the [DateTime][datetime] struct.
Although it is not in the spirit of this exercise, `IsLeapYear` would be the idiomatic way to determine if a year is a leap year in the "real world".

## Shortening

When the body of a function is a single expression, the function can be implemented as an [expression-bodied member][expression-bodied-member], like so

```csharp
public static bool IsLeapYear(int year) =>
    DateTime.IsLeapYear(year);
```

or

```csharp
public static bool IsLeapYear(int year) => DateTime.IsLeapYear(year);
```

[is-leap-year]: https://learn.microsoft.com/en-us/dotnet/api/system.datetime.isleapyear
[datetime]: https://learn.microsoft.com/en-us/dotnet/api/system.datetime
[expression-bodied-member]: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members
