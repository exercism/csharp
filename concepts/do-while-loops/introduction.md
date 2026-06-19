# Introduction

If the code in a loop should always be executed at least once, a `do`/`while` loop can be used:

```csharp
int x = 23;

do
{
    // Always executes at least once, then repeats as long as x > 10
    x = x - 2;
} while (x > 10)
```
