To repeatedly execute logic, one can use loops. If the code in a loop should always be executed at least one, a `do/while` loop can be used:

```csharp
int x = 0;

do
{
    x = GetX();
    // do something with x
}
while (x != 0);
```

This is used less frequently than a `while` loop but in some cases results in more natural looking code.
