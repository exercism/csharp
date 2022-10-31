# Method overloading

```csharp
public static class TwoFer
{
    public static string Speak()
    {
        return Speak("you");
    }

    public static string Speak(string name)
    {
        return $"One for {name}, one for me.";
    }
}
```

First, let's define the `Speak()` method that has a single parameter for the name:

```csharp
public static string Speak(string name)
{
    return $"One for {name}, one for me.";
}
```

Within the method, we use [string interpolation][string-interpolation] to build the return string where `{name}` is replaced with the value of the `name` parameter.

Then we define a second, parameterless method that calls the other `Speak()` method with `"you"` as its argument:

```csharp
public static string Speak()
{
    return Speak("you");
}
```

The compiler will be able to figure out which method to call based on the number of arguments passed to the `Speak()` method.

## Shortening

We can shorten the methods by rewriting them as [expression-bodied methods][expression-bodied-method]:

```csharp
public static string Speak() =>
    Speak("you");

public static string Speak(string name) =>
    $"One for {name}, one for me.";
```

or

```csharp
public static string Speak() => Speak("you");

public static string Speak(string name) => $"One for {name}, one for me.";
```

## String formatting

The [string formatting article][article-string-formatting] discusses alternative ways to format the returned string.

## Optional parameters vs. method overloads

The main alternative to using method overloads is to use an [optional parameter approach][approach-optional-parameter]. If you're interested in how these two solutions compare to each other, go check out our [optional parameters vs method overloads article][article-optional-parameters-vs-method-overloading].

[approach-optional-parameter]: https://exercism.org/tracks/csharp/exercises/two-fer/approaches/optional-parameter
[article-optional-parameters-vs-method-overloading]: https://exercism.org/tracks/csharp/exercises/two-fer/articles/optional-parameters-vs-method-overloading
[article-string-formatting]: https://exercism.org/tracks/csharp/exercises/two-fer/articles/string-formatting
[optional-parameters-introduction]: https://learn.microsoft.com/en-us/archive/msdn-magazine/2010/july/csharp-4-0-new-csharp-features-in-the-net-framework-4#named-arguments-and-optional-parameters
[method-overloading]: https://www.pluralsight.com/guides/overload-methods-invoking-overload-methods-csharp
[string-interpolation]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/interpolated
