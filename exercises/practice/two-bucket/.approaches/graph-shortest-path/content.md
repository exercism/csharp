# Shortest path in graph

```csharp
using System;
using System.Collections.Generic;

public enum Bucket { One, Two }
public record Result(int Moves, Bucket GoalBucket, int OtherBucket);
public record Buckets(int One, int Two);
public record State(int Moves, Buckets Buckets);

public class TwoBucket
{
    private readonly int oneCapacity;
    private readonly int twoCapacity;
    private readonly Bucket startFrom;

    public TwoBucket(int oneCapacity, int twoCapacity, Bucket startFrom)
    {
        this.oneCapacity = startFrom == Bucket.One ? oneCapacity : twoCapacity;
        this.twoCapacity = startFrom == Bucket.One ? twoCapacity : oneCapacity;
        this.startFrom = startFrom;
    }

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
}
```

This approach models the two-bucket problem as a graph, with each node representing the state of the two buckets.
We then use [Dijkstra's algorithm][dijkstras-algorithm] to find the shortest path to our goal state.

## Dijkstra's algorithm

The purpose of Dijkstra's algorithm is to find the shortest path between nodes in a graph.
It does this by via two two data structures:

1. A queue that contains any nodes that have not yet been visited
2. A dictionary that, for any nodes visited, contains the minimal costs to visit those nodes

After adding the starting node to the queue and the dictionary (with cost set to zero), we apply the algorithm's main loop:

- If the unvisited nodes queue is empty, there is no path from start to goal node and we stop execution
- If the unvisited nodes queue is _not_ empty, pop a node from the queue
  - If the node is the goal node, we've found the shortest path and we stop execution
  - If the node is _not_ the goal node, iterate over all the nodes that can be reached from that node
    - If the sibling node's costs are greater or equal to the minimal cost for that node (which means there is another, shorter path to that node), skip the sibling node
    - If the sibling node's costs are less than to the minimal cost for that node (which means there is no shorter path to that node or that node has not yet been processed)
      - Update the sibling node's minimal cost
      - Add the sibling node to the unvisited nodes queue

## Modelling the two bucket problem as a graph

To apply Dijkstra to solve our two bucket problem, we can consider the contents of our two buckets as a node:

- `(1, 5)`: bucket one contains one liter, bucket two contains five liters
- `(0, 3)`: bucket one is empty, bucket two contains three liters

The goal node is either:

- `(goal, _)`: bucket one contains exactly `goal` liters (bucket two can be any amount of liters)
- `(_, goal)`: bucket two contains exactly `goal` liters (bucket one can be any amount of liters)

The edges between nodes are formed by applying the two bucket problem's rules:

1. Pouring one bucket into the other bucket until either:
   a) the first bucket is empty
   b) the second bucket is full
2. Emptying a bucket and doing nothing to the other.
3. Filling a bucket and doing nothing to the other.

To represent a node, we'll actually wan to store three bits of information:

1. The (minimum) number of moves it takes to get to this state
2. The contents of bucket one
3. The contents of bucket three

There are lots of ways to model this, but we'll settle on two record types:

1. `Buckets`: describes the contents of both buckets via two properties:
   1. `One`: the contents of bucket one
   2. `Two`: the contents of bucket two
2. `State`: contains the number of moves _and_ its buckets' contents

Using [positional syntax][record-positional-syntax], we can model this (quite succinctly) as:

```csharp
public record Buckets(int One, int Two);
public record State(int Moves, Buckets Buckets);
```

## Constructor

Moving on to the `TwoBucket` class' implement, let's start by defining our constructor.
The stub file has the constructor defined as follows:

```csharp
public TwoBucket(int bucketOne, int bucketTwo, Bucket startBucket)
```

We want to store these arguments in fields to allow us to use them later on, which we can do as follows:

```csharp
public class TwoBucket
{
    private readonly int oneCapacity;
    private readonly int twoCapacity;
    private readonly Bucket startFrom;

    public TwoBucket(int oneCapacity, int twoCapacity, Bucket startFrom)
    {
        this.oneCapacity = oneCapacity;
        this.twoCapacity = twoCapacity;
        this.startFrom = startFrom;
    }
}
```

## Method: `Measure()`

Let's now move on to the `Measure()` method, which takes the goal and returns an instance of the `Result` type:

