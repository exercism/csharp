Many [types of struct and class members][expression-bodied-members] (fields being the primary exception) can use the expression-bodied member syntax. Defining a member with an expression often produces more concise and readable code than traditional blocks/statements.

```csharp
public int Times3(int input) => input * 3;

public int Interesting => 1729;
```

Expression-bodied-members cannot have blocks of multiple statements, but those with a functional background should be warned that anything that a traditional member can do can be achieved by one of these members. The "expression" can be an assignment operation creating side effects, or a method invocation meaning that anything is possible.

#### Ternary Operators

[Ternary operators][ternary-operators] allow if-conditions to be defined in expressions rather than statement blocks. This echoes functional programming approaches and can often make code more expressive and less error-prone.

The ternary operator combines 3 expressions: a condition followed by an expression to be evaluated and returned if the condition is true (the `if` part, introduced by `?`) and an expression to be evaluated and returned if the condition is false (the `else` part, introduced by `:`).

```csharp
int a = 3, b = 4;
int max = a > b ? a : b;
// => 4
```

#### Switch expression

[Switch expressions][switch-expressions] behave in a similar manner to [switch statements][switch-statements] covered in (TODO cross-ref-tba switch statements). They support a kind of decision table that maps input conditions to actions or values.

At the core of the switch expression is _pattern matching_. In the coding exercise we matched values against `const` patterns. In this case the inputs to the `switch` are a _range expression_ which is matched to const values and the values used by the _case guards_.

The cases (also known as _switch arms_) are evaluated in text order and the process is cut short and the associated value is returned as soon as a match is found.

The `_` case which is the last in the list is useful to ensure that the matching is exhaustive and to avoid possible run-time errors.

```csharp
double xx = 42d;

string interesting = xx switch
{
    0 => "I suppose zero is interesting",
    3.14 when DateTime.Now.Day == 14 && DateTime.Now.Month == 3 => "Mmm pie!",
    3.14 => "π",
    42 => "a bit of a cliché",
    1729 => "only if you are a pure mathematician",
    _ => "not interesting"
};

// => interesting == "a bit of a cliché"
```

An "arm" of the `switch` is selected when the pattern matches the range variable and any case guard evaluates to true.

Switch expression also support [type patterns][pattern-matching] and recursive matching.

#### Throw expressions

[`throw` expressions][throw-expressions] are an alternative to `throw` statements and in particular can add to the power of ternary and other compound expressions.

```csharp
string trimmed = str == null ? throw new ArgumentException() : str.Trim();
```

If `str` is `null` in the above code an exception is thrown.

#### Reference

- [Expressions][expressions]: explains what expressions are.
- [Expression-bodied members][expression-bodied-members]: what expression-bodied members are and how to define them.

[expressions]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expressions
[expression-bodied-members]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members
[ternary-operators]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/conditional-operator
[switch-expressions]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/switch-expression
[switch-statement]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/switch
[pattern-matching]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/switch-expression#patterns-and-case-guards
[throw-expressions]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/throw#the-throw-expression
