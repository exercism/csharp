# Accumulate

Implement the `accumulate` operation, which, given a collection and an
operation to perform on each element of the collection, returns a new
collection containing the result of applying that operation to each element of
the input collection.

Given the collection of numbers:

- 1, 2, 3, 4, 5

And the operation:

- square a number (`x => x * x`)

Your code should be able to produce the collection of squares:

- 1, 4, 9, 16, 25

Check out the test suite to see the expected method signature.

## Restrictions

Keep your hands off that select/collect/map/fmap/whatchamacallit functionality
provided by your standard library!
Solve this one yourself using other basic tools instead.

## Hints

This exercise requires you to write an extension method. For more information, see [this page](https://msdn.microsoft.com/en-us//library/bb383977.aspx).

## Running the tests

To run the tests, run the command `dotnet test` from within the exercise directory.

Initially, only the first test will be enabled. This is to encourage you to solve the exercise one step at a time.
Once you get the first test passing, remove the `Skip` property from the next test and work on getting that test passing.
Once none of the tests are skipped and they are all passing, you can submit your solution 
using `exercism submit Accumulate.cs`

### Laziness test

Since `accumulate` returns an `IEnumerable`, it's execution is deferred until `ToList()` it is called on it, which is tested with the `Accumulate_is_lazy` method

## Further information

For more detailed information about the C# track, including how to get help if
you're having trouble, please visit the exercism.io [C# language page](http://exercism.io/languages/csharp/resources).

## Source

Conversation with James Edward Gray II [https://twitter.com/jeg2](https://twitter.com/jeg2)

## Submitting Incomplete Solutions

It's possible to submit an incomplete solution so you can see how others have completed the exercise.
