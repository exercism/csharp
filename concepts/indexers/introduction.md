# Introduction

Indexers allow an object's values to be get or set via the indexing operator: `[]`. An indexer takes a single argument and can have both a `get` and/or `set` part. The `set` part of an indexer has a special `value` value, which is the value that is passed to the indexer.

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
