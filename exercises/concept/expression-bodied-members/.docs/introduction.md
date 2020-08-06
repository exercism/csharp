Many types of struct and class members (fields being the primary exception) can use the expression-bodied member syntax. Defining a member with an expression often produces more concise and readable code than traditional blocks/statements.

Methods and read-only properties are amongst the members that can be defined with expression bodies.

```csharp
public int Times3(int input) => input * 3;

public int Interesting => 1729;
```

#### Ternary operators

Ternary operators allow if-conditions to be defined in expressions rather than statement blocks. This echoes functional programming approaches and can often make code more expressive and less error-prone.

The ternary operator combines 3 expressions: a condition followed by an expression to be evaluated and returned if the condition is true (the `if` part, introduced by `?`) and an expression to be evaluated and returned if the condition is false (the `else` part, introduced by `:`).

```csharp
int a = 3, b = 4;
int max = a > b ? a : b;
// => 4
```

`throw` expressions are an alternative to `throw` statements and in particular can add to the power of ternary and other compound expressions.

```csharp
string trimmed = str == null ? throw new ArgumentException() : str.Trim();
```

#### Switch expressions

A switch expression can match a value to one case in a set of patterns and return the associated value or take the associated action. The association is denoted by the `=>` symbol. In addition, each pattern can have an optional case guard introduced with the `when` keyword. The case guard expression must evaluate to true for that "arm" of the switch to be selected. The cases (also known as _switch arms_) are evaluated in text order and the process is cut short and the associated value is returned as soon as a match is found.

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
