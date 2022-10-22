# `DateTime.IsLeapYear`

```csharp
// uses System for DateTime
public static bool IsLeapYear(int year) => DateTime.IsLeapYear(year);
```

This may be considered a "wicked cheat" for this exercise, by simply passing year into the [IsLeapYear][is-leap-year] method of the [DateTime][datetime] struct.
Although it is not in the spirit of this exercise, `IsLeapYear` would be the idiomatic way to determine if a year is a leap year in the "real world".

[is-leap-year]: https://learn.microsoft.com/en-us/dotnet/api/system.datetime.isleapyear?view=net-7.0
[datetime]: https://learn.microsoft.com/en-us/dotnet/api/system.datetime?view=net-7.0
