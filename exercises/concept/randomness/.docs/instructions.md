Continuing the theme of the wizards and warriors game, it is time to add an all purpose die rolling method. This will be the traditional 18 sided die with numbers 1 to 18. Players also generate a spell strength.

## 1. Enable a _wizards and warriors_ player to roll a die.

Implement a `RollDie()` method on the `Player` class.

```csharp
var player = new Player();
player.RollDie();
// => >= 1 <= 18
```

## 2. Players need their strength. Provide a means to generate spell strength

Implement a `GenerateSpellStregngth()` method on the player class. The spell strength is between 0.0 and 100.0.

Note that spell strength must be a real number (not an integer) to reduce the possibility of a tie when the strengths of two adversaries are compared.

```csharp
var player = new Player();
player.GenerateSpellStrength();
// => >= 0.0 < 100.0
```
