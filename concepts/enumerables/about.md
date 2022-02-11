# About

Types that implement the [`IEnumerable<T>`](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0) interface are known as being _enumerable_. All built-in collection types implement this interface.

An enumerable type can be iterated over using a `foreach` loop:

```csharp
var primes = new[] { 2, 3, 5, 7 };
foreach (var prime in primes)
{
    Console.Write(prime);
}
// => 2357
```

To implement `IEnumerable<T>`, a type has to implement one method: `IEnumerator<T> GetEnumerator()`. As seen, an enumerable defers the actual iterating over a collection to an `IEnumerator<T>` type. This interface has one property and three methods to implement:

- `public T Current { get; }`: get the current element.
- `public bool MoveNext ();`: move to the next element, returning `true` if the move to the next element was successful, and `false` if not (no more elements).
- `public void Reset ();`: reset the enumerator to its initial state (before the first element).
