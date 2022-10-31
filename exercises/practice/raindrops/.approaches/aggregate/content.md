# Aggregate

```csharp
using System.Linq;

public static class Raindrops
{
    private static readonly (int, string)[]  drips = { (3, "Pling"), (5, "Plang"), (7, "Plong") };

    public static string Convert(int number)
    {
        var drops = drips.Aggregate("", (acc, drop) => number % drop.Item1 == 0 ? acc + drop.Item2 : acc);
        return drops.Length > 0 ? drops : number.ToString();
    }
}
```

- This solution begins by defining an array of [tuples][tuples].
Each [tuple][tuple] has an `int` and a `string`.
- The LINQ method [Aggregate][aggregate] is called on the `drips` array.
It passes the accumulator, which starts as an empty string, and each tuple to a [lambda expression][lambda-expression].
The lambda expression uses a [ternary operator][ternary] to test if `number` is evenly divisible by the `int` in the tuple.
If so, it returns the accumulator `string` concatenated with the `string` in the tuple.
If `number` is not evenly divisble by the `int` in the tuple, it simply returns the accumulator `string`.
- The result of all the iterations of `Aggregate` is the value of the accumulator `string`.
That value is set to the `drops` `string`.
- A [ternary operator][ternary] is used to test the `drops` `string`.
If the length of `drops` is greater than `0`, then `drops` is returned from the function.
Otherwise `number`.[`ToString`][tostring]() is returned from the function.

[tuples]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-tuples
[tuple]: https://learn.microsoft.com/en-us/dotnet/api/system.tuple-2
[aggregate]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.aggregate
[lambda-expression]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions
[ternary]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/conditional-operator
[tostring]: https://learn.microsoft.com/en-us/dotnet/api/system.object.tostring
