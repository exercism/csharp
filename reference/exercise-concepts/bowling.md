# Concepts of bowling

[Example implementation](https://github.com/exercism/csharp/blob/master/exercises/bowling/Example.cs)

## General

- functions: used as the main entry point for the exercise
- function arguments: input strand is passed as an arguments
- return values: returning a value from a method
- conditionals using if: conditionally execute logic using an `if` statement
- exceptions: throw an exception in the event of invalid input
- scoping: use `{` and `}` to denote scoping
- classes: the tested method is defined in a class
- objects: creating an object to keep track of the rolls
- state: keeping track of the rolls
- members: methods linked to a class instance
- visibility: making tested method and tested class `public`
- imports: import types through `using` statements
- namespaces: knowing where to find the `List<T>` class
- type inference: using `var` to define the score
- assignment: assigning values, such as the score
- mutation: mutating the list after it has been created
- immutability: defining the max score and number of frames as `const` and the list as `readonly`
- equality operator: `==`, `!=`
- ordering operators:`<`, `>`, `<=`, `>=`
- math operators: `+`, `%`, `+=` are used
- indexers: accessing a single `int` of the rolls
- enumerables: lists can can be iterated over as an enumerable
- for loop: iterate over rolls using a `for` loop
- integers: an `int` is used for rolls
- booleans: a `bool` is used in helper methods
- lists: a `List<int>` is used as to store the rolls in
- nullable values: a `int?` is uses as the return value

## Note

- The return value should not be an `int?`, as this is still a remnant of an older version of the exercise. The latest version uses exceptions for all error cases, and should thus return a regular `int`.
