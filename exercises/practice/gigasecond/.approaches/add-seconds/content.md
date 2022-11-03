# AddSeconds

```csharp
using System;

public static class Gigasecond
{
    public static DateTime Add(DateTime birthDate)
    {
        return birthDate.AddSeconds(1_000_000_000);
    }
}
```

The `DateTime` class has an [AddSeconds() method][datetime-addseconds] that takes the number of seconds to add to the `DateTime` instance.
We then simply pass in the gigasecond value and a new `DateTime` instance is returned with the amount of seconds specified added to it.

## Shortening

There are two things we can do to further shorten this method:

1. Remove the curly braces by converting to an [expression-bodied method][expression-bodied-method]
1. Replace `1_000_000_000` with `1e9`, which is the same number but in scientific notation

Using this, we end up with:

```csharp
public static DateTime Add(DateTime birthDate) => birthDate.AddSeconds(1e9);
```

[expression-bodied-method]: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members#methods
[datetime-addseconds]: https://learn.microsoft.com/en-us/dotnet/api/system.datetime.addseconds