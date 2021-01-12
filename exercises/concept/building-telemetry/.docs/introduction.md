This exercise discusses some details of method parameters and their use in C#.

Parameters convey information from a calling method to a called method.

- The behavior of parameters can be modified by the use of modifies such as `ref` and `out`.

- A parameter with the `out` modifier conveys a value back from the called method to the caller. The parameter can be passed to the called method without being initialized and in any case it is treated within the called method as if, on entry, it had not been initialized. An understanding of the behavior and rules regarding parameter modifiers can be gained most easily through examples (see below) and compiler messages.

```csharp
void Foo(out int val)
{
    val = 42;
}
void Bar(int val)
{
    val = 42;
}

int importantValue = 1729;
Foo(out importantValue);
var result = importantValue == 42;
// => true

importantValue = 1729;
Bar(importantValue);
result = importantValue == 1729;
// => true
```

- `out` parameters must be assigned to within a called method.

- A parameter with the `ref` modifier passes a value into a called method. When the method returns the caller will find any updates made by the called method in that parameter.

```csharp
void Foo(ref int val)
{
    val *= 7;
}

int importantValue = 6;
Foo(ref importantValue);
return importantValue;
// => 42
```

- `ref` parameters must be variables as the called method will be operating directly on the parameter as seen by the caller.
- The `out` and `ref` modifiers are required both in the called method signature and at the call site.
