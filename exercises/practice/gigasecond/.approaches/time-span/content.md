# TimeSpan

```csharp
using System;

public static class Gigasecond
{
    public static DateTime Add(DateTime birthDate)
    {
        return birthDate + TimeSpan.FromSeconds(1_000_000_000);
    }
}
```

The `DateTime` class supports adding a `TimeSpan` instance via the [`+` operator][datetime-plus-operator-timespan].
We then simply use the `+` operator on the `DateTime` instance and pass it the gigasecond in the form of a `TimeSpan` by using its [`TimeSpan.FromSeconds()` factory method][time-span-from-seconds].
This will return a new `DateTime` instance with the amount of seconds represented by the `TimeSpan` added to it.

## Shortening

There are two things we can do to further shorten this method:

1. Remove the curly braces by converting to an [expression-bodied method][expression-bodied-method]
1. Replace `1_000_000_000` with `1e9`, which is the same number but in scientific notation

Using this, we end up with:

```csharp
public static DateTime Add(DateTime birthDate) => birthDate + TimeSpan.FromSeconds(1e9);
```

[expression-bodied-method]: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members#methods
[datetime-plus-operator-timespan]: https://learn.microsoft.com/en-us/dotnet/api/system.datetime.op_addition
[time-span-from-seconds]: https://learn.microsoft.com/en-us/dotnet/api/system.timespan.fromseconds