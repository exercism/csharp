In this exercise you're playing a role-playing game named "Wizard and Warriors," which allows you to play as either a Wizard or a Warrior.

There are different rules for Warriors and Wizards to determine how much damage points they deal.

For a Warrior, these are the rules:

- Deal 6 points of damage if the character they are attacking is not vulnerable
- Deal 10 points of damage if the character they are attacking is vulnerable

For a Wizard, these are the rules:

- Deal 12 points of damage if the Wizard prepared a spell in advanced
- Deal 3 points of damage if the Wizard did not prepare a spell in advance

In general, characters are never vulnerable. However, Wizards _are_ vulnerable if they haven't prepared a spell.

You have six tasks that work with Warriors and Wizard characters.

## 1. Describe a character

Override the `ToString()` method on the `Character` class to return a description of the character, formatted as `"Character is a <CHARACTER_TYPE>"`.

```csharp
var warrior = new Warrior();
warrior.ToString();
// => "Character is a Warrior"
```

## 2. Make characters not vulnerable by default

Ensure that the `Character.Vulnerable()` method always returns `false`.

```csharp
var warrior = new Warrior();
warrior.Vulnerable();
// => false
```

## 3. Allow Wizards to prepare a spell

Implement the `Wizard.PrepareSpell()` method to allow a Wizard to prepare a spell in advance.

```csharp
var wizard = new Wizard();
wizard.PrepareSpell();
```

## 4. Make Wizards vulnerable when not having prepared a spell

Ensure that the `Vulnerable()` method returns `true` if the wizard did not prepare a spell; otherwise, return `false`.

```csharp
var wizard = new Wizard();
wizard.Vulnerable();
// => true
```

## 5. Calculate the damage points for a Wizard

Implement the `Wizard.DamagePoints()` method to return the damage points dealt: 12 damage points when a spell has been prepared, 3 damage points when not.

```csharp
var wizard = new Wizard();
var warrior = new Warrior();

wizard.PrepareSpell();
wizard.DamagePoints(warrior);
// => 12
```

## 6. Calculate the damage points for a Warrior

Implement the `Warrior.DamagePoints()` method to return the damage points dealt: 10 damage points when the target is vulnerable, 6 damage points when not.

```csharp
var warrior = new Warrior();
var wizard = new Wizard();

warrior.DamagePoints(wizard);
// => 10
```
