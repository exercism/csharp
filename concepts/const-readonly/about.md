# About

By default, values in C# are _mutable_, that is they can change over time. To make a value _immutable_, there are two options:

1. Add the [`const` modifier](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/const)
2. Add the [`readonly` modifier](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/readonly#readonly-field-example)

The `const` modifier has some restrictions:

1. It can only be applied to "constant" types: strings, booleans and numbers.
1. The `const` value must be initialized immediately.

See [definining constants](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/how-to-define-constants) for more information.

If your value is a non-constant type or you need to initialize the value in a constructor, `readonly` can be used to enforce immutability.
