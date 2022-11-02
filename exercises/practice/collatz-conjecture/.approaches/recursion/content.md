# Recursion

```csharp
using System;

public static class CollatzConjecture
{
    public static int Steps(int number)
    {
        if (number <= 0)
            throw new ArgumentOutOfRangeException(nameof(number));

        return Steps(number, stepCount: 0);
    }

    private static int Steps(int number, int stepCount)
    {
        if (number == 1)
            return stepCount;

        if (number % 2 == 0)
            return Steps(number / 2, stepCount + 1);

        return Steps(number * 3 + 1, stepCount + 1);
    }
}
```

## Shortening

A ternary operator can be used instead of an `if` statement:

```csharp
var nextNumer = number % 2 == 0 ? number / 2 : number * 3 + 1;
return Steps(nextNumer, stepCount + 1);
```

or just inline it:

```csharp
return Steps(number % 2 == 0 ? number / 2 : number * 3 + 1, stepCount + 1);
```
