```csharp
using System.Linq;
using System.Collections.Generic;

public static class Raindrops
{
    public static string Convert(int number)
    {
        var drops =  (new List<(int, string)>{(3, "Pling"), (5, "Plang"), (7, "Plong")})
            .Aggregate("", (acc, drop) => number % drop.Item1 == 0 ? acc + drop.Item2: acc);
        return drops != "" ? drops: number.ToString();
    }
}
```