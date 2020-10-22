[`throw` expressions][throw-expressions] are an alternative to `throw` statements and in particular can add to the power of ternary and other compound expressions.

```csharp
string trimmed = str == null ? throw new ArgumentException() : str.Trim();
```

If `str` is `null` in the above code an exception is thrown.

[throw-expressions]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/throw#the-throw-expression
