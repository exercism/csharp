# Introduction

The key to this exercise is to repeatedly apply a relatively simple algorithm on two bits of state: the two bucket's contents.
The trick is that some states can't be solved, and that you need to find the optimal/shortest way of getting to the goal.

## General guidance

- Carefully consider how to model your state; you can use classes, tuples, arrays, records, dictionaries and more

## Approach: shortest path in graph

```csharp
public record Buckets(int One, int Two);
public record State(int Moves, Buckets Buckets);

public Result Measure(int goal)
{
    if (goal > oneCapacity && goal > twoCapacity)
        throw new ArgumentException("Goal cannot not be reached", nameof(goal));

    var initialState = new State(Moves: 0, Buckets: new(One: 0, Two: 0));

    var unprocessed = new PriorityQueue<State, int>();
    unprocessed.Enqueue(initialState, initialState.Moves);

    var statesMinMoveCount = new Dictionary<Buckets, int> { [initialState.Buckets] = initialState.Moves };

    while (unprocessed.TryDequeue(out var state, out _))
    {
        if (state.Buckets.One == goal)
            return new(state.Moves, startFrom == Bucket.One ? Bucket.One : Bucket.Two, state.Buckets.Two);

        if (state.Buckets.Two == goal)
            return new(state.Moves, startFrom == Bucket.One ? Bucket.Two : Bucket.One, state.Buckets.One);

        foreach (var newState in Moves(state))
        {
            if (newState.Moves >= statesMinMoveCount.GetValueOrDefault(newState.Buckets, int.MaxValue))
                continue;

            statesMinMoveCount[newState.Buckets] = newState.Moves;
            unprocessed.Enqueue(newState, newState.Moves);
        }
    }

    throw new ArgumentException("Could not find path");
}

private IEnumerable<State> Moves(State state)
{
    if (state.Buckets.One == 0)
        yield return new(state.Moves + 1, new(oneCapacity, state.Buckets.Two));

    if (state.Buckets.One > 0 && state.Buckets.Two == 0)
        yield return new(state.Moves + 1, new(state.Buckets.One, twoCapacity));

    if (state.Buckets.Two == twoCapacity)
        yield return new(state.Moves + 1, new(state.Buckets.One, 0));

    if (state.Buckets.One > 0 && state.Buckets.Two < twoCapacity)
    {
        var amount = Math.Min(state.Buckets.One, twoCapacity - state.Buckets.Two);
        yield return new(state.Moves + 1, new(state.Buckets.One - amount, state.Buckets.Two + amount));
    }
}
```

This approach models the two-bucket problem as a graph, with each node representing the state of the two buckets.
We then use [Dijkstra's algorithm][dijkstras-algorithm] to find the shortest path to our goal state.
For more information, check the [shortest path in graph approach][approach-shortest-path].

[approach-shortest-path]: https://exercism.org/tracks/csharp/exercises/two-bucket/approaches/graph-shortest-path
[dijkstras-algorithm]: https://en.wikipedia.org/wiki/Dijkstra%27s_algorithm
