# Introduction

The key to this exercise is to allow the `Speak()` method to be called _with_ and _without_ an argument.
There are two ways to do this in C#:

1. [Optional parameters][optional-parameters]
2. [Method overloading][method-overloading]

## General guidance

- Try to not repeat any string building logic ([DRY][dry])
- [String interpolation][article-string-formatting] is a great way to build strings

## Approach: optional parameter

```csharp
public static string Speak(string name = "you")
{
    return $"One for {name}, one for me.";
}
```

This approach uses an optional parameter to allow the method to be called both with and without a name.
For more information, check the [optional-parameter approach][approach-optional-parameter].

## Approach: method overloading

```csharp
public static string Speak()
{
    return Speak("you");
}

public static string Speak(string name)
{
    return $"One for {name}, one for me.";
}
```

This approach uses method overloading to allow the method to be called both with and without a name.
For more information, check the [method overloading][approach-method-overloading].

## Which approach to use?

The optional parameter approach is not only more concise, it also more clearly encodes that name has a default value (which is not immediately apparent with the method overloading approach).

[optional-parameters]: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/named-and-optional-arguments
[method-overloading]: https://www.pluralsight.com/guides/overload-methods-invoking-overload-methods-csharp
[approach-optional-parameter]: https://exercism.org/tracks/csharp/exercises/two-fer/approaches/optional-parameter
[approach-method-overloading]: https://exercism.org/tracks/csharp/exercises/two-fer/approaches/method-overloading
[article-optional-parameters-vs-method-overloading]: https://exercism.org/tracks/csharp/exercises/two-fer/articles/optional-parameters-vs-method-overloading
[article-string-formatting]: https://exercism.org/tracks/csharp/exercises/two-fer/articles/string-formatting
[dry]: https://en.wikipedia.org/wiki/Don%27t_repeat_yourself
