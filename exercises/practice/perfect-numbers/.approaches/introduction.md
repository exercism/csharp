# Introduction

The key to this exercise is to calculate the sum of a number's factors.

## General guidance

- Consider what the highest possible factor of a number is whilst determining the factors
- Try and start the method by doing any error checking

## Approach: `if` statements

```csharp
public static Classification Classify(int number)
{
    if (number < 1)
        throw new ArgumentOutOfRangeException(nameof(number));

    var sum = Enumerable.Range(1, number / 2)
        .Sum(n => number % n == 0 ? n : 0);

    if (sum < number)
        return Classification.Deficient;

    if (sum > number)
        return Classification.Abundant;

    return Classification.Perfect;
}
```

## Approach: `switch` expression

```csharp
public static Classification Classify(int number)
{
    var sum = Enumerable.Range(1, number - 1)
        .Sum(n => number % n == 0 ? n : 0);

    return (sum < number, sum > number) switch
    {
        (true, _) => Classification.Deficient,
        (_, true) => Classification.Abundant,
        _ => Classification.Perfect,
    };
}
```