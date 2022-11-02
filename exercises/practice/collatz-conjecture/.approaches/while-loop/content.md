# `while` loop

```csharp
using System;

public static class CollatzConjecture
{
    public static int Steps(int number)
    {
        if (number <= 0)
            throw new ArgumentOutOfRangeException(nameof(number));

        var currentNumber = number;
        var stepCount = 0;

        while (currentNumber != 1)
        {
            if (currentNumber % 2 == 0)
                currentNumber = currentNumber / 2;
            else
                currentNumber = currentNumber * 3 + 1;

            stepCount++;
        }

        return stepCount;
    }
}
```

The first step is to check the `number` parameter for validity:

```csharp
if (number <= 0)
    throw new ArgumentOutOfRangeException(nameof(number));
```

We then define two variables:

- `currentNumber`: contains the current number in the sequence as a result of repeated application of the algorithm (with its starting value being the `number` parameter)
- `stepCount`: keeps track of the number of steps (which is the number of times we apply the algorithm)

```csharp
var currentNumber = number;
var stepCount = 0;
```

```exercism/note
Re-assiging values to a parameter _is_ possible, but it is considered good practice to not do that.
```

Then a `while` loop starts by checking whether the current number is not equal to `1`; if it is, the method terminates:

```csharp
while (currentNumber != 1)
```

Within the loop, we update the `currentNumber` based on the algorithm, re-assigning its value with its next value in the sequence.

```csharp
if (currentNumber % 2 == 0)
    currentNumber = currentNumber / 2;
else
    currentNumber = currentNumber * 3 + 1;
```

Then we increment the number of steps, to indicate that we've just applied the algorithm:

```csharp
stepCount++;
```

The `while` loop then continues until the `currentNumber` is equal to `1`, after which we return the step count:

```csharp
return stepCount;
```

## Shortening

A [ternary operator][ternary-operator] can be used instead of an `if` statement:

```csharp
currentNumber = currentNumber % 2 == 0 ? currentNumber / 2 : currentNumber * 3 + 1;
```

[ternary-operator]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/conditional-operator
