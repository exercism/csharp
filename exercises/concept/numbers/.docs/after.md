One of the key aspects of working with numbers in C# is the distinction between integers (numbers with no digits after the decimal separator) and floating-point numbers (numbers with zero or more digits after the decimal separator).

The two most commonly used numeric types in C# are `int` (a 32-bit integer) and `double` (a 64-bit floating-point number). Arithmetic is done using the standard [arithmetic operators][arithmetic-operators] (`+`, `-`, `*`, etc.).

Numbers can be compared using the standard [comparison operators][comparison-operators] (`<`, `>=`, etc.). The result of a comparison can be used in `if` statements to conditionally execute code.

When converting between numeric types, there are two types of numeric conversions:

1. Implicit conversions: no data will be lost and no additional syntax is required.
2. Explicit conversions: data could be lost and additional syntax in the form of a _cast_ is required.

As an `int` has less precision than a `double`, converting from an `int` to a `double` is safe and is thus an implicit conversion. However, converting from a `double` to an `int` could mean losing data, so that requires an explicit conversion.

[arithmetic-operators]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/arithmetic-operators
[equality-operators]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/equality-operators
[comparison-operators]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/comparison-operators
