# Recursion

```csharp
using System;

public static class CollatzConjecture
{
    public static int Steps(int number)
    {
        if (number <= 0)
            throw new ArgumentOutOfRangeException(nameof(number));

        return Steps(number, 0);
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

The first step is to check the `number` parameter for validity:

```csharp
if (number <= 0)
    throw new ArgumentOutOfRangeException(nameof(number));
```

The next step is to call the overload `Steps()` method and return its value.

```csharp
return Steps(number, 0);
```

````exercism/note
For someone new to the code, it might not be clear what the `0` argument in the `Steps(number, 0)` call represents.
You could introduce an appropriately named variable and use that as the argument:

```csharp
var stepCount = 0;
return Steps(number, stepCount);
```

This is already much better, but another option is to use a [named argument](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/named-and-optional-arguments#named-arguments):

```csharp
return Steps(number, stepCount: 0);
```
````

Let's examine the overload `Steps()` method, which looks like this:

```csharp
private static int Steps(int number, int stepCount)
{
    if (number == 1)
        return stepCount;

    if (number % 2 == 0)
        return Steps(number / 2, stepCount + 1);

    return Steps(number * 3 + 1, stepCount + 1);
}
```

The first step is to check if the `number` parameter is equal to `1`
If it is, we return the step count.
This condition is often referred to the _terminating condition_, which is something that every recursive method must have (we'll get to the recursive component next).

If the `number` is not `1`, we need to apply the algorithm:

```csharp
if (number % 2 == 0)
    return Steps(number / 2, stepCount + 1);

return Steps(number * 3 + 1, stepCount + 1);
```

We can see the algorithm being reflected here, but the interesting thing is that we're calling _the same method that we're in_ but with different arguments.
The two recursive calls represent the two options in the algorithm, and each applies the algorithm to the number to pass in the updated number of the first argument.
The second argument is the step count, but incremented by one to indicate that we've applied the algorithm once.

The method call stack will look something like this:

```csharp
Steps(4)
Steps(4, 0) // number = 4, stepCount = 0
Steps(2, 1) // number = 2, stepCount = 1
Steps(1, 2) // number = 1, stepCount = 2
```

Or in table format:

| `number` | `stepCount` | Returned value                     |
| -------- | ----------- | ---------------------------------- |
| 4        | 0           | `Steps(number / 2, stepCount + 1)` |
| 2        | 1           | `Steps(number / 2, stepCount + 1)` |
| 1        | 2           | `stepCount`                        |

You can see that the same method is called three times, with the third time no longer doing a recursive call but returning the step count as the terminating condition was reached.

## Shortening

A [ternary operator][ternary-operator] can be used instead of an `if` statement:

```csharp
var nextNumer = number % 2 == 0 ? number / 2 : number * 3 + 1;
return Steps(nextNumer, stepCount + 1);
```

or just inline it:

```csharp
return Steps(number % 2 == 0 ? number / 2 : number * 3 + 1, stepCount + 1);
```

[ternary-operator]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/conditional-operator
