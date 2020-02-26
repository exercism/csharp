There are three floating-point types in C#: `float`, `double` and `decimal`. The most commonly used type is `double`, whereas `decimal` is normally used when working with monetary data.

Each floating-point type has its own [precision, approximate range and size][docs-microsoft.com-characteristics-of-the-floating-point-types].

Some conversions between floating point types are [automatic (implicit)][docs-microsoft.com-implicit-numeric-conversion], but others are [manual (explicit)][docs-microsoft.com-explicit-numeric-conversion].

Always be careful when checking the values of floating-point types for equality, as values that can appear to represent the same value could actually be different. See [this article][docs.microsoft.com_precision-in-comparisons] for more information.

You can find a short introduction to floating-point numbers at [0.30000000000000004.com][0.30000000000000004.com]. The [Float Toy page][evanw.github.io-float-toy] has a nice, graphical explanation how a floating-point numbers' bits are converted to an actual floating-point value.

To repeatedly execute logic, one can use loops. One of the most common loop types in C# is the `while` loop, which keeps on looping until a boolean condition evaluates to `true`.

[docs-microsoft.com-explicit-numeric-conversion]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/numeric-conversions#explicit-numeric-conversions
[docs-microsoft.com-implicit-numeric-conversion]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/numeric-conversions#implicit-numeric-conversions
[docs-microsoft.com-characteristics-of-the-floating-point-types]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/floating-point-numeric-types#characteristics-of-the-floating-point-types
[docs.microsoft.com_precision-in-comparisons]: https://docs.microsoft.com/en-us/dotnet/api/system.double.equals#precision-in-comparisons
[0.30000000000000004.com]: https://0.30000000000000004.com/
[evanw.github.io-float-toy]: https://evanw.github.io/float-toy/
