# `switch` expression

```csharp
using System;

public static class Darts
{
    public static int Score(double x, double y)
    {
        return Math.Sqrt(x * x + y * y) switch
        {
            > 10.0 => 0,
            > 5.0 => 1,
            > 1.0 => 5,
            _ => 10
        };
    }
}
```

The first step is to calculate the distance from the center of the board, which we can with the [cartesian coordinates distance formula][distance-formula]:

```csharp
Math.Sqrt(x * x + y * y)
```

Before we'll look at the score calculation, let's re-iterate the games rules:

| Lands         | Distance                  | Points |
| ------------- | ------------------------- | ------ |
| Outside       | > 10 units                | 0      |
| Outer circle  | > 5 units and <= 10 units | 1      |
| Middle circle | > 1 unit and <= 5 units   | 5      |
| Inner circle  | <= 1 unit                 | 10     |

Directly translating this to code gives us:

```csharp
return Math.Sqrt(x * x + y * y) switch
{
    > 10.0 => 0,
    > 5.0 and <= 10 => 1,
    > 1.0 and <= 5.0 => 5,
    _ => 10
};
```

However, due to the order of evaluation, we know in our second condition, `<= 10.0` must always `true` as otherwise `> 10.0` would have been `true`.
The same reasoning applies to the `<= 5.0` condition.
We can thus shorten our code to:

```csharp
return Math.Sqrt(x * x + y * y) switch
{
    > 10.0 => 0,
    > 5.0 => 1,
    > 1.0 => 5,
    _ => 10
};
```

## Shortening

When the body of a method is a single expression, the method can be implemented as a [member-bodied expression][member-bodied-expressions]:

```csharp
public static int Score(double x, double y) =>
    Math.Sqrt(x * x + y * y) switch
    {
        > 10.0 => 0,
        > 5.0 => 1,
        > 1.0 => 5,
        _ => 10
    };
```

[distance-formula]: https://www.thoughtco.com/understanding-the-distance-formula-2312242
[member-bodied-expressions]: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members
