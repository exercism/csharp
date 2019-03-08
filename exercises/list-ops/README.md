# List Ops

Implement basic list operations.

In functional languages list operations like `length`, `map`, and
`reduce` are very common. Implement a series of basic list operations,
without using existing functions.

The precise number and names of the operations to be implemented will be 
track dependent to avoid conflicts with existing names, but the general
operations you will implement include:

* `append` (*given two lists, add all items in the second list to the end of the first list*);
* `concatenate` (*given a series of lists, combine all items in all lists into one flattened list*);
* `filter` (*given a predicate and a list, return the list of all items for which `predicate(item)` is True*);
* `length` (*given a list, return the total number of items within it*);
* `map` (*given a function and a list, return the list of the results of applying `function(item)` on all items*);
* `foldl` (*given a function, a list, and initial accumulator, fold (reduce) each item into the accumulator from the left using `function(accumulator, item)`*);
* `foldr` (*given a function, a list, and an initial accumulator, fold (reduce) each item into the accumulator from the right using `function(item, accumulator)`*);
* `reverse` (*given a list, return a list with all the original items, but in reversed order*);

## Hints
The `Foldl` and `Foldr` methods are "fold" functions, which is a concept well-known in the functional programming world, but less so in the object-oriented one. If you'd like more background information, check out this [fold](https://en.wikipedia.org/wiki/Fold_(higher-order_function)) page.

## Running the tests

To run the tests, run the command `dotnet test` from within the exercise directory.

Initially, only the first test will be enabled. This is to encourage you to solve the exercise one step at a time.
Once you get the first test passing, remove the `Skip` property from the next test and work on getting that test passing.
Once none of the tests are skipped and they are all passing, you can submit your solution 
using `exercism submit ListOps.cs`

## Further information

For more detailed information about the C# track, including how to get help if
you're having trouble, please visit the exercism.io [C# language page](http://exercism.io/languages/csharp/resources).

