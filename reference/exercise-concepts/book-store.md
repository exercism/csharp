# Concepts of book-store

[Example implementation](https://github.com/exercism/csharp/blob/master/exercises/book-store/Example.cs)

## General

- functions: used as the main entry point for the exercise and used for sub functions in order to break the solution down into smaller chunks
- function arguments: books are passed as an argument
- return values: returning a value from a method
- conditionals using if: conditionally execute logic using an `if` statement
- scoping: use `{` and `}` to denote scoping
- classes: the tested method is defined in a class
- members: methods linked to a class instance
- visibility: making tested method and tested class `public`
- imports: import types through `using` statements
- namespaces: knowing where to find the `Linq` methods
- type inference: using `var` to define complex types
- assignment: assigning values
- immutability: defining the base book price as a `const`
- equality operator: `==`
- ordering operators: `>`
- math operators: `+`, `*`, `-` are used
- enumerables: arrays can can be iterated over as an enumerable (using Linq)
- floating point numbers: a `decimal` is used for calculating the total price
- arrays: an `int[]` is used as an input parameter to the main method
- math standard library: use of `Math.Round` and `Math.Min`
- mapping, selecting, ordering enumerables: using multiple Linq methods to manipulate enumerables (`Concat`, `GroupBy`, `Min`, `OrderByDescending`, `Select`, `Take`, `ToArray`, `Where`)

## Approach: switch

- switch: used to map the discount percentage based on the number of unique books

## Approach: dictionary

- dictionaries: `Dictionary<int, decimal>` for mapping the discount percentage based on the number of unique books
