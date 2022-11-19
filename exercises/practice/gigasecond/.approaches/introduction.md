# Introduction

The key to this exercise is to add a number of seconds to a C# `DateTime`.
As C# `DateTime` instances are immutable, this means that you'll need to return a new `DateTime` instance.

## General guidance

A gigasecond is equal to one billion seconds, which we can write as `1_000_000_000`.

```exercism/note
Using underscores as digit separators can help make large numbers a lot more readable.
```

Alternative, scientific notation can be used for a more compact notation: `1e9`.

## Approach: `AddSeconds()`

```csharp
public static DateTime Add(DateTime birthDate)
{
    return birthDate.AddSeconds(1_000_000_000);
}
```

This approach uses the `AddSeconds()` method to create a new `DateTime` instance with an added gigasecond number of seconds.
For more information, check the [`AddSeconds()` approach][approach-add-seconds].

## Approach: `TimeSpan`

```csharp
public static DateTime Add(DateTime birthDate)
{
    return birthDate + TimeSpan.FromSeconds(1_000_000_000);
}
```

This approach uses the `+` operator on the `DateTime` instance with a `TimeSpan` instance representing a gigasecond added to it.
For more information, check the [`TimeSpan` approach][approach-time-span].

## Which approach to use?

The difference between the two approaches is minor and merely cosmetic, so what approach you prefer comes down to personal preference.

[approach-add-seconds]: https://exercism.org/tracks/csharp/exercises/gigasecond/approaches/add-seconds
[approach-time-span]: https://exercism.org/tracks/csharp/exercises/gigasecond/approaches/time-span
