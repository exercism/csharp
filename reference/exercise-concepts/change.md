# Concepts of change

[Example implementation](https://github.com/exercism/csharp/blob/master/exercises/change/Example.cs)

## General

- functions: used as the main entry point for the exercise
- function arguments: input coins and target are passed as arguments
- out parameters: used when retrieving a value from the dictionary
- return values: returning a value from a method
- conditionals using if: conditionally execute logic using an `if` statement and the ternary operator
- exceptions: throw an exception in the event of invalid input
- scoping: use `{` and `}` to denote scoping
- classes: the tested method is defined in a class
- objects: creating an object to keep track of the coins
- members: methods linked to a class instance
- visibility: making tested method and tested class `public`
- imports: import types through `using` statements
- namespaces: knowing where to find the `List<T>` and `Dictionary<TKey, TValue>` classes
- type inference: using `var` to define the complex types (dictionaries)
- assignment: assigning values, such as the minimalCoinsMap
- mutation: mutating the dictionary after it has been created
- mapping, selecting, ordering enumerables: using multiple LINQ methods to manipulate enumerables (`Min`, `Where`, `OrderBy`, `Select`, `Aggregate`, `FirstOrDefault`, `ToList`, `ToArray`)
- ranges: a range is created for iterating over all values up to the target
- object initializers: initializing dictionary through object initializer
- integers: an `int` is used for a coin and the target
- array: a `int []` is used for the available coinage
- lists: a `List<int>` is used as to store the coins for a given value in
- nulls: a `null` value is used as a default
- ordering operators:`<`, `>`, `<=`
- equality operator: `!=`
- math operators: `-`, is used

## Approach: nested functions

- nested functions: using a nested method to simplify argument passing
