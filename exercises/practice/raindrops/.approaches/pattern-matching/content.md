# Pattern matching

```csharp
public static string Convert(int number) =>
    (number % 3, number % 5, number % 7) switch
    {
        (0, 0, 0) => "PlingPlangPlong",
        (0, 0, _) => "PlingPlang",
        (0, _, 0) => "PlingPlong",
        (_, 0, 0) => "PlangPlong",
        (0, _, _) => "Pling",
        (_, 0, _) => "Plang",
        (_, _, 0) => "Plong",
        _ => number.ToString()
    };
```

This approach uses [pattern matching][pattern-matching] to find the _pattern_ of the matching sounds, and in particular the [positional pattern][positional-pattern].
To do so, we construct a [tuple][tuples] with three values, which are the remainder of the input number for the numbers `3`, `5` and `7`:

```csharp
(number % 3, number % 5, number % 7)
```

To see how this works, consider when the value of `number` is `15`, for which we should return `"PlingPlang"`.
As `number % 3` and `number % 5` are both equal to `0`, and `number % 7` is equal to `1`, the tuple will be

```csharp
(0, 0, 1)
```

We can then pattern match on the tuple and test its against the above pattern:

```csharp
(number % 3, number % 5, number % 7) switch
{
    (0, 0, 1) => "PlingPlang",
}
```

Let's add a pattern for `"PlingPlangPlong"`, which requires the remainder to be `0` for all three values:

```csharp
(number % 3, number % 5, number % 7) switch
{
    (0, 0, 1) => "PlingPlang",
    (0, 0, 0) => "PlingPlangPlong",
}
```

While this works, a better option would be to reverse the order of the patterns.
As patterns are matched from top to bottom, we can rewrite this to:

```csharp
(number % 3, number % 5, number % 7) switch
{
    (0, 0, 0) => "PlingPlangPlong",
    (0, 0, _) => "PlingPlang",
}
```

The thing to note is that we're now using the wildcard pattern (`_`) in the second pattern, as we don't really care for its value, as long as it's not `0`, and we can now guarantee that as otherwise the first pattern would have matched.

It's now easy to add the remaining patterns:

```csharp
(number % 3, number % 5, number % 7) switch
{
    (0, 0, 0) => "PlingPlangPlong",
    (0, 0, _) => "PlingPlang",
    (0, _, 0) => "PlingPlong",
    (_, 0, 0) => "PlangPlong",
    (0, _, _) => "Pling",
    (_, 0, _) => "Plang",
    (_, _, 0) => "Plong",
    _ => number.ToString()
}
```

The last pattern is the wildcard pattern again, but this time we're saying that we don't care about the actual values of the entire tuple, not just one or two specific values.
In that case, we'll return the string version of the number.

[pattern-matching]: https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/pattern-matching
[positional-pattern]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/patterns#positional-pattern
[tuples]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-tuples