```csharp
public Result Measure(int goal)
```

First, let's do some quick validation to ensure that the goal does not exceed the capacity of both buckets (which makes it an impossible goal):

```csharp
if (goal > oneCapacity && goal > twoCapacity)
    throw new ArgumentException("Goal cannot not be reached", nameof(goal));
```

### Preparation

To prepare for running Dijkstra's algorithm, we'll need a couple of things:

1. An initial state (the node we're starting our search from)
2. A queue of moves we need to process/check
3. A dictionary that keeps tracks of the minimum number of moves for each state

#### Initial state

Our initial state is: no moves have been made and both buckets are empty.

```csharp
var initialState = new State(0, new Buckets(0, 0));
```

Using a [target-typed expression][target-typed-new], we can omit the `Buckets` type (as the compiler can infer it):

```csharp
var initialState = new State(0, new(0, 0));
```

Whilst this is very concise, there is even less context for what the magic numbers represent (and it wasn't that clear to begin with).
In this particular case, using [named arguments][named-arguments] can really help clarify the meaning of those magic numbers:

```csharp
var initialState = new State(Moves: 0, Buckets: new(One: 0, Two: 0));
```

#### Queue of moves

The natural data to keep track of our moves queue (which are the states we haven't yet processed) is a [`Queue<T>`][queue-type]:

```csharp
var unprocessed = new Queue<State>();
```

The type of our queue is the `State` type we use to describe each state/node.
We then add our initial state to the queue (as we've not yet processed its possible moves):

```csharp
unprocessed.Enqueue(initialState);
```

#### Dictionary of minimum number of moves for each state

The final bit of setup is to create a dictionary that maps the minimum number of moves for each bucket one/two contents combination:

```csharp
var statesMinMoveCount = new Dictionary<Buckets, int>();
```

The key is our `Buckets` type that describes the contents of the two buckets.
We don't want to use the `State` type as the key, as the dictionary's value will hold the (minimum) number of moves for those buckets.
We then add our initial state's `Buckets` field as the key with the value being the initial state's `Moves` field (`0`) (read as: it takes zero moves to get to the initial state):

```csharp
statesMinMoveCount.Add(initialState.Buckets, initialState.Moves);
```

We can even use dictionary initialization syntax to merge these two lines into a single line:

```csharp
new Dictionary<Buckets, int>() { [initialState.Buckets] = initialState.Moves };
```

### Loop

Having done our initialization, we can move on to the main loop, which runs untils there are no more unprocessed states.
We can use the queue's [`TryDequeue()` method][queue.try-dequeue] to both check if there is an element in the queue (the `bool` return value) and to capture that element in a variable out the `out` argument:

```csharp
while (unprocessed.TryDequeue(out var state))
```

Within the loop, we first check if we've reached our goal node:

```csharp
if (state.Buckets.One == goal)
    return new(state.Moves, Bucket.One, state.Buckets.Two);

if (state.Buckets.Two == goal)
    return new(state.Moves, Bucket.Two, state.Buckets.One);
```

If none of the two buckets have the desired contents, we then process the state's moves in a `foreach` loop:

```csharp
foreach (var newState in Moves(state))
{
    if (newState.Moves >= statesMinMoveCount.GetValueOrDefault(newState.Buckets, int.MaxValue))
        continue;

    statesMinMoveCount[newState.Buckets] = newState.Moves;
    unprocessed.Enqueue(newState, newState.Moves);
}
```

What we do here is to iterate over all the state's moves, as returned by the `Moves()` method (we'll get to its implementation in a bit).
Then, for each move's state, we check if its number of moves is greater or equal to the current minimum number of moves for those bucket contents.

```exercism/note
We use `int.MaxValue` as the default value for when no minimum number of moves have yet been found for the node, which should always be greater than the node's actual moves.
```

If the node's moves _are_ greater than or equal to the current minimum number of moves, we don't process the node as there is another, shorter path to that node.
Otherwise, we'll update the minimum number of moves for the node and add it to the unprocessed states queue.

If the loop finishes, the unprocessed states queue must be empty.
This implies that there is no path to the goal node, so we throw an exception:

```csharp
throw new ArgumentException("Could not find path");
```

## Determine valid moves

The `Moves()` method takes the current state and returns an enumerable of states that correspond to valid moves from that state:

```csharp
private IEnumerable<State> Moves(State state)
```

### Move: fill bucket one when empty

The first move we'll look at is to fill bucket one when it is empty.
We can implement this via:

```csharp
if (state.Buckets.One == 0)
    yield return new(state.Moves + 1, new(OneCapacity, state.Buckets.Two));
```

After checking if `state.Buckets.One` equals zero (meaning: bucket one is empty), we return a new state where the number of moves is incremented (after all, we've just applied a move), the first bucket is filled to its capacity and the second bucket is left unchanged.

```exercism/note
We use a [`yield` statement](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/yield) to _yield_ the state.
When a `yield` statement is written, the compiler transforms the method into a state machine that is suspended after each yield statement.
Even though we yield indidivual elements, what is returned from a caller's viewpoint is a sequence of elements.
```

### Move: fill bucket two when bucket two is empty and bucket one is not empty

For the second move, we'll fill the second bucket, provided it is not yet full and the first bucket is not empty:

```csharp
if (state.Buckets.One > 0 && state.Buckets.Two == 0)
    yield return new(state.Moves + 1, new(state.One, TwoCapacity));
```

Similar logic to our previous move, where the returned state has the number of moves increment, but this time the first bucket's state is left unchanged and the second bucket is filled to its capacity.

### Move: empty bucket two when filled to capacity

Our third move is to empty bucket two when filled to its capacity:

```csharp
if (state.Buckets.Two == TwoCapacity)
    yield return new(state.Moves + 1, new(state.Buckets.One, 0));
```

### Move: transfer contents from bucket one to bucket two

Our final move is to transfer as much of bucket one's contents to bucket two, provided bucket two is not filled to its capacity and bucket one is not empty:

```csharp
if (state.Buckets.One > 0 && state.Buckets.Two < TwoCapacity)
{
    var amount = Math.Min(state.Buckets.One, TwoCapacity - state.Buckets.Two);
    yield return new(state.Moves + 1, new(state.Buckets.One - amount, state.Buckets.Two + amount));
}
```

This move requires a bit more logic, as we need to determine exactly how much water we can transfer from bucket one to bucket two.
There are two constraints we need to consider:

1. Bucket two can receive an amount of water equal to its capacity minus its current contents
2. Bucket one can only pour an amount of water equal to its current contents

These two values form _upper bounds_, meaning that the amount of water we pour can never exceed both constraints.
As such, we can use `Math.Min` to return the lesser of the two values, which is the amount we can safely pour:

```csharp
var amount = Math.Min(state.Buckets.One, TwoCapacity - state.Buckets.Two);
```

Finally, we return a new state with an increment number of moves, bucket one's contents being its current contents minus the amount transferred and bucket two's contents being its current contents plus the amount transferred.

```csharp
yield return new(state.Moves + 1, new(state.Buckets.One - amount, state.Buckets.Two + amount));
```

Note that we haven't implemented all possible moves, but are viewing things from the viewpoint of the first bucket.
While this is still guaranteed to give us the correct results, we do need to tweak the constructor to have the first and second bucket's capacity depend on the starting bucket:

```csharp
this.oneCapacity = startFrom == Bucket.One ? oneCapacity : twoCapacity;
this.twoCapacity = startFrom == Bucket.One ? twoCapacity : oneCapacity;
```

and our goal-checking code:

```csharp
if (state.Buckets.One == goal)
    return new(state.Moves, startFrom == Bucket.One ? Bucket.One : Bucket.Two, state.Buckets.Two);

if (state.Buckets.Two == goal)
    return new(state.Moves, startFrom == Bucket.One ? Bucket.Two : Bucket.One, state.Buckets.One);
```

With these minor changes, we don't have to view things from the second bucket's viewpoint which makes the `Moves()` method simpler and shorter.

And with that, we have a working implementation!

## Using a priority queue

One way to optimize the speed of our algorithm is to use a special version of a queue, namely a [`PriorityQueue<T>`][priority-queue-type].
With this queue, you enqueue each item with a _priority_.
Then when dequeuing, it will return the item with the lowest priority first, regardless if other items (with a higher priority) were added to the queue later:

```csharp
var priorityStrings = new PriorityQueue<string, int>();
priorityStrings.Enqueue("warning", 2);
priorityStrings.Enqueue("error", 1);
priorityStrings.Enqueue("info", 3);

var dequeue = priorityStrings.Dequeue();
dequeue == "error";
```

The idea of using a priority queue in Dijkstra's algorithm is to prioritize processing nodes with the lowest cost, which in our case means: the nodes with the least number of moves.
This way, it is more likely that we'll find the minimum number of moves sooner.

The implementation is actually quite straightforward.
First, we'll replace our `Queue<State>` with a `PriorityQueue<State, int>`:

```csharp
var unprocessed = new PriorityQueue<State, int>();
```

Then, we'll enqueue the initial state with its number of moves (zero) as its priority:

```csharp
unprocessed.Enqueue(initialState, initialState.Moves);
```

And finally, we also modify the enqueue of a move's state:

```csharp
unprocessed.Enqueue(newState, newState.Moves);
```

All the other code is left unchanged, and we've optimized our implementation a bit!

## Alternative: tuples

Instead of using records, we can also model our state as a nested tuple:

```csharp
(Moves: 0, Buckets: (One: 0, Two: 0))
```

Using tuples over records will result in slightly less memory usage, but other than that they're mostly the same.
As we were already using named arguments _and_ we're using the same field names, we only have to change:

1. Constructor calls
2. Type definitions

### Removing constructor calls

As we are no longer instantiating records, we can lose the constructor calls.

We thus change our initial state from:

```csharp
var initialState = new State(Moves: 0, Buckets: new Buckets(One: 0, Two: 0));
```

to:

```csharp
var initialState = (Moves: 0, Buckets: (One: 0, Two: 0));
```

```exercism/note
We have given our [tuple fields a name](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-tuples#tuple-field-names)
This is not strictly necessary, but `initialState.Moves` is definitely more descriptive than `initialState.Item1`.
```

We then apply the same logic to the state creation in the `Moves()` method.
As an example, this code:

```csharp
yield return new(state.Moves + 1, new(OneCapacity, state.Buckets.Two));
```

becomes:

```csharp
yield return (state.Moves + 1, (OneCapacity, state.Buckets.Two));
```

Creating tuples requires less boilerplate, whilst still retaining the same _shape_ (fields).

### Type definitions

The type definitions and arguments become more verbose though.

We can see this in the queue and dictionary declarations:

```csharp
var unprocessed = new PriorityQueue<State, int>();
// ...
var statesMinMoveCount = new Dictionary<Buckets, int> { [initialState.Buckets] = initialState.Moves };
```

becomes:

```csharp
var unprocessed = new PriorityQueue<(int Moves, (int One, int Two) Buckets), int>();
// ...
var statesMinMoveCount = new Dictionary<(int One, int Two), int> { [initialState.Buckets] = initialState.Moves };
```

And the `Moves()` method changes from:

```csharp
private IEnumerable<State> Moves(State state)
```

to:

```csharp
private IEnumerable<(int Moves, (int One, int Two) Buckets)> Moves((int Moves, (int One, int Two) Buckets) state)
```

Clearly, the tuple-based approach is more verbose, although you could argue that it better shows what's actually in the state.

## Convert `TwoBucketResult` to a `record` type

The stub file declares the `TwoBucketResult` type as a class:

```csharp
public class TwoBucketResult
{
    public int Moves { get; set; }
    public Bucket GoalBucket { get; set; }
    public int OtherBucket { get; set; }
}
```

We can shorten this definition a bit by converting the `class` type to a [`record` type][record-type]:

```csharp
public record Result(int Moves, Bucket GoalBucket, int OtherBucket);
```

Using [positional syntax][record-positional-syntax], we have a nice shorthand way of defining our public (immutable) properties without breaking any code :)

[record-type]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/record
[record-positional-syntax]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/record#positional-syntax-for-property-definition
[dijkstras-algorithm]: https://en.wikipedia.org/wiki/Dijkstra%27s_algorithm
[yield-statement]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/yield
[tuple-type]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-tuples
[tuple-field-names]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-tuples#tuple-field-names
[queue-type]: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.queue-1
[dictionary-type]: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2
[priority-queue-type]: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.priorityqueue-2
[target-typed-new]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/target-typed-new
[named-arguments]: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/named-and-optional-arguments#named-arguments
[queue.try-dequeue]: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.queue-1.trydequeue
