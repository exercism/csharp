[Ternary operators][ternary-operators] allow if-conditions to be defined in expressions rather than statement blocks. This echoes functional programming approaches and can often make code more expressive and less error-prone.

The ternary operator combines 3 expressions: a condition followed by an expression to be evaluated and returned if the condition is true (the `if` part, introduced by `?`) and an expression to be evaluated and returned if the condition is false (the `else` part, introduced by `:`).

```csharp
int a = 3, b = 4;
int max = a > b ? a : b;
// => 4
```

[ternary-operators]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/conditional-operator
