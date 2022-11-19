# `DateTime.Add`

```csharp
using System; // for DateTime

public static bool IsLeapYear(int year) => (new DateTime(year, 2, 28)).AddDays(1.0).Day == 29;
```

This approach may be considered a "cheat" for this exercise.
By adding a day to February 28th for the year, you can see if the new day is the 29th or the 1st.
If it is the 29th, then the year is a leap year.
This is done by using the [AddDays][add=days] method and the [Day][day] property of the [DateTime][datetime] struct.

## Shortening

When the body of a function is a single expression, the function can be implemented as an [expression-bodied member][expression-bodied-member], like so

```csharp
public static bool IsLeapYear(int year) =>
  (new DateTime(year, 2, 28)).AddDays(1.0).Day == 29;
```

or

```csharp
public static bool IsLeapYear(int year) => (new DateTime(year, 2, 28)).AddDays(1.0).Day == 29;
```

[add=days]: https://learn.microsoft.com/en-us/dotnet/api/system.datetime.adddays
[day]: https://learn.microsoft.com/en-us/dotnet/api/system.datetime.day
[datetime]: https://learn.microsoft.com/en-us/dotnet/api/system.datetime
[expression-bodied-member]: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members
