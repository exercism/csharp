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
