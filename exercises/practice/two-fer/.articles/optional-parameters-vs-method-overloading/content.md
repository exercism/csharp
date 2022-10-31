# Optional parameters vs. method overloading

## Method overloading

Prior to C# 4.0, if you wanted a method to have a default value for one of its parameters, you needed to define an [overload of that method][method-overloading] (which the [method overloading approach][approach-method-overloading] uses):

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

These two methods have the same name, but they have a different number of parameters.
This allows the compiler to distinguish between calls to these methods based on the number of arguments passed to the method.

## Optional parameters

C# 4.0 introduced [optional parameters][optional-parameters] (which the [optional parameter approach][approach-optional-parameter] uses):

```csharp
public static string Speak(string name = "you")
{
    return $"One for {name}, one for me.";
}
```

Using an optional parameter, we can assign a default value to that parameter which is then used if no value is passed for that parameter: `Speak()` and `Speak("you")` are equivalent.
This new syntax allowed for a more succinct way of defining default values for parameters.

```exercism/note
Method overloading can do everything optional parameters can do, but the latter are arguably easier to read and write.
```

## What are the differences?

The main difference between the two is that optional parameters are more concise.
But what about their implementation?
Are optional parameters just overloaded methods in disguise?
Well, let's find out!

The most fool-proof way to check this is by examining the IL code (which is the intermediate code the .NET runtime executes) that both types of syntax compile to.
A great way to check the generated IL code for a bit of C# code is by using [sharplab.io].
We created a [sharplab gist][il-comparison] for the following C# code:

```csharp
public static class TwoFer
{
    public static string SpeakOverload()
    {
        return SpeakOverload("you");
    }

    public static string SpeakOverload(string name)
    {
        return $"One for {name}, one for me.";
    }

    public static string SpeakOptional(string name = "you")
    {
        return $"One for {name}, one for me.";
    }
}
```

We can then use the IL output option to view the generated IL code.

### IL code: method overloading

This is the IL code for the two method overloading methods:

```
.method public hidebysig static
    string SpeakOverload () cil managed
{
    // Method begins at RVA 0x2094
    // Code size 16 (0x10)
    .maxstack 1
    .locals init (
        [0] string
    )

    IL_0000: nop
    IL_0001: ldstr "you"
    IL_0006: call string TwoFer::SpeakOverload(string)
    IL_000b: stloc.0
    IL_000c: br.s IL_000e

    IL_000e: ldloc.0
    IL_000f: ret
} // end of method TwoFer::SpeakOverload

.method public hidebysig static
    string SpeakOverload (
        string name
    ) cil managed
{
    // Method begins at RVA 0x20b0
    // Code size 22 (0x16)
    .maxstack 3
    .locals init (
        [0] string
    )

    IL_0000: nop
    IL_0001: ldstr "One for "
    IL_0006: ldarg.0
    IL_0007: ldstr ", one for me."
    IL_000c: call string [System.Runtime]System.String::Concat(string, string, string)
    IL_0011: stloc.0
    IL_0012: br.s IL_0014

    IL_0014: ldloc.0
    IL_0015: ret
} // end of method TwoFer::SpeakOverload
```

### IL code: optional parameter

This is the IL code for the optional parameter method:

```
.method public hidebysig static
    string SpeakOptional (
        [opt] string name
    ) cil managed
{
    .param [1] = "you"
    // Method begins at RVA 0x20d4
    // Code size 22 (0x16)
    .maxstack 3
    .locals init (
        [0] string
    )

    IL_0000: nop
    IL_0001: ldstr "One for "
    IL_0006: ldarg.0
    IL_0007: ldstr ", one for me."
    IL_000c: call string [System.Runtime]System.String::Concat(string, string, string)
    IL_0011: stloc.0
    IL_0012: br.s IL_0014

    IL_0014: ldloc.0
    IL_0015: ret
} // end of method TwoFer::SpeakOptional
```

### Comparison

The big differences are that the generated IL code:

- does not include code that resembles the parameterless overloaded method's IL code,
- is _nearly_ identical to the single parameter, overloaded method's IL code, except for this one line:

```
.param [1] = "you"
```

This demonstrates that optional parameters are _not_ overloaded methods in disguise.

```exercism/note
Note how the interpolated string is actually converted to a `string.Concat` call in the IL code.
```

## Conclusion

Optional parameters are not only more elegant to use, they also result in a slightly smaller binary as less code is generated.

[approaches]: https://exercism.org/tracks/csharp/exercises/two-fer/approaches
[approach-optional-parameter]: https://exercism.org/tracks/csharp/exercises/two-fer/approaches/optional-parameter
[approach-method-overloading]: https://exercism.org/tracks/csharp/exercises/two-fer/approaches/method-overloading
[optional-parameters]: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/named-and-optional-arguments
[method-overloading]: https://www.pluralsight.com/guides/overload-methods-invoking-overload-methods-csharp
[sharplab.io]: https://sharplab.io
[il-comparison]: https://sharplab.io/#gist:a8991b6f70ee94145dbd43b571b9ef61
