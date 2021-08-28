# About

Where types cannot be cast implicitly, you must use an explicit cast [operator][cast-operator].
The cast operator is nothing more than the target type in parentheses before the value you want to cast:

```csharp

int i = 7;
byte b = (byte)i; // Explicit cast from int to byte
```

Using an explicit cast is potentially dangerous. The two most common errors are:

- Casting to an incompatible type. This will throw an exception at runtime.
- Casting to a numeric value that is insufficiently "wide". This can result in a sign conflict or an overflow exception being thrown in the case of integers

Note: an expression of type `int` can be explicitly cast to `char`. This may result in an invalid `char`.

[cast-operator]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/type-testing-and-cast#cast-expression
