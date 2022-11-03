# Sequence

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

public static class CollatzConjecture
{
    public static int Steps(int number)
    {
        if (number <= 0)
            throw new ArgumentOutOfRangeException(nameof(number));

        return Sequence(number).Count();
    }

    private static IEnumerable<int> Sequence(int number)
    {
        var currentNumber = number;

        while (currentNumber != 1)
        {
            if (currentNumber % 2 == 0)
                currentNumber = currentNumber / 2;
            else
                currentNumber = currentNumber * 3 + 1;

            yield return currentNumber;
        }
    }
}
```

The first step is to check the `number` parameter for validity:

```csharp
if (number <= 0)
    throw new ArgumentOutOfRangeException(nameof(number));
```

In the second step, the `Sequence()` method is called with `number` as its argument.
This method returns the sequence of numbers (`IEnumerable<int>`) that one gets by repeated application of the algorithm (excluding the number we start with).
Then, we count the amount of numbers in that sequence to get the number of steps:

| Number | Sequence                    | Count |
| ------ | --------------------------- | ----- |
| 2      | 1                           | 1     |
| 4      | 2, 1                        | 2     |
| 12     | 6, 3, 10, 5, 16, 8, 4, 2, 1 | 9     |

Let's examine the `Sequence()` method more closely.
As a reminder, this is what the method looks like:

```csharp
private static IEnumerable<int> Sequence(int number)
{
    var currentNumber = number;

    while (currentNumber != 1)
    {
        if (currentNumber % 2 == 0)
            currentNumber = currentNumber / 2;
        else
            currentNumber = currentNumber * 3 + 1;

        yield return currentNumber;
    }
}
```

First, we start out with assigning the `number` parameter to a `currentNumber` variable, which we'll use to keep track of where in the collatz conjecture sequence we currently are.

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

Finally, we use a [`yield` statement][yield-statement] to _yield_ the current number.

```csharp
yield return currentNumber;
```

When a `yield` statement is written, the compiler transforms the method into a state machine that is suspended after each yield statement.
Note that even though we are yield indidivual elements, what is returned from a caller's viewpoint is a sequence of elements.

Methods that use a `yield` statement are also _lazy_, which means that calling `Sequence(number)` by itself does not do anything.
It is only when we call `Count()` on the sequence, that we're forcing iteration over the elements in the sequence.

```exercism/note
Using `yield` statement to generate a lazy sequence allows one to work with "infinite" sequences efficiently, as only the element to be returned (and the generated state machine) take up memory.
```

## Shortening

A [ternary operator][ternary-operator] can be used instead of an `if` statement:

```csharp
currentNumber = currentNumber % 2 == 0 ? currentNumber / 2 : currentNumber * 3 + 1;
```

[ternary-operator]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/conditional-operator
[yield-statement]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/yield
