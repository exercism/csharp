# Optional parameter

```csharp
public static class TwoFer
{
    public static string Speak(string name = "you")
    {
        return $"One for {name}, one for me.";
    }
}
```

We define a single `Speak()` method with one optional parameter: `name`.
This optional parameter has its default value set to the string `"you"`.
The caller of a method with an optional parameter can either pass in a value (which is then used) or not pass in a value (which caused the default value to be used).

These calls are thus identical:

```csharp
`Speak()`
`Speak("you")`
```

Within the method, we use [string interpolation][string-interpolation] to build the return string where `{name}` is replaced with the value of the `name` parameter.

## Shortening

We can shorten the method by rewriting it as an [expression-bodied method][expression-bodied-method]:

```csharp
public static string Speak(string name = "you") =>
    $"One for {name}, one for me.";
```

or

```csharp
public static string Speak(string name = "you") => $"One for {name}, one for me.";
```

## String formatting

The [string formatting article][article-string-formatting] discusses alternative ways to format the returned string.

## Optional parameters vs. method overloads

The main alternative to using an optional parameter is to use a [method overloading approach][approach-method-overloading]. If you're interested in how these two solutions compare to each other, go check out our [optional parameters vs method overloads article][article-optional-parameters-vs-method-overloading].

[string-interpolation]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/interpolated
[expression-bodied-method]: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members#methods
[approach-method-overloading]: https://exercism.org/tracks/csharp/exercises/two-fer/approaches/method-overloading
[article-optional-parameters-vs-method-overloading]: https://exercism.org/tracks/csharp/exercises/two-fer/articles/optional-parameters-vs-method-overloading
[article-string-formatting]: https://exercism.org/tracks/csharp/exercises/two-fer/articles/string-formatting
