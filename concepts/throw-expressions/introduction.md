`throw` expressions are an alternative to `throw` statements and in particular can add to the power of ternary and other compound expressions.

```csharp
string trimmed = str == null ? throw new ArgumentException() : str.Trim();
```
