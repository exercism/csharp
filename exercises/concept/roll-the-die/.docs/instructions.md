# Instructions

In this exercise, you are playing a role-playing game named "Wizards and Warriors."
To play this game, you need an all-purpose die rolling method to determine various outcomes.
This will be the traditional 18-sided die with numbers 1 to 18.
Players will also need to generate a random spell strength.

## 1. Enable a _Wizards and Warriors_ player to roll a die

Implement a `RollDie()` method on the `Player` class.

```csharp
var player = new Player();
player.RollDie();
// => >= 1 <= 18
```

## 2. Players need their strength. Provide a means to generate spell strength

Implement a `GenerateSpellStrength()` method on the player class.
The spell strength is between 0.0 and up to but not including 100.0.

Note that spell strength must be a floating-point number (not an integer) to reduce the possibility of a tie when the strengths of two adversaries are compared.

```csharp
var player = new Player();
player.GenerateSpellStrength();
// => >= 0.0 < 100.0
```
