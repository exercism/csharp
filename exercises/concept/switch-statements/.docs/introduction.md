Wikipedia describes a `switch` statement as "a type of selection control mechanism used to allow the value of a variable or expression to change the control flow of program".

The mechanism involves the following keywords: `switch`, `case`, `break` and `default`.

At their simplest they test a primitive or string expression and make a decision based on its value. For example:

```csharp
string direction = GetDirection();
switch (direction)
{
    case "left":
        GoLeft();
        break;
    case "right":
        GoRight();
        break;
    default:
        MarkTime();
        break;
}
```

At their most sophisticated they introduce down casting `case <Type> <variable>:` and guards (`when`).

```csharp
Animal animal = GetAnimal();

switch (animal)
{
    case Dog canine:
    case Coyote canine:
        canine.Bark();
        break;
    case Cat cat when cat.HasOnly8Lives():
        cat.IsCareful();
        cat.Meow();
        break;
    case Cat cat:
        cat.Meow();
        break;
}
```
