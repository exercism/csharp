Booleans in C# are represented by the `bool` type, which values can be either `true` or `false`.

C# supports three [boolean operators][operators]: `!` (NOT), `&&` (AND), and `||` (OR). The `&&` and `||` operators use _short-circuit evaluation_, which means that the right-hand side of the operator is only evaluated when needed.

```csharp
true || false // => true
true && false // => false
```

The three boolean operators each have a different [_operator precedence_][precedence]. As a consequence, they are evaluated in this order: `not` first, `&&` second, and finally `||`. If you want to 'escape' these rules, you can enclose a boolean expression in parentheses (`()`), as the parentheses have an even higher operator precedence.

```csharp
!true && false   // => false
!(true && false) // => true
```

[operators]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/boolean-logical-operators
[precedence]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/boolean-logical-operators#operator-precedence
