# Concepts of nucleotide-count

[Example implementation](https://github.com/exercism/csharp/blob/master/exercises/nucleotide-count/Example.cs)

## General

- functions: used as the main entry point for the exercise
- function arguments: input strand is passed as an argument
- return values: returning a value from a method
- conditionals using if: conditionally execute logic using an `if` statement
- exceptions: throw an exception in the event of invalid input
- scoping: use `{` and `}` to denote scoping
- interfaces: the type returned is an `IDictionary<char, int>`
- classes: the tested method is defined in a class
- objects: creating an instance of the `Dictionary<char, int>` class
- static: the tested method is a static method
- visibility: making tested method and tested class `public`
- imports: import types through `using` statements
- namespaces: knowing where to find the `Dictionary<char, int>` class
- type inference: using `var` to define variable for dictionary
- assignment: assigning values, such as the dictionary
- mutation: mutating the dictionary after it has been created
- math operators: `+` or `++` operator to increment count
- strings: a `string` passed as the single input parameter
- characters: a `char` is used as key in the dictionary that is returned
- integers: an `int` is used as value in the dictionary that is returned
- dictionaries: a `Dictionary<char, int>` is used as return value

## Approach: foreach loop

- foreach loop: iterate over letters using a `foreach` loop
- enumerables: a `string` can be iterated over as an enumerable

## Approach: for loop

- for loop: iterate over letters using a `for` loop
- indexers: accessing a single `char` of a `string` using an indexer

## Approach: object initializer for dictionary

- object initializers: initializing dictionary through object initializer

## Approach: using TryGetValue

- out parameters: capturing the value as an `out` parameter

## Notes

- Having the exercise return an `IDictionary<char, int>` means that the users will have to know about interfaces too. This was not the goal of the exercise (teaching about dictionaries is), so it's interesting to see that this was missed. Good thing to keep in mind when developing Concept Exercises.
