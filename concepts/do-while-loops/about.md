TODO: clarify context for do-while loop
A closely related construct is the `do` loop:

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
