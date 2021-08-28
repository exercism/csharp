# About

[Indexers](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/indexers/) allow an object's values to be get or set via the indexing operator: `[]`. An indexer takes a single argument and can have both a `get` and/or `set` part. The `set` part of an indexer has a special `value` value, which is the value that is passed to the indexer.

```csharp
class LapTimes
{
    private int[] times = new[] { 2, 4, 3, 8 };

    public int this[int lap]
    {
        get { return times[lap]; }
        set { times[lap] = value; }
    }
}

var lapTimes = new LapTimes();

// Use the getter
Console.WriteLine(lapTimes[1]); // => 4

// Use the setter
lapTimes[2] = 5;
Console.WriteLine(lapTimes[2]); // => 5
```

If you omit the `set` part of the indexer, you get a read-only indexer. An expression-body can be used to make defining a read-only indexer more succinct:

```csharp
class LapTimes
{
    private int[] times = new[] { 2, 4, 3, 8 };

    public int this[int lap] => times[lap];
}
```

An indexer's parameter doesn't have to be an `int`, it can be any type:

```csharp
class LapTimes
{
    // ...
    public int this[string lap] => times[Convert.ToInt32(lap)];
}
```

Indexers can also be overloaded:

```csharp
class LapTimes
{
    public int this[int lap] => times[lap];
    public int this[string lap] => times[Convert.ToInt32(lap)];
}
```
