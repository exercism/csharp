# `if` statements

```csharp
using System;

public static class Darts
{
    public static int Score(double x, double y)
    {
        var distanceFromCenter = Math.Sqrt(x * x + y * y);

        if (distanceFromCenter > 10.0)
            return 0;

        if (distanceFromCenter > 5.0)
            return 1;

        if (distanceFromCenter > 1.0)
            return 5;

        return 10;
    }
}
```

The first step is to calculate the distance from the center of the board, which we can with the [cartesian coordinates distance formula][distance-formula]

```csharp
var distanceFromCenter = Math.Sqrt(x * x + y * y);
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
if (distanceFromCenter > 10.0)
    return 0;

if (distanceFromCenter > 5.0 && distanceFromCenter <= 10.0)
    return 1;

if (distanceFromCenter > 1.0 && distanceFromCenter <= 5.0)
    return 5;

return 10;
```

However, due to the order of evaluation, we know in our second condition, `distanceFromCenter <= 10.0` must always `true` as otherwise `distanceFromCenter > 10.0` would have been `true`.
The same reasoning applies to the `distanceFromCenter <= 5.0` condition.
We can thus shorten our code to:

```csharp
if (distanceFromCenter > 10.0)
    return 0;

if (distanceFromCenter > 5.0)
    return 1;

if (distanceFromCenter > 1.0)
    return 5;

return 10;
```

[distance-formula]: https://www.thoughtco.com/understanding-the-distance-formula-2312242
