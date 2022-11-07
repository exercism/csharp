# Introduction

The key to this exercise is to calculate the sum of a number's factors.

## General guidance

- Consider what the highest possible factor of a number is whilst determining the factors
- Try and start the methode by doing any error checking

## Approach: `if` statements

```csharp
public static Classification Classify(int number)
{
    if (number < 1)
        throw new ArgumentOutOfRangeException(nameof(number));

    var sumOfFactors = Enumerable.Range(1, number / 2)
        .Where(factor => number % factor == 0)
        .Sum();

    if (sumOfFactors < number)
        return Classification.Deficient;

    if (sumOfFactors > number)
        return Classification.Abundant;

    return Classification.Perfect;
}
```
