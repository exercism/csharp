# Introduction

The key to this exercise is to repeatedly apply an algorithm to a number and then stop when its halting condition occurs (which is when the number is `1`).

## General guidance

- Make sure you return when the number is `1`, otherwise you'll end up in an endless loop
- You can use a [`nameof` expression][nameof] when throwing the `ArgumentOutOfRangeException` to refer to the name of the parameter
- It is good practice to not re-assign to the parameter, but to introduce a new variable instead

## Approach: `while` loop

```csharp
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
```

This approach uses a [`while` loop][while] to check and update the current number after applying the algorithm to it.
For more information, check the [`while` loop approach][approach-while-loop].

## Approach: recursion

```csharp
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
```

This approach uses a recursion to calculate the steps, with each call to `Steps(int number, int stepCount)` representing a single application of the algorithm.
For more information, check the [recursion approach][approach-recursion].

### Approach: sequence

```csharp
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
```

This approach creates a (lazy) sequence of the numeric values that one gets by repeated application of the algorithm (using a while loop).
It then counts that sequence to get the number of steps.
For more information, check the [sequence approach][approach-sequence].

## Which approach to use?

The difference between the three approaches is mostly cosmetic, so what approach you prefer comes down to personal preference.

[approach-recursion]: https://exercism.org/tracks/csharp/exercises/collatz-conjecture/approaches/recursion
[approach-while-loop]: https://exercism.org/tracks/csharp/exercises/collatz-conjecture/approaches/while-loop
[approach-sequence]: https://exercism.org/tracks/csharp/exercises/collatz-conjecture/approaches/sequence
[nameof]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/nameof
[while]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/iteration-statements#the-while-statement
