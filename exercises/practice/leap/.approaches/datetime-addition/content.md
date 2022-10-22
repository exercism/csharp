# `DateTime.Add`

```csharp
// uses System for DateTime
public static bool IsLeapYear(int year) => (new DateTime(year, 2, 28)).AddDays(1.0).Day == 29;
```

This approach may be considered a "cheat" for this exercise.
By adding a day to February 28th for the year, we can see if the new day is the 29th or the 1st.
If it is the 29th, then the year is a leap year.
This is done by using the [AddDays][add=days] method and the [Day][day] property of the [DateTime][datetime] struct.

[add=days]: https://learn.microsoft.com/en-us/dotnet/api/system.datetime.adddays?view=net-7.0
[day]: https://learn.microsoft.com/en-us/dotnet/api/system.datetime.day?view=net-7.0
[datetime]: https://learn.microsoft.com/en-us/dotnet/api/system.datetime?view=net-7.0
