# LINQ

```csharp
using System;
using System.Linq;

public enum YachtCategory { Ones, Twos, Threes, Fours, Fives, Sixes, FullHouse, FourOfAKind, LittleStraight, BigStraight, Choice, Yacht }

public static class YachtGame
{
    public static int Score(int[] dice, YachtCategory category) =>
        category switch
        {
            YachtCategory.Ones => SingleDiceScore(dice, 1),
            YachtCategory.Twos => SingleDiceScore(dice, 2),
            YachtCategory.Threes => SingleDiceScore(dice, 3),
            YachtCategory.Fours => SingleDiceScore(dice, 4),
            YachtCategory.Fives => SingleDiceScore(dice, 5),
            YachtCategory.Sixes => SingleDiceScore(dice, 6),
            YachtCategory.FullHouse => FullHouseScore(dice),
            YachtCategory.FourOfAKind => FourOfAKindScore(dice),
            YachtCategory.LittleStraight => LittleStraightScore(dice),
            YachtCategory.BigStraight => BigStraightScore(dice),
            YachtCategory.Choice => ChoiceScore(dice),
            YachtCategory.Yacht => YachtScore(dice),
            _ => throw new ArgumentOutOfRangeException(nameof(category), "Invalid category")
        };

    private static int SingleDiceScore(int[] dice, int targetDie) =>
        dice.Where(die => die == targetDie).Sum();

    private static int FullHouseScore(int[] dice) =>
        dice.Any(die => dice.Count(other => other == die) == 2) &&
        dice.Any(die => dice.Count(other => other == die) == 3) ? dice.Sum() : 0;

    private static int FourOfAKindScore(int[] dice) =>
        dice.FirstOrDefault(die => dice.Count(other => other == die) >= 4, 0) * 4;

    private static int LittleStraightScore(int[] dice) =>
        dice.Distinct().Count() == 5 && !dice.Contains(6) ? 30 : 0;

    private static int BigStraightScore(int[] dice) =>
        dice.Distinct().Count() == 5 && !dice.Contains(1) ? 30 : 0;

    private static int YachtScore(int[] dice) =>
        dice.Distinct().Count() == 1 ? 50 : 0;

    private static int ChoiceScore(int[] dice) => dice.Sum();
}
```

## Single dice

The score for the `Ones`/`Twos`/`Threes`/`Fours`/`Fives`/`Sixes` categories all have the same logic: sum the number of occurences of a specific dice value.

The implementation is a direct translation:

1. Filter the dice that match our target die using [`Where()`][enumerable.where]
2. Sum the matching dice using [`Sum()`][enumerable.sum]

```csharp
private static int SingleDiceScore(int[] dice, int targetDie) =>
    dice.Where(die => die == targetDie).Sum();
```

## Full house

A full house category applies when one dice occurs twice, and another dice occurs thrice.
The score then is the sum of the dice.

To figure out if one dice occurs twice, we can use [`Any()`][enumerable.any] and within its lambda check if the count of the dice equal two.
We then do the same thing for the dice occuring thrice.
If both conditions are true, we sum the dice using `Sum()`:

```csharp
private static int FullHouseScore(int[] dice) =>
    dice.Any(die => dice.Count(other => other == die) == 2) &&
    dice.Any(die => dice.Count(other => other == die) == 3) ? dice.Sum() : 0;
```

## Four of a kind

The four of kind category applies when one dice occurs at least four times.
The score is then the value of that dice multiplied by four.

To figure out if a dice occurs at least four times, we can use [`Count()`][enumerable.count]: `dice.Count(other => other == die) >= 4`

Then, we'll try to find that dice using [`FirstOrDefault()`][enumerable.first-or-default] with the condition being the above-mentioned count check.
Note that we pass a default value of zero to the `FirstOrDefault()` method, which means that it will return either: the dice occuring at least four times, or zero if it could not be found.

Finally, we multiply the dice value we found by 4:

```csharp
private static int FourOfAKindScore(int[] dice) =>
    dice.FirstOrDefault(die => dice.Count(other => other == die) >= 4, 0) * 4;
```

Note: as `0 * 4 == 0`, we've also correctly handled the case where there is no dice occuring at least four times.

## Little straight

Dice can be scores as a little straight (30 point) if the dice are 1-2-3-4-5.
One way to approach this is to check that:

1. All five dice are different: we can check the number of dice by first getting the unique dice using [`Distinct()`][enumerable.distinct] and then counting those dice using [`Count()`][enumerable.count].
2. None of the dice is `6`: we use [`Contains()`][enumerable.contains] to ensure that `6` is not one of the dice

```csharp
private static int LittleStraightScore(int[] dice) =>
    dice.Distinct().Count() == 5 && !dice.Contains(6) ? 30 : 0;
```

## Big straight

Dice can be scores as a big straight (30 point) if the dice are 2-3-4-5-6.
One way to approach this is to check that:

1. All five dice are different: we can check the number of dice by first getting the unique dice using [`Distinct()`][enumerable.distinct] and then counting those dice using [`Count()`][enumerable.count].
2. None of the dice is `1`: we use [`Contains()`][enumerable.contains] to ensure that `1` is not one of the dice

```csharp
private static int BigStraightScore(int[] dice) =>
    dice.Distinct().Count() == 5 && !dice.Contains(1) ? 30 : 0;
```

## Yacht

Dice can be scored as a yacht (50 points) if all five dice have the same face.
We can check this by first getting the unique dice using `Distinct()` and then counting those dice using `Count()`.
This gives us the number of unique dice, which must be one if the dice represent a yacht score.

```csharp
private static int YachtScore(int[] dice) =>
    dice.Distinct().Count() == 1 ? 50 : 0;
```

## Choice

This is the simplest category: the score is the sum of all dice.
We can use `Sum()` for that:

```csharp
private static int ChoiceScore(int[] dice) => dice.Sum();
```

## Putting it all together

The final step is to call the above methods for the right category, which we can do using a [`switch` expression][switch-expression] and an [expression-bodied member][expression-bodied-member]:

```csharp
public static int Score(int[] dice, YachtCategory category) =>
    category switch
    {
        YachtCategory.Ones => SingleDiceScore(dice, 1),
        YachtCategory.Twos => SingleDiceScore(dice, 2),
        YachtCategory.Threes => SingleDiceScore(dice, 3),
        YachtCategory.Fours => SingleDiceScore(dice, 4),
        YachtCategory.Fives => SingleDiceScore(dice, 5),
        YachtCategory.Sixes => SingleDiceScore(dice, 6),
        YachtCategory.FullHouse => FullHouseScore(dice),
        YachtCategory.FourOfAKind => FourOfAKindScore(dice),
        YachtCategory.LittleStraight => LittleStraightScore(dice),
        YachtCategory.BigStraight => BigStraightScore(dice),
        YachtCategory.Choice => ChoiceScore(dice),
        YachtCategory.Yacht => YachtScore(dice),
        _ => throw new ArgumentOutOfRangeException(nameof(category), "Invalid category")
    };
```

[enumerable.any]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.any
[enumerable.distinct]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.distinct
[enumerable.count]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.count
[enumerable.contains]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.contains
[enumerable.where]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.where
[enumerable.sum]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.sum
[enumerable.first-or-default]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.firstordefault
[switch-expression]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/switch-expression
[expression-bodied-member]: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members
