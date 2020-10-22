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

[switch-expressions]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/switch-expression
[switch-statement]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/switch
[pattern-matching]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/switch-expression#patterns-and-case-guards
